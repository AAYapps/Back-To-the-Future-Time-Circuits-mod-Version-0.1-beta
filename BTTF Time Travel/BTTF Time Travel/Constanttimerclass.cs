using GTA;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;

namespace BTTF_Time_Travel
{
    class Constanttimerclass
    {
        public string show_debug()
        {
            UIText debug2 = new UIText("delay: " + delay + " " + DateTime.Now.Millisecond, new Point(400, 300), (float)0.6);
            debug2.Draw();
            return debug2.Caption;
        }


        double delay = 0;
        bool runonce = false;
        bool start = false;
        bool pause = false;
        public void Start()
        {
            if (!runonce)
            {
                start = true;
                runonce = true;
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
            Variableclass.write_in_log("delay reset");
            delay = 0;
        }

        bool half_time = false;

        public void Delay_changer(double delayint)
        {
            //tick
            if ((DateTime.Now.Millisecond > 0 && DateTime.Now.Millisecond < 100) || (DateTime.Now.Millisecond > 400 && DateTime.Now.Millisecond < 500) || (DateTime.Now.Millisecond > 700 && DateTime.Now.Millisecond < 800))
            {
                if (start)
                {
                    if (!pause)
                    {
                        if (!half_time)
                        {
                            delay += delayint;
                            half_time = true;
                        }
                    }
                }
            }
            else
            {
                half_time = false;
            }
        }

        public void Delay_changer()
        {

            //tick
            if ((DateTime.Now.Millisecond > 0 && DateTime.Now.Millisecond < 100) || (DateTime.Now.Millisecond > 400 && DateTime.Now.Millisecond < 500) || (DateTime.Now.Millisecond > 700 && DateTime.Now.Millisecond < 800))
            {
                if (start)
                {
                    if (!pause)
                    {
                        if (!half_time)
                        {
                            delay += .5;
                            half_time = true;
                        }
                    }
                }
            }
            else
            {
                half_time = false;
            }
        }

        public bool running()
        {
            return start;
        }

        public double getdelay()
        {
            return delay;
        }

        public void Stop()
        {
            Variableclass.write_in_log("delay end");
            start = false;
            runonce = false;
        }
    }
}
