using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTF_Time_Travel
{
    class Time_reentry : Variableclass
    {
        static bool entertime = false;
        static bool runonce = false;
        static bool runonce2 = false;

        public static void enterintime()
        {
            entertime = true;
        }

        public static bool getenterintime()
        {
            return entertime;
        }

        public static bool below84 = false;
        public static void below48()
        {
            below84 = true;
        }

        public static void Tick()
        {
            if (past84)
            {
                if (!freezing.started)
                {
                    if (!runonce)
                    {
                        Constanttimerclass.Start();
                        runonce = true;
                    }

                    if (Constanttimerclass.getdelay() < 20)
                    {
                        if (Constanttimerclass.getdelay() < 6)
                        {
                            if (!freezing.started)
                            {
                                if (!entertime)
                                {
                                    if (!invicible)
                                    {
                                        Variableclass.Deloreon.IsInvincible = false;
                                        Variableclass.Deloreon.CanBeVisiblyDamaged = true;
                                    }
                                    past84 = false;
                                    below84 = false;
                                    runonce = false;
                                    sparks.Stop();
                                    Constanttimerclass.Stop();
                                    Constanttimerclass.Reset();
                                    Game.Player.CanControlCharacter = true;
                                }
                            }
                        }
                        else if (Constanttimerclass.getdelay() == 6)
                        {
                            TimeCircuits.timetravelentry();
                            Function.Call(Hash.SET_CLOCK_DATE, TimeCircuits.getmonth(), TimeCircuits.getday(), TimeCircuits.getyear());
                            Function.Call(Hash.SET_CLOCK_TIME, TimeCircuits.gethour(), TimeCircuits.getminute(), 0);
                        }
                        else if (Constanttimerclass.getdelay() == 7)
                        {
                            if (!runonce2)
                            {
                                reenterybttf1incar.Play();
                                runonce2 = true;
                            }
                        }

                        else if (Constanttimerclass.getdelay() == 8)
                        {
                            if (refilltimecurcuits)
                            {
                                Deloreon.Speed = 40;
                                if (!invicible)
                                {
                                    Variableclass.Deloreon.IsInvincible = false;
                                    Variableclass.Deloreon.CanBeVisiblyDamaged = true;
                                }
                                refilltimecurcuits = false;
                                entertime = false;
                                TimeCircuits.resetrunonce();
                                Deloreon.IsVisible = true;
                                Game.Player.CanControlCharacter = true;
                                Constanttimerclass.Reset();
                                freezing.start();
                                runonce = false;
                                runonce2 = false;
                                past84 = false;
                                below84 = false;
                            }
                        }
                    }
                }
            }
        }
    }
}
