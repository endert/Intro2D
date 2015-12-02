using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace Intro2D_Particles
{
    class ParticleHandler
    {
        List<Particle> particles;

        private float spawnTime;
        private float count;

        public static Random random;
        public ParticleHandler (float spawnTime_)
        {
            particles = new List<Particle>();
            random = new Random();

            spawnTime = spawnTime_;

            count = 0;

            

        }

        public static void loadContent()
        {
            Particle.loadContent();
        }

        public void update(GameTime time)
        {
           

            count += (float)time.EllapsedTime.TotalMilliseconds;

            if (count > spawnTime)
            {

                for (int i = 0; i < 1; i++)
                {
                    particles.Add(new Particle(new Vector2f((float)random.Next((int)Game.WINDOW_SIZE.X), -50)));
                }
                count = 0;
                
            }

            for (int i = 0; i < particles.Count; i++)
            {
                if(!particles[i].isAlive())
                {
                    particles.Remove(particles[i]);
                   

                }
            }

            for (int i = 0; i < particles.Count; i++)
            {

                particles[i].update(time);
            }
        }
        public void draw(RenderWindow win)
        {
            for (int i = 0; i < particles.Count; i++)
            {
                particles[i].draw(win);
            }
        }

    }
}
