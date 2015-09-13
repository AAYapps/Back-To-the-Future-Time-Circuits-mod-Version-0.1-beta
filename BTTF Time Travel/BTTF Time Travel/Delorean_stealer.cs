using GTA;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTF_Time_Travel
{
    class Delorean_stealer : Variableclass
    {
        public static void start()
        {
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
                    }
                }
            }
        }
    }
}
