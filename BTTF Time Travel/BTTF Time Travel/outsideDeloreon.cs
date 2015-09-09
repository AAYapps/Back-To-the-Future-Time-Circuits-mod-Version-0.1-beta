using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTF_Time_Travel
{
    class outsideDeloreon: Deloreonfunctions
    {

        static void playerout()
        {
            /*Vector3 playerpos = Game.Player.Character.Position;
            Vector3 playerrot = Game.Player.Character.Rotation;

            UIText Instruct = new UIText("X: " + playerpos.X + Environment.NewLine
                + "Y: " + playerpos.Y + Environment.NewLine
                + "Z: " + playerpos.Z + Environment.NewLine
                + "rX: " + playerrot.X + Environment.NewLine
                + "rY: " + playerrot.Y + Environment.NewLine
                + "rZ: " + playerrot.Z + Environment.NewLine
                , new Point(400, 400), (float)0.6);
            Instruct.Draw();*/

            if (!(Deloreon == null))
            {
                if (!ifwentoutoffcar)
                {
                    if (!carjustdied)
                    {
                        if (!RCmode)
                        {
                            engineoff.Play();
                        }
                    }
                    ifwentoutoffcar = true;
                    engineturningon = false; ;
                }
                engineison = false;

                if (MrFusionfilltask)
                {
                    if (Game.Player.Character.IsInRangeOf(Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)-2.85, 0)), (float)0.6))
                    {
                        if (!refilltimecurcuits)
                        {
                            if (Constanttimerclass.getdelay() == 0)
                            {
                                Mrfrefill.Play();
                                Game.Player.Character.Task.AimAt(Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)-2.89, 0)), 10);
                                Deloreon.OpenDoor(VehicleDoor.Trunk, false, false);
                                Constanttimerclass.Start();
                            }
                            else if (Constanttimerclass.getdelay() == 4)
                            {
                                Deloreon.CloseDoor(VehicleDoor.Trunk, false);
                                mrfopened = false;
                                refilltimecurcuits = true;
                                MrFusionfilltask = false;
                                Constanttimerclass.Stop();
                                Constanttimerclass.Reset();
                            }
                        }
                    }
                }

                if (RCmodeenabled)
                {
                    if (!RCmode)
                    {
                        if (!(RCped == null))
                        {
                            if (!(Game.Player.Character == playerped))
                            {
                                Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, playerped, true, true);
                            }
                        }
                    }

                    if (RCmode)
                    {
                        if (!(RCped == null))
                        {
                            if (!RCped.IsInVehicle())
                            {
                                ToggleRCmode();
                            }
                        }

                        if (!RCmodeactive)
                        {
                            if (!(RCped == null))
                            {
                                Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, RCped, true, true);
                                RCmodeactive = true;
                            }
                            else
                            {
                                playerped = Game.Player.Character;
                                RCped = Deloreon.CreatePedOnSeat(VehicleSeat.Driver, Game.Player.Character.Model);
                                RCped.IsVisible = false;
                                RCped.CanBeDraggedOutOfVehicle = true;
                            }
                        }
                    }
                    else if (!RCmode)
                    {
                        if (!(RCped == null))
                        {
                            if (Game.Player.Character == playerped)
                            {
                                RCmodeactive = false;
                                RCped.Delete();
                                RCped = null;
                            }
                        }
                    }
                }
                
                if (retreive)
                {
                    if (!(Deloreonretreiver == null))
                    {
                        if (Game.Player.Character.IsInRangeOf(Deloreonretreiver.Position, 5))
                        {
                            Deloreonretreiver.Delete();
                            retreive = false;
                        }
                    }
                }

                if (!Deloreon.IsDriveable)
                {
                    if (!carjustdied)
                    {
                        carjustdied = true;
                        trend.Play();
                        Deloreon.IsPersistent = false;
                        Deloreon.MarkAsNoLongerNeeded();
                        Deloreon = null;
                        engineison = false;
                        ifwentoutoffcar = true;
                    }
                }
            }
        }
        static void stealerplayerout()
        {
            if (!(Deloreon == null))
            {
                if (Deloreonstealer.IsInRangeOf(Deloreon.Position, 2))
                {
                    if (!Deloreonstealer.IsInVehicle(Deloreon))
                    {
                        if (!deloreonstealergoingincar)
                        {
                            deloreonstealergoingincar = true;
                        }
                    }
                }

                if (!ifwentoutoffcar)
                {
                    if (!carjustdied)
                    {
                        engineoff.Play();
                    }
                    ifwentoutoffcar = true;
                    engineturningon = false; ;
                }
                engineison = false;

                if (!Deloreon.IsDriveable)
                {
                    if (!carjustdied)
                    {
                        carjustdied = true;
                        trend.Play();
                        Deloreon = null;
                        engineison = false;
                        ifwentoutoffcar = true;
                    }
                }
            }
        }

        public static void Checkifout()
        {
            if (Deloreonstealer == null)
            {
                if (!Game.Player.Character.IsInVehicle())
                {
                    playerout();
                }
            }
            else if (!(Deloreonstealer == null))
            {
                if (Deloreonstealer.IsDead)
                {
                    Deloreon2 = null;
                    Deloreonstealer.CurrentBlip.Remove();
                    Deloreonstealer.Detach();
                    Deloreonstealer = null;
                }

                if (!Game.Player.Character.IsInVehicle() && Deloreonstealer.IsInVehicle())
                {
                    stealerplayerout();
                }
            }
        }

        public static void Checkifout2()
        {
            if (!Game.Player.Character.IsInVehicle())
            {
                if (!(Deloreon2 == null))
                {
                    if (!ifwentoutoffcar2)
                    {
                        if (!carjustdied2)
                        {
                            engineoff.Play();
                        }
                        ifwentoutoffcar2 = true;
                        engineturningon2 = false; ;
                    }
                    engineison2 = false;

                    if (retreive2)
                    {
                        if (Game.Player.Character.IsInRangeOf(Deloreonretreiver2.Position, 5))
                        {
                            Deloreonretreiver2.CurrentVehicle.SoundHorn(1);
                            Deloreonretreiver2.CurrentVehicle.SoundHorn(1);
                            Deloreonretreiver2.CurrentVehicle.OpenDoor(VehicleDoor.FrontLeftDoor, false, false);
                            Deloreonretreiver2.Task.ClearAllImmediately();
                            Deloreonretreiver2.Task.ShuffleToNextVehicleSeat(Deloreon);
                            retreive2 = false;
                        }
                    }

                    if (!Deloreon2.IsDriveable)
                    {
                        if (!carjustdied2)
                        {
                            carjustdied2 = true;
                            trend.Play();
                            Deloreon2 = null;
                            engineison2 = false;
                            ifwentoutoffcar2 = true;
                        }
                    }
                }
            }
        }
    }
}
