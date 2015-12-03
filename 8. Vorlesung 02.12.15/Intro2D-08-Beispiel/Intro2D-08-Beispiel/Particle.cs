using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_08_Beispiel
{
    class Particle
    {
        public bool IsAlive { get; protected set; }
        Sprite s;
        static Texture[] t;
        float lifeTime;
        Random r = new Random();
        float size;

        public Particle(Vector2f spawnPos)
        {
            t = new Texture[4];
            t[0] = new Texture("Assets/flake0.png");
            t[1] = new Texture("Assets/flake1.png");
            t[2] = new Texture("Assets/flake2.png");
            t[3] = new Texture("Assets/flake3.png");
            size = (float)r.NextDouble() * 0.5f + 0.5f;

            lifeTime = 0;
            s = new Sprite(t[r.Next(3)]);
            s.Position = spawnPos;
            s.Scale = new Vector2f(size, size);
            IsAlive = true;
        }

        public void Update(GameTime t)
        {
            lifeTime += (float)t.Ellapsed.TotalMilliseconds;

            s.Position += new Vector2f((float)Math.Sin(lifeTime * 0.003) / 40 * size, size/10) * (float)t.Ellapsed.TotalMilliseconds;

            if (s.Position.Y > 1000)
                IsAlive = false;
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(s);
        }
    }
}
