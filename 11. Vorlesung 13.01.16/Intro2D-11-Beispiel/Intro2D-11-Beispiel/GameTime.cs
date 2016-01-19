using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Intro2D_11_Beispiel
{
    public sealed class GameTime
    {
        private Stopwatch watch;

        public TimeSpan TotalTime { get; private set; }
        public TimeSpan ElapsedTime { get; private set; }

        public GameTime()
        {
            watch = new Stopwatch();
            TotalTime = TimeSpan.FromSeconds(0);
            ElapsedTime = TimeSpan.FromSeconds(0);

            watch.Start();
        }

        public void Update()
        {
            ElapsedTime = watch.Elapsed - TotalTime;
            TotalTime = watch.Elapsed;
        }

    }
}
