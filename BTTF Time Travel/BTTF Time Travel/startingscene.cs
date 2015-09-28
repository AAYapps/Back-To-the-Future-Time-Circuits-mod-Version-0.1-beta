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
        static Constanttimerclass delay = new Constanttimerclass();

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
                    if (delay.getdelay() == 0)
                    {
                        SoundPlayer Intro = new SoundPlayer(Properties.Resources.Intro);
                        Intro.Play();
                        delay.Start();
                    }
                    else if (delay.getdelay() <= 22)
                    {
                        if (delay.getdelay() > 4 && delay.getdelay() < 7)
                        {
                            UIText debug = new UIText("Joshua Vanderzee" + Environment.NewLine + "       Presents", new Point(280, 300), (float)1.5);
                            debug.Draw();
                        }
                        else if (delay.getdelay() > 10 && delay.getdelay() < 13)
                        {
                            UIText debug = new UIText("               A" + Environment.NewLine + "Grand Theft Auto V BTTF" + Environment.NewLine + "             Mod", new Point(280, 200), (float)1.5);
                            debug.Draw();
                        }
                        else if (delay.getdelay() > 15 && delay.getdelay() < 20)
                        {
                            UIText debug = new UIText("Go to the Desert air feild", new Point(280, 200), (float)1.5);
                            debug.Draw();
                        }
                        else if (delay.getdelay() == 22)
                        {
                            if (!makeoneblip)
                            {
                                if (loction == null)
                                {
                                    loction = World.CreateBlip(new Vector3(1724, 3314, 40));
                                    loction.Color = BlipColor.Green;
                                    makeoneblip = true;
                                }
                            }
                            delay.Stop();
                        }
                    }
                    else if (delay.getdelay() == 23)
                    {
                        if (Game.Player.Character.IsInRangeOf(new Vector3(1724, 3314, 40), 220))
                        {
                            startscene = false;
                            //CreateDeloreoninbuilding(new Vector3(1724, 3314, 40));
                        }
                    }
                }
                else if (character == PedHash.Franklin)
                {
                    if (delay.getdelay() == 0)
                    {
                        delay.Start();
                    }
                    else if (delay.getdelay() < 3)
                    {
                        UIText debug = new UIText("Please switch to Michael to start the cutscene", new Point(400, 300), (float)0.6);
                        debug.Draw();
                    }
                    else if (delay.getdelay() >= 3)
                    {
                        startscene = false;
                        delay.Stop();
                    }
                }
                else if (character == PedHash.Trevor)
                {
                    if (delay.getdelay() == 0)
                    {
                        delay.Start();
                    }
                    else if (delay.getdelay() < 3)
                    {
                        UIText debug = new UIText("Please switch to Michael to start the cutscene", new Point(400, 300), (float)0.6);
                        debug.Draw();
                    }
                    else if (delay.getdelay() >= 3)
                    {
                        startscene = false;
                        delay.Stop();
                    }
                }
            }
        }
    }
}
