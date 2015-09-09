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
    class Deloreonfunctions2 : Variableclass
    {
        public static void CreateDeloreon()
        {
            Plut.Play();

            Vector3 position = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 5, 0));

            // At 90 degrees to the players heading
            float heading = Game.Player.Character.Heading - 90;

            if (!(Deloreon2 == null))
            {
                Deloreon2.Delete();
            }
            Deloreon2 = World.CreateVehicle(VehicleHash.Ruiner, position, heading);
            Deloreon2.IsInvincible = true;

            deloreonspoawned2 = true;

            Deloreon2.DirtLevel = 0;
            Deloreon2.CustomPrimaryColor = Color.Silver;
            Deloreon2.CustomSecondaryColor = Color.Black;
            Deloreon2.NumberPlate = "OutATime";

            Deloreon2.PlaceOnGround();
        }

        public static void RetreiveDeloreon()
        {
            if (!(Deloreon2 == null))
            {
                Deloreonretreiver2 = Deloreon2.CreatePedOnSeat(VehicleSeat.Driver, Game.Player.Character.Model);
                Deloreon2.Repair();
                Deloreon2.PlaceOnGround();
                Deloreonretreiver2.AddBlip();
                Deloreonretreiver2.Task.DriveTo(Deloreon2, Game.Player.Character.GetOffsetInWorldCoords(new Vector3(-5, 0, 0)), 0, 100, 1);
                retreive2 = true;
            }

        }

        public static void toggletimesurcuitsswitch()
        {
            if (Game.Player.Character.IsInVehicle())
            {
                if (!(Deloreon2 == null))
                {
                    if (Game.Player.Character.CurrentVehicle == Deloreon2)
                    {
                        toggletimecurcuits2 = !toggletimecurcuits2;
                        if (toggletimecurcuits2)
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
        }

        public static void Toggleflight()
        {
            if (Game.Player.Character.IsInVehicle())
            {
                if (!(Deloreon2 == null))
                {
                    if (Game.Player.Character.CurrentVehicle == Deloreon2)
                    {
                        if (flyingison2)
                        {
                            flyingison2 = false;
                            hoveroff.Play();
                            flyheight2 = 0;
                        }
                        else
                        {
                            flycount2 = 0;
                            flyingison2 = true;
                            hoveron.Play();
                        }
                    }
                }
            }
        }

        public static void ToggleMrfusion()
        {
            if (Game.Player.Character.IsInVehicle())
            {
                if (!(Deloreon2 == null))
                {
                    if (Game.Player.Character.CurrentVehicle == Deloreon2)
                    {
                        if (!refilltimecurcuits2)
                        {
                            refilltimecurcuits2 = true;
                            Mrfrefill.Play();
                            mrfopened2 = true;
                        }
                    }
                }
            }
        }

        public static void ToggleEngine()
        {
            if (Game.Player.Character.IsInVehicle())
            {
                if (!(Deloreon2 == null))
                {
                    if (Game.Player.Character.CurrentVehicle == Deloreon2)
                    {
                        if (!engineison2)
                        {
                            engineon.Play();
                            Function.Call(Hash.SET_VEHICLE_ENGINE_ON, Game.Player.Character.CurrentVehicle, true, true);
                            engineturningon2 = true;
                            engineison2 = true;
                        }
                        else
                        {
                            engineoff.Play();
                            Function.Call(Hash.SET_VEHICLE_ENGINE_ON, Game.Player.Character.CurrentVehicle, false, false);
                            engineturningon2 = false;
                            engineison2 = false;
                        }
                    }
                }
            }
        }

        public static void Flighthight(int num)
        {
            flyheight2 += num;
        }

        public static void Check()
        {
            if (Game.Player.Character.IsGettingIntoAVehicle)
            {
                if (!(Deloreon2 == null))
                {
                    carjustdied2 = false;
                }
            }
            else if (Game.Player.Character.IsInVehicle() || RCmode2)
            {
                if (!(Deloreon2 == null))
                {
                    if (Game.Player.Character.CurrentVehicle == Deloreon2)
                    {
                        if (toggletimecurcuits2)
                        {
                            Timedisplayf2 = new UIText(TimeCircuits.timedisplayfuture(), new Point(700, 350), 1, Color.Red);
                            Timedisplaypres2 = new UIText(TimeCircuits.timedisplaypresent(), new Point(700, 390), 1, Color.Green);
                            Timedisplaypast2 = new UIText(TimeCircuits.timedisplaypast(), new Point(700, 430), 1, Color.Yellow);

                            Timedisplayf2.Draw();
                            Timedisplaypres2.Draw();
                            Timedisplaypast2.Draw();
                        }

                        if (flyingison2)
                        {
                            if (flyheight2 > 0)
                            {
                                flyheight2--;
                                if (flycount2 >= 30)
                                {
                                    Deloreon2.ApplyForce(Deloreon2.GetOffsetInWorldCoords(new Vector3(0, 0, flyheight2)));
                                }
                                else
                                {
                                    flycount2++;
                                    flyheight2 = 2;
                                    Deloreon2.ApplyForce(Deloreon2.GetOffsetInWorldCoords(new Vector3(0, 0, flyheight2)));
                                }
                            }

                        }

                        if (!engineturningon2)
                        {
                            if (!engineison2)
                            {
                                engineon.Play();
                                ifegnineturnedon2 = true;
                                engineison2 = true;
                                engineturningon2 = true;
                                ifwentoutoffcar2 = false;
                                Function.Call(Hash.SET_VEHICLE_ENGINE_ON, Game.Player.Character.CurrentVehicle, true);
                            }
                        }

                        if (!Game.Player.Character.CurrentVehicle.IsDriveable)
                        {
                            if (!carjustdied2)
                            {
                                carjustdied2 = true;
                                trend.Play();
                                Deloreon2 = null;
                                Game.Player.Character.CurrentVehicle.Detach();
                                engineison2 = false;
                                ifwentoutoffcar2 = true;
                            }
                        }


                        if (mrfopened2)
                        {
                            if (timemrfisopen2 == 70)
                            {
                                Function.Call(Hash.SET_VEHICLE_DOOR_OPEN, Game.Player.Character.CurrentVehicle, 5, false, false);
                                timemrfisopen2--;
                            }
                            else if (timemrfisopen2 <= 0)
                            {
                                Function.Call(Hash.SET_VEHICLE_DOOR_SHUT, Game.Player.Character.CurrentVehicle, 5, false);
                                mrfopened2 = false;
                                timemrfisopen2 = 70;
                            }
                            else
                            {
                                timemrfisopen2--;
                            }
                        }

                        if (toggletimecurcuits2)
                        {
                            if (Game.Player.Character.CurrentVehicle.Speed * 2.4 > 84 && Game.Player.Character.CurrentVehicle.Speed * 2.4 < 88)
                            {
                                if (!past842)
                                {
                                    if (refilltimecurcuits2)
                                    {
                                        sparksfeul.PlayLooping();
                                    }
                                    else
                                    {
                                        sparks.PlayLooping();
                                    }
                                    past842 = true;
                                }
                            }
                            else if (Game.Player.Character.CurrentVehicle.Speed * 2.4 >= 88)
                            {
                                if (refilltimecurcuits2)
                                {
                                    TimeCircuits.timetravelentry();
                                    refilltimecurcuits2 = false;
                                    Timetravelreentery.Play();
                                    Function.Call(Hash.SET_CLOCK_DATE, TimeCircuits.getmonth(), TimeCircuits.getday(), TimeCircuits.getyear());
                                    Function.Call(Hash.SET_CLOCK_TIME, TimeCircuits.gethour(), TimeCircuits.getminute(), 0);
                                    if (Game.Player.WantedLevel > 0)
                                    {
                                        Game.Player.WantedLevel = 0;
                                    }
                                }

                                if (!(Deloreonstealer == null))
                                {
                                    Deloreonstealer.IsVisible = true;
                                    Deloreon.IsVisible = true;
                                }
                            }
                            else
                            {
                                if (past842)
                                {
                                    sparks.Stop();
                                    past842 = false;
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}

