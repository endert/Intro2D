using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_08_Beispiel
{
    class Game
    {
        RenderWindow win;
        GameTime gTime;
        ParticleHandler pH;
        //Particle p;

        public Game()
        {
            win = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Particles ^^");
            win.Closed += (sender, e) => { ((RenderWindow)sender).Close(); };
            gTime = new GameTime();
            //p = new Particle(new SFML.Window.Vector2f(100, -3));
            
            pH = new ParticleHandler();
        }

        public void Run()
        {
            while (win.IsOpen())
            {
                win.DispatchEvents();
                Update();
                Draw();
            }
        }

        void Update()
        {
            gTime.Update();
            pH.Update(gTime);
            //p.Update(gTime);
        }

        void Draw()
        {
            win.Clear(new Color(101, 156, 239));

            pH.Draw(win);
            //p.Draw(win);

            win.Display();
        }
    }
}
