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
        Sprite[] sprite;

        public Vector2f getPosition()
        {
            return this.position;
        }

        public float getHeight()
        {
            return sprite[0].Texture.Size.X;
        }

        public float getWidth()
        {
            return sprite[0].Texture.Size.Y;
        }


        public Enemy(Vector2f _position, string texturePath, string texturePath2)
        {
            sprite = new Sprite[2];
            position = _position;

            Texture tex = new Texture(texturePath);
            Texture tex2 = new Texture(texturePath2);

            sprite[0] = new Sprite(tex);
            sprite[1] = new Sprite(tex2);
        }

        public void draw(RenderWindow win, GameTime time)
        {
            for (int i = 0; i < sprite.Length; i++)
            {
                sprite[i].Position = position;
            }
            if (time.TotalTime.Milliseconds % 500 < 250)
                win.Draw(sprite[0]);
            else
                win.Draw(sprite[1]);
        }

        public void move(Vector2f playerposition, GameTime time)
        {
            /*position.X += 0.1f;
            if(position.X > 800)
            {
                position.X = position.X % 800;
            }*/

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
