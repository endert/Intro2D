using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Intro2D_07_Beispiel
{
    /// <summary>
    /// Example for a TitleScreen
    /// </summary>
    class TitleScreen : GameState
    {
        Sprite Background;

        public void Draw(RenderWindow win)
        {
            win.Draw(Background);
        }

        public void Initialize()
        {
            Background = new Sprite(new Texture("Pictures/TitelScreen.png"));
        }

        public void LoadContent()
        {
        }

        public EGameState Update(GameTime t)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                return EGameState.None;

            return EGameState.TitleScreen;
        }
    }
}
