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

        public Player(Vector2f spawnPosition)
        {
            scale = 0.25f;
            Texture playerTexture = new Texture("Content/player.png");
            sprite = new Sprite(playerTexture);

            position = spawnPosition;
            sprite.Position = position;

            sprite.Scale = new Vector2f(scale, scale);
        }

        public void move()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                position = new Vector2f(position.X - 1, position.Y);
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                position = new Vector2f(position.X + 1, position.Y);
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                position = new Vector2f(position.X, position.Y - 1);
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                position = new Vector2f(position.X, position.Y + 1);

            sprite.Position = position;
        }

    }
}
