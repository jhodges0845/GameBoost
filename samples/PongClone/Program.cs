using GameBoost.Core;
using GameBoost.Physics;
using GameBoost.Rendering;

// Configuration constants
const int GridWidth = 40;
const int GridHeight = 20;
const float DeltaTime = 0.016f; // ~60 FPS for smoother movement
Vector2D Gravity = new Vector2D(0f, 0f); // No gravity for Pong

// Game objects
PhysicsBody ball;
Sprite paddle1, paddle2, groundSprite;
int player1Score = 0, player2Score = 0;

// Initialize game objects
void InitializeGameObjects()
{
    ball = new PhysicsBody(new Vector2D(20f, 10f), new Vector2D(20f, 8f), 1f, 2f, 2f); // Initial ball velocity
    paddle1 = new Sprite(new Vector2D(5f, 10f), 2f, 5f, "paddle"); // Left paddle
    paddle2 = new Sprite(new Vector2D(35f, 10f), 2f, 5f, "paddle"); // Right paddle
    groundSprite = new Sprite(new Vector2D(20f, 2f), 40f, 1f, "ground"); // Full-width ground (for boundary)
}

// Handle input
void HandleInput()
{
    if (Console.KeyAvailable)
    {
        var key = Console.ReadKey(true).Key;
        float step = 1f;
        switch (key)
        {
            case ConsoleKey.UpArrow: paddle1.Position = new Vector2D(paddle1.Position.X, Math.Max(2.5f, paddle1.Position.Y + step)); break; // Up increases Y
            case ConsoleKey.DownArrow: paddle1.Position = new Vector2D(paddle1.Position.X, Math.Min(17.5f, paddle1.Position.Y - step)); break; // Down decreases Y
            case ConsoleKey.W: paddle2.Position = new Vector2D(paddle2.Position.X, Math.Max(2.5f, paddle2.Position.Y + step)); break; // W increases Y
            case ConsoleKey.S: paddle2.Position = new Vector2D(paddle2.Position.X, Math.Min(17.5f, paddle2.Position.Y - step)); break; // S decreases Y
        }
    }
}

// Update physics of the ball
void UpdatePhysics()
{
    float startY = ball.Position.Y;
    float velocityY = ball.Velocity.Y;

    // Apply velocity (no gravity)
    velocityY += Gravity.Y * DeltaTime; // Gravity is 0, so no effect
    float endY = startY + ball.Velocity.Y * DeltaTime;
    float endX = ball.Position.X + ball.Velocity.X * DeltaTime;

    // Wall collisions (top/bottom)
    if (endY + ball.Height / 2f >= GridHeight - 1 || endY - ball.Height / 2f <= 0)
    {
        ball.Velocity = new Vector2D(ball.Velocity.X, -ball.Velocity.Y);
        endY = Math.Clamp(endY, ball.Height / 2f, GridHeight - 1 - ball.Height / 2f);
    }

    // Paddle collisions (simplified)
    float ballLeft = endX - ball.Width / 2f;
    float ballRight = endX + ball.Width / 2f;
    float paddle1Right = paddle1.Position.X + paddle1.Width / 2f;
    float paddle2Left = paddle2.Position.X - paddle2.Width / 2f;
    if (ballLeft <= paddle1Right && ball.Position.Y >= paddle1.Position.Y - paddle1.Height / 2f && ball.Position.Y <= paddle1.Position.Y + paddle1.Height / 2f)
    {
        ball.Velocity = new Vector2D(-ball.Velocity.X, ball.Velocity.Y); // Bounce off paddle1
        endX = paddle1Right + ball.Width / 2f + 0.1f; // Prevent sticking
    }
    else if (ballRight >= paddle2Left && ball.Position.Y >= paddle2.Position.Y - paddle2.Height / 2f && ball.Position.Y <= paddle2.Position.Y + paddle2.Height / 2f)
    {
        ball.Velocity = new Vector2D(-ball.Velocity.X, ball.Velocity.Y); // Bounce off paddle2
        endX = paddle2Left - ball.Width / 2f - 0.1f; // Prevent sticking
    }

    // Scoring
    if (endX + ball.Width / 2f < 0)
    {
        player2Score++;
        ball.Position = new Vector2D(20f, 10f); // Reset ball
        ball.Velocity = new Vector2D(5f, 2f);   // Reset velocity
    }
    else if (endX - ball.Width / 2f > GridWidth)
    {
        player1Score++;
        ball.Position = new Vector2D(20f, 10f); // Reset ball
        ball.Velocity = new Vector2D(-5f, 2f);  // Reset velocity
    }

    ball.Position = new Vector2D(endX, endY);
}

