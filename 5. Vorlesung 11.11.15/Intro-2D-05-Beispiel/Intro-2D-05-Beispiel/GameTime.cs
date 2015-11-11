using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro_2D_05_Beispiel
{
    class GameTime
    {
        Stopwatch watch;
        public TimeSpan Ellapsed { get; private set; }
        public TimeSpan Total { get; private set; }

        public GameTime()
        {
            watch = new Stopwatch();
            Ellapsed = new TimeSpan();
            Total = new TimeSpan();

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
