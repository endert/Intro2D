using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_2D_05_Beispiel
{
    class Program
    {
        //Enemies (attributes, no need to access outside of this class)
        static Enemy enemy1;
        static Enemy enemy2;

        //properties (need in other classes, for example Enemie needs player and all gObj needs the map
        public static Player Player { get; private set; }
        public static Map map { get; private set; }

        static GameTime gTime;

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
            gTime = new GameTime();
            map = new Map(new System.Drawing.Bitmap("Pictures/Map.bmp"));
            Player = new Player(new Vector2f(map.TileSize + 30,map.TileSize + 30));
            enemy1 = new Enemy("Pictures/EnemyGreen.png", new Vector2f(800, 100), "Pictures/EnemyGreenMove.png");
            enemy2 = new Enemy("Pictures/EnemyRed.png", new Vector2f(100, 600), "Pictures/EnemyGreenMove.png");
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
            gTime.Update();
            Player.Update(gTime);
            enemy1.Update(gTime);
            enemy2.Update(gTime);
        }
    }
}