// Render the current frame
void RenderFrame()
{
    // Move cursor to top-left to overwrite previous frame
    Console.SetCursorPosition(0, 0);

    // Build the grid as a string to write all at once
    char[,] grid = new char[GridHeight, GridWidth];
    for (int y = 0; y < GridHeight; y++)
        for (int x = 0; x < GridWidth; x++)
            grid[y, x] = '.';

    // Draw ball
    Vector2D ballScreenPos = RenderingUtils.WorldToScreen(ball.Position, new Camera2D(new Vector2D(0f, 0f), 1f, GridWidth, GridHeight));
    int ballScreenX = (int)Math.Round(ballScreenPos.X);
    int ballScreenY = (int)Math.Round(GridHeight - 1 - ballScreenPos.Y);
    int ballWidth = (int)ball.Width;
    int ballHeight = (int)ball.Height;
    for (int dy = 0; dy < ballHeight; dy++)
        for (int dx = 0; dx < ballWidth; dx++)
            if (ballScreenX + dx >= 0 && ballScreenX + dx < GridWidth && ballScreenY + dy >= 0 && ballScreenY + dy < GridHeight)
                grid[ballScreenY + dy, ballScreenX + dx] = 'O'; // Ball as 'O'

    // Draw paddles
    Vector2D paddle1ScreenPos = RenderingUtils.WorldToScreen(paddle1.Position, new Camera2D(new Vector2D(0f, 0f), 1f, GridWidth, GridHeight));
    Vector2D paddle2ScreenPos = RenderingUtils.WorldToScreen(paddle2.Position, new Camera2D(new Vector2D(0f, 0f), 1f, GridWidth, GridHeight));
    int paddle1ScreenX = (int)Math.Round(paddle1ScreenPos.X);
    int paddle1ScreenY = (int)Math.Round(GridHeight - 1 - paddle1ScreenPos.Y);
    int paddle2ScreenX = (int)Math.Round(paddle2ScreenPos.X);
    int paddle2ScreenY = (int)Math.Round(GridHeight - 1 - paddle2ScreenPos.Y);
    int paddleWidth = (int)paddle1.Width;
    int paddleHeight = (int)paddle1.Height;
    for (int dy = 0; dy < paddleHeight; dy++)
        for (int dx = 0; dx < paddleWidth; dx++)
        {
            if (paddle1ScreenX + dx >= 0 && paddle1ScreenX + dx < GridWidth && paddle1ScreenY + dy >= 0 && paddle1ScreenY + dy < GridHeight)
                grid[paddle1ScreenY + dy, paddle1ScreenX + dx] = '|'; // Paddle 1
            if (paddle2ScreenX + dx >= 0 && paddle2ScreenX + dx < GridWidth && paddle2ScreenY + dy >= 0 && paddle2ScreenY + dy < GridHeight)
                grid[paddle2ScreenY + dy, paddle2ScreenX + dx] = '|'; // Paddle 2
        }

    //// Draw ground (as boundary)
    //Vector2D groundScreenPos = RenderingUtils.WorldToScreen(groundSprite.Position, new Camera2D(new Vector2D(0f, 0f), 1f, GridWidth, GridHeight));
    //int groundScreenY = (int)Math.Round(GridHeight - 1 - groundScreenPos.Y);
    //for (int dx = 0; dx < GridWidth; dx++)
    //    grid[groundScreenY, dx] = '=';

    // Display scores
    Console.WriteLine($"Player 1: {player1Score}  Player 2: {player2Score}");
    Console.WriteLine("\nSimple Graphics Window (40x20 grid)");

    // Draw the grid
    for (int y = 0; y < GridHeight; y++)
    {
        for (int x = 0; x < GridWidth; x++)
            Console.Write(grid[y, x]);
        Console.WriteLine();
    }

    // Pad with empty lines to ensure consistent overwrite
    for (int i = 0; i < 5; i++) // Buffer to prevent scrolling
        Console.WriteLine(new string(' ', GridWidth));
}


// Main game loop
InitializeGameObjects();

while (true)
{
    HandleInput();
    UpdatePhysics();
    RenderFrame();
    System.Threading.Thread.Sleep((int)(DeltaTime * 1000)); // Sync with deltaTime
}