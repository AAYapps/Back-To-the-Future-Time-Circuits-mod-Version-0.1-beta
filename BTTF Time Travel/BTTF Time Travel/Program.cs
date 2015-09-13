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
        // 1724, 3314, 40 this is to the possion of delorean
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
        }

        System.Speech.Synthesis.SpeechSynthesizer Timeteller = new System.Speech.Synthesis.SpeechSynthesizer();

        bool runonce = false;
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
            else if (e.KeyCode == Keys.F12)
            {
                if (!runonce)
                {
                    if (Game.Player.Character.IsInVehicle())
                    {
                        if (engine.enginestarted)
                        {
                            Variableclass.engineoff.Play();
                            engine.enginestarted = false;
                            engine.audioplayed = false;
                        }
                        else if (!engine.enginestarted)
                        {
                            engine.startsounddelay = true;
                            engine.audioplayed = false;
                        }
                    }
                    runonce = true;
                }
            }
        }

        bool testprop = false;
        bool manual = false;
        bool spawned = false;
        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (!external_display)
            {
                if (e.KeyCode == Keys.N)
                {
                    external_display = true;
                }
                else if (e.KeyCode == Keys.Y)
                {
                    external_display = true;
                    external_show = true;
                }
            }
            else
            {
                if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
                {
                    Deloreonfunctions.toggletimesurcuitsswitch();
                    Deloreonfunctions2.toggletimesurcuitsswitch();
                }
                else if (e.KeyCode == Keys.F11)
                {
                    if (Variableclass.invicible)
                    {
                       Variableclass.Deloreon.IsInvincible = false;
                        Variableclass.Deloreon.CanBeVisiblyDamaged = true;
                        Variableclass.invicible = false;
                        UI.Notify("Is no longer invicible");
                    }
                    else
                    {
                        Variableclass.invicible = true;
                        Variableclass.Deloreon.IsInvincible = true;
                        Variableclass.Deloreon.CanBeVisiblyDamaged = false;
                        UI.Notify("Is invicible");
                    }
                }
                else if (e.KeyCode == Keys.N)
                {
                    Deloreonfunctions.RetreiveDeloreon();
                    Deloreonfunctions2.RetreiveDeloreon();
                }
                else if (e.KeyCode == Keys.K)
                {
                    startingscene.Start();
                }
                else if (e.KeyCode == Keys.T)
                {
                    Deloreonfunctions.ToggleRCmode();
                }
                else if (e.KeyCode == Keys.H)
                {
                    if (!spawned)
                    {
                        Deloreonfunctions.CreateDeloreon();
                        spawned = true;
                    }
                    else if (spawned)
                    {
                        spawned = false;
                        Deloreonfunctions.RemoveDelorean();
                    }
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
                else if (e.KeyCode == Keys.Space)
                {
                    //testprop = !testprop;
                }
                else if (e.KeyCode == Keys.Multiply)
                {
                    ExperimentScene.possiondisplay = !ExperimentScene.possiondisplay;
                }
                else if (e.KeyCode == Keys.F12)
                {
                    if (engine.stalled == true)
                    {
                        if (engine.starts == true)
                        {
                            engine.crank = false;
                            engine.audioplayed2 = false;
                            engine.audioplayed = false;
                        }
                        else
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.engine_off);
                            player.Play();
                            player.Stop();
                            engine.audioplayed2 = false;
                            engine.audioplayed = false;
                            engine.crank = false;
                        }
                    }
                    runonce = false;
                }
                else if (e.KeyCode == Keys.Divide)
                {
                    if (manual)
                    {
                        Constanttimerclass.Stop();
                        Constanttimerclass.Reset();
                        manual = false;
                    }
                    else
                    {
                        Constanttimerclass.Start();
                        manual = true;
                    }
                }


                if (Variableclass.toggletimecurcuits)
                {
                    if (Game.Player.Character.CurrentVehicle == Variableclass.Deloreon)
                    {
                        TimeCircuits.keyset(e.KeyCode);
                    }
                }
            }
        }

        string text = "";
        bool entered = false;
        bool external_display = false;
        bool external_show = false;

        private void onTick(object sender, EventArgs e)
        {
            try
            {
                if (testprop)
                {
                    if (entered)
                    {
                        var model = new Model(text);
                        model.Request(250);

                        // Check the model is valid
                        if (model.IsInCdImage && model.IsValid)
                        {
                            // Ensure the model is loaded before we try to create it in the world
                            while (!model.IsLoaded) Script.Wait(50);

                            // Create the prop in the world
                            World.CreateProp(model, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 5, 0)), true, true);
                        }
                        
                        // Mark the model as no longer needed to remove it from memory.
                        model.MarkAsNoLongerNeeded();
                    }
                }

                if (!external_display)
                {
                    UIText Instruct = new UIText("Do you want to show exteral time circuits view? Y, N", new Point(200, 200), (float)0.9);
                    Instruct.Draw();
                    if (external_show)
                    {
                        counttimer.Start();
                        external_show = false;
                    }
                }
                engine.tickEvent();
                ExperimentScene.tick();
                startingscene.scene(Game.Player.Character.Model);
                Deloreonfunctions.Check();
                Deloreonfunctions2.Check();
                outsideDeloreon.Checkifout();
                outsideDeloreon.Checkifout2();
                if (Time_reentry.below84)
                {
                    Time_reentry.Tick();
                }
            }
            catch(Exception d)
            {
                UIText debug2 = new UIText("Error: " + d.Message, new Point(400, 300), (float)0.6);
                debug2.Draw();
            }
        }

    }
}
