using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_07_Beispiel
{
    class Game
    {
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
            win = new RenderWindow(new VideoMode(1200, 1000), "Intro2D-04-Beispiel-Player-Enemy");
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
