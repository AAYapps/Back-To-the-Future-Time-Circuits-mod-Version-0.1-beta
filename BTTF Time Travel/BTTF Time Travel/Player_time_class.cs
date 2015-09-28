using GTA;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTF_Time_Travel
{
    class Player_time_class
    {
        #region Time Curcuits variables
        public static int fday1 = 2, fday2 = 9, fmonth1 = 0, fmonth2 = 5
            , fy1 = 2, fy2 = 0, fy3 = 1, fy4 = 5, fh1 = 1
            , fh2 = 0, fm1 = 0, fm2 = 9, presday1 = 1, presday2 = 0
            , presmonth1 = 0, presmonth2 = 9, presy1 = 1, presy2 = 9
            , presy3 = 9, presy4 = 5, presh1 = 0, presh2 = 6
            , presm1 = 1, presm2 = 1, pastday1 = 3, pastday2 = 0
            , pastmonth1 = 1, pastmonth2 = 0, pasty1 = 1, pasty2 = 9
            , pasty3 = 9, pasty4 = 5, pasth1 = 1, pasth2 = 2, pastm1 = 4, pastm2 = 6;
        public static string fampm = "am", presampm = "pm", pastampm = "am";
        #endregion

        public static int getday()
        {
            return (presday1 * 10) + presday2;
        }

        public static int getmonth()
        {
            return (presmonth1 * 10) + presmonth2;
        }

        public static int getyear()
        {
            return (presy1 * 1000) + (presy2 * 100) + (presy3 * 10) + presy4;
        }

        public static int gethour()
        {
            if (presampm == "am")
            {
                return ((presh1 * 10) + presh2);
            }
            else
            {
                return ((presh1 * 10) + presh2) + 12;
            }
        }

        public static int getminute()
        {
            return (presm1 * 10) + presm2;
        }

        public static void timetick()
        {
            int hour = World.CurrentDayTime.Hours;
            if (hour == 0)
            {
                presh1 = 1;
                presh2 = 2;
            }
            else if (hour == 1)
            {
                presh1 = 0;
                presh2 = 1;
            }
            else if (hour == 2)
            {
                presh1 = 0;
                presh2 = 2;
            }
            else if (hour == 3)
            {
                presh1 = 0;
                presh2 = 3;
            }
            else if (hour == 4)
            {
                presh1 = 0;
                presh2 = 4;
            }
            else if (hour == 5)
            {
                presh1 = 0;
                presh2 = 5;
            }
            else if (hour == 6)
            {
                presh1 = 0;
                presh2 = 6;
            }
            else if (hour == 7)
            {
                presh1 = 0;
                presh2 = 7;
            }
            else if (hour == 8)
            {
                presh1 = 0;
                presh2 = 8;
            }
            else if (hour == 9)
            {
                presh1 = 0;
                presh2 = 9;
            }
            else if (hour == 10)
            {
                presh1 = 1;
                presh2 = 0;
            }
            else if (hour == 11)
            {
                presh1 = 1;
                presh2 = 1;
            }
            else if (hour == 12)
            {
                presh1 = 1;
                presh2 = 2;
            }
            else if (hour == 13)
            {
                presh1 = 0;
                presh2 = 1;
            }
            else if (hour == 14)
            {
                presh1 = 0;
                presh2 = 2;
            }
            else if (hour == 15)
            {
                presh1 = 0;
                presh2 = 3;
            }
            else if (hour == 16)
            {
                presh1 = 0;
                presh2 = 4;
            }
            else if (hour == 17)
            {
                presh1 = 0;
                presh2 = 5;
            }
            else if (hour == 18)
            {
                presh1 = 0;
                presh2 = 6;
            }
            else if (hour == 19)
            {
                presh1 = 0;
                presh2 = 7;
            }
            else if (hour == 20)
            {
                presh1 = 0;
                presh2 = 8;
            }
            else if (hour == 21)
            {
                presh1 = 0;
                presh2 = 9;
            }
            else if (hour == 22)
            {
                presh1 = 1;
                presh2 = 0;
            }
            else if (hour == 23)
            {
                presh1 = 1;
                presh2 = 1;
            }

            int presmin = World.CurrentDayTime.Minutes;
            if (presmin < 10)
            {
                presm1 = 0;
                presm2 = presmin;
            }
            else
            {
                if (presmin < 20)
                {
                    presm1 = 1;
                    presm2 = presmin - 10;
                }
                else if (presmin < 30)
                {
                    presm1 = 2;
                    presm2 = presmin - 20;
                }
                else if (presmin < 40)
                {
                    presm1 = 3;
                    presm2 = presmin - 30;
                }
                else if (presmin < 50)
                {
                    presm1 = 4;
                    presm2 = presmin - 40;
                }
                else if (presmin < 60)
                {
                    presm1 = 5;
                    presm2 = presmin - 50;
                }
            }
        }
    }
}
