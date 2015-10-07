using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_02_Beispiel
{
    class Enemy : GameObjects
    {

        
        public Enemy(Vector2f _position, string texturePath)
        {
            scale = 1;
            position = _position;

            Texture tex = new Texture(texturePath);
            sprite = new Sprite(tex);

            sprite.Position = position;
        }

        public void move(Vector2f playerposition, GameTime time)
        {
            Vector2f direction = playerposition - position;
            float length = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
            position += new Vector2f((direction/(length* 5)).X * time.EllapsedTime.Milliseconds,(direction/(length*5)).Y * time.EllapsedTime.Milliseconds);
        }

        public void move2 (GameTime time)
        {
            position.X += 0.1f * time.EllapsedTime.Milliseconds;
            if (position.X > 800)
            {
                position.X = position.X % 800;
            }
        }

    }
}
