// Initialize rendering context
using GameBoost.Core;
using GameBoost.Rendering;
using TextureDemo;

IScreen screen = new SfmlScreen(800, 600);
var context = new SfmlRenderContext((uint)screen.Width, (uint)screen.Height, "Texture Demo");

// Load a texture (place a sample PNG in the project folder)
var texture = new SfmlTexture("sample.png");
var obj = new RenderableObject(texture, new Vector2D(100, 100));

// Main loop
while (context.IsActive())
{
    context.Clear(0.2f, 0.3f, 0.3f, 1.0f); // Teal background
    obj.Render(context);
    context.Display();
}