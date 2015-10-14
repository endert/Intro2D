using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_02_Beispiel
{
    class Player
    {
        Sprite playerSprite;
        Texture playerTexture;
        Vector2f playerPosition;

        public Player()
        {
            
            playerSprite = new Sprite();
            playerTexture = new Texture("Content/coding-logo.png");
            playerPosition = new Vector2f(0,0);

            playerSprite.Texture = playerTexture;
            playerSprite.Position = playerPosition;
            playerSprite.Scale = new Vector2f(0.25f, 0.25f);
        }

        public void Move()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                playerSprite.Position = new Vector2f(playerSprite.Position.X - 1, playerSprite.Position.Y);
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                playerSprite.Position = new Vector2f(playerSprite.Position.X, playerSprite.Position.Y + 1);
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                playerSprite.Position = new Vector2f(playerSprite.Position.X + 1, playerSprite.Position.Y);
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                playerSprite.Position = new Vector2f(playerSprite.Position.X, playerSprite.Position.Y - 1);

        }
        public void Draw(RenderWindow window)
        {
            window.Draw(playerSprite);
        }

    }
}
