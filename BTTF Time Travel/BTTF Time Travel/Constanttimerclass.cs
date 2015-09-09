using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BTTF_Time_Travel
{
    class Constanttimerclass
    {
        static public void startthread()
        {
            counttimer.Start();
        }

        static Thread counttimer = new Thread(new ThreadStart(Counttimer_Tick));

        static int delay = 0;
        static bool runonce = false;
        static bool start = false;
        static bool pause = false;
        static public void Start()
        {
            if (!runonce)
            {
                start = true;
                delay = 0;
                runonce = true;
                delay++;
            }
        }

        static public void Pause()
        {
            pause = true;
        }

        static public void Resume()
        {
            pause = false;
        }

        static public void Reset()
        {
            delay = 0;
        }

        private static void Counttimer_Tick()
        {
            do
            {
                if (start)
                {
                    if (!pause)
                    {
                        delay++;
                        Thread.Sleep(1000);
                    }
                }
            } while (true);
        }

        static public int getdelay()
        {
            return delay;
        }

        static public void Stop()
        {
            delay++;
            start = false;
            runonce = false;
        }

    }
}
