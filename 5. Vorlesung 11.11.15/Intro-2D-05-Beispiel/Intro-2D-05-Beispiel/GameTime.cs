using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_2D_05_Beispiel
{
    /// <summary>
    /// class that contains infos about the time
    /// </summary>
    class GameTime
    {
        //the watch for measuring the time
        Stopwatch watch;
        /// <summary>
        /// System.TimeSpan that represents the total Time that is passed since initializing this instanz
        /// </summary>
        public TimeSpan Total { get; private set; }
        /// <summary>
        /// System.TimeSpan that represents the time, that is needed to pass throught the gameloop once
        /// </summary>
        public TimeSpan Ellapsed { get; private set; }

        public GameTime()
        {
            watch = new Stopwatch();
            Total = new TimeSpan();
            Ellapsed = new TimeSpan();

            watch.Start();
        }

        public void Update()
        {
            Ellapsed = watch.Elapsed - Total;
            Total = watch.Elapsed;
        }
    }
}








































//class GameTime
//{
//    Stopwatch watch;
//    public TimeSpan Ellapsed { get; private set; }
//    public TimeSpan Total { get; private set; }

//    public GameTime()
//    {
//        watch = new Stopwatch();
//        Ellapsed = new TimeSpan();
//        Total = new TimeSpan();

//        watch.Start();
//    }

//    public void Update()
//    {
//        Ellapsed = watch.Elapsed - Total;
//        Total = watch.Elapsed;
//    }
//}
