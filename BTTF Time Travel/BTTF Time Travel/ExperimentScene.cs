using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTF_Time_Travel
{
    class ExperimentScene:Variableclass
    {
        static Constanttimerclass delay = new Constanttimerclass();

        #region Variables
        static bool tasksent = false;
        static bool runonce = false;
        static bool sayshi = false;
        static bool reentry = false;
        static bool ExperimentwithEinstein = false;
        static public bool Docwithremote = false;
        static bool Libeadsappear = false;
        static SoundPlayer DeloreonEnter = new SoundPlayer(Properties.Resources.DeloreonEnterScene);
        static SoundPlayer Experimentstart = new SoundPlayer(Properties.Resources.YouMadeItScene);
        static SoundPlayer Experimentstartintro = new SoundPlayer(Properties.Resources.TestIntroScene);
        static SoundPlayer Experimentstartwithremote = new SoundPlayer(Properties.Resources.TestwithDogScene);
        static SoundPlayer Experimentstartwithreentry = new SoundPlayer(Properties.Resources.ReentryScene);
        static SoundPlayer Experimentsuccess = new SoundPlayer(Properties.Resources.Testsuccess);
        static SoundPlayer Libeads = new SoundPlayer(Properties.Resources.LibeadsenterScene);
        public static bool possiondisplay = false;
        #endregion

        static Vehicle Docstruck;

        public static void CreateDeloreonintruck(Vector3 truckposition)
        {
            if (!(Docstruck == null))
            {
                Docstruck.Delete();
            }
            Model gmcvan = new Model("GMCVAN");
            if (gmcvan.IsValid)
            {
                Docstruck = World.CreateVehicle(gmcvan, truckposition);
                Docstruck.Rotation = new Vector3(0, 0, 102);
                Docstruck.OpenDoor(VehicleDoor.Trunk, false, true);

                Vector3 position = Docstruck.GetOffsetInWorldCoords(new Vector3(0, -10, 0));

                TimeTravel.instantDelorean.Deloreanlist.Add(new TimeCircuits());
                TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon = World.CreateVehicle(new Model("BTTF"), position);
                TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.Rotation = new Vector3(0, 0, 102);
                TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.IsInvincible = true;
                TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.CanBeVisiblyDamaged = false;
                if (!(Doc == null))
                {
                    Doc.Delete();
                }
                Doc = TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.CreatePedOnSeat(VehicleSeat.Driver, new Model("S_M_M_Doctor_01"));
                Doc.RelationshipGroup = (int)Relationship.Companion;

                Einstein = World.CreatePed(PedHash.Chop, Docstruck.GetOffsetInWorldCoords(new Vector3(-20, 0, 0)));
                Einstein.RelationshipGroup = (int)Relationship.Companion;
                Einstein.IsInvincible = true;

                TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.DirtLevel = 0;
                TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.NumberPlate = "OutATime";
            }
        }
        /*
        public static void CreateDeloreoninbuilding(Vector3 position)
        {
            if (!(Doc == null))
            {
                Doc.Delete();
            }
            Doc = car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Scientist01SMM);
            Doc.RelationshipGroup = (int)Relationship.Companion;

            if (!(Einstein == null))
            {
                Einstein.Delete();
            }
            Einstein = World.CreatePed(PedHash.Chop, car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(-20, 0, 0)));
            Einstein.RelationshipGroup = (int)Relationship.Companion;
            Einstein.IsInvincible = true;

            car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.DirtLevel = 0;
            car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.CustomPrimaryColor = Color.Silver;
            car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.CustomSecondaryColor = Color.Black;
            car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.NumberPlate = "OutATime";
            DocsExparamentstart = true;
            delay.Reset();

        }
        */
        #region Doc
        static public Ped Doc;
        static public Ped Einstein;
        #endregion

        static Blip posblip;
        static bool isintruck = true;
        static bool driveonce = false;
        static bool pressede = false;
        static public void tick()
        {
            UIText Instruct = new UIText("delay: " + delay.getdelay(), new Point(400, 300), (float)0.9);
            Instruct.Draw();

            try
            {
                if (isintruck)
                {
                    if (TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.IsInRangeOf(Docstruck.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), (float)2.6))
                    {
                        Docstruck.CloseDoor(VehicleDoor.Trunk, true);
                        isintruck = false;
                        DocsExparamentstart = true;
                        delay.Reset();
                    }
                    else
                    {
                        if (!driveonce)
                        {
                            Doc.Task.DriveTo(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon, Docstruck.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), 1, 10);
                            driveonce = true;
                        }
                    }
                }
            }
            catch
            {

            }

            if (DocsExparamentstart)
            {
                if (!tasksent)
                {
                    if (Game.Player.Character.IsInRangeOf(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), (float)20.8))
                    {
                        if (!runonce)
                        {
                            loction.Remove();
                            loction = null;
                            tasksent = true;
                            runonce = true;
                            delay.Start();
                            DeloreonEnter.Play();
                        }
                    }
                    if (Game.Player.Character.IsInRangeOf(Doc.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), (float)24.8))
                    {
                        Einstein.Task.RunTo(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 2, 0)));
                    }
                }
                else if (tasksent)
                {
                    tasksent = false;
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.Repair();
                }

                if (delay.getdelay() == 24.5)
                {
                    Docstruck.OpenDoor(VehicleDoor.Trunk, false, false);
                }
                else if (delay.getdelay() >= 74)
                {
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.EngineRunning = false;
                    if (delay.getdelay() >= 68)
                    {
                        Doc.Task.LeaveVehicle(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon, false);
                        DocsExparamentstart = false;
                        runonce = false;
                        //sayshi = true;
                        delay.Stop();
                        delay.Reset();
                    }
                }
                else if (delay.getdelay() >= 38 && delay.getdelay() <= 60)
                {
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.Speed = (float)-0.9;
                }
            }
            else if (sayshi)
            {
                if (Game.Player.Character.IsInRangeOf(Doc.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), (float)3.8))
                {
                    Doc.Task.LookAt(Game.Player.Character);
                    if (!runonce)
                    {
                        Experimentstart.Play();
                        runonce = true;
                        delay.Start();
                    }
                }

                if (delay.getdelay() >= 7)
                {
                    delay.Stop();
                    delay.Reset();
                    runonce = false;
                    ExperimentwithEinstein = true;
                    sayshi = false;
                }
            }
            else if (ExperimentwithEinstein)
            {
                UI.ShowSubtitle("Experiment with Einstein is on");
                if (Game.IsKeyPressed(Keys.Up))
                {
                    Doc.Task.LookAt(Game.Player.Character);
                    if (!runonce)
                    {
                        runonce = true;
                        delay.Start();
                    }
                }

                if (delay.getdelay() == 0)
                {
                    UIText Instruct2 = new UIText("Take out phone and open the camera app", new Point(400, 300), (float)0.9);
                    Instruct2.Draw();
                }
                else if (delay.getdelay() == 5)
                {
                    Experimentstartintro.Play();
                }
                else if (delay.getdelay() < 35)
                {
                    if (delay.getdelay() == 18)
                    {
                        Einstein.Task.RunTo(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(-5, -4, 0)), true, 10);
                        Einstein.Task.RunTo(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(-3, 0, 0)), true, 10);
                    }
                    else if (delay.getdelay() == 24)
                    {
                        if (Einstein.IsInVehicle(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon))
                        {
                            delay.Resume();
                            Einstein.Task.ClearAll();
                        }
                        else
                        {
                            delay.Pause();
                            Einstein.Task.ClearAll();
                            Einstein.Task.WarpIntoVehicle(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon, VehicleSeat.Driver);
                        }
                    }
                }
                else if (delay.getdelay() >= 36)
                {
                    delay.Stop();
                    delay.Reset();
                    runonce = false;
                    //Docwithremote = true;
                    ExperimentwithEinstein = false;
                    Einstein.Task.ClearAll();
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.EngineRunning = true;
                }
            }
            else if (Docwithremote)
            {
                UI.ShowSubtitle("Remote with doc is on");
                try
                {
                    if (!pressede)
                        if (!TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].RCmode)
                        {
                            UIText Instruct2 = new UIText("Switch to Remote Control Mode in the menu. Have it set the Car " + TimeTravel.instantDelorean.Deloreanlist.Count, new Point(400, 300), (float)0.9);
                            Instruct2.Draw();
                        }
                        else if (TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].RCmode)
                        {
                            if (!runonce)
                            {
                                posblip = World.CreateBlip(Docstruck.GetOffsetInWorldCoords(new Vector3(0, -250, 0)), 5);
                                posblip.Color = BlipColor.Yellow;
                                runonce = true;
                            }
                            UIText Instruct2 = new UIText("Press E when Ready", new Point(400, 300), (float)0.9);
                            Instruct2.Draw();
                        }

                    if (Game.IsKeyPressed(Keys.E))
                    {
                        if (runonce)
                        {
                            runonce = false;
                            Experimentstartwithremote.Play();
                            delay.Start();
                        }
                    }
                    else if (delay.getdelay() >= 10 && delay.getdelay() <= 24)
                    {
                        TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.Speed = 0;
                    }
                    else if (delay.getdelay() >= 25 && delay.getdelay() <= 62)
                    {
                        if (TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.Speed < 46)
                        {
                            TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.PlaceOnGround();
                            TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.Speed += (float)0.1;
                        }
                    }
                    else if (delay.getdelay() == 58)
                    {
                        TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.IsVisible = false;
                    }
                    else if (delay.getdelay() == 59)
                    {
                        TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.Speed = 0;
                        TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].ifwentoutoffcar = true;
                        TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].RCmode = false;
                    }
                    else if (delay.getdelay() == 60)
                    {
                        Experimentsuccess.Play();
                    }
                    else if (delay.getdelay() == 62)
                    {
                        TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].RCmodeenabled = true;
                    }
                    else if (delay.getdelay() == 114)
                    {
                        Einstein = TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Chop);
                        delay.Stop();
                        delay.Reset();
                        Experimentstartwithreentry.Play();
                        Docwithremote = false;
                        reentry = true;
                    }
                }
                catch (Exception e)
                {
                    UI.ShowSubtitle(e.Message + " " + e.Source);
                }

                
            }
            else if (reentry)
            {
                if (delay.getdelay() == 0)
                {
                    delay.Start();
                }
                else if (delay.getdelay() == 3)
                {
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.Position = Doc.GetOffsetInWorldCoords(new Vector3(3, -18, 0));
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.Rotation = Docstruck.Rotation;
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.Speed = 30;
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.IsVisible = true;
                }
                else if (delay.getdelay() < 4 && delay.getdelay() > 26)
                {
                    if (TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.Speed > 0)
                    {
                        TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.Speed -= (float)0.1;
                    }
                    World.AddExplosion(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), ExplosionType.Car, 10, 0);
                }
                else if (delay.getdelay() == 26)
                {
                    World.AddExplosion(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), ExplosionType.Car, 14, 0);

                    World.AddExplosion(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), ExplosionType.Car, 14, 0);

                }
                else if (delay.getdelay() < 40)
                {
                    World.AddExplosion(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), ExplosionType.Car, 10, 0);
                }
                else if (delay.getdelay() == 40)
                {
                    Doc.Task.RunTo(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3((float)-2.5, 0, 0)));
                }
                else if (delay.getdelay() == 51)
                {
                    Doc.Task.EnterVehicle(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon, VehicleSeat.Driver);
                }
                else if (delay.getdelay() == 52)
                {
                    Doc.Task.ClearAll();
                }
                else if (delay.getdelay() == 58)
                {
                    Einstein.Task.LeaveVehicle();
                }
                else if (delay.getdelay() == 80)
                {
                    Doc.Task.EnterVehicle(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon, VehicleSeat.Driver);
                }
                else if (delay.getdelay() >= 84 && delay.getdelay() < 124)
                {
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].toggletimecurcuits = true;

                    if (delay.getdelay() >= 98)
                    {
                        TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Settime(0, 4, 0, 7, 1, 7, 7, 6, 0, 8, 1, 2, "am");
                    }
                    if (delay.getdelay() >= 103)
                    {
                        TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Settime(2, 5, 1, 2, 0, 0, 0, 0, 1, 1, 1, 2, "am");
                    }
                    if (delay.getdelay() >= 110)
                    {
                        TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Settime(0, 5, 0, 9, 1, 9, 5, 5, 1, 1, 1, 2, "am");
                    }
                }
                else if (delay.getdelay() == 124)
                {
                    TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].toggletimecurcuits = false;
                    delay.Stop();
                    delay.Reset();
                    reentry = false;
                    Libeadsappear = true;
                    Doc.Task.LeaveVehicle(TimeTravel.instantDelorean.Deloreanlist[TimeTravel.instantDelorean.Deloreanlist.Count - 1].Deloreon, true);
                }
            }
            else if (Libeadsappear)
            {

            }
            delay.Delay_changer();
        }
        /*
        static public void tick2()
        {
            try
            {
                if (possiondisplay)
                {
                    UIText Instruct = new UIText("delay: " + delay.getdelay() + " X: " + car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Position.X.ToString() + " Y: " + car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Position.Y.ToString() + " Z: " + car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Position.Z.ToString()
                        + Environment.NewLine + " rx: " + car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Rotation.X + " ry: " + car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Rotation.Y + " rz: " + car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Rotation.Z, new Point(400, 400), (float)0.9);
                    Instruct.Draw();
                }
            }
            catch
            {

            }


            if (DocsExparamentstart)
            {
                if (!tasksent)
                {
                    if (Game.Player.Character.IsInRangeOf(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), (float)30.8))
                    {
                        if (!runonce)
                        {
                            loction.Remove();
                            loction = null;
                            tasksent = true;
                            runonce = true;
                            delay.Start();
                            DeloreonEnter.Play();
                        }
                    }
                    if (Game.Player.Character.IsInRangeOf(Doc.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), (float)24.8))
                    {
                        Einstein.Task.RunTo(Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0, 2, 0)));
                    }
                }
                else if (tasksent)
                {
                    tasksent = false;
                    car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Repair();
                }

                if (delay.getdelay() == 18)
                {

                }
                else if (delay.getdelay() >= 45)
                {
                    car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.EngineRunning = false;
                    if (delay.getdelay() >= 52)
                    {
                        Doc.Task.LeaveVehicle(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon, false);
                        DocsExparamentstart = false;
                        runonce = false;
                        sayshi = true;
                        delay.Stop();
                        delay.Reset();
                    }
                }
                else if (delay.getdelay() >= 28)
                {
                    car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Speed = (float)-2;
                }
            }
            else if (sayshi)
            {
                if (Game.Player.Character.IsInRangeOf(Doc.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), (float)3.8))
                {
                    Doc.Task.LookAt(Game.Player.Character);
                    if (!runonce)
                    {
                        Experimentstart.Play();
                        runonce = true;
                        delay.Start();
                    }
                }

                if (delay.getdelay() >= 7)
                {
                    delay.Stop();
                    delay.Reset();
                    runonce = false;
                    ExperimentwithEinstein = true;
                    sayshi = false;
                }
            }
            else if (ExperimentwithEinstein)
            {
                if (Game.IsKeyPressed(Keys.Up))
                {
                    Doc.Task.LookAt(Game.Player.Character);
                    if (!runonce)
                    {
                        runonce = true;
                        delay.Start();
                    }
                }

                if (delay.getdelay() == 0)
                {
                    UIText Instruct2 = new UIText("Take out phone and open the camera app", new Point(400, 300), (float)0.9);
                    Instruct2.Draw();
                }
                else if (delay.getdelay() == 5)
                {
                    Experimentstartintro.Play();
                }
                else if (delay.getdelay() < 35)
                {
                    if (delay.getdelay() == 18)
                    {
                        Einstein.Task.RunTo(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(-5, -4, 0)), true, 10);
                        Einstein.Task.RunTo(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(-3,0,0)), true, 10);
                    }
                    else if (delay.getdelay() == 24)
                    {
                        if (Einstein.IsInVehicle(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon))
                        {
                            delay.Resume();
                            Einstein.Task.ClearAll();
                        }
                        else
                        {
                            delay.Pause();
                            Einstein.Task.ClearAll();
                            Einstein.Task.WarpIntoVehicle(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon, VehicleSeat.Driver);
                        }
                    }
                }
                else if (delay.getdelay() >= 36)
                {

                    delay.Stop();
                    delay.Reset();
                    runonce = false;
                    Docwithremote = true;
                    ExperimentwithEinstein = false;
                    Einstein.Task.ClearAll();

                    //RCmodeenabled = false;
                }
            }
            else if (Docwithremote)
            {
                if (car.Deloreanlist[car.Deloreanlist.Count - 1].RCmode)
                {
                    if (!runonce)
                    {
                        runonce = true;
                    }
                }
                else
                {
                    UIText Instruct2 = new UIText("Switch to Remote Control Mode \"T\"", new Point(400, 300), (float)0.9);
                    Instruct2.Draw();
                }

                if (Game.Player.Character.IsInRangeOf(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(-250, 0, 0)), 90))
                {
                    if (runonce)
                    {
                        runonce = false;
                        Experimentstartwithremote.Play();
                        delay.Start();
                    }
                }
                else if (delay.getdelay() >= 10 && delay.getdelay() <= 24)
                {
                    car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Speed = 0;
                }
                else if (delay.getdelay() >= 25 && delay.getdelay() <= 62)
                {
                    if (car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Speed < 46)
                    {
                        car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.PlaceOnGround();
                        car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Speed += (float)0.1;
                    }
                }
                else if (delay.getdelay() == 58)
                {
                    car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.IsVisible = false;
                }
                else if (delay.getdelay() == 59)
                {
                    car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Speed = 0;
                    car.Deloreanlist[car.Deloreanlist.Count - 1].ifwentoutoffcar = true;
                    car.Deloreanlist[car.Deloreanlist.Count - 1].RCmode = false;
                }
                else if (delay.getdelay() == 60)
                {
                    Experimentsuccess.Play();
                }
                else if (delay.getdelay() == 62)
                {
                    car.Deloreanlist[car.Deloreanlist.Count - 1].RCmodeenabled = true;
                }
                else if (delay.getdelay() == 114)
                {
                    Einstein = car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Chop);
                    delay.Stop();
                    delay.Reset();
                    Experimentstartwithreentry.Play();
                    Docwithremote = false;
                    reentry = true;
                }
            }
            else if (reentry)
            {
                if (delay.getdelay() == 0)
                {
                    delay.Start();
                }
                else if (delay.getdelay() == 3)
                {
                    car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Position = Doc.GetOffsetInWorldCoords(new Vector3(3,-18,0));
                    car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Rotation = Doc.Rotation;
                    car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Speed = 30;
                    car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.IsVisible = true;
                }
                else if (delay.getdelay() < 4 && delay.getdelay() > 26)
                {
                    if (car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Speed > 0)
                    {
                        car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.Speed -= (float)0.1;
                    }
                    World.AddExplosion(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), ExplosionType.SmokeG, 10, 0);
                }
                else if (delay.getdelay() == 26)
                {
                    World.AddExplosion(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), ExplosionType.SmokeG, 14, 0);

                    World.AddExplosion(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), ExplosionType.SmokeG, 14, 0);

                }
                else if (delay.getdelay() < 40)
                {
                    World.AddExplosion(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), ExplosionType.SmokeG, 10, 0);
                }
                else if (delay.getdelay() == 40)
                {
                    Doc.Task.RunTo(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon.GetOffsetInWorldCoords(new Vector3((float)-2.5,0,0)));
                }
                else if (delay.getdelay() == 51)
                {
                    Doc.Task.EnterVehicle(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon, VehicleSeat.Driver);
                }
                else if (delay.getdelay() == 52)
                {
                    Doc.Task.ClearAll();
                }
                else if (delay.getdelay() == 58)
                {
                    Einstein.Task.LeaveVehicle();
                }
                else if (delay.getdelay() == 80)
                {
                    Doc.Task.EnterVehicle(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon, VehicleSeat.Driver);
                }
                else if (delay.getdelay() >= 84 && delay.getdelay() < 124)
                {
                    car.Deloreanlist[car.Deloreanlist.Count - 1].toggletimecurcuits = true;

                    if (delay.getdelay() >= 98)
                    {
                        car.Deloreanlist[car.Deloreanlist.Count - 1].Settime(0, 4, 0, 7, 1, 7, 7, 6, 0, 8, 1, 2, "am");
                    }
                    if (delay.getdelay() >= 103)
                    {
                        car.Deloreanlist[car.Deloreanlist.Count - 1].Settime(2, 5, 1, 2, 0, 0, 0, 0, 1, 1, 1, 2, "am");
                    }
                    if (delay.getdelay() >= 110)
                    {
                        car.Deloreanlist[car.Deloreanlist.Count - 1].Settime(0, 5, 0, 9, 1, 9, 5, 5, 1, 1, 1, 2, "am");
                    }
                }
                else if (delay.getdelay() == 124)
                {
                    car.Deloreanlist[car.Deloreanlist.Count - 1].toggletimecurcuits = false;
                    delay.Stop();
                    delay.Reset();
                    reentry = false;
                    Libeadsappear = true;
                    Doc.Task.LeaveVehicle(car.Deloreanlist[car.Deloreanlist.Count - 1].Deloreon, true);
                }
            }
            else if (Libeadsappear)
            {

            }
        }
        */
    }
}
