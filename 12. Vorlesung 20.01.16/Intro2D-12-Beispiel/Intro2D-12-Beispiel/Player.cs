using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_12_Beispiel
{
    class Player
    {
        RectangleShape s;
        public float Hp { get; private set; }
        float MaxHp = 200;
        public Vector2f Position { get { return s.Position; } set { s.Position = value; } }

        public Player(float hp = 200)
        {
            s = new RectangleShape(new Vector2f(100, 200));
            Hp = hp;
        }

        public Player(float hp, Vector2f pos) : this(hp)
        {
            s.Position = pos;
        }

        public void Draw(RenderWindow win)
        {
            win.Draw(s);
        }

        public void Update()
        {
            s.Scale = new Vector2f(Hp / MaxHp, Hp / MaxHp);

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                s.Position += new Vector2f(0.1f, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.I))
                s.Position += new Vector2f(0, 0.1f);
            if (Keyboard.IsKeyPressed(Keyboard.Key.U))
                s.Position += new Vector2f(-0.1f, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.V))
                s.Position += new Vector2f(0, -0.1f);

            if (Keyboard.IsKeyPressed(Keyboard.Key.G))
                Hp += 0.1f;
            if (Keyboard.IsKeyPressed(Keyboard.Key.R))
                Hp -= 0.1f;
        }
    }
}
