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
            Deloreon = null;

            Plut.Play();

            Vector3 position = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 5, 0));

            // At 90 degrees to the players heading
            float heading = Game.Player.Character.Heading - 90;

            Deloreon = World.CreateVehicle(VehicleHash.Dune2, position, heading);

            Variableclass.deloreonspoawned = true;

            Variableclass.Deloreon.IsInvincible = true;
            Variableclass.Deloreon.CanBeVisiblyDamaged = false;

            Deloreon.DirtLevel = 0;
            Deloreon.CustomPrimaryColor = Color.Silver;
            Deloreon.CustomSecondaryColor = Color.Black;
            Deloreon.NumberPlate = "OutATime";
            Deloreon.PlaceOnGround();
        }

        public static void RemoveDelorean()
        {
            Deloreon.Delete();
        }

        public static void CreateDeloreoninbuilding(Vector3 position)
        {
            if (!(Deloreon == null))
            {
                Deloreon.Delete();
            }
            Deloreon = World.CreateVehicle(VehicleHash.Voltic, position);
            Deloreon.Rotation = new Vector3(0, 0, 102 - 90);
            Deloreon.IsInvincible = true;
            Deloreon.CanBeVisiblyDamaged = false;
            if (!(Doc == null))
            {
                Doc.Delete();
            }
            Doc = Deloreon.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Scientist01SMM);
            Doc.RelationshipGroup = (int)Relationship.Companion;

            if (!(Einstein == null))
            {
                Einstein.Delete();
            }
            Einstein = World.CreatePed(PedHash.Chop, Deloreon.GetOffsetInWorldCoords(new Vector3(-20, 0, 0)));
            Einstein.RelationshipGroup = (int)Relationship.Companion;
            Einstein.IsInvincible = true;

            deloreonspoawned = true;

            Deloreon.DirtLevel = 0;
            Deloreon.CustomPrimaryColor = Color.Silver;
            Deloreon.CustomSecondaryColor = Color.Black;
            Deloreon.NumberPlate = "OutATime";
            DocsExparamentstart = true;
            Constanttimerclass.Reset();
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
                        if (refilltimecurcuits)
                        {
                            Constanttimerclass.Start();
                            runoncefeul = true;
                        }
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
                                flyingturnedon = false;
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
        static bool runoncefeul = false;
        static bool flyingturnedon = false;
        static void Deloreonfunctioning()
        {
            if (flyingison)
            {
                if (flycount < 30)
                {
                    if (!flyingturnedon)
                    {
                        flycount++;
                        if (flyheight < 0.6)
                        {
                            flyheight = 0.2;
                        }
                        Deloreon.ApplyForce(new Vector3(0, 0, (float)flyheight));
                        flyingturnedon = true;
                    }
                }

                if (flyingturnedon)
                {
                    if (Deloreon.HeightAboveGround < flyheight)
                    {
                        Deloreon.ApplyForce(new Vector3(0, 0, (float)0.4));
                    }
                    else if (Deloreon.HeightAboveGround > flyheight)
                    {
                        //Deloreon.ApplyForce(new Vector3(0, 0, (float)-0.4));
                    }
                }

                if (Deloreon.Rotation.Z != 0)
                {
                    Deloreon.Velocity = new Vector3(0, 0, 0);
                }

                if (flyheight > 0)
                {
                    if (flyingturnedon)
                    {
                        flyheight -= 0.1;
                        if (!(flyheight > 0.6))
                        {
                            Deloreon.ApplyForce(new Vector3(0, 0, (float)flyheight));
                        }
                    }
                }
                else if (flyheight < 0)
                {
                    if (flyingturnedon)
                    {
                        flyheight += 0.1;
                        if (!(flyheight < 0.6))
                        {
                            Deloreon.ApplyForce(new Vector3(0, 0, (float)-flyheight));
                        }
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
                        //engineon.Play();
                        engine.startsounddelay = true;
                        engine.audioplayed = false;
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

            if (refilltimecurcuits)
            {
                if (runoncefeul)
                {
                    if (Constanttimerclass.getdelay() >= 3)
                    {
                        Constanttimerclass.Stop();
                        Constanttimerclass.Reset();
                        inputonfeul.Play();
                        runoncefeul = false;
                    }
                }
            }

            if (mrfopened)
            {
                if (Constanttimerclass.getdelay() == 0)
                {
                    Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, Game.Player.Character.CurrentVehicle, 5, false, false);
                    Constanttimerclass.Start();
                }
                else if (Constanttimerclass.getdelay() == 5)
                {
                    Function.Call(Hash.SET_VEHICLE_DOOR_SHUT, Game.Player.Character.CurrentVehicle, 5, false);
                    mrfopened = false;
                    Constanttimerclass.Stop();
                    Constanttimerclass.Reset();
                }
            }
            else if (toggletimecurcuits)
            {
                if (!refilltimecurcuits)
                {
                    Mrfusion = new UIText("Empty", new Point(800, 110), 1, Color.Orange);
                    Mrfusion.Draw();
                }
                Timedisplayf = new UIText(TimeCircuits.timedisplayfuture(), new Point(700, 150), 1, Color.Red);
                Timedisplaypres = new UIText(TimeCircuits.timedisplaypresent(), new Point(700, 190), 1, Color.Green);
                Timedisplaypast = new UIText(TimeCircuits.timedisplaypast(), new Point(700, 230), 1, Color.Yellow);
                Timedisplayinput = new UIText(TimeCircuits.timeinputstring, new Point(700, 270), 1, Color.DarkGreen);
                Timedisplayf.Draw();
                Timedisplaypres.Draw();
                Timedisplaypast.Draw();
                Timedisplayinput.Draw();

                if (Game.Player.Character.CurrentVehicle.Speed * 2.4 > 84 && Game.Player.Character.CurrentVehicle.Speed * 2.4 < 88)
                {
                    World.DrawLightWithRange(Variableclass.Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.Cyan, (float)1.2, 300);
                    if (!past84)
                    {
                        if (refilltimecurcuits)
                        {
                            sparksfeul.PlayLooping();
                            Constanttimerclass.Start();
                            Variableclass.Deloreon.IsInvincible = true;
                            Variableclass.Deloreon.CanBeVisiblyDamaged = false;
                        }
                        else
                        {
                            if (!freezing.started)
                            {
                                sparks.PlayLooping();
                            }
                        }
                        past84 = true;
                    }
                }
                else if (Game.Player.Character.CurrentVehicle.Speed * 2.4 >= 88)
                {
                    World.DrawLightWithRange(Variableclass.Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.Cyan, (float)1.2, 300);
                    if (refilltimecurcuits)
                    {
                        if (Constanttimerclass.getdelay() < 5)
                        {
                            if (Constanttimerclass.getdelay() > 2)
                            {  
                                int eplode = (int)ExplosionType.FlameExplode;
                                World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, -2)), (ExplosionType)eplode, (float)1, 0);
                                World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, -2)), (ExplosionType)eplode, (float)1, 0);
                            }
                        }
                        else
                        {
                            World.AddExplosion(Deloreon.Position, ExplosionType.Car, 10, 0);
                            Timetravelreenterycutscene.Play();
                            //Timetravelreentery.Play();
                            Deloreon.Speed = 0;
                            if (!invicible)
                            {
                                Variableclass.Deloreon.IsInvincible = true;
                                Variableclass.Deloreon.CanBeVisiblyDamaged = false;
                            }
                            Deloreon.IsVisible = false;
                            Time_reentry.enterintime();
                            Game.Player.CanControlCharacter = false;
                            Constanttimerclass.Reset();
                            Constanttimerclass.Stop();
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
                        Time_reentry.below48();
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
                            else
                            {
                                Delorean_stealer.start();
                            }
                        }
                        else
                        {
                            Deloreonfunctioning();
                        }
                    }
                }
            }
        }
    }
}
