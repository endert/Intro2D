using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_10_Beispiel
{
    class Game
    {
        public static Vector2u WindowSize { get; private set; }
        //the window
        RenderWindow win;
        //variables to check if we need to change the gamestate
        EGameState prev = EGameState.None, curr = EGameState.TitleScreen;
        //the gamestate we are in
        GameState state;
        //the gametime
        GameTime gTime;

        public Game()
        {
            uint x = 85;
            win = new RenderWindow(new VideoMode(16*x, 9*x), "Intro2D-04-Beispiel-Player-Enemy");
            WindowSize = win.Size;
            win.Closed += (sender, e) => { ((RenderWindow)sender).Close(); };
            gTime = new GameTime();
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

        /// <summary>
        /// should be called when curr != prev
        /// </summary>
        void HandleGameState()
        {
            switch (curr)
            {
                case EGameState.None:
                    win.Close();
                    break;
                case EGameState.TitleScreen:
                    state = new TitleScreen();
                    state.LoadContent();
                    state.Initialize();
                    break;
                case EGameState.InGame:
                    state = new InGame();
                    state.LoadContent();
                    state.Initialize();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// checks if the gamestate changed and updates the state
        /// </summary>
        void Update()
        {
            if(prev != curr)
            {
                HandleGameState();
                prev = curr;
            }

            curr = state.Update(gTime);
        }

        /// <summary>
        /// clears the window, draws the content of the window then display it
        /// </summary>
        void Draw()
        {
            win.Clear(new Color(50, 120, 190));

            state.Draw(win);

            win.Display();
        }
    }
}
