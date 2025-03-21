﻿using GameBoost.Core;
using GameBoost.Physics;
using GameBoost.Rendering;
using PhysicsDemo;
//using TextureDemo;

const float DeltaTime = 0.33f; // Match refresh rate (~3 FPS)
MathUtils _mathUtils = new MathUtils();
Vector2D Gravity = new Vector2D(0f, -10f, _mathUtils);

// Game objects
PhysicsBody box;
RenderableObject boxRender;
RenderableObject groundRender;

// Initialize render context and textures
IRenderContext context = new SfmlRenderContext(800, 600, "Bouncing Box Demo");
IScreen screen = new SfmlScreen(800, 600, _mathUtils); // Match window size
ITexture boxTexture = new SfmlTexture("Box.png"); // Ensure Box.png exists
ITexture groundTexture = new SfmlTexture("Ground.png"); // Ensure Ground.png exists

// Initialize game objects
void InitializeGameObjects()
{
    box = new PhysicsBody(new Vector2D(20f, 15f, _mathUtils), new Vector2D(0f, -5f, _mathUtils), 1f, 2f, 2f); // Position in world units (40x20 grid)
    IVector2D boxScreenPos = screen.ConvertWorldToScreen(box.Position);
    boxRender = new RenderableObject(boxTexture, boxScreenPos);

    // Ground at Y=2 in world coordinates
    IVector2D groundScreenPos = screen.ConvertWorldToScreen(new Vector2D(20f, 2f, _mathUtils));
    groundRender = new RenderableObject(groundTexture, groundScreenPos);
}

// Update physics of the box
void UpdatePhysics(float groundHeight)
{
    // Current position and velocity
    double startY = box.Position.Y;
    double velocityY = box.Velocity.Y;

    // Apply gravity to velocity
    velocityY += Gravity.Y * DeltaTime;

    // Calculate new position without collision
    double endY = startY + velocityY * DeltaTime;

    // Ground collision check
    double boxBottom = endY - box.Height / 2f;
    double groundTop = groundHeight + 0.5f; // Ground sprite height is 1f in world units
    if (boxBottom <= groundTop)
    {
        // Calculate time of impact within the frame
        double timeToImpact = (startY - box.Height / 2f - groundTop) / (startY - endY);
        if (timeToImpact < 0 || timeToImpact > 1) timeToImpact = 0; // Clamp to frame

        // Adjust position to exact collision point
        double collisionY = startY + (velocityY * timeToImpact * DeltaTime);
        box.Position = new Vector2D(box.Position.X, groundTop + box.Height / 2f, _mathUtils);

        // Bounce: Apply velocity change at collision point
        box.Velocity = new Vector2D(box.Velocity.X, -velocityY * 0.5f, _mathUtils);
    }
    else
    {
        // No collision, update normally
        box.Position = new Vector2D(box.Position.X, endY, _mathUtils);
        box.Velocity = new Vector2D(box.Velocity.X, velocityY, _mathUtils);
    }
}

// Handle ceiling collisions
void HandleCollisions(float ceilingHeight)
{
    // Ceiling collision
    double boxTop = box.Position.Y + box.Height / 2f;
    if (boxTop >= ceilingHeight)
    {
        box.Velocity = new Vector2D(box.Velocity.X, -box.Velocity.Y * 0.5f, _mathUtils);
        box.Position = new Vector2D(box.Position.X, ceilingHeight - box.Height / 2f, _mathUtils);
    }
}

// Render the current frame
void RenderFrame()
{
    // Update render positions using IScreen
    IVector2D boxScreenPos = screen.ConvertWorldToScreen(box.Position);
    boxRender.Position = boxScreenPos;
    groundRender.Position = screen.ConvertWorldToScreen(new Vector2D(20f, 2f, _mathUtils)); // Ground stays at Y=2

    context.Clear(0.2f, 0.3f, 0.3f, 1.0f);
    groundRender.Render(context);
    boxRender.Render(context);
    context.Display();
}

// Main game loop
InitializeGameObjects();

while (context.IsActive())
{
    UpdatePhysics(2f); // Ground Y position in world units
    HandleCollisions(19f); // Ceiling at GridHeight - 1 = 19 in world units
    RenderFrame();
    System.Threading.Thread.Sleep((int)(DeltaTime * 1000)); // Sync refresh with deltaTime
}

