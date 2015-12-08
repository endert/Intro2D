using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;


namespace Intro2D_Particles
{
    class Game
    {

        static RenderWindow win;
        static GameTime time;
        private static ParticleHandler handler;


        public static Vector2u WINDOW_SIZE = new Vector2u(1336, 768);


        public static void Main()
        {

            win = new RenderWindow(new VideoMode(WINDOW_SIZE.X, WINDOW_SIZE.Y), "Huch, wo komme ich denn her?");
            time = new GameTime();
            time.start();
            win.Closed += win_Closed;


            win.SetVerticalSyncEnabled(true);
            win.SetFramerateLimit(60);

            //Call First :)
            loadContent();
            initialize();


            while (win.IsOpen())
            {
                win.DispatchEvents();
                time.update();
                update(time);
                draw(win);
            }
        }


        public static void initialize()
        {
            handler = new ParticleHandler(10);
        }
        public static void loadContent()
        {
            ParticleHandler.loadContent();
        }
        public static void update(GameTime time)
        {
            handler.update(time);
        }
        public static void draw(RenderWindow win)
        {
            //AcaOrange new Color(255, 144, 1)
            //Cornflower blue new Color(101, 156, 239)
            win.Clear(new Color(101, 156, 239));

            handler.draw(win);

            

            win.Display();
        }


        static void win_Closed(object sender, EventArgs e)
        {
            ((RenderWindow) sender).Close();
        }
    }
}
