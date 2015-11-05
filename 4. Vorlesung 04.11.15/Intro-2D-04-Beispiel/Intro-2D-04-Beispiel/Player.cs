using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Intro_2D_04_Beispiel
{
    /// <summary>
    /// the player
    /// </summary>
    class Player : GameObject
    {
        /// <summary>
        /// initializes the Player with default values
        /// </summary>
        public Player(Vector2f startPosition)
        {
            textur = new Texture("Pictures/Player.png");
            sprite = new Sprite(textur);
            sprite.Position = startPosition;
            movementSpeed = 0.2f;

            //scale needed because the texture is way too large
            sprite.Scale = new Vector2f(0.1f, 0.1f);
        }

        /// <summary>
        /// sets the MovingDirection according to the keyboard input
        /// </summary>
        void KeyboardInput()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                MovingDirection = new Vector2f(MovingDirection.X, -1);
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                MovingDirection = new Vector2f(MovingDirection.X, 1);
            else
                MovingDirection = new Vector2f(MovingDirection.X, 0);

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                MovingDirection = new Vector2f(-1, MovingDirection.Y);
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                MovingDirection = new Vector2f(1, MovingDirection.Y);
            else
                MovingDirection = new Vector2f(0, MovingDirection.Y);
        }

        /// <summary>
        /// Calls the Move methode
        /// </summary>
        public override void Update()
        {
            KeyboardInput();
            Move();
        }
    }
}
