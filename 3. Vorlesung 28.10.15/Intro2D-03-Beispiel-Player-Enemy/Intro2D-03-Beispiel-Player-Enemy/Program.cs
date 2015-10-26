using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_03_Beispiel_Player_Enemy
{
    //ToDo: write classes for Player and Enemy

    class Program
    {
        //ToDo: Declare Player and two Enemies

        static void Main(string[] args)
        {
            RenderWindow win = new RenderWindow(new VideoMode(800, 600), "Intro2D-03-Beispiel-Player-Enemy");
            win.Closed += (sender, e) => { ((RenderWindow)sender).Close(); };

            //ToDo: Initialize Player and Enemies

            while (win.IsOpen())
            {
                Update();
                Draw(win);
                win.DispatchEvents();
            } 
        }

        static void Draw(RenderWindow window)
        {
            window.Clear(new Color(50, 120, 190));

            //ToDo: Draw Player and Enemies

            window.Display();
        }

        static void Update()
        {
            //ToDo: Update Player and Enemies
        }
    }
}
