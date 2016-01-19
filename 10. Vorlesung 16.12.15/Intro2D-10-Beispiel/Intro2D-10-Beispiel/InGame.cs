using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;
using SFML.Audio;

namespace Intro2D_10_Beispiel
{
    class InGame : GameState
    {
        //Enemies (attributes, no need to access outside of this class)
        Enemy enemy1;
        Enemy enemy2;

        //properties (need in other classes, for example Enemie needs player and all gObj needs the map
        public static Player Player { get; private set; }
        public static Map map { get; private set; }
        static List<ParticleHandler> pHandler;

        Sound BackgroundMusic;
        public static Sound JumpSound { get; private set; }

        GameTime gTime;

        public static View Camera { get; private set; }

        public void Draw(RenderWindow win)
        {
            win.SetView(Camera);
            map.Draw(win);
            Player.Draw(win);
            enemy1.Draw(win);
            enemy2.Draw(win);

            foreach (ParticleHandler p in pHandler)
                p.Draw(win);
        }

        public void Initialize()
        {
            gTime = new GameTime();
            BackgroundMusic = new Sound(new SoundBuffer("Sound/asia_1.ogg"));
            BackgroundMusic.Loop = true;
            BackgroundMusic.Volume = 30;
            BackgroundMusic.Play();
            pHandler = new List<ParticleHandler>();

            JumpSound = new Sound(new SoundBuffer("Sound/jumpSound.wav"));
            JumpSound.Volume = 100;

            map = new Map(new System.Drawing.Bitmap("Pictures/Map.bmp"));
            Player = new Player(new Vector2f(map.TileSize + 30, map.TileSize + 30));
            enemy1 = new Enemy("Pictures/EnemyGreen.png", new Vector2f(800, 100), "Pictures/EnemyGreenMove.png");
            enemy2 = new Enemy("Pictures/EnemyRed.png", new Vector2f(100, 600), "Pictures/EnemyGreenMove.png");

            Camera = new View(new FloatRect(0, 0, 1200, 1000));
        }

        public void LoadContent()
        {
            
        }

        private Vector2f VectorToMoveView()
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

        public static void SpawnParticles(Vector2f pos)
        {
            pHandler.Add(new ParticleHandler(pos));
        }

        public EGameState Update(GameTime t)
        {
            gTime.Update();
            Player.Update(gTime);
            enemy1.Update(gTime);
            enemy2.Update(gTime);
            Camera.Move(VectorToMoveView());
            for(int i = 0; i<pHandler.Count; ++i)
            {
                if (!pHandler[i].IsAlive)
                {
                    pHandler.RemoveAt(i);
                    i--;
                    continue;
                }
                pHandler[i].Update(t);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                return EGameState.None;

            return EGameState.InGame;
        }
    }
}
