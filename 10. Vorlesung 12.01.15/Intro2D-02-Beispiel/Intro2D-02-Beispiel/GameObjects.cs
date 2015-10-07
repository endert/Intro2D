using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_02_Beispiel
{
    abstract class GameObjects
    {
        protected Sprite sprite;
        protected float scale;
        protected Vector2f position;

        public Vector2f getPosition()
        {
            return this.position;
        }

        public float getHeight()
        {
            return sprite.Texture.Size.X * scale;
        }

        public float getWidth()
        {
            return sprite.Texture.Size.Y * scale;
        }

        public void draw(RenderWindow win)
        {
            sprite.Position = this.getPosition();
            win.Draw(sprite);
        }
    }
}
