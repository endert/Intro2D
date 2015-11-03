using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_03_Beispiel_Player_Enemy
{
    /// <summary>
    /// the enemy
    /// </summary>
    class Enemy
    {
        //attributes
        Texture textur;
        Sprite sprite;
        
        /// <summary>
        /// initializes a new Enemy
        /// </summary>
        /// <param name="direction">the direction to the texture as a string</param>
        /// <param name="sPosition">start position</param>
        public Enemy(string direction, Vector2f sPosition)
        {
            textur = new Texture(direction);
            sprite = new Sprite(textur);

            sprite.Position = sPosition;
        } 

        /// <summary>
        /// moves in the given direction
        /// </summary>
        /// <param name="playerPos"></param>
        public void Move(Vector2f playerPos)
        {
            //evaluate the direction from this position to the given one. Math \(^^)/
            Vector2f direction = playerPos - sprite.Position;

            //evaluate the length of the direction vector. Math \(^^)/
            float length = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);

            //norming the direction vector, so it have the length of 1. Math \(^^)/
            direction = direction / length;

            //adding a percentage of the direction to the position. guess what comes now^^ Math \(^^)/
            sprite.Position += direction*0.01f;
        }

        /// <summary>
        /// draws the sprite in the given window
        /// </summary>
        /// <param name="win"></param>
        public void Draw(RenderWindow win)
        {
            win.Draw(sprite);
        }
    }
}
