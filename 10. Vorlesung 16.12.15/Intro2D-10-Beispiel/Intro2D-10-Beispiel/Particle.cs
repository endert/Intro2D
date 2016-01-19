using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_10_Beispiel
{
    class Particle
    {
        Shape S;
        public bool IsAlive { get; private set; }
        Vector2f D;
        float Speed;
        float LifeTime;

        public Particle(Vector2f pos, Vector2f direction, Shape shape, Color color, float speed = 0.1f, int lifeTime = 400)
        {
            S = shape;
            S.FillColor = color;
            IsAlive = true;
            D = direction;
            D = D / (float)Math.Sqrt(D.X * D.X + D.Y * D.Y);
            S.Position = pos;
            Speed = speed;
            LifeTime = lifeTime;
        }

        public Particle(Vector2f pos, Vector2f direction, CircleShape cShape, Color color, float radius = 1, float speed = 0.1f, int lifeTime = 400) : this(pos, direction, new CircleShape(radius), color, speed, lifeTime) { }

        public Particle(Vector2f pos, Vector2f direction, Shape shape) : this(pos, direction, shape, Color.Red) { }
        public Particle(Vector2f pos, Vector2f direction) : this(pos, direction, new CircleShape(1), Color.Red) { }

        public void Update(GameTime t)
        {
            if (LifeTime < 0)
                IsAlive = false;

            S.Position += D * Speed * (1 + t.Ellapsed.Milliseconds);
            LifeTime -= (1 + (float)t.Ellapsed.TotalMilliseconds);
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(S);
        }
    }
}
