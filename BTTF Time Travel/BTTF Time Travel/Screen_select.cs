using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTF_Time_Travel
{
    class Screen_select
    {
        public static void showOnMonitor(int showOnMonitor, Form form, bool windowless)
        {
            Screen[] sc;
            sc = Screen.AllScreens;

            form.Left = (sc[showOnMonitor].Bounds.Width / 2) - (form.Width / 2);
            form.Top = (sc[showOnMonitor].Bounds.Height / 2) - (form.Height / 2);
            form.StartPosition = FormStartPosition.Manual;

            if (windowless)
            {
                form.FormBorderStyle = FormBorderStyle.None;
            }

        }
    }
}
