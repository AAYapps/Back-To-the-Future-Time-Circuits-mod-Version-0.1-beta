using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GTA;
using System.Media;
using GTA.Math;
using GTA.Native;
using System.Drawing;

namespace BTTF_Time_Travel
{
    class Deloreonfunctions: Variableclass
    {
        public static void CreateDeloreon()
        {
            Plut.Play();

            Vector3 position = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 5, 0));

            // At 90 degrees to the players heading
            float heading = Game.Player.Character.Heading - 90;

            if (!(Deloreon == null))
            {
                Deloreon.Delete();
            }
            Deloreon = World.CreateVehicle(VehicleHash.Voltic, position, heading);

            Variableclass.deloreonspoawned = true;

            Deloreon.DirtLevel = 0;
            Deloreon.CustomPrimaryColor = Color.Silver;
            Deloreon.CustomSecondaryColor = Color.Black;
            Deloreon.NumberPlate = "OutATime";
            Deloreon.IsInvincible = true;
            Deloreon.CanBeVisiblyDamaged = false;
            Deloreon.PlaceOnGround();
        }

        public static void CreateDeloreonintruck(Vector3 truckposition)
        {
            

            // At 90 degrees to the players heading
            float heading = Game.Player.Character.Heading - 90;

            if (!(Docstruck == null))
            {
                Docstruck.Delete();
            }

            Docstruck = World.CreateVehicle(VehicleHash.Benson, truckposition, heading);
            Docstruck.Rotation = new Vector3(0, 0, 102);
            Docstruck.OpenDoor(VehicleDoor.Trunk, false, true);

            Vector3 position = Docstruck.GetOffsetInWorldCoords(new Vector3(0, -10, 0));

            if (!(Deloreon == null))
            {
                Deloreon.Delete();
            }
            Deloreon = World.CreateVehicle(VehicleHash.Voltic, position, heading);
            Deloreon.Rotation = new Vector3(0, 0, 102);
            Deloreon.IsInvincible = true;
            Deloreon.CanBeVisiblyDamaged = false;
            if (!(Doc == null))
            {
                Doc.Delete();
            }
            Doc = Deloreon.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Scientist01SMM);
            Doc.RelationshipGroup = (int)Relationship.Companion;

            Einstein = World.CreatePed(PedHash.Chop, Docstruck.GetOffsetInWorldCoords(new Vector3(-20, 0, 0)));
            Einstein.RelationshipGroup = (int)Relationship.Companion;
            Einstein.IsInvincible = true;

            deloreonspoawned = true;

            Deloreon.DirtLevel = 0;
            Deloreon.CustomPrimaryColor = Color.Silver;
            Deloreon.CustomSecondaryColor = Color.Black;
            Deloreon.NumberPlate = "OutATime";
        }

        public static void RetreiveDeloreon()
        {
            if (!(Deloreonstealer == null))
            {
                if (!Deloreonstealer.IsInVehicle(Deloreon))
                {
                    Deloreonretreiver = Deloreon.CreatePedOnSeat(VehicleSeat.Driver, Game.Player.Character.Model);
                    Deloreon.Repair();
                    Deloreon.PlaceOnGround();
                    Deloreonretreiver.AddBlip();
                    Deloreonretreiver.Task.DriveTo(Deloreon, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(-5, 0, 0)), 0, 100, 1);
                    Deloreonretreiver.IsVisible = false;
                    retreive = true;
                }
            }
            else
            {
                Deloreonretreiver = Deloreon.CreatePedOnSeat(VehicleSeat.Driver, Game.Player.Character.Model);
                Deloreon.Repair();
                Deloreon.PlaceOnGround();
                Deloreonretreiver.AddBlip();
                Deloreonretreiver.Task.DriveTo(Deloreon, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(-5, 0, 0)), 0, 100, 1);
                retreive = true;
            }
        }

        static void timesurcuitsswitch()
        {
            if (Game.Player.Character.IsInVehicle())
            {
                if (Game.Player.Character.CurrentVehicle == Deloreon)
                {
                    toggletimecurcuits = !toggletimecurcuits;
                    if (toggletimecurcuits)
                    {
                        inputon.Play();
                    }
                    else
                    {
                        inputoff.Play();
                    }
                }
            }
        }

        public static void toggletimesurcuitsswitch()
        {
            if (!(Deloreonstealer == null))
            {
                if (!Deloreonstealer.IsInVehicle(Deloreon))
                {
                    timesurcuitsswitch();
                }
            }
            else
            {
                timesurcuitsswitch();
            }
        }

        public static void ToggleRCmode()
        {
            if (!(Deloreonstealer == null))
            {
                if (!Deloreonstealer.IsInVehicle(Deloreon))
                {
                    RCmode = !RCmode;

                    if (RCmode)
                    {
                        RCcontrolstart.Play();
                        Deloreon.EngineRunning = true;
                    }
                    else
                    {
                        RCcontrolstop.Play();
                        Deloreon.EngineRunning = false;
                    }
                }
            }
            else
            {
                if (!ExperimentScene.Docwithremote)
                {
                    RCmode = !RCmode;

                    if (RCmode)
                    {
                        RCcontrolstart.Play();
                        Deloreon.EngineRunning = true;
                    }
                    else
                    {
                        RCcontrolstop.Play();
                        Deloreon.EngineRunning = false;
                    }
                }
                else
                {
                    RCmode = !RCmode;
                    if (!RCmode)
                    {
                        Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, playerped, true, true);
                    }
                    else
                    {
                        RCcontrolstart.Play();
                        RCped = Einstein;
                        playerped = Game.Player.Character;
                        if (RCped == Einstein)
                        {
                            if (playerped == Game.Player.Character)
                            {
                                Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, RCped, true, true);
                            }
                        }
                    }
                }
            }
        }

        public static void Toggleflight()
        {
            if (!(Deloreonstealer == null))
            {
                if (!Deloreonstealer.IsInVehicle(Deloreon))
                {
                    if (Game.Player.Character.IsInVehicle())
                    {
                        if (Game.Player.Character.CurrentVehicle == Deloreon)
                        {
                            if (flyingison)
                            {
                                flyingison = false;
                                hoveroff.Play();
                                flyheight = 0;
                            }
                            else
                            {
                                flycount = 0;
                                flyingison = true;
                                hoveron.Play();
                            }
                        }
                    }
                }
            }
            else
            {
                if (Game.Player.Character.IsInVehicle())
                {
                    if (Game.Player.Character.CurrentVehicle == Deloreon)
                    {
                        if (flyingison)
                        {
                            flyingison = false;
                            hoveroff.Play();
                            flyheight = 0;
                        }
                        else
                        {
                            flycount = 0;
                            flyingison = true;
                            hoveron.Play();
                        }
                    }
                }
            }
        }

        public static void ToggleMrfusion()
        {
            if (!(Deloreonstealer == null))
            {
                if (!Deloreonstealer.IsInVehicle(Deloreon))
                {
                    if (Game.Player.Character.IsInVehicle())
                    {
                        if (Game.Player.Character.CurrentVehicle == Deloreon)
                        {
                            if (!refilltimecurcuits)
                            {
                                refilltimecurcuits = true;
                                Mrfrefill.Play();
                                mrfopened = true;
                            }
                        }
                    }
                }
            }
            else
            {
                if (Game.Player.Character.IsInVehicle())
                {
                    if (Game.Player.Character.CurrentVehicle == Deloreon)
                    {
                        if (!refilltimecurcuits)
                        {
                            refilltimecurcuits = true;
                            Mrfrefill.Play();
                            mrfopened = true;
                        }
                    }
                }
                else
                {
                    if (Game.Player.Character.IsInRangeOf(Deloreon.Position, 5))
                    {
                        MrFusionfilltask = true;
                    }
                }
            }
        }

        public static void Flighthight(int num)
        {
            flyheight += num;
        }

        static int delay = 0;
        static bool entertime = false;
        static bool runonce = false;
        static bool runonce2 = false;
        static void Deloreonfunctioning()
        {
            if (flyingison)
            {
                if (flyheight > 0)
                {
                    if (flycount >= 30)
                    {
                        flyheight--;
                        Deloreon.ApplyForce(Deloreon.GetOffsetInWorldCoords(new Vector3(0, 0, flyheight)));
                    }
                    else
                    {
                        flycount++;
                        flyheight = 2;
                        Deloreon.ApplyForce(Deloreon.GetOffsetInWorldCoords(new Vector3(0, 0, flyheight)));
                    }
                }
            }

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

            if (!engineturningon)
            {
                if (!engineison)
                {
                    if (!RCmode)
                    {
                        engineon.Play();
                    }
                    ifegnineturnedon = true;
                    engineison = true;
                    engineturningon = true;
                    ifwentoutoffcar = false;
                    Function.Call(Hash.SET_VEHICLE_ENGINE_ON, Game.Player.Character.CurrentVehicle, true);
                }
            }

            if (!Game.Player.Character.CurrentVehicle.IsDriveable)
            {
                if (!carjustdied)
                {
                    carjustdied = true;
                    trend.Play();
                    Deloreon.IsPersistent = false;
                    Deloreon.MarkAsNoLongerNeeded();
                    Deloreon = null;
                    Game.Player.Character.CurrentVehicle.Detach();
                    engineison = false;
                    ifwentoutoffcar = true;
                }
            }

            if (mrfopened)
            {
                if (Constanttimerclass.getdelay() == 0)
                {
                    Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, Game.Player.Character.CurrentVehicle, 5, false, false);
                    Constanttimerclass.Start();
                }
                else if (Constanttimerclass.getdelay() == 4)
                {
                    Function.Call(Hash.SET_VEHICLE_DOOR_SHUT, Game.Player.Character.CurrentVehicle, 5, false);
                    mrfopened = false;
                    Constanttimerclass.Stop();
                    Constanttimerclass.Reset();
                }
            }
            else if (toggletimecurcuits)
            {
                Timedisplayf = new UIText(TimeCircuits.timedisplayfuture(), new Point(700, 150), 1, Color.Red);
                Timedisplaypres = new UIText(TimeCircuits.timedisplaypresent(), new Point(700, 190), 1, Color.Green);
                Timedisplaypast = new UIText(TimeCircuits.timedisplaypast(), new Point(700, 230), 1, Color.Yellow);
                Timedisplayf.Draw();
                Timedisplaypres.Draw();
                Timedisplaypast.Draw();

                if (Game.Player.Character.CurrentVehicle.Speed * 2.4 > 84 && Game.Player.Character.CurrentVehicle.Speed * 2.4 < 88)
                {
                    if (!past84)
                    {
                        if (refilltimecurcuits)
                        {
                            sparksfeul.PlayLooping();
                            Constanttimerclass.Start();
                        }
                        else
                        {
                            sparks.PlayLooping();
                        }
                        past84 = true;
                    }
                }
                else if (Game.Player.Character.CurrentVehicle.Speed * 2.4 >= 88)
                {
                    if (refilltimecurcuits)
                    {
                        if (Constanttimerclass.getdelay() < 5)
                        {
                            if (Constanttimerclass.getdelay() > 3)
                            {
                                World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), (ExplosionType)4, (float)0.0001, 0);
                                World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), (ExplosionType)4, (float)0.0001, 0);
                            }
                        }
                        else
                        {
                            World.AddExplosion(Deloreon.Position, ExplosionType.BigExplosion1, 10, 0);
                            Timetravelreenterycutscene.Play();
                            //Timetravelreentery.Play();
                            Deloreon.Speed = 0;
                            Deloreon.IsVisible = false;
                            Constanttimerclass.Stop();
                            Constanttimerclass.Reset();
                            entertime = true;
                            if (Game.Player.WantedLevel > 0)
                            {
                                Game.Player.WantedLevel = 0;
                            }
                        }
                    }
                }
                else
                {
                    if (past84)
                    {
                        if (!runonce)
                        {
                            Constanttimerclass.Start();
                            runonce = true;
                        }

                        if (Constanttimerclass.getdelay() < 18)
                        {
                            if (Constanttimerclass.getdelay() < 3)
                            {
                                if (!entertime)
                                {
                                    past84 = false;
                                    runonce = false;
                                    sparks.Stop();
                                    Constanttimerclass.Stop();
                                    Constanttimerclass.Reset();
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
                                if(!runonce2)
                                {
                                    reenterybttf1incar.Play();
                                    runonce2 = true;
                                } 
                            }
                            else if (Constanttimerclass.getdelay() == 7)
                            {
                                if (refilltimecurcuits)
                                {
                                    refilltimecurcuits = false;
                                    Constanttimerclass.Stop();
                                    Constanttimerclass.Reset();
                                    runonce = false;
                                    runonce2 = false;
                                    entertime = false;
                                    past84 = false;
                                    TimeCircuits.resetrunonce();
                                    Deloreon.Speed = 40;
                                    Deloreon.IsVisible = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        public static void Check()
        {
            if (Game.Player.Character.IsGettingIntoAVehicle)
            {
                if (!(Deloreon == null))
                {
                    carjustdied = false;
                }
            }
            else if (Game.Player.Character.IsInVehicle() || RCmode)
            {
                if (!(Deloreon == null))
                {
                    if (Game.Player.Character.CurrentVehicle == Deloreon)
                    {
                        if (!(Deloreonstealer == null))
                        {
                            if (!Deloreonstealer.IsInVehicle(Deloreon))
                            {
                                Deloreonfunctioning();
                            }
                        }
                        else
                        {
                            Deloreonfunctioning();
                        }
                    }
                }
            }

            if (!(Deloreonstealer == null))
            {
                if (Deloreonstealer.IsGettingIntoAVehicle)
                {
                    if (!(Deloreon == null))
                    {
                        carjustdied = false;
                    }
                }
                else if (Deloreonstealer.IsInVehicle())
                {
                    if (!(Deloreon == null))
                    {
                        if (Deloreonstealer.CurrentVehicle == Deloreon)
                        {
                            if (!deloreonstealerincar)
                            {
                                deloreonstealerincar = true;
                                if (Deloreonstealer.CurrentVehicle == Deloreon)
                                {
                                    deloreonstealergoingincar = true;
                                    if (!refilltimecurcuits)
                                    {
                                        refilltimecurcuits = true;
                                        Mrfrefill.Play();
                                        mrfopened = true;
                                    }
                                }
                                Deloreonfunctions2.CreateDeloreon();
                                Deloreon2.PlaceOnNextStreet();
                                Deloreonfunctions2.RetreiveDeloreon();
                            }

                            if (Deloreonstealer.IsDead)
                            {
                                Deloreon2 = null;
                                Deloreonstealer.Detach();
                                Deloreonstealer = null;
                                Deloreonstealer.Delete();
                            }

                            if (toggletimecurcuits)
                            {
                                Timedisplayf = new UIText(TimeCircuits.timedisplayfuture(), new Point(700, 150), 1, Color.Red);
                                Timedisplaypres = new UIText(TimeCircuits.timedisplaypresent(), new Point(700, 190), 1, Color.Green);
                                Timedisplaypast = new UIText(TimeCircuits.timedisplaypast(), new Point(700, 230), 1, Color.Yellow);

                                Timedisplayf.Draw();
                                Timedisplaypres.Draw();
                                Timedisplaypast.Draw();
                            }

                            if (flyingison)
                            {
                                if (flyheight > 0)
                                {
                                    flyheight--;
                                    if (flycount >= 30)
                                    {
                                        Deloreon.Position = Deloreon.GetOffsetInWorldCoords(new Vector3(0, 0, flyheight));
                                    }
                                    else
                                    {
                                        flycount++;
                                        flyheight += 2;
                                        Deloreon.Position = Deloreon.GetOffsetInWorldCoords(new Vector3(0, 0, flyheight));
                                    }
                                }

                            }

                            if (!engineturningon)
                            {
                                if (!engineison)
                                {
                                    engineon.Play();
                                    ifegnineturnedon = true;
                                    engineison = true;
                                    engineturningon = true;
                                    ifwentoutoffcar = false;
                                    Function.Call(Hash.SET_VEHICLE_ENGINE_ON, Deloreonstealer.CurrentVehicle, true);
                                }
                            }

                            if (!Deloreonstealer.CurrentVehicle.IsDriveable)
                            {
                                if (!carjustdied)
                                {
                                    carjustdied = true;
                                    trend.Play();
                                    Deloreon = null;
                                    Deloreonstealer.CurrentVehicle.Detach();
                                    Deloreonstealer.Kill();
                                    engineison = false;
                                    ifwentoutoffcar = true;
                                }
                            }

                            if (mrfopened)
                            {
                                if (Constanttimerclass.getdelay() == 0)
                                {
                                    Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, Deloreonstealer.CurrentVehicle, 5, false, false);
                                    Constanttimerclass.Start();
                                }
                                else if (Constanttimerclass.getdelay() == 70)
                                {
                                    Function.Call(Hash.SET_VEHICLE_DOOR_SHUT, Deloreonstealer.CurrentVehicle, 5, false);
                                    mrfopened = false;
                                    Constanttimerclass.Stop();
                                    Constanttimerclass.Reset();
                                    if (Deloreonstealer.CurrentVehicle == Deloreon)
                                    {
                                        toggletimecurcuits = !toggletimecurcuits;
                                        if (toggletimecurcuits)
                                        {
                                            inputon.Play();
                                        }
                                        else
                                        {
                                            inputoff.Play();
                                        }
                                    }
                                }
                            }

                            if (toggletimecurcuits)
                            {
                                if (Deloreonstealer.CurrentVehicle.Speed * 2.4 > 84 && Deloreonstealer.CurrentVehicle.Speed * 2.4 < 88)
                                {
                                    if (!past84)
                                    {
                                        if (refilltimecurcuits)
                                        {
                                            sparksfeul.PlayLooping();
                                        }
                                        else
                                        {
                                            sparks.PlayLooping();
                                        }
                                        past84 = true;
                                    }
                                }
                                else if (Deloreonstealer.CurrentVehicle.Speed * 2.4 >= 88)
                                {
                                    if (refilltimecurcuits)
                                    {
                                        TimeCircuits.timetravelentry();
                                        refilltimecurcuits = false;
                                        Timetravelreenterycutscene.Play();
                                        //Function.Call(Hash.SET_CLOCK_DATE, TimeCircuits.getmonth(), TimeCircuits.getday(), TimeCircuits.getyear());
                                        //Function.Call(Hash.SET_CLOCK_TIME, TimeCircuits.gethour(), TimeCircuits.getminute(), 0);
                                        Deloreonstealer.IsVisible = false;
                                        Deloreon.IsVisible = false;
                                        Game.Player.WantedLevel = 5;
                                    }
                                }
                                else
                                {
                                    if (past84)
                                    {
                                        sparks.Stop();
                                        past84 = false;
                                    }
                                }
                            }
                        }
                        else if (Game.Player.Character.IsInVehicle(Deloreon))
                        {
                            Deloreonfunctioning();
                        }
                    }
                }
            }
        }
    }
}
