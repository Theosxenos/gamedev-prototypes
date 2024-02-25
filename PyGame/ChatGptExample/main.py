import pygame
import sys

# Initialize Pygame
pygame.init()

# Set up display
screen_width, screen_height = 640, 480
screen = pygame.display.set_mode((screen_width, screen_height))

# 
game_clock = pygame.time.Clock()

# Colors
background_color = (255, 255, 255)  # White
box_color = (0, 0, 255)  # Blue

# Box properties
box_position = [screen_width // 2, screen_height // 2]
box_size = 50

speed = float(100)

# Game loop flag
running = True

# Game loop
while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False

    dt = game_clock.tick(60)/1000
    # Key press detection
    keys = pygame.key.get_pressed()
    if keys[pygame.K_LEFT]:
        box_position[0] -= speed * dt
    if keys[pygame.K_RIGHT]:
        box_position[0] +=  speed * dt
    if keys[pygame.K_UP]:
        box_position[1] -=  speed * dt
    if keys[pygame.K_DOWN]:
        box_position[1] +=  speed * dt

    # Fill the screen with the background color
    screen.fill(background_color)

    # Draw the box
    pygame.draw.rect(screen, box_color, (box_position[0], box_position[1], box_size, box_size))

    # Update the display
    pygame.display.flip()

# Quit Pygame
pygame.quit()
sys.exit()
