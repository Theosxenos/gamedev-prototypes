using SFML.Graphics;
using SFML.System;
using SFML.Window;

var window = new RenderWindow(new VideoMode(640, 480), "SFML Application");
var rectangle = new RectangleShape(new Vector2f(50, 50))
{
    FillColor = Color.Red,
    Position = new Vector2f(320, 240) // Starting position at the center
};

float movementSpeed = 100.0f; // Units per second
Clock clock = new Clock(); // Create a clock to track delta time

window.Closed += (sender, e) => window.Close();

// This should be outside the loop to avoid multiple subscriptions
window.KeyPressed += (sender, e) =>
{
    // This event will trigger once per key press
    if (e.Code == Keyboard.Key.Escape)
    {
        window.Close();
    }
};

while (window.IsOpen)
{
    window.DispatchEvents();

    // Calculate delta time
    float deltaTime = clock.Restart().AsSeconds();

    // Example of continuous movement handling
    if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
    {
        rectangle.Position += new Vector2f(-movementSpeed * deltaTime, 0);
    }
    if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
    {
        rectangle.Position += new Vector2f(movementSpeed * deltaTime, 0);
    }
    if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
    {
        rectangle.Position += new Vector2f(0, -movementSpeed * deltaTime);
    }
    if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
    {
        rectangle.Position += new Vector2f(0, movementSpeed * deltaTime);
    }

    window.Clear(Color.Black);
    window.Draw(rectangle);
    window.Display();
}
