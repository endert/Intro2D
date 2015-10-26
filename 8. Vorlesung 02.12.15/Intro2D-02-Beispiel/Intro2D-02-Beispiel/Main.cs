using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;

namespace Intro2D_02_Beispiel
{
    class Game
    {
        static RenderWindow win;
        static GameTime time;

        
        public static void Main()
        {

            win = new RenderWindow(new VideoMode(800, 600), "Mein zweites Fenster");
            time = new GameTime();
            time.start();
            win.Closed += win_Closed;

            initialize();
            loadContent();

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

        }
        public static void loadContent()
        {

        }
        public static void update(GameTime time)
        {

        }
        public static void draw(RenderWindow win)
        {
            Color AcaOrange = new Color(255, 144, 1);
            Color CornflowerBlue = new Color(101, 156, 239);
            win.Clear(CornflowerBlue);

            win.Display();
        }


        static void win_Closed(object sender, EventArgs e)
        {
            ((RenderWindow) sender).Close();
        }
    }
}
