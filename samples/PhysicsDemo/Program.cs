using GameBoost.Core;
using GameBoost.Physics;
using GameBoost.Rendering;

// Define two bodies
var body1 = new PhysicsBody(new Vector2D(0, 0), new Vector2D(1f, 0), 1f, 2f, 2f);
var body2 = new PhysicsBody(new Vector2D(5, 0), new Vector2D(-1f, 0), 1f, 2f, 2f);

// Simulate manually
for (int i = 0; i < 10; i++)
{
    body1 = body1.Move(0.1f);
    body2 = body2.Move(0.1f);

    if (body1.CollidesWith(body2))
    {
        (body1, body2) = PhysicsUtils.ResolveCollision(body1, body2);
    }

    Console.WriteLine($"Step {i}: Body1 at {body1.Position.X}, Body2 at {body2.Position.X}");
}