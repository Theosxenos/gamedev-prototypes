using SDL2;
using System;

if (SDL.SDL_Init(SDL.SDL_INIT_VIDEO) < 0)
{
    Console.WriteLine($"There was an issue initializing SDL. {SDL.SDL_GetError()}");
}


// Create a new window given a title, size, and passes it a flag indicating it should be shown.
var window = SDL.SDL_CreateWindow("SDL .NET 6 Tutorial", SDL.SDL_WINDOWPOS_UNDEFINED, SDL.SDL_WINDOWPOS_UNDEFINED, 640, 480, SDL.SDL_WindowFlags.SDL_WINDOW_SHOWN);

if (window == IntPtr.Zero)
{
    Console.WriteLine($"There was an issue creating the window. {SDL.SDL_GetError()}");
}

// Creates a new SDL hardware renderer using the default graphics device with VSYNC enabled.
var renderer = SDL.SDL_CreateRenderer(window, 
    -1, 
    SDL.SDL_RendererFlags.SDL_RENDERER_ACCELERATED | 
    SDL.SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC);

if (renderer == IntPtr.Zero)
{
    Console.WriteLine($"There was an issue creating the renderer. {SDL.SDL_GetError()}");
}

// Initilizes SDL_image for use with png files.
if (SDL_image.IMG_Init(SDL_image.IMG_InitFlags.IMG_INIT_PNG) == 0)
{
    Console.WriteLine($"There was an issue initializing SDL2_Image {SDL_image.IMG_GetError()}");
}

// Player
var player = new SDL.SDL_FRect()
{
    h = 50,
    w = 50,
    x = 240,
    y = 320
};
float speed = 100;

var running = true;
uint lastTime = SDL.SDL_GetTicks(), currentTime, deltaTime;

// Main loop for the program
while (running)
{
    currentTime = SDL.SDL_GetTicks();
    deltaTime = currentTime - lastTime;
    lastTime = currentTime;
    float deltaSeconds = deltaTime / 1000.0f; // Convert milliseconds to seconds.

    // Check to see if there are any events and continue to do so until the queue is empty.
    while (SDL.SDL_PollEvent(out SDL.SDL_Event e) == 1)
    {
        switch (e.type)
        {
            case SDL.SDL_EventType.SDL_QUIT:
                running = false;
                break;
            case SDL.SDL_EventType.SDL_KEYDOWN:
                switch (e.key.keysym.sym)
                {
                    case SDL.SDL_Keycode.SDLK_UP:
                        player.y -= speed * deltaSeconds;
                        break;
                    case SDL.SDL_Keycode.SDLK_DOWN:
                        player.y += speed * deltaSeconds;
                        break;
                    case SDL.SDL_Keycode.SDLK_LEFT:
                        player.x -= speed * deltaSeconds;
                        break;
                    case SDL.SDL_Keycode.SDLK_RIGHT:
                        player.x += speed * deltaSeconds;
                        break;
                }
                break;
        }
    }

    // Sets the color that the screen will be cleared with.
    if (SDL.SDL_SetRenderDrawColor(renderer, 135, 206, 235, 255) < 0)
    {
        Console.WriteLine($"There was an issue with setting the render draw color. {SDL.SDL_GetError()}");
    }

    // Clears the current render surface.
    if (SDL.SDL_RenderClear(renderer) < 0)
    {
        Console.WriteLine($"There was an issue with clearing the render surface. {SDL.SDL_GetError()}");
    }

    SDL.SDL_SetRenderDrawColor(renderer, 255, 0, 0, 0);
    SDL.SDL_RenderFillRectF(renderer, ref player);
    SDL.SDL_RenderDrawRectF(renderer, ref player);
    
    // Switches out the currently presented render surface with the one we just did work on.
    SDL.SDL_RenderPresent(renderer);
}

// Clean up the resources that were created.
SDL.SDL_DestroyRenderer(renderer);
SDL.SDL_DestroyWindow(window);
SDL.SDL_Quit();