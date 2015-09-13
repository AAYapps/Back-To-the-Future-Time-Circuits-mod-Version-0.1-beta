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

        public static bool below84 = false;
        public static void below48()
        {
            below84 = true;
        }
        static int eplode = (int)ExplosionType.BZGas;
        public static void Tick()
        {
            UIText debug2 = new UIText("Working below84 " + below84 + " entertime " + entertime + " past84 " + past84, new Point(400, 300), (float)0.6);
            debug2.Draw();
            if (past84)
            {
                if (!runonce)
                {
                    Constanttimerclass.Start();
                    runonce = true;
                }

                if (Constanttimerclass.getdelay() < 32)
                {
                    if (Constanttimerclass.getdelay() < 3)
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
                    else if (Constanttimerclass.getdelay() == 5)
                    {
                        TimeCircuits.timetravelentry();
                        Function.Call(Hash.SET_CLOCK_DATE, TimeCircuits.getmonth(), TimeCircuits.getday(), TimeCircuits.getyear());
                        Function.Call(Hash.SET_CLOCK_TIME, TimeCircuits.gethour(), TimeCircuits.getminute(), 0);
                    }
                    else if (Constanttimerclass.getdelay() == 6)
                    {
                        if (!runonce2)
                        {
                            reenterybttf1incar.Play();
                            runonce2 = true;
                        }
                    }

                    else if (Constanttimerclass.getdelay() == 7)
                    {
                        if (refilltimecurcuits)
                        {
                            if (!invicible)
                            {
                                Variableclass.Deloreon.IsInvincible = false;
                                Variableclass.Deloreon.CanBeVisiblyDamaged = true;
                            }
                            refilltimecurcuits = false;
                            entertime = false;
                            TimeCircuits.resetrunonce();
                            Deloreon.Speed = 40;
                            Deloreon.IsVisible = true;
                            Game.Player.CanControlCharacter = true;
                        }
                    }
                    else if (Constanttimerclass.getdelay()  == 9)
                    {
                        cold.Play();
                        
                        
                    }
                    else if (Constanttimerclass.getdelay() == 10)
                    {
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                        Vent.Play();
                    }
                    else if (Constanttimerclass.getdelay() == 13)
                    {
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                    }
                    else if (Constanttimerclass.getdelay() == 15)
                    {
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3((float)0.5, -2, 0)), ExplosionType.Steam, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-(float)0.5, -2, 0)), ExplosionType.Steam, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                    }
                    else if (Constanttimerclass.getdelay() == 20)
                    {
                        cold.Play();
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                    }
                    else if (Constanttimerclass.getdelay() == 25)
                    {
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                        World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                    }
                    else if (Constanttimerclass.getdelay() >= 30)
                    {
                        Constanttimerclass.Stop();
                        Constanttimerclass.Reset();
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
