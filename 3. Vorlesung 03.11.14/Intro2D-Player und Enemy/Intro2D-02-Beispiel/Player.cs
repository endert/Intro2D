using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_02_Beispiel
{
    class Player : GameObjects
    {
        public Vector2f playerPosition;
        Sprite playerSprite;

        public Player()
        {
            Texture playerTexture = new Texture("Pictures/player.png");
            playerSprite = new Sprite(playerTexture);

            playerPosition = new Vector2f(0, 0);
            playerSprite.Position = playerPosition;

            playerSprite.Scale = new Vector2f(0.25f, 0.25f);
        }

        public void move()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                playerPosition = new Vector2f(playerPosition.X - 1, playerPosition.Y);
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                playerPosition = new Vector2f(playerPosition.X + 1, playerPosition.Y);
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                playerPosition = new Vector2f(playerPosition.X, playerPosition.Y- 1);
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                playerPosition = new Vector2f(playerPosition.X, playerPosition.Y + 1);

            playerSprite.Position = playerPosition;
        }

        public void draw(RenderWindow win)
        {
            win.Draw(playerSprite);
        }

    }
}
