using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Intro2D_07_Beispiel
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

        /// <summary>
        /// initializes the Player with default values
        /// </summary>
        public Player(Vector2f startPosition)
        {
            textur = new Texture("Pictures/Player.png");
            sprite = new Sprite(textur);
            sprite.Position = startPosition;
            baseMovementSpeed = 0.2f;
            jumpingHeight = 200;
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

            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && !isJumping && touchedGround)
            {
                isJumping = true;
                maxheight = sprite.Position.Y - jumpingHeight;
                //Program.JumpSound.Play();
            }
        }

        /// <summary>
        /// Calls the Move methode
        /// </summary>
        public override void Update(GameTime gTime)
        {
            float div = sprite.Position.Y - maxheight;

            //touchedGround = !Program.map.CheckDownWards(this);

           // if(!isJumping && Program.map.CheckDownWards(this))
            {
                sprite.Position += new Vector2f(0, (div+1f)/300);
            }
            if (isJumping)
            {
                sprite.Position -= new Vector2f(0, (div + 1f) / 300);
                if (Math.Abs(div) < 1f)
                {
                    isJumping = false;
                }
            }

            movementSpeed = baseMovementSpeed * gTime.Ellapsed.Milliseconds;
            KeyboardInput();
            Move();
        }
    }
}
