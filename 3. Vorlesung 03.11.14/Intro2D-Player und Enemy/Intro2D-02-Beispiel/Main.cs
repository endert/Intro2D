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
        public static void Main()
        {
            // Erzeuge ein neues Fenster
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Mein erstes Fenster");

            // Achte darauf, ob Fenster geschlossen wird
            win.Closed += win_Closed;

            initialize();
            loadContent();

            // Das eigentliche Spiel
            while (win.IsOpen())
            {
                // Schauen ob Fenster geschlossen werden soll
                win.DispatchEvents();

                update();
                draw(win);
            }
        }

        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            ((RenderWindow)sender).Close();
        }

        static Player player;
        static Enemy tobi, tobi2;


        static void initialize()
        {
            player = new Player();
            tobi = new Enemy(new Vector2f(400f, 300f), "Pictures/Enemy.png");
            tobi2 = new Enemy(new Vector2f(100f, 200f), "Pictures/EnemyGreen.png");
        }

        static void loadContent()
        {

        }

        static void update()
        {
            player.move();
            tobi.move(player.playerPosition);
            tobi2.move(player.playerPosition);
        }

        static void draw(RenderWindow win)
        {
            win.Clear(new Color(0,0,255));
            player.draw(win);
            tobi.draw(win);
            tobi2.draw(win);
            win.Display();
        }
    }
}
