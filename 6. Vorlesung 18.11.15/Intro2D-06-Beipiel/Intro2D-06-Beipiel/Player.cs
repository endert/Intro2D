using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Intro2D_06_Beispiel
{
    /// <summary>
    /// the player
    /// </summary>
    class Player : GameObject
    {
        bool isJumping = false;
        float maxheight;
        float jumpingHeight;
        bool touchedGround = false;
        bool rechedHeight = true;

        /// <summary>
        /// initializes the Player with default values
        /// </summary>
        public Player(Vector2f startPosition)
        {
            textur = new Texture("Pictures/Player.png");
            sprite = new Sprite(textur);
            sprite.Position = startPosition;
            baseMovementSpeed = 0.2f;
            jumpingHeight = 100;
            maxheight = sprite.Position.Y;

            //scale needed because the texture is way too large
            sprite.Scale = new Vector2f(0.1f, 0.1f);
        }

        /// <summary>
        /// sets the MovingDirection according to the keyboard input
        /// </summary>
        void KeyboardInput()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                MovingDirection = new Vector2f(-1, MovingDirection.Y);
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                MovingDirection = new Vector2f(1, MovingDirection.Y);
            else
                MovingDirection = new Vector2f(0, MovingDirection.Y);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && !isJumping)
            {
                isJumping = true;
                rechedHeight = false;
                maxheight = sprite.Position.Y - jumpingHeight;
            }
        }

        /// <summary>
        /// Calls the Move methode
        /// </summary>
        public override void Update(GameTime gTime)
        {
            touchedGround = !Program.map.CheckDownWards(this);
            float div = (sprite.Position.Y + 10 - maxheight);

            if (!rechedHeight && sprite.Position.Y - maxheight < 0.1f)
                rechedHeight = true;

            if (!rechedHeight && isJumping)
            {
                sprite.Position = new Vector2f(sprite.Position.X, sprite.Position.Y - (div / 400) * gTime.Ellapsed.Milliseconds);
            }

            if(!touchedGround && rechedHeight)
            {
                sprite.Position = new Vector2f(sprite.Position.X, sprite.Position.Y + (div/450) * gTime.Ellapsed.Milliseconds);
                isJumping = false;
            }

            movementSpeed = baseMovementSpeed * gTime.Ellapsed.Milliseconds;
            KeyboardInput();
            Move();
        }
    }
}
