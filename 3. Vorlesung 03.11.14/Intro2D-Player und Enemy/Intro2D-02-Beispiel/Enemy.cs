using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_02_Beispiel
{
    class Enemy
    {
        Vector2f position;
        Sprite sprite;

        public Enemy(Vector2f _position, string texturePath)
        {
            position = _position;

            Texture tex = new Texture(texturePath);
            sprite = new Sprite(tex);
        }

        public void draw(RenderWindow win)
        {
            sprite.Position = position;
            win.Draw(sprite);
        }

        public void move(Vector2f playerposition)
        {
            /*position.X += 0.1f;
            if(position.X > 800)
            {
                position.X = position.X % 800;
            }*/

            Vector2f direction = playerposition - position;
            float length = (float)Math.Sqrt(direction.X * direction.X + direction.Y * direction.Y);
            position += direction/(length* 5);
        }

    }
}
