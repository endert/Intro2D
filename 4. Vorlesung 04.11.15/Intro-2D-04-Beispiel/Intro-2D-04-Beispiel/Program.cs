using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_2D_04_Beispiel
{
    class Program
    {
        //declare Players and Enemies
        public static Player Player { get; private set; }
        static Enemy enemy1;
        static Enemy enemy2;
        public static Map map { get; private set; }

        static void Main(string[] args)
        {
            RenderWindow win = new RenderWindow(new VideoMode(1200, 1000), "Intro2D-04-Beispiel-Player-Enemy");
            win.Closed += (sender, e) => { ((RenderWindow)sender).Close(); };

            Initialize();

            while (win.IsOpen())
            {
                Update();
                Draw(win);
                win.DispatchEvents();
            } 
        }

        /// <summary>
        /// initialize Player and Enemies, by calling the constructors
        /// </summary>
        public static void Initialize()
        {
            map = new Map(new System.Drawing.Bitmap("Pictures/Map.bmp"));
            Player = new Player(new Vector2f(map.TileSize + 30,map.TileSize + 30));
            enemy1 = new Enemy("Pictures/EnemyGreen.png", new Vector2f(900, 100));
            enemy2 = new Enemy("Pictures/EnemyRed.png", new Vector2f(100, 600));
        }

        /// <summary>
        /// clear the window
        /// <para>draws all gameobjects in the window</para>
        /// <para>displays all drawn objects</para>
        /// </summary>
        static void Draw(RenderWindow window)
        {
            window.Clear(new Color(50, 120, 190));

            map.Draw(window);
            Player.Draw(window);
            enemy1.Draw(window);
            enemy2.Draw(window);

            window.Display();
        }

        /// <summary>
        /// updates all Gameobjects
        /// </summary>
        static void Update()
        {
            Player.Update();
            enemy1.Update();
            enemy2.Update();
        }
    }
}
