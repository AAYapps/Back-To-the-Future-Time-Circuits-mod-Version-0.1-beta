using System;
using System.Windows.Forms;
using GTA;
using System.Media;
using GTA.Native;
using GTA.Math;
using System.Drawing;
using System.IO;
using System.Threading;

namespace BTTF_Time_Travel
{
    class TimeTravel : Script
    {
        static Thread counttimer = new Thread(new ThreadStart(Counttimer_Tick));

        private static void Counttimer_Tick()
        {
            Form display = new Time_Display();
            display.Show();
            do
            {
                if (Variableclass.toggletimecurcuits)
                {
                    display.Text = "on";
                    display.Tag = "true";
                }
                else
                {
                    display.Text = "off";
                    display.Tag = "false";
                }
                Application.DoEvents();
            } while (true);
        }

        public TimeTravel()
        {
            Constanttimerclass.startthread();
            Interval = 8;
            Tick += onTick;
            KeyUp += onKeyUp;
            KeyDown += onKeyDown;
            counttimer.Start();
        }

        System.Speech.Synthesis.SpeechSynthesizer Timeteller = new System.Speech.Synthesis.SpeechSynthesizer();

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.U)
            {
                Deloreonfunctions.Flighthight(1);
                Deloreonfunctions2.Flighthight(1);
            }
            else if (e.KeyCode == Keys.J)
            {
                Deloreonfunctions.Flighthight(-1);
                Deloreonfunctions2.Flighthight(-1);
            }
        }

        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
            {
                Deloreonfunctions.toggletimesurcuitsswitch();
                Deloreonfunctions2.toggletimesurcuitsswitch();
            }
            else if (e.KeyCode == Keys.N)
            {
                Deloreonfunctions.RetreiveDeloreon();
                Deloreonfunctions2.RetreiveDeloreon();
            }
            else if(e.KeyCode == Keys.K)
            {
                startingscene.Start();
            }
            else if (e.KeyCode == Keys.T)
            {
                Deloreonfunctions.ToggleRCmode();
            }
            else if (e.KeyCode == Keys.H)
            {
                Deloreonfunctions.CreateDeloreon();
            }
            else if (e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemMinus)
            {
                Deloreonfunctions.ToggleMrfusion();
                Deloreonfunctions2.ToggleMrfusion();
            }
            else if (e.KeyCode == Keys.L)
            {
                Deloreonfunctions.Toggleflight();
                Deloreonfunctions2.Toggleflight();
            }
            else if (e.KeyCode == Keys.B)
            {
                DeloreonStealer.Start();
            }

            if (Variableclass.toggletimecurcuits)
            {
                if (Game.Player.Character.CurrentVehicle == Variableclass.Deloreon)
                {
                    TimeCircuits.keyset(e.KeyCode);
                }
            }
        }

        private void onTick(object sender, EventArgs e)
        {
            try
            {
                ExperimentScene.tick();
                startingscene.scene(Game.Player.Character.Model);
                Deloreonfunctions.Check();
                Deloreonfunctions2.Check();
                outsideDeloreon.Checkifout();
                outsideDeloreon.Checkifout2();
            }
            catch(Exception d)
            {
                UIText debug2 = new UIText("Error: " + d.Message, new Point(400, 300), (float)0.6);
                debug2.Draw();
            }
        }

    }
}
