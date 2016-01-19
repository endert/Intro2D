using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_11_Beispiel
{
    class Game
    {
        RenderWindow win;
        Sprite BackgroundGrayScale;

        Sprite BackgroundMult;
        Sprite Overlay;
        GameTime t;

        Shader GrayScaleShader;
        RenderStates GrayScaleState;

        RenderTexture MultTexture;
        Shader MultShader;
        RenderStates MultState;
        RenderStates Add;
        
        public Game()
        {
            win = win = new RenderWindow(new SFML.Window.VideoMode(800, 670), "Shader^^");
            win.Closed += (sender, e) => { ((RenderWindow)sender).Close(); };

            BackgroundGrayScale = new Sprite(new Texture("bg.png"));

            BackgroundMult = new Sprite(new Texture("wall.png"));
            Overlay = new Sprite(new Texture("lightMask.png"));
            t = new GameTime();

            GrayScaleShader = new Shader(null, "GrayScale.frag");
            GrayScaleState = new RenderStates(GrayScaleShader);

            MultTexture = new RenderTexture(800, 670);
            MultShader = new Shader(null, "Mult.frag");
            MultState = new RenderStates(MultShader);
            Add = new RenderStates(BlendMode.Add);
        }

        public void Run()
        {
            while (win.IsOpen())
            {
                win.DispatchEvents();
                Update();
                Draw();
            }
        }

        void Update()
        {
            t.Update();

            GrayScaleShader.SetParameter("time", (float)t.TotalTime.TotalSeconds);

            Vector2i Mousepos = Mouse.GetPosition(win);

            Overlay.Position = new Vector2f(Mousepos.X, -Mousepos.Y + BackgroundMult.Texture.Size.Y);
            Overlay.Position -= new Vector2f(Overlay.Texture.Size.X / 2, Overlay.Texture.Size.Y / 2);
        }

        void Draw()
        {
            win.Clear();

            //DrawGrayScale();
            DrawMult();

            win.Display();
        }

        void DrawGrayScale()
        {
            win.Draw(BackgroundGrayScale, GrayScaleState);
        }

        void DrawMult()
        {
            MultTexture.Clear();

            MultTexture.Draw(Overlay, Add);

            MultTexture.Display();

            MultShader.SetParameter("overlay", MultTexture.Texture);

            win.Draw(BackgroundMult, MultState);
        }
    }
}
