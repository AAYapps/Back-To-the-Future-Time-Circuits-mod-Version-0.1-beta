using GTA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTF_Time_Travel
{
    class TimeCircuits
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
        private static string fampm = "am", presampm = "pm", pastampm = "am";
        private static bool runonce = false;

        static int tday1, tday2, tmonth1, tmonth2, ty1, ty2, ty3, ty4, th1, th2, tm1, tm2;
        static string tampm = "";
        #endregion

        public static string timeinputstring = "";

        #region Time Curcuits sounds
        static SoundPlayer num0 = new SoundPlayer(Properties.Resources._0);
        static SoundPlayer num1 = new SoundPlayer(Properties.Resources._1);
        static SoundPlayer num2 = new SoundPlayer(Properties.Resources._2);
        static SoundPlayer num3 = new SoundPlayer(Properties.Resources._3);
        static SoundPlayer num4 = new SoundPlayer(Properties.Resources._4);
        static SoundPlayer num5 = new SoundPlayer(Properties.Resources._5);
        static SoundPlayer num6 = new SoundPlayer(Properties.Resources._6);
        static SoundPlayer num7 = new SoundPlayer(Properties.Resources._7);
        static SoundPlayer num8 = new SoundPlayer(Properties.Resources._8);
        static SoundPlayer num9 = new SoundPlayer(Properties.Resources._9);
        static SoundPlayer inputerror = new SoundPlayer(Properties.Resources.input_enter_error);
        static SoundPlayer inputenter = new SoundPlayer(Properties.Resources.input_enter);
        #endregion

        public static void keyset(Keys key)
        {
            switch (key)
            {
                case Keys.NumPad0:
                    num0.Play();
                    timeinputstring += 0 + " ";
                    timeinput(0, datecount);
                    break;
                case Keys.D0:
                    num0.Play();
                    timeinputstring += 0 + " ";
                    timeinput(0, datecount);
                    break;
                case Keys.NumPad1:
                    num1.Play();
                    timeinputstring += 1 + " ";
                    timeinput(1, datecount);
                    break;
                case Keys.D1:
                    num1.Play();
                    timeinputstring += 1 + " ";
                    timeinput(1, datecount);
                    break;
                case Keys.NumPad2:
                    num2.Play();
                    timeinputstring += 2 + " ";
                    timeinput(2, datecount);
                    break;
                case Keys.D2:
                    num2.Play();
                    timeinputstring += 2 + " ";
                    timeinput(2, datecount);
                    break;
                case Keys.NumPad3:
                    num3.Play();
                    timeinputstring += 3 + " ";
                    timeinput(3, datecount);
                    break;
                case Keys.D3:
                    num3.Play();
                    timeinputstring += 3 + " ";
                    timeinput(3, datecount);
                    break;
                case Keys.NumPad4:
                    num4.Play();
                    timeinputstring += 4 + " ";
                    timeinput(4, datecount);
                    break;
                case Keys.D4:
                    num4.Play();
                    timeinputstring += 4 + " ";
                    timeinput(4, datecount);
                    break;
                case Keys.NumPad5:
                    num5.Play();
                    timeinputstring += 5 + " ";
                    timeinput(5, datecount);
                    break;
                case Keys.D5:
                    num5.Play();
                    timeinputstring += 5 + " ";
                    timeinput(5, datecount);
                    break;
                case Keys.NumPad6:
                    num6.Play();
                    timeinputstring += 6 + " ";
                    timeinput(6, datecount);
                    break;
                case Keys.D6:
                    num6.Play();
                    timeinputstring += 6 + " ";
                    timeinput(6, datecount);
                    break;
                case Keys.NumPad7:
                    num7.Play();
                    timeinputstring += 7 + " ";
                    timeinput(7, datecount);
                    break;
                case Keys.D7:
                    num7.Play();
                    timeinputstring += 7 + " ";
                    timeinput(7, datecount);
                    break;
                case Keys.NumPad8:
                    num8.Play();
                    timeinputstring += 8 + " ";
                    timeinput(8, datecount);
                    break;
                case Keys.D8:
                    num8.Play();
                    timeinputstring += 8 + " ";
                    timeinput(8, datecount);
                    break;
                case Keys.NumPad9:
                    num9.Play();
                    timeinputstring += 9 + " ";
                    timeinput(9, datecount);
                    break;
                case Keys.D9:
                    num9.Play();
                    timeinputstring += 9 + " ";
                    timeinput(9, datecount);
                    break;
                case Keys.Enter:
                    timeinputstring = "";
                    if (datecount > 11)
                    {
                        inputenter.Play();
                        Settime(tday1, tday2, tmonth1, tmonth2, ty1, ty2, ty3, ty4, th1, th2, tm1, tm2, tampm);
                        datecount = 0;
                        tday1 = 0;
                        tday2 = 0;
                        tmonth1 = 0;
                        tmonth2 = 0;
                        ty1 = 0;
                        ty2 = 0;
                        ty3 = 0;
                        ty4 = 0;
                        th1 = 0;
                        th2 = 0;
                        tm1 = 0;
                        tm2 = 0;
                        tampm = "am";
                    }
                    else if (datecount < 9)
                    {
                        inputenter.Play();
                        Settime(tday1, tday2, tmonth1, tmonth2, ty1, ty2, ty3, ty4, fh1, fh2, fm1, fm2, fampm);
                        datecount = 0;
                        tday1 = 0;
                        tday2 = 0;
                        tmonth1 = 0;
                        tmonth2 = 0;
                        ty1 = 0;
                        ty2 = 0;
                        ty3 = 0;
                        ty4 = 0;
                        th1 = 0;
                        th2 = 0;
                        tm1 = 0;
                        tm2 = 0;
                        tampm = "am";
                    }
                    else
                    {
                        inputerror.Play();
                    }
                    break;
            }
        }

        static int datecount = 0;
        private static void timeinput(int numpadnumber, int count)
        {
            if (count > 11)
            {
                inputerror.Play();
            }
            else
            {
                switch (count)
                {
                    case 0:
                        if (numpadnumber < 2)
                        {
                            tmonth1 = numpadnumber;
                        }
                        else
                        {
                            inputerror.Play();
                            datecount--;
                        }
                        break;
                    case 1:
                        if (numpadnumber > 0)
                        {
                            if (tmonth1 < 3)
                            {
                                tmonth2 = numpadnumber;
                            }
                            else
                            {
                                inputerror.Play();
                                datecount--;
                            }
                        }
                        else
                        {
                            if (tmonth1 > 0)
                            {
                                tmonth2 = numpadnumber;
                            }
                            else
                            {
                                inputerror.Play();
                                datecount--;
                            }
                        }
                        break;
                    case 2:
                        if (tmonth2 == 2)
                        {
                            if (numpadnumber < 3)
                            {
                                tday1 = numpadnumber;
                            }
                            else
                            {
                                inputerror.Play();
                                datecount--;
                            }
                        }
                        else
                        {
                            if (numpadnumber < 4)
                            {
                                tday1 = numpadnumber;
                            }
                        }
                        break;
                    case 3:
                        if (tday1 < 3)
                        {
                            tday2 = numpadnumber;
                        }
                        else
                        {
                            if (numpadnumber < 2)
                            {
                                if (numpadnumber == 1)
                                {
                                    if (tmonth2 == 1 || tmonth2 == 3 || tmonth2 == 5 || tmonth2 == 7 || tmonth2 == 8 || tmonth2 == 10 || tmonth2 == 12)
                                    {
                                        inputerror.Play();
                                        datecount--;
                                    }
                                    else
                                    {
                                        tday2 = numpadnumber;
                                    }
                                }
                                else
                                {
                                    tday2 = numpadnumber;
                                }
                            }
                            else
                            {
                                inputerror.Play();
                                datecount--;
                            }
                        }
                        break;
                    case 4:
                        ty1 = numpadnumber;
                        break;
                    case 5:
                        ty2 = numpadnumber;
                        break;
                    case 6:
                        ty3 = numpadnumber;
                        break;
                    case 7:
                        ty4 = numpadnumber;
                        break;
                    case 8:
                        if (numpadnumber == 0)
                        {
                            tampm = "am";
                            th1 = numpadnumber;
                        }
                        else if (numpadnumber == 1)
                        {
                            tampm = "am";
                            th1 = numpadnumber;
                        }
                        else if (numpadnumber == 2)
                        {
                            tampm = "pm";
                            th1 = numpadnumber;
                        }
                        else
                        {
                            inputerror.Play();
                            datecount--;
                        }
                        break;
                    case 9:
                        if (th1 == 0)
                        {
                            th2 = numpadnumber;
                        }
                        else if (th1 == 1)
                        {
                            if (numpadnumber < 2)
                            {
                                th2 = numpadnumber;
                            }
                            else if (numpadnumber > 1)
                            {
                                tampm = "pm";
                                th1--;
                                th2 = numpadnumber - 2;
                            }
                        }
                        else if (th1 == 2)
                        {
                            if (numpadnumber < 2)
                            {
                                tampm = "pm";
                                th1 -= 2;
                                th2 = numpadnumber + 8;
                            }
                            else if (numpadnumber == 3)
                            {
                                tampm = "pm";
                                th1--;
                                th2 = numpadnumber - 2;
                            }
                            else
                            {
                                inputerror.Play();
                                datecount--;
                            }
                        }
                        break;
                    case 10:
                        if (numpadnumber < 6)
                        {
                            tm1 = numpadnumber;
                        }
                        else
                        {
                            inputerror.Play();
                            datecount--;
                        }
                        break;
                    case 11:
                        tm2 = numpadnumber;
                        break;
                }
                datecount++;
            }
        }

        public static void Settime(int day1 = 2, int day2 = 9, int month1 = 0, int month2 = 5
            , int y1 = 2, int y2 = 0, int y3 = 1, int y4 = 5, int h1 = 1
            , int h2 = 2, int m1 = 0, int m2 = 9, string ampm = "pm")
        {
            fday1 = day1;
            fday2 = day2;
            fmonth1 = month1;
            fmonth2 = month2;
            fy1 = y1;
            fy2 = y2;
            fy3 = y3;
            fy4 = y4;
            fh1 = h1;
            fh2 = h2;
            fm1 = m1;
            fm2 = m2;
            fampm = ampm;
        }

        public static void resetrunonce()
        {
            runonce = false;
        }

        public static void timetravelentry()
        {
            if (!runonce)
            {
                pastday1 = presday1;
                pastday2 = presday2;
                pastmonth1 = presmonth1;
                pastmonth2 = presmonth2;
                pasty1 = presy1;
                pasty2 = presy2;
                pasty3 = presy3;
                pasty4 = presy4;
                pasth1 = presh1;
                pasth2 = presh2;
                pastm1 = presm1;
                pastm2 = presm2;
                pastampm = presampm;
                presday1 = fday1;
                presday2 = fday2;
                presmonth1 = fmonth1;
                presmonth2 = fmonth2;
                presy1 = fy1;
                presy2 = fy2;
                presy3 = fy3;
                presy4 = fy4;
                presh1 = fh1;
                presh2 = fh2;
                presm1 = fm1;
                presm2 = fm2;
                presampm = fampm;
                runonce = true;
            }
        }

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

        public static string timedisplayfuture()
        {
            string fampmindcator = "'";
            if (fampm == "pm")
            {
                fampmindcator = ".";
            }

            string fmonthname = "";
            if ((fmonth1 * 10) + fmonth2 == 1)
            {
                fmonthname = "JAN";
            }
            else if ((fmonth1 * 10) + fmonth2 == 2)
            {
                fmonthname = "FEB";
            }
            else if ((fmonth1 * 10) + fmonth2 == 3)
            {
                fmonthname = "MAR";
            }
            else if ((fmonth1 * 10) + fmonth2 == 4)
            {
                fmonthname = "APR";
            }
            else if ((fmonth1 * 10) + fmonth2 == 5)
            {
                fmonthname = "MAY";
            }
            else if ((fmonth1 * 10) + fmonth2 == 6)
            {
                fmonthname = "JUN";
            }
            else if ((fmonth1 * 10) + fmonth2 == 7)
            {
                fmonthname = "JUL";
            }
            else if ((fmonth1 * 10) + fmonth2 == 8)
            {
                fmonthname = "AUG";
            }
            else if ((fmonth1 * 10) + fmonth2 == 9)
            {
                fmonthname = "SEP";
            }
            else if ((fmonth1 * 10) + fmonth2 == 10)
            {
                fmonthname = "OCT";
            }
            else if ((fmonth1 * 10) + fmonth2 == 11)
            {
                fmonthname = "NOV";
            }
            else if ((fmonth1 * 10) + fmonth2 == 12)
            {
                fmonthname = "DEC";
            }

            if (fh1 == 0 && fh2 == 0)
            {
                return (fmonthname.PadLeft(5) + " " + (fday1.ToString()
                    + fday2.ToString()).PadRight(3) + (fy1.ToString() + fy2.ToString() + fy3.ToString()
                    + fy4.ToString()).PadLeft(5) + fampmindcator + ((fh1 + 1).ToString() + (fh2 + 2).ToString()
                    + ":" + fm1.ToString() + fm2.ToString()).PadRight(6));
            }
            else
            {
                return (fmonthname.PadLeft(5) + " " + (fday1.ToString()
                    + fday2.ToString()).PadRight(3) + (fy1.ToString() + fy2.ToString() + fy3.ToString()
                    + fy4.ToString()).PadLeft(5) + fampmindcator + (fh1.ToString() + fh2.ToString()
                    + ":" + fm1.ToString() + fm2.ToString()).PadRight(6));
            }
        }

        public static string timedisplaypresent()
        {
            string minutestring = "";

            int presmin = World.CurrentDayTime.Minutes;
            if (presmin < 10)
            {
                presm1 = 0;
                presm2 = presmin;
                minutestring = "0" + presmin;
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
                    presm1 = 1;
                    presm2 = presmin - 10;
                }
                else if (presmin < 40)
                {
                    presm1 = 1;
                    presm2 = presmin - 10;
                }
                else if (presmin < 50)
                {
                    presm1 = 1;
                    presm2 = presmin - 10;
                }
                minutestring = presmin.ToString();
            }

            string presampmindcator = "'";

            int hour = World.CurrentDayTime.Hours;
            string hours;
            if (hour < 10 && hour > 0)
            {
                presh1 = 0;
                presh2 = hour;
                hours = "0" + hour;
            }
            else if (hour == 0)
            {
                presh1 = 1;
                presh2 = 2;
                hours = "12";
            }
            else
            {
                if (hour > 12)
                {
                    if (hour < 22)
                    {
                        presh1 = 0;
                        presh2 = (hour - 12);
                        hours = "0" + (hour - 12);
                        presampmindcator = ".";
                    }
                    else
                    {
                        presh1 = 1;
                        presh2 = hour - 10;
                        hours = (hour - 12).ToString();
                        presampmindcator = ".";
                    }
                }
                else
                {
                    presh1 = 1;
                    presh2 = hour - 10;
                    hours = hour.ToString();
                }
            }
            string presyear;
            presyear = presy1.ToString() + presy2 + presy3 + presy4;

            string presmonthname;

                presmonthname = "";
                if ((presmonth1 * 10) + presmonth2 == 1)
                {
                    presmonthname = "JAN";
                }
                else if ((presmonth1 * 10) + presmonth2 == 2)
                {
                    presmonthname = "FEB";
                }
                else if ((presmonth1 * 10) + presmonth2 == 3)
                {
                    presmonthname = "MAR";
                }
                else if ((presmonth1 * 10) + presmonth2 == 4)
                {
                    presmonthname = "APR";
                }
                else if ((presmonth1 * 10) + presmonth2 == 5)
                {
                    presmonthname = "MAY";
                }
                else if ((presmonth1 * 10) + presmonth2 == 6)
                {
                    presmonthname = "JUN";
                }
                else if ((presmonth1 * 10) + presmonth2 == 7)
                {
                    presmonthname = "JUL";
                }
                else if ((presmonth1 * 10) + presmonth2 == 8)
                {
                    presmonthname = "AUG";
                }
                else if ((presmonth1 * 10) + presmonth2 == 9)
                {
                    presmonthname = "SEP";
                }
                else if ((presmonth1 * 10) + presmonth2 == 10)
                {
                    presmonthname = "OCT";
                }
                else if ((presmonth1 * 10) + presmonth2 == 11)
                {
                    presmonthname = "NOV";
                }
                else if ((presmonth1 * 10) + presmonth2 == 12)
                {
                    presmonthname = "DEC";
                }

            return (presmonthname.ToString().PadLeft(5) + " " + (presday1.ToString()
                + presday2.ToString()).PadRight(3) + " " + presyear.PadLeft(5) + presampmindcator + (hours
                + ":" + minutestring).PadRight(6));
        }

        public static string timedisplaypast()
        {
            string pastampmindcator = "'";
            if (pastampm == "pm")
            {
                pastampmindcator = ".";
            }

            string pastmonthname = "";
            if ((pastmonth1 * 10) + pastmonth2 == 1)
            {
                pastmonthname = "JAN";
            }
            else if ((pastmonth1 * 10) + pastmonth2 == 2)
            {
                pastmonthname = "FEB";
            }
            else if ((pastmonth1 * 10) + pastmonth2 == 3)
            {
                pastmonthname = "MAR";
            }
            else if ((pastmonth1 * 10) + pastmonth2 == 4)
            {
                pastmonthname = "APR";
            }
            else if ((pastmonth1 * 10) + pastmonth2 == 5)
            {
                pastmonthname = "MAY";
            }
            else if ((pastmonth1 * 10) + pastmonth2 == 6)
            {
                pastmonthname = "JUN";
            }
            else if ((pastmonth1 * 10) + pastmonth2 == 7)
            {
                pastmonthname = "JUL";
            }
            else if ((pastmonth1 * 10) + pastmonth2 == 8)
            {
                pastmonthname = "AUG";
            }
            else if ((pastmonth1 * 10) + pastmonth2 == 9)
            {
                pastmonthname = "SEP";
            }
            else if ((pastmonth1 * 10) + pastmonth2 == 10)
            {
                pastmonthname = "OCT";
            }
            else if ((pastmonth1 * 10) + pastmonth2 == 11)
            {
                pastmonthname = "NOV";
            }
            else if ((pastmonth1 * 10) + pastmonth2 == 12)
            {
                pastmonthname = "DEC";
            }

            if (pasth1 == 0 && pasth2 == 0)
            {
                return (pastmonthname.PadLeft(5) + " " + (pastday1.ToString()
                + pastday2.ToString()).PadRight(3) + " " + (pasty1.ToString() + pasty2.ToString() + pasty3.ToString()
                + pasty4.ToString()).PadLeft(5) + pastampmindcator + ((pasth1 + 1).ToString() + (pasth2 + 2).ToString()
                + ":" + pastm1.ToString() + pastm2.ToString()).PadRight(6));
            }
            else
            {
                return (pastmonthname.PadLeft(5) + " " + (pastday1.ToString()
                    + pastday2.ToString()).PadRight(3) + " " + (pasty1.ToString() + pasty2.ToString() + pasty3.ToString()
                    + pasty4.ToString()).PadLeft(5) + pastampmindcator + (pasth1.ToString() + pasth2.ToString()
                    + ":" + pastm1.ToString() + pastm2.ToString()).PadRight(6));
            }
        }
    }
}
