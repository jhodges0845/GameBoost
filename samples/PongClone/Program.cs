using GameBoost.Core;
using GameBoost.Physics;
using GameBoost.Rendering;
using PongClone;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

IScreen screen = new SfmlScreen(800, 600, new MathUtils());
IMathUtils _mathUtils = new MathUtils();
var context = new SfmlRenderContext((uint)screen.Width, (uint)screen.Height, "Pong Demo");
var ballTexture = new SfmlTexture("PongBall.png");
var paddleTexture = new SfmlTexture("PongPaddle.png");

var ball = new PhysicsBody(new Vector2D(400, 300, _mathUtils), new Vector2D(100, 75, _mathUtils), 1f, 16, 16);
var leftPaddle = new PhysicsBody(new Vector2D(50, 250, _mathUtils), new Vector2D().Zero(), 1f, 16, 64);
var rightPaddle = new PhysicsBody(new Vector2D(734, 250, _mathUtils), new Vector2D().Zero(), 1f, 16, 64);

var ballRender = new RenderableObject(ballTexture, ball.Position);
var leftPaddleRender = new RenderableObject(paddleTexture, leftPaddle.Position);
var rightPaddleRender = new RenderableObject(paddleTexture, rightPaddle.Position);

int player1Score = 0;
int player2Score = 0;
var font = new Font("font.ttf");
var scoreText = new Text($"Player 1: {player1Score}  Player 2: {player2Score}", font, 24)
{
    Position = new SFML.System.Vector2f(300, 10),
    FillColor = Color.White
};

double ballSpeedMultiplier = 1f;
var clock = new Clock();
double deltaTime;
double baseSpeed = 100f;
double paddleSpeed = 400f;
bool hasCollidedThisFrame = false;
double bounceOffset = 2f; // Increased offset to prevent re-collision
int framesSinceCollision = 0; // Delay collision checks after bounce
const int collisionDelayFrames = 1; // Skip collision check for 1 frame

(int player1Score, int player2Score, IVector2D ballPosition, IVector2D ballVelocity, double ballSpeedMultiplier) UpdateScoring(PhysicsBody ball, int player1Score, int player2Score, double ballSpeedMultiplier)
{
    if (ball.Position.X <= 0)
    {
        player2Score++;
        return (player1Score, player2Score, new Vector2D(400, 300, _mathUtils), new Vector2D(100, 75, _mathUtils), 1f);
    }
    else if (ball.Position.X + ball.Width >= 800)
    {
        player1Score++;
        return (player1Score, player2Score, new Vector2D(400, 300, _mathUtils), new Vector2D(-100, 75, _mathUtils), 1f);
    }
    return (player1Score, player2Score, ball.Position, ball.Velocity, ballSpeedMultiplier);
}


while (context.IsActive())
{
    deltaTime = Math.Min(clock.Restart().AsSeconds(), 1f / 30f);

    // Paddle controls
    if (Keyboard.IsKeyPressed(Keyboard.Key.W)) leftPaddle.Velocity = new Vector2D(0, -paddleSpeed, _mathUtils);
    else if (Keyboard.IsKeyPressed(Keyboard.Key.S)) leftPaddle.Velocity = new Vector2D(0, paddleSpeed, _mathUtils);
    else leftPaddle.Velocity = new Vector2D().Zero();

    if (Keyboard.IsKeyPressed(Keyboard.Key.Up)) rightPaddle.Velocity = new Vector2D(0, -paddleSpeed, _mathUtils);
    else if (Keyboard.IsKeyPressed(Keyboard.Key.Down)) rightPaddle.Velocity = new Vector2D(0, paddleSpeed, _mathUtils);
    else rightPaddle.Velocity = new Vector2D().Zero();

    // Move paddles
    leftPaddle = leftPaddle.Move(deltaTime, 0f, screen.Width, 0f, screen.Height);
    rightPaddle = rightPaddle.Move(deltaTime, 0f, screen.Width, 0f, screen.Height);

    // Predict ball movement and handle collisions
    IVector2D ballDisplacement = ball.Velocity.Multiply(deltaTime);
    IVector2D newBallPosition = ball.Position.Add( ballDisplacement);
    PhysicsBody tempBall = ball;
    tempBall.Position = newBallPosition;

    if (framesSinceCollision <= collisionDelayFrames)
    {
        framesSinceCollision++;
    }
    else
    {
        if (tempBall.CollidesWith(leftPaddle) && ball.Velocity.Dot(new Vector2D(-1, 0, _mathUtils)) > 0) // Moving toward left paddle
        {
            if (!hasCollidedThisFrame)
            {
                ballSpeedMultiplier += 0.1f;
                IVector2D direction = new Vector2D(Math.Abs(ball.Velocity.X), ball.Velocity.Y, _mathUtils).Normalize();
                ball.Velocity = direction.Multiply( baseSpeed).Multiply(ballSpeedMultiplier);

                // Position correction along bounce direction
                ball.Position = new Vector2D(leftPaddle.Position.X + leftPaddle.Width + bounceOffset, ball.Position.Y, _mathUtils);

                hasCollidedThisFrame = true;
                framesSinceCollision = 0;
                Console.WriteLine($"Left Paddle Hit! Multiplier: {ballSpeedMultiplier}, Velocity: ({ball.Velocity.X}, {ball.Velocity.Y}), Position: ({ball.Position.X}, {ball.Position.Y})");
            }
        }
        else if (tempBall.CollidesWith(rightPaddle) && ball.Velocity.Dot(new Vector2D(1, 0, _mathUtils)) > 0) // Moving toward right paddle
        {
            if (!hasCollidedThisFrame)
            {
                ballSpeedMultiplier += 0.15f;
                IVector2D direction = new Vector2D(-Math.Abs(ball.Velocity.X), ball.Velocity.Y, _mathUtils).Normalize();
                ball.Velocity = direction.Multiply( baseSpeed ).Multiply( ballSpeedMultiplier);

                // Position correction along bounce direction
                ball.Position = new Vector2D(rightPaddle.Position.X - ball.Width - bounceOffset, ball.Position.Y, _mathUtils);

                hasCollidedThisFrame = true;
                framesSinceCollision = 0;
                Console.WriteLine($"Right Paddle Hit! Multiplier: {ballSpeedMultiplier}, Velocity: ({ball.Velocity.X}, {ball.Velocity.Y}), Position: ({ball.Position.X}, {ball.Position.Y})");
            }
        }
        else
        {
            hasCollidedThisFrame = false;
        }
    }

    // Apply movement if no immediate re-collision
    if (!hasCollidedThisFrame)
    {
        ball = ball.Move(deltaTime, 0f, screen.Width, 0f, screen.Height);
    }

    // Collision with top and bottom walls
    if (ball.Position.Y <= 0 || ball.Position.Y + ball.Height >= 600)
    {
        ball.Velocity = new Vector2D(ball.Velocity.X, -ball.Velocity.Y, _mathUtils);
    }

    // Scoring
    (player1Score, player2Score, ball.Position, ball.Velocity, ballSpeedMultiplier) = UpdateScoring(ball, player1Score, player2Score, ballSpeedMultiplier);


    scoreText.DisplayedString = $"Player 1: {player1Score}  Player 2: {player2Score}";

    ballRender.Position = ball.Position;
    leftPaddleRender.Position = leftPaddle.Position;
    rightPaddleRender.Position = rightPaddle.Position;

    context.Clear(0.2f, 0.3f, 0.3f, 1.0f);
    ballRender.Render(context);
    leftPaddleRender.Render(context);
    rightPaddleRender.Render(context);
    context.DrawText(scoreText);
    context.Display();
}


