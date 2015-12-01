using SFML.Graphics;
using SFML.Window;
using SFML.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_07_Beispiel
{
    class Program
    {
        static void Main(string[] args)
        {
            //initialize a new a game and run it
            Game g = new Game();
            //the whole game loop from the programm
            g.Run();
        }
    }
}
