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
        static Player player;
        public static void Main()
        {
            // Erzeuge ein neues Fenster
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Mein erstes Fenster");

            // Achte darauf, ob Fenster geschlossen wird
            win.Closed += win_Closed;

            initialize();
            // Das eigentliche Spiel
            while (win.IsOpen())
            {
                draw(win);
                update();
                // Schauen ob Fenster geschlossen werden soll
                win.DispatchEvents();
            }
        }

        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            ((RenderWindow)sender).Close();
        }


        public static void initialize()
        {
            player = new Player();
        }

        public static void draw(RenderWindow window)
        {
            window.Clear();
            player.draw(window);
            window.Display();
        }

        public static void update()
        {
            player.move();
        }
    }
}
