using System.Numerics;
using Raylib_cs;

const int screenWidth = 800;
const int screenHeight = 450;
Raylib.InitWindow(screenWidth, screenHeight, "Raylib-cs Simple Game");
Raylib.SetTargetFPS(60);

Rectangle player = new Rectangle(new Vector2(screenWidth / 2, screenHeight / 2), 50, 50);
float speed = 200;

while (!Raylib.WindowShouldClose())
{
    if (Raylib.IsKeyDown(KeyboardKey.Left)) player.X -= speed * Raylib.GetFrameTime();
    if (Raylib.IsKeyDown(KeyboardKey.Right)) player.X += speed * Raylib.GetFrameTime();
    if (Raylib.IsKeyDown(KeyboardKey.Up)) player.Y -= speed * Raylib.GetFrameTime();
    if (Raylib.IsKeyDown(KeyboardKey.Down)) player.Y += speed * Raylib.GetFrameTime();

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Black);

    Raylib.DrawText("Hello, world!", 12, 12, 20, Color.White);

    Raylib.DrawRectangleRec(player, Color.Red);

    Raylib.EndDrawing();
}

Raylib.CloseWindow();
