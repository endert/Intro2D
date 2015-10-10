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
            win.Closed += Win_Closed;

            Initialize();
            // Das eigentliche Spiel
            while (win.IsOpen())
            {
                Draw(win);
                Update();
                // Schauen ob Fenster geschlossen werden soll
                win.DispatchEvents();
            }
        }

        static void Win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            ((RenderWindow)sender).Close();
        }


        public static void Initialize()
        {
            player = new Player();
        }

        public static void Draw(RenderWindow window)
        {
            window.Clear();
            player.Draw(window);
            window.Display();
        }

        public static void Update()
        {
            player.Move();
        }
    }
}
