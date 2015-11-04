using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_2D_04_Beispiel
{
    /// <summary>
    /// the enemy
    /// </summary>
    class Enemy : GameObject
    {
        /// <summary>
        /// initializes a new Enemy
        /// </summary>
        /// <param name="direction">the direction to the texture as a string</param>
        /// <param name="sPosition">start position</param>
        public Enemy(string direction, Vector2f sPosition)
        {
            textur = new Texture(direction);
            sprite = new Sprite(textur);
            MovementSpeed = 0.1f;

            sprite.Position = sPosition;
        }

        /// <summary>
        /// calls the move Methode
        /// </summary>
        public override void Update()
        {
            MovingDirection = Program.Player.Position - sprite.Position;
            Move();
        }
    }
}
