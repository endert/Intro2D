using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_10_Beispiel
{
    /// <summary>
    /// names of the existing GameStates
    /// </summary>
    enum EGameState
    {
        None = -1,

        TitleScreen,
        MainMenu,
        InGame,
        Credits,

        Count
    }

    /// <summary>
    /// the methods of every gamestate
    /// </summary>
    interface GameState
    {
        /// <summary>
        /// Initialize the content
        /// </summary>
        void Initialize();
        /// <summary>
        /// loads all needed stuff for the initialize
        /// </summary>
        void LoadContent();
        /// <summary>
        /// draws the content
        /// </summary>
        /// <param name="win"></param>
        void Draw(RenderWindow win);
        /// <summary>
        /// updates the content
        /// </summary>
        /// <param name="t">the next GameState</param>
        /// <returns></returns>
        EGameState Update(GameTime t);
    }
}
