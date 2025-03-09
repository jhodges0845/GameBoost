using GameBoost.Core;
using GameBoost.Physics;
using GameBoost.Rendering;


const int GridWidth = 40;
const int GridHeight = 20;
const float DeltaTime = 0.33f; // Match refresh rate (~3 FPS, corrected from ~30 FPS)
Vector2D Gravity = new Vector2D(0f, -10f);

// Game objects
 PhysicsBody box;
 Sprite boxSprite;
 Sprite groundSprite;

// Initialize game objects
void InitializeGameObjects()
{
    box = new PhysicsBody(new Vector2D(20f, 15f), new Vector2D(0f, -5f), 1f, 2f, 2f); // Added initial downward velocity
    groundSprite = new Sprite(new Vector2D(20f, 2f), 40f, 1f, "ground");
}

// Update physics of the box

void UpdatePhysics()
{
    // Current position and velocity
    float startY = box.Position.Y;
    float velocityY = box.Velocity.Y;

    // Apply gravity to velocity
    velocityY += Gravity.Y * DeltaTime;

    // Calculate new position without collision
    float endY = startY + velocityY * DeltaTime;

    // Ground collision check
    float boxBottom = endY - box.Height / 2f;
    float groundTop = groundSprite.Position.Y + groundSprite.Height / 2f;
    if (boxBottom <= groundTop)
    {
        // Calculate time of impact within the frame
        float timeToImpact = (startY - box.Height / 2f - groundTop) / (startY - endY);
        if (timeToImpact < 0 || timeToImpact > 1) timeToImpact = 0; // Clamp to frame

        // Adjust position to exact collision point
        float collisionY = startY + (velocityY * timeToImpact * DeltaTime);
        box.Position = new Vector2D(box.Position.X, groundTop + box.Height / 2f);

        // Bounce: Apply velocity change at collision point
        box.Velocity = new Vector2D(box.Velocity.X, -velocityY * 0.5f);
    }
    else
    {
        // No collision, update normally
        box.Position = new Vector2D(box.Position.X, endY);
        box.Velocity = new Vector2D(box.Velocity.X, velocityY);
    }

    // Update boxSprite
    boxSprite = new Sprite(box.Position, 2f, 2f, "box");
}

void HandleCollisions()
{
    // Ceiling collision
    float boxTop = box.Position.Y + box.Height / 2f;
    float ceiling = GridHeight - 1;
    if (boxTop >= ceiling)
    {
        box.Velocity = new Vector2D(box.Velocity.X, -box.Velocity.Y * 0.5f);
        box.Position = new Vector2D(box.Position.X, GridHeight - 1 - box.Height / 2f);
    }
}

// Render the current frame
void RenderFrame()
{
    Console.Clear();

    // Initialize the grid
    char[,] grid = new char[GridHeight, GridWidth];
    for (int y = 0; y < GridHeight; y++)
        for (int x = 0; x < GridWidth; x++)
            grid[y, x] = '.';

    // Calculate screen positions
    Vector2D boxScreenPos = RenderingUtils.WorldToScreen(boxSprite.Position, new Camera2D(new Vector2D(0f, 0f), 1f, GridWidth, GridHeight));
    Vector2D groundScreenPos = RenderingUtils.WorldToScreen(groundSprite.Position, new Camera2D(new Vector2D(0f, 0f), 1f, GridWidth, GridHeight));

    int screenX = (int)Math.Round(boxScreenPos.X);
    int screenY = (int)Math.Round(GridHeight - 1 - boxScreenPos.Y);
    int boxWidth = (int)boxSprite.Width;
    int boxHeight = (int)boxSprite.Height;

    int groundScreenX = (int)Math.Round(groundScreenPos.X);
    int groundScreenY = (int)Math.Round(GridHeight - 1 - groundScreenPos.Y);
    int groundWidth = (int)groundSprite.Width;
    int groundHeight = (int)groundSprite.Height;

    // Draw box
    for (int dy = 0; dy < boxHeight; dy++)
        for (int dx = 0; dx < boxWidth; dx++)
        {
            int gridX = screenX + dx;
            int gridY = screenY + dy;
            if (gridX >= 0 && gridX < GridWidth && gridY >= 0 && gridY < GridHeight)
                grid[gridY, gridX] = 'B';
        }

    // Draw ground
    for (int dx = 0; dx < groundWidth; dx++)
    {
        int gridX = dx;
        int gridY = groundScreenY;
        if (gridX >= 0 && gridX < GridWidth && gridY >= 0 && gridY < GridHeight)
            grid[gridY, gridX] = '=';
    }

    // Print debug information
    Console.WriteLine($"Box Position: ({box.Position.X:F1}, {box.Position.Y:F1}), Screen: ({screenX}, {screenY})");
    Console.WriteLine($"Ground Position: ({groundSprite.Position.X:F1}, {groundSprite.Position.Y:F1}), Screen: ({groundScreenX}, {groundScreenY})");
    Console.WriteLine($"DeltaTime: {DeltaTime}, Gravity: ({Gravity.X:F1}, {Gravity.Y:F1})");

    // Draw the grid
    Console.WriteLine("\nSimple Graphics Window (40x20 grid)");
    for (int y = 0; y < GridHeight; y++)
    {
        for (int x = 0; x < GridWidth; x++)
            Console.Write(grid[y, x]);
        Console.WriteLine();
    }
}

// Main game loop using top-level statements
InitializeGameObjects();

while (true)
{
    UpdatePhysics();
    HandleCollisions();
    RenderFrame();
    System.Threading.Thread.Sleep((int)(DeltaTime * 1000)); // Sync refresh with deltaTime
}


