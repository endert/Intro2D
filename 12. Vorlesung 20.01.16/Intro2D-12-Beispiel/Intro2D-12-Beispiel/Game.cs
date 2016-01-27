using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_12_Beispiel
{
    class Game
    {
        RenderWindow win;
        string Path = "Saves/PlayerData.end";
        Player p;

        public Game()
        {
            win = new RenderWindow(new SFML.Window.VideoMode(800, 600), "Load/ Save");
            win.Closed += (sender, e) => { ((RenderWindow)sender).Close(); };

            Load();
        }

        void Load()
        {
            if(File.Exists(Path))
            {
                using(StreamReader reader = new StreamReader(Path))
                {
                    float hp = Convert.ToSingle(reader.ReadLine());

                    p = new Player(hp);
                }
            }
            else
                p = new Player();
        }

        void Save()
        {
            if (!Directory.Exists("Saves"))
                Directory.CreateDirectory("Saves");

            using (StreamWriter writer = new StreamWriter(Path))
            {
                writer.WriteLine(p.Hp);
            }
        }

        public void Run()
        {
            while (win.IsOpen())
            {
                Update();
                Draw();
                
                win.DispatchEvents();
            }
        }

        void Update()
        {
            p.Update();
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
            {
                Save();
                win.Close();
            }
        }

        void Draw()
        {
            win.Clear();
            p.Draw(win);
            win.Display();
        }
    }
}
