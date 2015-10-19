using System;
using System.Windows.Forms;
using GTA;
using System.Media;
using GTA.Native;
using GTA.Math;
using System.Drawing;
using System.IO;
using System.Threading;
using NativeUI;
using System.Collections.Generic;
using System.Reflection;

namespace BTTF_Time_Travel
{
    class TimeTravel : Script
    {
        #region variables
        Constanttimerclass timesetting = new Constanttimerclass();

        #endregion

        // 1724, 3314, 40 this is to the possion of delorean for tutorial mode

        public TimeTravel()
        {
            Interval = 8;
            Tick += onTick;
            KeyUp += onKeyUp;
            KeyDown += onKeyDown;
            loadscriptsettings();
            Game.Player.CanControlCharacter = true;
        }

        System.Speech.Synthesis.SpeechSynthesizer Timeteller = new System.Speech.Synthesis.SpeechSynthesizer();

        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (menu)
            {
                if (e.KeyCode == Keys.W)
                {
                    if (menuitem < 1)
                    {
                        menuitem = 4;
                    }
                    else
                    {
                        menuitem--;
                    }
                }
                else if (e.KeyCode == Keys.S)
                {
                    if (menuitem > 3)
                    {
                        menuitem = 0;
                    }
                    else
                    {
                        menuitem++;
                    }
                }
            }
            else
            {
                if (e.KeyCode == Keys.U)
                {
                    Function.Call(Hash.SET_VEHICLE_EXTRA, 1, 1);
                }
                else if (e.KeyCode == Keys.J)
                {
                    Function.Call(Hash.SET_VEHICLE_EXTRA, 1, 0);
                }
            }
        }

        /*
                            Ped playerPed = Game.Player.Character;

                    Function.Call(Hash.REQUEST_NAMED_PTFX_ASSET, "scr_family4");
                    Function.Call(Hash._SET_PTFX_ASSET_NEXT_CALL, "scr_family4");
                    Function.Call<bool>(Hash.START_PARTICLE_FX_NON_LOOPED_AT_COORD, "scr_fam4_trailer_sparks", playerPed.Position.X, playerPed.Position.Y + 1, playerPed.Position.Z, 3, 0, 0, 2, false, false, false);
        */

