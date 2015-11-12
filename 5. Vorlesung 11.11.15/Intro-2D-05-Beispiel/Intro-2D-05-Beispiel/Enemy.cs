using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_2D_05_Beispiel
{
    /// <summary>
    /// the enemy
    /// </summary>
    class Enemy : GameObject
    {
        //needed for the animation
        Texture textur2;

        /// <summary>
        /// initializes a new Enemy
        /// </summary>
        /// <param name="direction">the direction to the texture as a string</param>
        /// <param name="sPosition">start position</param>
        public Enemy(string direction, Vector2f sPosition)
        {
            textur = new Texture(direction);
            sprite = new Sprite(textur);
            baseMovementSpeed = 0.1f;

            sprite.Position = sPosition;
        }

        /// <summary>
        /// overloaded constructor
        /// <para>programm calls the best fitting one</para>
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="sPos"></param>
        /// <param name="direction2"></param>
        public Enemy(string direction, Vector2f sPos, string direction2) : this(direction, sPos)
        {
            textur2 = new Texture(direction2);
        }

        /// <summary>
        /// animates the enemy by switching the texture of the sprite
        /// </summary>
        /// <param name="gTime"></param>
        protected void Animate(GameTime gTime)
        {
            if (gTime.Total.Milliseconds % 1000 < 500)
                sprite.Texture = textur;
            else
                sprite.Texture = textur2;
        }

        /// <summary>
        /// calls the move Methode
        /// </summary>
        public override void Update(GameTime gTime)
        {
            movementSpeed = baseMovementSpeed * gTime.Ellapsed.Milliseconds;
            MovingDirection = Program.Player.Position - sprite.Position;
            Move();
            if (isMoving)
                Animate(gTime);
        }
    }
}
