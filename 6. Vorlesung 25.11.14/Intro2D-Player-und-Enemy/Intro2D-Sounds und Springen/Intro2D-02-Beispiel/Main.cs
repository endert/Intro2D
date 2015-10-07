using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;

namespace Intro2D_02_Beispiel
{
    class Game
    {
        public static void Main()
        {
            // Erzeuge ein neues Fenster
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Mein erstes Fenster");

            GameTime time = new GameTime();
            // Achte darauf, ob Fenster geschlossen wird
            win.Closed += win_Closed;

            initialize();
            loadContent();

            //pandasOnTheRun.Play();
            //pandasOnTheRun.Loop = true;

            time.start();

            // Das eigentliche Spiel
            while (win.IsOpen())
            {
                // Schauen ob Fenster geschlossen werden soll
                win.DispatchEvents();
                time.update();

                update(time);
                draw(win, time);
            }
            time.stop();
        }

        static void win_Closed(object sender, EventArgs e)
        {
            // Fenster Schließen
            ((RenderWindow)sender).Close();
        }

        static Player player;
        static Enemy tobi, tobi2;
        static Map map;
        //static Music pandasOnTheRun;


        static void initialize()
        {
            //pandasOnTheRun = new Music("yourOwnPath");
            player = new Player();
            tobi = new Enemy(new Vector2f(400f, 300f), "Pictures/Enemy.png","Pictures/EnemyGreenMove.png");
            tobi2 = new Enemy(new Vector2f(100f, 200f), "Pictures/EnemyGreen.png", "Pictures/EnemyGreenMove.png");
            map = new Map();

        }

        static void loadContent()
        {

        }

        static void update(GameTime time)
        {
            player.move(map, time);
            tobi.move(player.getPosition(),time);
            tobi2.move2(time);

            if (collision(player.getPosition(), player.getHeight(), player.getWidth(), tobi.getPosition(), tobi.getHeight(), tobi.getWidth()))
                Console.WriteLine("collision!!111");


        }

        static void draw(RenderWindow win, GameTime time)
        {

            win.Clear(new Color(0, 0, 255));
            map.draw(win);
            player.draw(win);
            tobi.draw(win, time);
            tobi2.draw(win, time);
            win.Display();
        }

        static bool collision(Vector2f obj1, float hObj1, float wObj1, Vector2f obj2, float hObj2, float wObj2)
        {
            Vector2f Mobj1 = new Vector2f(obj1.X + wObj1 / 2, obj1.Y + hObj1 / 2);
            Vector2f Mobj2 = new Vector2f(obj2.X + wObj2 / 2, obj2.Y + hObj2 / 2);

            float rx1 = wObj1 / 2;
            float rx2 = wObj2 / 2;

            float ry1 = hObj1 / 2;
            float ry2 = hObj2 / 2;

            float dx = Math.Abs(Mobj1.X - Mobj2.X);
            float dy = Math.Abs(Mobj1.Y - Mobj2.Y);

            if (dx < rx1 + rx2 && dy < ry1 + ry2)
                return true;

            else
                return false;
        }
    }

}
