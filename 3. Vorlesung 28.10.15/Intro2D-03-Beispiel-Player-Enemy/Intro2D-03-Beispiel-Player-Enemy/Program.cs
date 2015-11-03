//wenn ihr Probleme mit englischen Kommentaren habt, dann beschwert euch in der nächsten Vorlesung, bei eurem Englisch Lehrer.

using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_03_Beispiel_Player_Enemy
{
    class Program
    {
        //declare Players and Enemies
        static Player player;
        static Enemy enemy1;
        static Enemy enemy2;

        static void Main(string[] args)
        {
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Intro2D-03-Beispiel-Player-Enemy");
            win.Closed += (sender, e) => { ((RenderWindow)sender).Close(); };

            //initialize Player and Enemies, by calling the constructors
            player = new Player();
            enemy1 = new Enemy("Pictures/EnemyGreen.png", new Vector2f(900,100));
            enemy2 = new Enemy("Pictures/EnemyRed.png", new Vector2f(100,600) );

            while (win.IsOpen())
            {
                Update();
                Draw(win);
                win.DispatchEvents();
            } 
        }

        /// <summary>
        /// clear the window
        /// <para>draws all gameobjects in the window</para>
        /// <para>displays all drawn objects</para>
        /// </summary>
        static void Draw(RenderWindow window)
        {
            window.Clear(new Color(50, 120, 190));

            player.Draw(window);
            enemy1.Draw(window);
            enemy2.Draw(window);

            window.Display();
        }

        /// <summary>
        /// updates all Gameobjects
        /// </summary>
        static void Update()
        {
            player.Move();
            enemy1.Move(player.GetPosition());
            enemy2.Move(player.GetPosition());
        }
    }
}
