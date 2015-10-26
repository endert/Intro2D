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

        static Player player;
        static Enemy sara;
        static Enemy sara2;

        
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
                draw(win, time);
            }
        }


        public static void initialize()
        {
            player = new Player(new Vector2f(0, 0));

            sara = new Enemy(new Vector2f(250, 0), "Content/EnemyGreen.png");
            sara2 = new Enemy(new Vector2f(250, 100), "Content/EnemyRed.png");
        }
        public static void loadContent()
        {

        }
        public static void update(GameTime time)
        {
            player.move();
            sara.move(player.getPosition(), time);
            sara2.move2(time);

            if (collision(player.getPosition(), (float)player.getWidth(), (float)player.getHeight(), sara.getPosition(), (float)sara.getWidth(), (float)sara.getHeight()))
                Console.Write("Collision!!1elf");
        }
        public static void draw(RenderWindow win, GameTime time)
        {
            Color AcaOrange = new Color(255, 144, 1);
            Color CornflowerBlue = new Color(101, 156, 239);
            win.Clear(CornflowerBlue);

            player.draw(win);
            sara.draw(win);
            sara2.draw(win);

            win.Display();
        }



        public static bool collision(Vector2f obj1, float hObj1, float wObj1, Vector2f obj2, float hObj2, float wObj2)
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




        static void win_Closed(object sender, EventArgs e)
        {
            ((RenderWindow) sender).Close();
        }
    }
}
