using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace Intro2D_10_Beispiel
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
            Background.Scale = new Vector2f((float)Game.WindowSize.X / (float)Background.Texture.Size.X, (float)Game.WindowSize.Y / (float)Background.Texture.Size.Y);
        }

        public void LoadContent()
        {
        }

        public EGameState Update(GameTime t)
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
                return EGameState.None;

            for(int i = 0; i<(int)Keyboard.Key.KeyCount; ++i)
            {
                if (Keyboard.IsKeyPressed((Keyboard.Key)i))
                {
                    return EGameState.InGame;
                }
            }

            return EGameState.TitleScreen;
        }
    }
}
