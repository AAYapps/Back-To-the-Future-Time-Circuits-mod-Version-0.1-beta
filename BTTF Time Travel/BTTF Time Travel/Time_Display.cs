using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTF_Time_Travel
{
    public partial class Time_Display : Form
    {
        public Time_Display()
        {
            InitializeComponent();
        }

        void displayoff()
        {
            futuremonth.BackgroundImage = null;
            futureday1.BackgroundImage = null;
            futureday2.BackgroundImage = null;
            futureyear1.BackgroundImage = null;
            futureyear2.BackgroundImage = null;
            futureyear3.BackgroundImage = null;
            futureyear4.BackgroundImage = null;
            futurehour1.BackgroundImage = null;
            futurehour2.BackgroundImage = null;
            futuremin1.BackgroundImage = null;
            futuremin2.BackgroundImage = null;
            presmonth.BackgroundImage = null;
            presday1.BackgroundImage = null;
            presday2.BackgroundImage = null;
            presyear1.BackgroundImage = null;
            presyear2.BackgroundImage = null;
            presyear3.BackgroundImage = null;
            presyear4.BackgroundImage = null;
            preshour1.BackgroundImage = null;
            preshour2.BackgroundImage = null;
            presmin1.BackgroundImage = null;
            presmin2.BackgroundImage = null;
            pastmonth.BackgroundImage = null;
            pastday1.BackgroundImage = null;
            pastday2.BackgroundImage = null;
            pastyear1.BackgroundImage = null;
            pastyear2.BackgroundImage = null;
            pastyear3.BackgroundImage = null;
            pastyear4.BackgroundImage = null;
            pasthour1.BackgroundImage = null;
            pasthour2.BackgroundImage = null;
            pastmin1.BackgroundImage = null;
            pastmin2.BackgroundImage = null;
        }

        enum time
        {
            Future,
            Present,
            Past
        }

        void displaymonth(int month, PictureBox monthdisplay, time display)
        {
            switch(month)
            {
                case 1:
                    if (display == time.Future)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_10;
                    }
                    else if(display == time.Present)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_10;
                    }
                    else if (display == time.Past)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_10;
                    }
                    break;
                case 2:
                    if (display == time.Future)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_11;
                    }
                    else if (display == time.Present)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_11;
                    }
                    else if (display == time.Past)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_11;
                    }
                    break;
                case 3:
                    if (display == time.Future)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_12;
                    }
                    else if (display == time.Present)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_12;
                    }
                    else if (display == time.Past)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_12;
                    }
                    break;
                case 4:
                    if (display == time.Future)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_13;
                    }
                    else if (display == time.Present)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_13;
                    }
                    else if (display == time.Past)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_13;
                    }
                    break;
                case 5:
                    if (display == time.Future)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_14;
                    }
                    else if (display == time.Present)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_14;
                    }
                    else if (display == time.Past)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_14;
                    }
                    break;
                case 6:
                    if (display == time.Future)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_15;
                    }
                    else if (display == time.Present)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_15;
                    }
                    else if (display == time.Past)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_15;
                    }
                    break;
                case 7:
                    if (display == time.Future)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_16;
                    }
                    else if (display == time.Present)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_16;
                    }
                    else if (display == time.Past)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_16;
                    }
                    break;
                case 8:
                    if (display == time.Future)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_17;
                    }
                    else if (display == time.Present)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_17;
                    }
                    else if (display == time.Past)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_17;
                    }
                    break;
                case 9:
                    if (display == time.Future)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_18;
                    }
                    else if (display == time.Present)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_18;
                    }
                    else if (display == time.Past)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_18;
                    }
                    break;
                case 10:
                    if (display == time.Future)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_19;
                    }
                    else if (display == time.Present)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_19;
                    }
                    else if (display == time.Past)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_19;
                    }
                    break;
                case 11:
                    if (display == time.Future)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_20;
                    }
                    else if (display == time.Present)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_20;
                    }
                    else if (display == time.Past)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_20;
                    }
                    break;
                case 12:
                    if (display == time.Future)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_21;
                    }
                    else if (display == time.Present)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_21;
                    }
                    else if (display == time.Past)
                    {
                        monthdisplay.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_21;
                    }
                    break;
            }
        }

        void displaymunber(int number1, int number2, PictureBox display1, PictureBox display2, time display)
        {
            switch(number1)
            {
                case 0:
                    if (display == time.Future)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_0;
                    }
                    else if (display == time.Present)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_0;
                    }
                    else if (display == time.Past)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_0;
                    }
                    break;
                case 1:
                    if (display == time.Future)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_1;
                    }
                    else if (display == time.Present)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_1;
                    }
                    else if (display == time.Past)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_1;
                    }
                    break;
                case 2:
                    if (display == time.Future)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_2;
                    }
                    else if (display == time.Present)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_2;
                    }
                    else if (display == time.Past)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_2;
                    }
                    break;
                case 3:
                    if (display == time.Future)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_3;
                    }
                    else if (display == time.Present)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_3;
                    }
                    else if (display == time.Past)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_3;
                    }
                    break;
                case 4:
                    if (display == time.Future)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_4;
                    }
                    else if (display == time.Present)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_4;
                    }
                    else if (display == time.Past)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_4;
                    }
                    break;
                case 5:
                    if (display == time.Future)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_5;
                    }
                    else if (display == time.Present)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_5;
                    }
                    else if (display == time.Past)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_5;
                    }
                    break;
                case 6:
                    if (display == time.Future)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_6;
                    }
                    else if (display == time.Present)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_6;
                    }
                    else if (display == time.Past)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_6;
                    }
                    break;
                case 7:
                    if (display == time.Future)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_7;
                    }
                    else if (display == time.Present)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_7;
                    }
                    else if (display == time.Past)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_7;
                    }
                    break;
                case 8:
                    if (display == time.Future)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_8;
                    }
                    else if (display == time.Present)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_8;
                    }
                    else if (display == time.Past)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_8;
                    }
                    break;
                case 9:
                    if (display == time.Future)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_9;
                    }
                    else if (display == time.Present)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_9;
                    }
                    else if (display == time.Past)
                    {
                        display1.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_9;
                    }
                    break;
            }

            switch (number2)
            {
                case 0:
                    if (display == time.Future)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_0;
                    }
                    else if (display == time.Present)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_0;
                    }
                    else if (display == time.Past)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_0;
                    }
                    break;
                case 1:
                    if (display == time.Future)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_1;
                    }
                    else if (display == time.Present)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_1;
                    }
                    else if (display == time.Past)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_1;
                    }
                    break;
                case 2:
                    if (display == time.Future)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_2;
                    }
                    else if (display == time.Present)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_2;
                    }
                    else if (display == time.Past)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_2;
                    }
                    break;
                case 3:
                    if (display == time.Future)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_3;
                    }
                    else if (display == time.Present)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_3;
                    }
                    else if (display == time.Past)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_3;
                    }
                    break;
                case 4:
                    if (display == time.Future)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_4;
                    }
                    else if (display == time.Present)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_4;
                    }
                    else if (display == time.Past)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_4;
                    }
                    break;
                case 5:
                    if (display == time.Future)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_5;
                    }
                    else if (display == time.Present)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_5;
                    }
                    else if (display == time.Past)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_5;
                    }
                    break;
                case 6:
                    if (display == time.Future)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_6;
                    }
                    else if (display == time.Present)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_6;
                    }
                    else if (display == time.Past)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_6;
                    }
                    break;
                case 7:
                    if (display == time.Future)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_7;
                    }
                    else if (display == time.Present)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_7;
                    }
                    else if (display == time.Past)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_7;
                    }
                    break;
                case 8:
                    if (display == time.Future)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_8;
                    }
                    else if (display == time.Present)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_8;
                    }
                    else if (display == time.Past)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_8;
                    }
                    break;
                case 9:
                    if (display == time.Future)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.red_9;
                    }
                    else if (display == time.Present)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.green_9;
                    }
                    else if (display == time.Past)
                    {
                        display2.BackgroundImage = BTTF_Time_Travel.Properties.Resources.amber_9;
                    }
                    break;
            }
        }

        public void Time_Tick_1(object sender, EventArgs e)
        {
            if (this.Text == "off")
            {
                displayoff();
            }
            else if (this.Text == "on")
            {
                displaymonth((TimeCircuits.fmonth1 * 10) + TimeCircuits.fmonth2, futuremonth, time.Future);
                displaymunber(TimeCircuits.fday1, TimeCircuits.fday2, futureday1, futureday2, time.Future);
                displaymunber(TimeCircuits.fy1, TimeCircuits.fy2, futureyear1, futureyear2, time.Future);
                displaymunber(TimeCircuits.fy3, TimeCircuits.fy4, futureyear3, futureyear4, time.Future);
                if (TimeCircuits.fh1 == 0 && TimeCircuits.fh2 == 0)
                {
                    displaymunber(1, 2, futurehour1, futurehour2, time.Future);
                }
                else
                {
                    displaymunber(TimeCircuits.fh1, TimeCircuits.fh2, futurehour1, futurehour2, time.Future);
                }
                displaymunber(TimeCircuits.fm1, TimeCircuits.fm2, futuremin1, futuremin2, time.Future);

                displaymonth((TimeCircuits.presmonth1 * 10) + TimeCircuits.presmonth2, presmonth, time.Present);
                displaymunber(TimeCircuits.presday1, TimeCircuits.presday2, presday1, presday2, time.Present);
                displaymunber(TimeCircuits.presy1, TimeCircuits.presy2, presyear1, presyear2, time.Present);
                displaymunber(TimeCircuits.presy3, TimeCircuits.presy4, presyear3, presyear4, time.Present);
                if (TimeCircuits.fh1 == 0 && TimeCircuits.fh2 == 0)
                {
                    displaymunber(1, 2, preshour1, preshour2, time.Present);
                }
                else
                {
                    displaymunber(TimeCircuits.presh1, TimeCircuits.presh2, preshour1, preshour2, time.Present);
                }
                displaymunber(TimeCircuits.presm1, TimeCircuits.presm2, presmin1, presmin2, time.Present);

                displaymonth((TimeCircuits.pastmonth1 * 10) + TimeCircuits.pastmonth2, pastmonth, time.Past);
                displaymunber(TimeCircuits.pastday1, TimeCircuits.pastday2, pastday1, pastday2, time.Past);
                displaymunber(TimeCircuits.pasty1, TimeCircuits.pasty2, pastyear1, pastyear2, time.Past);
                displaymunber(TimeCircuits.pasty3, TimeCircuits.pasty4, pastyear3, pastyear4, time.Past);
                if (TimeCircuits.fh1 == 0 && TimeCircuits.fh2 == 0)
                {
                    displaymunber(1, 2, pasthour1, pasthour2, time.Past);
                }
                else
                {
                    displaymunber(TimeCircuits.pasth1, TimeCircuits.pasth2, pasthour1, pasthour2, time.Past);
                }

                displaymunber(TimeCircuits.pastm1, TimeCircuits.pastm2, pastmin1, pastmin2, time.Past);
            }
        }

        private void Time_Display_Load(object sender, EventArgs e)
        {
            var primaryDisplay = Screen.AllScreens.ElementAtOrDefault(0);
            var extendedDisplay = Screen.AllScreens.FirstOrDefault(s => s != primaryDisplay) ?? primaryDisplay;

            this.Left = extendedDisplay.WorkingArea.Left + (extendedDisplay.Bounds.Size.Width / 2) - (this.Size.Width / 2);
            this.Top = extendedDisplay.WorkingArea.Top + (extendedDisplay.Bounds.Size.Height / 2) - (this.Size.Height / 2);
        }
    }
}
