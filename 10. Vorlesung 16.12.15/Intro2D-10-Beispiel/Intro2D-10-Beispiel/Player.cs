using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Intro2D_10_Beispiel
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
        bool isFalling = false;

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
                InGame.JumpSound.Play();
            }
        }

        /// <summary>
        /// Calls the Move methode
        /// </summary>
        public override void Update(GameTime gTime)
        {
            float div = sprite.Position.Y - maxheight;

            touchedGround = !InGame.map.CheckDownWards(this);

            if(touchedGround && isFalling)
            {
                InGame.SpawnParticles(sprite.Position + new Vector2f((sprite.Texture.Size.X * sprite.Scale.X) /2, sprite.Texture.Size.Y*sprite.Scale.Y));
            }

            if (touchedGround && !isJumping)
                maxheight = sprite.Position.Y;

            if(!isJumping && InGame.map.CheckDownWards(this))
            {
                sprite.Position += new Vector2f(0, (div + 3f) / 200);
            }
            if (isJumping)
            {
                sprite.Position -= new Vector2f(0, (div + 3f) / 200);
                if (Math.Abs(div) < 1f)
                {
                    isJumping = false;
                }
            }

            movementSpeed = baseMovementSpeed * gTime.Ellapsed.Milliseconds;
            KeyboardInput();
            Move();

            isFalling = !touchedGround && !isJumping;
        }
    }
}
