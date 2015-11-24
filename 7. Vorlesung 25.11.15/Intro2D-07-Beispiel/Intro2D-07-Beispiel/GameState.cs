using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_07_Beispiel
{
    enum EGameState
    {
        None = -1,

        TitleScreen,
        MainMenu,
        InGame,
        Credits,

        Count
    }

    interface GameState
    {
        void Initialize();
        void LoadContent();
        void Draw(RenderWindow win);
        void Update(GameTime t);
    }
}
