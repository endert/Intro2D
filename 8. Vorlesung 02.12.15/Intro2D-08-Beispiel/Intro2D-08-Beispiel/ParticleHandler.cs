using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_08_Beispiel
{
    class ParticleHandler
    {
        List<Particle> particles;
        Random r = new Random();
        float count;

        public ParticleHandler()
        {
            particles = new List<Particle>();
        }

        void SpawnParticles(int maxNumber)
        {
            for(int i = particles.Count; i <= maxNumber; i++)
            {
                
                Particle p = new Particle(new Vector2f(805* (float)r.NextDouble() - 5, -100 * (float)r.NextDouble()));
                particles.Add(p);
            }
        }

        public void Update(GameTime t)
        {
            count += (float)t.Ellapsed.TotalMilliseconds;
            //SpawnParticles(100);
            if (count > 10)
            {
                particles.Add(new Particle(new Vector2f(800 * (float)r.NextDouble(), -r.Next(10))));
                count = 0;
            }
            for(int i = 0; i<particles.Count; i++)
            {
                if (!particles[i].IsAlive)
                {
                    particles.RemoveAt(i);
                    i--;
                    continue;
                }

                particles[i].Update(t);
            }
        }

        public void Draw(RenderWindow win)
        {
            foreach (Particle p in particles)
            {
                p.Draw(win);
            }
        }
    }
}
