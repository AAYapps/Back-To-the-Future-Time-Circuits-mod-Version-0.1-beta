using System;
using GTA;
using GTA.Native;
using System.Drawing;
using System.Media;
using GTA.Math;

namespace BTTF_Time_Travel
{
    class startingscene:Variableclass
    {
        static bool startscene = false;
        public static void Start()
        {
            startscene = true;
        }

        static bool makeoneblip = false;
        static System.Speech.Synthesis.SpeechSynthesizer Timeteller = new System.Speech.Synthesis.SpeechSynthesizer();
        static public void scene(Model character)
        {
            if (startscene)
            {
                if (character == PedHash.Michael)
                {
                    if (Constanttimerclass.getdelay() == 0)
                    {
                        SoundPlayer Intro = new SoundPlayer(Properties.Resources.Intro);
                        Intro.Play();
                        Constanttimerclass.Start();
                    }
                    else if (Constanttimerclass.getdelay() <= 22)
                    {
                        if (Constanttimerclass.getdelay() > 4 && Constanttimerclass.getdelay() < 7)
                        {
                            UIText debug = new UIText("Joshua Vanderzee" + Environment.NewLine + "       Presents", new Point(280, 300), (float)1.5);
                            debug.Draw();
                        }
                        else if (Constanttimerclass.getdelay() > 10 && Constanttimerclass.getdelay() < 13)
                        {
                            UIText debug = new UIText("               A" + Environment.NewLine + "Grand Theft Auto V BTTF" + Environment.NewLine + "             Mod", new Point(280, 200), (float)1.5);
                            debug.Draw();
                        }
                        else if (Constanttimerclass.getdelay() > 15 && Constanttimerclass.getdelay() < 20)
                        {
                            string presmonthname = "";
                            try
                            {
                                if (World.CurrentDate.Month == 1)
                                {
                                    presmonthname = "January";
                                }
                                else if (World.CurrentDate.Month == 2)
                                {
                                    presmonthname = "February";
                                }
                                else if (World.CurrentDate.Month == 3)
                                {
                                    presmonthname = "March";
                                }
                                else if (World.CurrentDate.Month == 4)
                                {
                                    presmonthname = "April";
                                }
                                else if (World.CurrentDate.Month == 5)
                                {
                                    presmonthname = "May";
                                }
                                else if (World.CurrentDate.Month == 6)
                                {
                                    presmonthname = "June";
                                }
                                else if (World.CurrentDate.Month == 7)
                                {
                                    presmonthname = "July";
                                }
                                else if (World.CurrentDate.Month == 8)
                                {
                                    presmonthname = "August";
                                }
                                else if (World.CurrentDate.Month == 9)
                                {
                                    presmonthname = "September";
                                }
                                else if (World.CurrentDate.Month == 10)
                                {
                                    presmonthname = "October";
                                }
                                else if (World.CurrentDate.Month == 11)
                                {
                                    presmonthname = "November";
                                }
                                else if (World.CurrentDate.Month == 12)
                                {
                                    presmonthname = "December";
                                }
                            }
                            catch
                            {
                                if (TimeCircuits.getmonth() == 1)
                                {
                                    presmonthname = "January";
                                }
                                else if (TimeCircuits.getmonth() == 2)
                                {
                                    presmonthname = "February";
                                }
                                else if (TimeCircuits.getmonth() == 3)
                                {
                                    presmonthname = "March";
                                }
                                else if (TimeCircuits.getmonth() == 4)
                                {
                                    presmonthname = "April";
                                }
                                else if (TimeCircuits.getmonth() == 5)
                                {
                                    presmonthname = "May";
                                }
                                else if (TimeCircuits.getmonth() == 6)
                                {
                                    presmonthname = "June";
                                }
                                else if (TimeCircuits.getmonth() == 7)
                                {
                                    presmonthname = "July";
                                }
                                else if (TimeCircuits.getmonth() == 8)
                                {
                                    presmonthname = "August";
                                }
                                else if (TimeCircuits.getmonth() == 9)
                                {
                                    presmonthname = "September";
                                }
                                else if (TimeCircuits.getmonth() == 10)
                                {
                                    presmonthname = "October";
                                }
                                else if (TimeCircuits.getmonth() == 11)
                                {
                                    presmonthname = "November";
                                }
                                else if (TimeCircuits.getmonth() == 12)
                                {
                                    presmonthname = "December";
                                }
                            }
                            

                            string ampm = "AM";
                            int hours = World.CurrentDayTime.Hours;
                            if (World.CurrentDayTime.Hours > 12)
                            {
                                hours = hours - 12;
                                ampm = "PM";
                            }

                            UIText debug = new UIText(World.CurrentDate.DayOfWeek.ToString().PadLeft(15) + Environment.NewLine + presmonthname + " " + World.CurrentDate.Day + " " + World.CurrentDate.Year + Environment.NewLine + "        " + hours + ":" + World.CurrentDayTime.Minutes + " " + ampm, new Point(280, 200), (float)1.5);
                            debug.Draw();
                        }
                        else if (Constanttimerclass.getdelay() == 22)
                        {
                            if (!makeoneblip)
                            {
                                if (loction == null)
                                {
                                    loction = World.CreateBlip(new Vector3(1264, 3141, 40));
                                    loction.Color = BlipColor.Green;
                                    makeoneblip = true;
                                }
                            }
                            Constanttimerclass.Stop();
                        }
                    }
                    else if (Constanttimerclass.getdelay() == 23)
                    {
                        if (Game.Player.Character.IsInRangeOf(new Vector3(1264, 3141, 40), 220))
                        {
                            startscene = false;
                            Deloreonfunctions.CreateDeloreonintruck(new Vector3(1294, 3141, 40));
                            ExperimentScene.Start();
                        }
                    }
                }
                else if (character == PedHash.Franklin)
                {
                    if (Constanttimerclass.getdelay() == 0)
                    {
                        Constanttimerclass.Start();
                    }
                    else if (Constanttimerclass.getdelay() < 3)
                    {
                        UIText debug = new UIText("Please switch to Michael to start the cutscene", new Point(400, 300), (float)0.6);
                        debug.Draw();
                    }
                    else if (Constanttimerclass.getdelay() >= 3)
                    {
                        startscene = false;
                        Constanttimerclass.Stop();
                    }
                }
                else if (character == PedHash.Trevor)
                {
                    if (Constanttimerclass.getdelay() == 0)
                    {
                        Constanttimerclass.Start();
                    }
                    else if (Constanttimerclass.getdelay() < 3)
                    {
                        UIText debug = new UIText("Please switch to Michael to start the cutscene", new Point(400, 300), (float)0.6);
                        debug.Draw();
                    }
                    else if (Constanttimerclass.getdelay() >= 3)
                    {
                        startscene = false;
                        Constanttimerclass.Stop();
                    }
                }
            }
        }
    }
}
