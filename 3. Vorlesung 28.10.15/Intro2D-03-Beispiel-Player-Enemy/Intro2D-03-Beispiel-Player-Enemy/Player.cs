using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Intro2D_03_Beispiel_Player_Enemy
{
    /// <summary>
    /// the player
    /// </summary>
    class Player
    {
        //the attributes
        Texture textur;
        Sprite sprite;

        /// <summary>
        /// initializes the Player with default values
        /// </summary>
        public Player()
        {
            textur = new Texture("Pictures/Player.png");
            sprite = new Sprite(textur);

            //scale needed because the texture is way too large
            sprite.Scale = new Vector2f(0.3f, 0.3f);
        }

        /// <summary>
        /// Get the Position of this instance
        /// </summary>
        /// <returns>sprite.Position</returns>
        public Vector2f GetPosition()
        {
            return sprite.Position;
        }

        /// <summary>
        /// Moves according to the keyboard input
        /// </summary>
        public void Move()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                sprite.Position = sprite.Position + new Vector2f(0, -0.1f);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                sprite.Position += new Vector2f(0, 0.1f);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                sprite.Position += new Vector2f(-0.1f, 0);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                sprite.Position += new Vector2f(0.1f, 0);
            }
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
