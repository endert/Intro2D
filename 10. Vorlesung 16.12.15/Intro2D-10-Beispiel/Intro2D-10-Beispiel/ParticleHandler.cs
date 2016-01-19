using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_10_Beispiel
{
    class ParticleHandler
    {
        Vector2f Pos;
        List<Particle> Particles;
        CircleShape Debug = new CircleShape(3.5f);
        Random R = new Random();
        float SpawnTime;
        public bool IsAlive { get; private set; }

        public ParticleHandler(Vector2f position, int spawnTime = 100)
        {
            SpawnTime = spawnTime;
            IsAlive = true;
            Pos = position;
            Debug.Position = Pos - new Vector2f(Debug.Radius, Debug.Radius);
            Debug.FillColor = Color.Black;
            Particles = new List<Particle>();
        }

        public void Update(GameTime t)
        {
            if (SpawnTime < 0 && Particles.Count <= 0)
                IsAlive = false;

            if (SpawnTime > 0)
                Particles.Add(new Particle(Pos, new Vector2f(2 * (float)R.NextDouble() - 1, 2 * (float)R.NextDouble() - 1), new CircleShape(1), Color.Black, (float)R.NextDouble() * 4, (float)R.NextDouble() / 4, R.Next(200)));

            for (int i = 0; i < Particles.Count; ++i)
            {
                if (!Particles[i].IsAlive)
                {
                    Particles.RemoveAt(i);
                    i--;
                    continue;
                }

                Particles[i].Update(t);
            }

            SpawnTime -= 1 + (float)t.Ellapsed.TotalMilliseconds;
        }

        public void Draw(RenderWindow win)
        {
            //win.Draw(Debug);
            foreach (Particle p in Particles)
                p.Draw(win);
        }
    }
}
