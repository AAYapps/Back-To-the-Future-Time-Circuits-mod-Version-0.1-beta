using GTA;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;

namespace BTTF_Time_Travel
{
    class Constanttimerclass
    {

        double delay = 0;
        bool runonce = false;
        bool start = false;
        bool pause = false;
        public void Start()
        {
            if (!runonce)
            {
                start = true;
                delay = 0;
                runonce = true;
                delay++;
            }
        }

        public void Pause()
        {
            pause = true;
        }

        public void Resume()
        {
            pause = false;
        }

        public void Reset()
        {
            delay = 0;
        }

        double temptick = 0;

        public double getdelay()
        {

            int tick = World.CurrentDayTime.Seconds;
            //tick
            if (tick != temptick)
            {
                if (start)
                {
                    if (!pause)
                    {
                        delay += 0.045;
                    }
                }
                temptick = tick;
            }
            return delay;
        }

        public void Stop()
        {
            start = false;
            runonce = false;
        }

    }
}
