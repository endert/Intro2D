using SFML.Graphics;
using SFML.Window;
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_06_Beispiel
{
    class Program
    {
        //Enemies (attributes, no need to access outside of this class)
        static Enemy enemy1;
        static Enemy enemy2;

        //properties (need in other classes, for example Enemie needs player and all gObj needs the map
        public static Player Player { get; private set; }
        public static Map map { get; private set; }

        static Sound BackgroundMusic;
        public static Sound JumpSound { get; private set; }

        static GameTime gTime;

        public static View Camera { get; private set; }

        static void Main(string[] args)
        {
            RenderWindow win = new RenderWindow(new VideoMode(1200, 1000), "Intro2D-06-Beispiel-Player-Enemy");
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
            BackgroundMusic = new Sound(new SoundBuffer("Sound/asia_1.ogg"));
            BackgroundMusic.Loop = true;
            BackgroundMusic.Volume = 30;
            BackgroundMusic.Play();

            JumpSound = new Sound(new SoundBuffer("Sound/jumpSound.wav"));
            JumpSound.Volume = 100;

            map = new Map(new System.Drawing.Bitmap("Pictures/Map.bmp"));
            Player = new Player(new Vector2f(map.TileSize + 30, map.TileSize + 30));
            enemy1 = new Enemy("Pictures/EnemyGreen.png", new Vector2f(800, 100), "Pictures/EnemyGreenMove.png");
            enemy2 = new Enemy("Pictures/EnemyRed.png", new Vector2f(100, 600), "Pictures/EnemyGreenMove.png");

            Camera = new View(new FloatRect(0, 0, 1200, 1000));
        }

        /// <summary>
        /// clear the window
        /// <para>draws all gameobjects in the window</para>
        /// <para>displays all drawn objects</para>
        /// </summary>
        static void Draw(RenderWindow window)
        {
            window.Clear(new Color(50, 120, 190));
            window.SetView(Camera);
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
            Camera.Move(VectorToMoveView());
        }

        static private Vector2f VectorToMoveView()
        {
            Vector2f res = Player.Position + Player.Size / 2 - Camera.Center;
            
            //View don't move over map edge
            //*****************************
            if (Camera.Center.X + res.X < Camera.Size.X / 2)
                res.X = 0;
            if (Camera.Center.Y + res.Y < Camera.Size.Y / 2)
                res.Y = 0;
            if (Camera.Center.X + res.X + Camera.Size.X / 2 > 60 * map.TileSize)
                res.X = 0;
            if (Camera.Center.Y + res.Y + Camera.Size.Y / 2 > 40 * map.TileSize)
                res.Y = 0;
            //*****************************


            return res;
        }



















        //private static Vector2f VectorForViewMove()
        //{
        //    float XMove = (Player.Position.X + (Player.Size.X / 2)) - VIEW.Center.X;
        //    float YMove = (Player.Position.Y + (Player.Size.Y / 2)) - VIEW.Center.Y;

        //    //view cannot go over the map edge
        //    if (VIEW.Center.X + XMove < VIEW.Size.X / 2)
        //        XMove = 0;
        //    if (VIEW.Center.Y + YMove < VIEW.Size.Y / 2)
        //        YMove = 0;
        //    if (VIEW.Center.X + YMove + (VIEW.Size.X / 2) > 60 * map.TileSize)
        //        XMove = 0;
        //    if (VIEW.Center.Y + YMove + (VIEW.Size.Y / 2) > 40 * map.TileSize)
        //        YMove = 0;
        //    //*********************************

        //    return new Vector2f(XMove, YMove);
        //}
    }
}
