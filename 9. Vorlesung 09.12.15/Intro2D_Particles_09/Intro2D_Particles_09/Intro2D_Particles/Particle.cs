using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;


namespace Intro2D_Particles
{
    class Particle
    {
        private static Texture[] texture;
        private Sprite sprite;
        private float size;
        private float lifeTime;


        public Particle (Vector2f position)
        {

            size = (float)ParticleHandler.random.NextDouble();
            if (size < 0.5f)
                size = 0.5f;

            lifeTime = 0;

            sprite = new Sprite(texture[ParticleHandler.random.Next(texture.Length)]);
            sprite.Position = position;
            sprite.Scale = new Vector2f(size, size);
        }

        public static void loadContent()
        {
            texture = new Texture[4];
            texture[0] = new Texture("Content//Flakes//flake0.png");
            texture[1] = new Texture("Content//Flakes//flake1.png");
            texture[2] = new Texture("Content//Flakes//flake2.png");
            texture[3] = new Texture("Content//Flakes//flake3.png");
        }

        public void update(GameTime time)
        {
            lifeTime += (float)time.EllapsedTime.TotalMilliseconds;

            sprite.Position += new Vector2f((float)Math.Sin(lifeTime*0.003)/4 * size, size);


        }
        public void draw(RenderWindow win)
        {
            win.Draw(sprite);
        }

        public bool isAlive()
        {
            if (sprite.Position.Y > Game.WINDOW_SIZE.Y)
                return false;
            else
                return true;


        }

    }
}