        public void ItemSelectHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            UI.Notify("You have selected: ~b~" + selectedItem.Text);
        }

        void loadscriptsettings()
        {
            if (File.Exists(Application.StartupPath + "\\scripts\\BTTF Time Travel.ini"))
            {
                int counter = 0;
                string line;

                // Read the file and display it line by line.
                System.IO.StreamReader file =
                   new System.IO.StreamReader(Application.StartupPath + "\\scripts\\BTTF Time Travel.ini");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("Time_circuit_display: "))
                    {

                    }
                    else if (line.Contains("invincibility: "))
                    {

                    }


                    counter++;
                }

                file.Close();
            }
            else
            {
                // Write the string to a file.
                System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\scripts\\BTTF Time Travel.ini");
                file.WriteLine("Time_circuit_display: 1");
                file.WriteLine("");
                file.WriteLine("invincibility: true");

                file.Close();
            }

            if (File.Exists(Application.StartupPath + "\\scripts\\Time_circuits_info.ini"))
            {
                int counter = 0;
                string line;

                bool future = false;
                bool present = false;
                bool past = false;

                // Read the file and display it line by line.
                System.IO.StreamReader file =
                   new System.IO.StreamReader(Application.StartupPath + "\\scripts\\Time_circuits_info.ini");
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Contains("Future:"))
                    {
                        future = true;
                        present = false;
                        past = false;
                    }
                    else if (line.Contains("Present:"))
                    {
                        future = false;
                        present = true;
                        past = false;
                    }
                    else if (line.Contains("Past:"))
                    {
                        future = false;
                        present = false;
                        past = true;
                    }

                    #region future
                    if (future)
                    {
                        if (line.Contains("month1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.fmonth1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.fmonth1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.fmonth1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.fmonth1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.fmonth1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.fmonth1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.fmonth1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.fmonth1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.fmonth1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.fmonth1 = 9;
                            }
                        }
                        else if (line.Contains("month2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.fmonth2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.fmonth2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.fmonth2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.fmonth2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.fmonth2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.fmonth2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.fmonth2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.fmonth2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.fmonth2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.fmonth2 = 9;
                            }
                        }
                        else if (line.Contains("day1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.fday1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.fday1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.fday1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.fday1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.fday1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.fday1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.fday1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.fday1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.fday1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.fday1 = 9;
                            }
                        }
                        else if (line.Contains("day2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.fday2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.fday2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.fday2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.fday2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.fday2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.fday2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.fday2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.fday2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.fday2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.fday2 = 9;
                            }
                        }
                        else if (line.Contains("year1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.fy1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.fy1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.fy1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.fy1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.fy1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.fy1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.fy1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.fy1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.fy1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.fy1 = 9;
                            }
                        }
                        else if (line.Contains("year2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.fy2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.fy2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.fy2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.fy2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.fy2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.fy2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.fy2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.fy2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.fy2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.fy2 = 9;
                            }
                        }
                        else if (line.Contains("year3 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.fy3 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.fy3 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.fy3 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.fy3 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.fy3 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.fy3 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.fy3 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.fy3 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.fy3 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.fy3 = 9;
                            }
                        }
                        else if (line.Contains("year4 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.fy4 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.fy4 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.fy4 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.fy4 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.fy4 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.fy4 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.fy4 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.fy4 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.fy4 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.fy4 = 9;
                            }
                        }
                        else if (line.Contains("hour1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.fh1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.fh1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.fh1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.fh1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.fh1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.fh1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.fh1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.fh1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.fh1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.fh1 = 9;
                            }
                        }
                        else if (line.Contains("hour2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.fh2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.fh2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.fh2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.fh2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.fh2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.fh2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.fh2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.fh2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.fh2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.fh2 = 9;
                            }
                        }
                        else if (line.Contains("min1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.fm1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.fm1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.fm1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.fm1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.fm1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.fm1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.fm1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.fm1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.fm1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.fm1 = 9;
                            }
                        }
                        else if (line.Contains("min2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.fm2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.fm2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.fm2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.fm2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.fm2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.fm2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.fm2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.fm2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.fm2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.fm2 = 9;
                            }
                        }
                        else if (line.Contains("ampm = "))
                        {
                            if (line.Contains("am"))
                            {
                                Player_time_class.fampm = "am";
                            }
                            else if (line.Contains("pm"))
                            {
                                Player_time_class.fampm = "pm";
                            }
                        }
                    }
                    #endregion

                    #region present
                    if (present)
                    {
                        if (line.Contains("month1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.presmonth1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.presmonth1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.presmonth1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.presmonth1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.presmonth1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.presmonth1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.presmonth1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.presmonth1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.presmonth1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.presmonth1 = 9;
                            }
                        }
                        else if (line.Contains("month2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.presmonth2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.presmonth2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.presmonth2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.presmonth2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.presmonth2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.presmonth2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.presmonth2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.presmonth2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.presmonth2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.presmonth2 = 9;
                            }
                        }
                        else if (line.Contains("day1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.presday1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.presday1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.presday1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.presday1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.presday1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.presday1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.presday1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.presday1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.presday1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.presday1 = 9;
                            }
                        }
                        else if (line.Contains("day2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.presday2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.presday2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.presday2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.presday2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.presday2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.presday2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.presday2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.presday2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.presday2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.presday2 = 9;
                            }
                        }
                        else if (line.Contains("year1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.presy1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.presy1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.presy1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.presy1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.presy1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.presy1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.presy1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.presy1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.presy1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.presy1 = 9;
                            }
                        }
                        else if (line.Contains("year2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.presy2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.presy2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.presy2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.presy2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.presy2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.presy2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.presy2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.presy2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.presy2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.presy2 = 9;
                            }
                        }
                        else if (line.Contains("year3 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.presy3 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.presy3 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.presy3 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.presy3 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.presy3 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.presy3 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.presy3 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.presy3 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.presy3 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.presy3 = 9;
                            }
                        }
                        else if (line.Contains("year4 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.presy4 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.presy4 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.presy4 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.presy4 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.presy4 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.presy4 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.presy4 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.presy4 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.presy4 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.presy4 = 9;
                            }
                        }
                        else if (line.Contains("hour1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.presh1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.presh1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.presh1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.presh1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.presh1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.presh1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.presh1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.presh1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.presh1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.presh1 = 9;
                            }
                        }
                        else if (line.Contains("hour2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.presh2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.presh2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.presh2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.presh2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.presh2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.presh2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.presh2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.presh2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.presh2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.presh2 = 9;
                            }
                        }
                        else if (line.Contains("min1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.presm1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.presm1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.presm1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.presm1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.presm1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.presm1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.presm1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.presm1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.presm1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.presm1 = 9;
                            }
                        }
                        else if (line.Contains("min2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.presm2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.presm2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.presm2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.presm2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.presm2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.presm2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.presm2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.presm2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.presm2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.presm2 = 9;
                            }
                        }
                        else if (line.Contains("ampm = "))
                        {
                            if (line.Contains("am"))
                            {
                                Player_time_class.presampm = "am";
                            }
                            else if (line.Contains("pm"))
                            {
                                Player_time_class.presampm = "pm";
                            }
                        }
                    }
                    #endregion

                    Function.Call(Hash.SET_RANDOM_WEATHER_TYPE);
                    Function.Call(Hash.SET_CLOCK_DATE, Player_time_class.getmonth(), Player_time_class.getday(), Player_time_class.getyear());
                    Function.Call(Hash.SET_CLOCK_TIME, Player_time_class.gethour(), Player_time_class.getminute(), 0);

                    #region past
                    if (past)
                    {
                        if (line.Contains("month1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.pastmonth1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.pastmonth1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.pastmonth1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.pastmonth1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.pastmonth1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.pastmonth1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.pastmonth1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.pastmonth1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.pastmonth1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.pastmonth1 = 9;
                            }
                        }
                        else if (line.Contains("month2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.pastmonth2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.pastmonth2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.pastmonth2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.pastmonth2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.pastmonth2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.pastmonth2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.pastmonth2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.pastmonth2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.pastmonth2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.pastmonth2 = 9;
                            }
                        }
                        else if (line.Contains("day1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.pastday1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.pastday1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.pastday1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.pastday1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.pastday1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.pastday1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.pastday1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.pastday1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.pastday1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.pastday1 = 9;
                            }
                        }
                        else if (line.Contains("day2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.pastday2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.pastday2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.pastday2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.pastday2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.pastday2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.pastday2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.pastday2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.pastday2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.pastday2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.pastday2 = 9;
                            }
                        }
                        else if (line.Contains("year1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.pasty1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.pasty1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.pasty1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.pasty1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.pasty1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.pasty1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.pasty1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.pasty1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.pasty1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.pasty1 = 9;
                            }
                        }
                        else if (line.Contains("year2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.pasty2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.pasty2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.pasty2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.pasty2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.pasty2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.pasty2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.pasty2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.pasty2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.pasty2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.pasty2 = 9;
                            }
                        }
                        else if (line.Contains("year3 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.pasty3 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.pasty3 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.pasty3 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.pasty3 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.pasty3 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.pasty3 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.pasty3 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.pasty3 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.pasty3 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.pasty3 = 9;
                            }
                        }
                        else if (line.Contains("year4 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.pasty4 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.pasty4 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.pasty4 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.pasty4 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.pasty4 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.pasty4 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.pasty4 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.pasty4 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.pasty4 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.pasty4 = 9;
                            }
                        }
                        else if (line.Contains("hour1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.pasth1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.pasth1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.pasth1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.pasth1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.pasth1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.pasth1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.pasth1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.pasth1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.pasth1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.pasth1 = 9;
                            }
                        }
                        else if (line.Contains("hour2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.pasth2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.pasth2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.pasth2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.pasth2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.pasth2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.pasth2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.pasth2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.pasth2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.pasth2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.pasth2 = 9;
                            }
                        }
                        else if (line.Contains("min1 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.pastm1 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.pastm1 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.pastm1 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.pastm1 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.pastm1 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.pastm1 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.pastm1 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.pastm1 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.pastm1 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.pastm1 = 9;
                            }
                        }
                        else if (line.Contains("min2 = "))
                        {
                            if (line.Contains("0"))
                            {
                                Player_time_class.pastm2 = 0;
                            }
                            else if (line.Contains("1"))
                            {
                                Player_time_class.pastm2 = 1;
                            }
                            else if (line.Contains("2"))
                            {
                                Player_time_class.pastm2 = 2;
                            }
                            else if (line.Contains("3"))
                            {
                                Player_time_class.pastm2 = 3;
                            }
                            else if (line.Contains("4"))
                            {
                                Player_time_class.pastm2 = 4;
                            }
                            else if (line.Contains("5"))
                            {
                                Player_time_class.pastm2 = 5;
                            }
                            else if (line.Contains("6"))
                            {
                                Player_time_class.pastm2 = 6;
                            }
                            else if (line.Contains("7"))
                            {
                                Player_time_class.pastm2 = 7;
                            }
                            else if (line.Contains("8"))
                            {
                                Player_time_class.pastm2 = 8;
                            }
                            else if (line.Contains("9"))
                            {
                                Player_time_class.pastm2 = 9;
                            }
                        }
                        else if (line.Contains("ampm = "))
                        {
                            if (line.Contains("am"))
                            {
                                Player_time_class.pastampm = "am";
                            }
                            else if (line.Contains("pm"))
                            {
                                Player_time_class.pastampm = "pm";
                            }
                        }
                    }
                    #endregion

                    counter++;
                }

                file.Close();
            }
            else
            {
                File.WriteAllText(Application.StartupPath + "\\scripts\\Time_circuits_info.ini", string.Empty);
                // Compose a string that consists of three lines.

                // Write the string to a file.
                System.IO.StreamWriter file = new System.IO.StreamWriter(Application.StartupPath + "\\scripts\\Time_circuits_info.ini");

                file.WriteLine("Future:");
                file.WriteLine("month1 = " + Player_time_class.fmonth1);
                file.WriteLine("month2 = " + Player_time_class.fmonth2);
                file.WriteLine("day1 = " + Player_time_class.fday1);
                file.WriteLine("day2 = " + Player_time_class.fday2);
                file.WriteLine("year1 = " + Player_time_class.fy1);
                file.WriteLine("year2 = " + Player_time_class.fy2);
                file.WriteLine("year3 = " + Player_time_class.fy3);
                file.WriteLine("year4 = " + Player_time_class.fy4);
                file.WriteLine("hour1 = " + Player_time_class.fh1);
                file.WriteLine("hour2 = " + Player_time_class.fh2);
                file.WriteLine("min1 = " + Player_time_class.fm1);
                file.WriteLine("min2 = " + Player_time_class.fm2);
                file.WriteLine("ampm = " + Player_time_class.fampm);
                file.WriteLine("Present:");
                file.WriteLine("\nmonth1 = " + Player_time_class.presmonth1);
                file.WriteLine("\nmonth2 = " + Player_time_class.presmonth2);
                file.WriteLine("\nday1 = " + Player_time_class.presday1);
                file.WriteLine("\nday2 = " + Player_time_class.presday2);
                file.WriteLine("\nyear1 = " + Player_time_class.presy1);
                file.WriteLine("\nyear2 = " + Player_time_class.presy2);
                file.WriteLine("\nyear3 = " + Player_time_class.presy3);
                file.WriteLine("\nyear4 = " + Player_time_class.presy4);
                file.WriteLine("\nhour1 = " + Player_time_class.presh1);
                file.WriteLine("\nhour2 = " + Player_time_class.presh2);
                file.WriteLine("\nmin1 = " + Player_time_class.presm1);
                file.WriteLine("\nmin2 = " + Player_time_class.presm2);
                file.WriteLine("\nampm = " + Player_time_class.presampm);
                file.WriteLine("\n\nPast:");
                file.WriteLine("\nmonth1 = " + Player_time_class.pastmonth1);
                file.WriteLine("\nmonth2 = " + Player_time_class.pastmonth2);
                file.WriteLine("\nday1 = " + Player_time_class.pastday1);
                file.WriteLine("\nday2 = " + Player_time_class.pastday2);
                file.WriteLine("\nyear1 = " + Player_time_class.pasty1);
                file.WriteLine("\nyear2 = " + Player_time_class.pasty2);
                file.WriteLine("\nyear3 = " + Player_time_class.pasty3);
                file.WriteLine("\nyear4 = " + Player_time_class.pasty4);
                file.WriteLine("\nhour1 = " + Player_time_class.pasth1);
                file.WriteLine("\nhour2 = " + Player_time_class.pasth2);
                file.WriteLine("\nmin1 = " + Player_time_class.pastm1);
                file.WriteLine("\nmin2 = " + Player_time_class.pastm2);
                file.WriteLine("\nampm = " + Player_time_class.pastampm);


                file.Close();
            }

            //startingscene.Start();
        }

        bool menu = false;
        int menuitem = 0;
        bool runonce = false;

        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (menu)
            {
                if (e.KeyCode == Keys.F5)
                {
                    menu = false;
                    Game.Player.CanControlCharacter = true;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    if (menuitem == 0)
                    {
                        Variableclass.sent_message_to_circuits = true;
                    }
                    else if (menuitem == 1)
                    {
                        Vehicle Deloreon;

                        Vector3 position = Game.Player.Character.Position;

                        // At 90 degrees to the players heading
                        float heading = Game.Player.Character.Heading - 90;

                        Deloreon = World.CreateVehicle(VehicleHash.Dune2, position, heading);
                        Deloreon.Rotation = Game.Player.Character.Rotation;

                        Deloreon.DirtLevel = 0;
                        Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                        Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                        Deloreon.NumberPlate = "OutATime";
                        Deloreon.PlaceOnGround();
                        // Set the vehicle mods
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                        Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                        Deloreon.ToggleMod(VehicleToggleMod.XenonHeadlights, true);
                        Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                    }
                    else if (menuitem == 2)
                    {

                    }
                    else if (menuitem == 3)
                    {
                        
                    }
                    else if (menuitem == 4)
                    {
                        menu = false;
                        Game.Player.CanControlCharacter = true;
                    }
                }
            }
            else
            {
                if (e.KeyCode == Keys.F7)
                {
                    startingscene.Start();
                }
                else if (e.KeyCode == Keys.F11)
                {
                    Variableclass.sendinvincible = true;
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    Variableclass.resetall = true;
                }
                else if (e.KeyCode == Keys.T)
                {
                    Variableclass.rcmode_send = true;
                }
                else if (e.KeyCode == Keys.F10)
                {

                    ExperimentScene.possiondisplay = !ExperimentScene.possiondisplay;
                }
                else if (e.KeyCode == Keys.F5)
                {
                    menu = true;
                    Game.Player.CanControlCharacter = false;
                }
                Variableclass.keypressed = false;
            }
        }



        public void display_menu(string file, string extention)
        {
            string img = file;
            if (File.Exists(Application.StartupPath + "\\scripts\\menu images\\" + img + extention))
            {
                Sprite.DrawTexture(Application.StartupPath + "\\scripts\\menu images\\" + img + extention, new Point(50,50), new Size(1920, 1080));
            }
            else
            {
                UIText debug2 = new UIText("File is not present: " + img + extention, new Point(400, 100), (float)0.6);
                debug2.Draw();
            }
        }

        int temptick = 0;
        int explodecount = 0;

        void riot()
        {
            int tick2 = DateTime.Now.Second;
            //tick
            if (tick2 != temptick)
            {
                //Start Ped Despawning
                Ped[] peds = World.GetNearbyPeds(Game.Player.Character, 1000);
                Vehicle[] pedVehicles = World.GetNearbyVehicles(Game.Player.Character, 1000);
                for (int i = 0; i < peds.Length; i++)
                {
                    if (peds[i] != Game.Player.Character)
                    {
                        try
                        {
                            peds[i].RelationshipGroup = (int)Relationship.Hate;
                            peds[i].Weapons.Give(WeaponHash.HeavyPistol, 9999, true, true);
                            peds[i].Task.FightAgainst(World.GetClosestPed(peds[i + 1].Position, 1000));
                        }
                        catch
                        {

                        }
                    }
                    //GTA.Native.Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, peds[i], 0, 0, 0, 0, 0, 1);
                }
                Array.Clear(peds, 0, peds.Length);

                for (int i = 0; i < pedVehicles.Length; i++)
                {
                    if (pedVehicles[i] != Game.Player.Character.CurrentVehicle)
                    {
                        try
                        {
                            pedVehicles[i].GetPedOnSeat(VehicleSeat.Driver).RelationshipGroup = (int)Relationship.Hate;
                            pedVehicles[i].GetPedOnSeat(VehicleSeat.Driver).Weapons.Give(WeaponHash.HeavyPistol, 9999, true, true);
                            pedVehicles[i].GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(World.GetClosestPed(peds[i + 1].Position, 1000));
                            if (explodecount == 20)
                            {
                                pedVehicles[i].Explode();
                                explodecount = 0;
                            }
                            explodecount++;
                        }
                        catch
                        {

                        }
                    }
                    //GTA.Native.Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, pedVehicles[i], 0, 0, 0, 0, 0, 1);
                }
                Array.Clear(pedVehicles, 0, pedVehicles.Length);
                //End Ped Despawning
                temptick = tick2;
            }
        }
        Delorean_class instantDelorean = new Delorean_class();

        private void onTick(object sender, EventArgs e)
        {
            try
            {
                if (Game.Player.Character.IsInVehicle())
                {
                    if (!runonce)
                    {
                        if (Game.Player.Character.CurrentVehicle.Model == VehicleHash.Dune2)
                        {
                            instantDelorean.CreateDeloreonnearyou(Game.Player.Character.CurrentVehicle);
                            Tick += instantDelorean.Check;
                            runonce = true;
                        }
                    }
                }
                else
                {
                    runonce = false;
                }




                if (Player_time_class.presday1 == 2 && Player_time_class.presday2 == 9 && Player_time_class.presmonth1 == 0 && Player_time_class.presmonth2 == 4 && Player_time_class.presy1 == 1 && Player_time_class.presy2 == 9 && Player_time_class.presy3 == 9 && Player_time_class.presy4 == 2)
                {
                    riot();
                }
                else if (Player_time_class.presday1 == 3 && Player_time_class.presday2 == 0 && Player_time_class.presmonth1 == 0 && Player_time_class.presmonth2 == 4 && Player_time_class.presy1 == 1 && Player_time_class.presy2 == 9 && Player_time_class.presy3 == 9 && Player_time_class.presy4 == 2)
                {
                    riot();
                }
                else if (Player_time_class.presday1 == 0 && Player_time_class.presday2 == 1 && Player_time_class.presmonth1 == 0 && Player_time_class.presmonth2 == 5 && Player_time_class.presy1 == 1 && Player_time_class.presy2 == 9 && Player_time_class.presy3 == 9 && Player_time_class.presy4 == 2)
                {
                    riot();
                }
                else if (Player_time_class.presday1 == 0 && Player_time_class.presday2 == 2 && Player_time_class.presmonth1 == 0 && Player_time_class.presmonth2 == 5 && Player_time_class.presy1 == 1 && Player_time_class.presy2 == 9 && Player_time_class.presy3 == 9 && Player_time_class.presy4 == 2)
                {
                    riot();
                }
                else if (Player_time_class.presday1 == 0 && Player_time_class.presday2 == 3 && Player_time_class.presmonth1 == 0 && Player_time_class.presmonth2 == 5 && Player_time_class.presy1 == 1 && Player_time_class.presy2 == 9 && Player_time_class.presy3 == 9 && Player_time_class.presy4 == 2)
                {
                    riot();
                }
                else if (Player_time_class.presday1 == 0 && Player_time_class.presday2 == 4 && Player_time_class.presmonth1 == 0 && Player_time_class.presmonth2 == 5 && Player_time_class.presy1 == 1 && Player_time_class.presy2 == 9 && Player_time_class.presy3 == 9 && Player_time_class.presy4 == 2)
                {
                    riot();
                }

                //Function.Call(Hash.START_SCRIPT_FIRE, Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z, 50, false);
                //Function.Call(Hash.START_PARTICLE_FX_LOOPED_AT_COORD, "scr_sh_lighter_sparks", Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z, Game.Player.Character.Rotation.X, Game.Player.Character.Rotation.Y, Game.Player.Character.Rotation.Z, 10, 0, 0, 0);
                int tick = DateTime.Now.Second;
                //tick
                if (tick != temptick)
                {
                    Player_time_class.timetick();
                    temptick = tick;
                }

                if (menu)
                {
                    if (menuitem  == 0)
                    {
                        display_menu("time-circuits", ".png");
                    }
                    else if (menuitem == 1)
                    {
                        display_menu("delorean", ".png");
                    }
                    else if (menuitem == 2)
                    {
                        display_menu("marty-mcfly", ".png");
                    }
                    else if (menuitem == 3)
                    {
                        display_menu("DOC-BROWN", ".png");
                    }
                    else if (menuitem == 4)
                    {
                        display_menu("exit", ".png");
                    }
                }

                //Time_circuits_ingame_display.display_Time_circuits_dash();
                //Time_circuits_ingame_display.tick_text_only();
                ExperimentScene.tick();
                startingscene.scene(Game.Player.Character.Model);
            }
            catch(Exception d)
            {
                UIText debug2 = new UIText("Error: " + d.Message, new Point(400, 300), (float)0.6);
                debug2.Draw();
            }
        }

    }
}
