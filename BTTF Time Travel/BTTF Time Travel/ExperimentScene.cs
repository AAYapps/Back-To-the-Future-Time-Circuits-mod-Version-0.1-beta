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

        static Delorean_class car = new Delorean_class();

        public static void CreateDeloreoninbuilding(Vector3 position)
        {
            if (!(car.Deloreon == null))
            {
                car.Deloreon.Delete();
            }
            car.Deloreon = World.CreateVehicle(VehicleHash.Dune2, position);
            car.Deloreon.Rotation = new Vector3(0, 0, 102 - 90);
            car.Deloreon.IsInvincible = true;
            car.Deloreon.CanBeVisiblyDamaged = false;
            if (!(Doc == null))
            {
                Doc.Delete();
            }
            Doc = car.Deloreon.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Scientist01SMM);
            Doc.RelationshipGroup = (int)Relationship.Companion;

            if (!(Einstein == null))
            {
                Einstein.Delete();
            }
            Einstein = World.CreatePed(PedHash.Chop, car.Deloreon.GetOffsetInWorldCoords(new Vector3(-20, 0, 0)));
            Einstein.RelationshipGroup = (int)Relationship.Companion;
            Einstein.IsInvincible = true;

            car.Deloreon.DirtLevel = 0;
            car.Deloreon.CustomPrimaryColor = Color.Silver;
            car.Deloreon.CustomSecondaryColor = Color.Black;
            car.Deloreon.NumberPlate = "OutATime";
            DocsExparamentstart = true;
            delay.Reset();
        }

        #region Doc
        static public Ped Doc;
        static public Ped Einstein;
        #endregion

        static public void tick()
        {
            try
            {
                if (possiondisplay)
                {
                    UIText Instruct = new UIText("delay: " + delay.getdelay() + " X: " + car.Deloreon.Position.X.ToString() + " Y: " + car.Deloreon.Position.Y.ToString() + " Z: " + car.Deloreon.Position.Z.ToString()
                        + Environment.NewLine + " rx: " + car.Deloreon.Rotation.X + " ry: " + car.Deloreon.Rotation.Y + " rz: " + car.Deloreon.Rotation.Z, new Point(400, 400), (float)0.9);
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
                    if (Game.Player.Character.IsInRangeOf(car.Deloreon.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), (float)30.8))
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
                    car.Deloreon.Repair();
                }

                if (delay.getdelay() == 18)
                {

                }
                else if (delay.getdelay() >= 45)
                {
                    car.Deloreon.EngineRunning = false;
                    if (delay.getdelay() >= 52)
                    {
                        Doc.Task.LeaveVehicle(car.Deloreon, false);
                        DocsExparamentstart = false;
                        runonce = false;
                        sayshi = true;
                        delay.Stop();
                        delay.Reset();
                    }
                }
                else if (delay.getdelay() >= 28)
                {
                    car.Deloreon.Speed = (float)-2;
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
                        Einstein.Task.RunTo(car.Deloreon.GetOffsetInWorldCoords(new Vector3(-5, -4, 0)), true, 10);
                        Einstein.Task.RunTo(car.Deloreon.GetOffsetInWorldCoords(new Vector3(-3,0,0)), true, 10);
                    }
                    else if (delay.getdelay() == 24)
                    {
                        if (Einstein.IsInVehicle(car.Deloreon))
                        {
                            delay.Resume();
                            Einstein.Task.ClearAll();
                        }
                        else
                        {
                            delay.Pause();
                            Einstein.Task.ClearAll();
                            Einstein.Task.WarpIntoVehicle(car.Deloreon, VehicleSeat.Driver);
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
                if (car.RCmode)
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

                if (Game.Player.Character.IsInRangeOf(car.Deloreon.GetOffsetInWorldCoords(new Vector3(-250, 0, 0)), 90))
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
                    car.Deloreon.Speed = 0;
                }
                else if (delay.getdelay() >= 25 && delay.getdelay() <= 62)
                {
                    if (car.Deloreon.Speed < 46)
                    {
                        car.Deloreon.PlaceOnGround();
                        car.Deloreon.Speed += (float)0.1;
                    }
                }
                else if (delay.getdelay() == 58)
                {
                    car.Deloreon.IsVisible = false;
                }
                else if (delay.getdelay() == 59)
                {
                    car.Deloreon.Speed = 0;
                    car.ifwentoutoffcar = true;
                    car.RCmode = false;
                }
                else if (delay.getdelay() == 60)
                {
                    Experimentsuccess.Play();
                }
                else if (delay.getdelay() == 62)
                {
                    car.RCmodeenabled = true;
                }
                else if (delay.getdelay() == 114)
                {
                    Einstein = car.Deloreon.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Chop);
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
                    car.Deloreon.Position = Doc.GetOffsetInWorldCoords(new Vector3(3,-18,0));
                    car.Deloreon.Rotation = Doc.Rotation;
                    car.Deloreon.Speed = 30;
                    car.Deloreon.IsVisible = true;
                }
                else if (delay.getdelay() < 4 && delay.getdelay() > 26)
                {
                    if (car.Deloreon.Speed > 0)
                    {
                        car.Deloreon.Speed -= (float)0.1;
                    }
                    World.AddExplosion(car.Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), ExplosionType.SmokeG, 10, 0);
                }
                else if (delay.getdelay() == 26)
                {
                    World.AddExplosion(car.Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), ExplosionType.SmokeG, 14, 0);

                    World.AddExplosion(car.Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), ExplosionType.SmokeG, 14, 0);

                }
                else if (delay.getdelay() < 40)
                {
                    World.AddExplosion(car.Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), ExplosionType.SmokeG, 10, 0);
                }
                else if (delay.getdelay() == 40)
                {
                    Doc.Task.RunTo(car.Deloreon.GetOffsetInWorldCoords(new Vector3((float)-2.5,0,0)));
                }
                else if (delay.getdelay() == 51)
                {
                    Doc.Task.EnterVehicle(car.Deloreon, VehicleSeat.Driver);
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
                    Doc.Task.EnterVehicle(car.Deloreon, VehicleSeat.Driver);
                }
                else if (delay.getdelay() >= 84 && delay.getdelay() < 124)
                {
                    car.toggletimecurcuits = true;

                    if (delay.getdelay() >= 98)
                    {
                        car.Settime(0, 4, 0, 7, 1, 7, 7, 6, 0, 8, 1, 2, "am");
                    }
                    if (delay.getdelay() >= 103)
                    {
                        car.Settime(2, 5, 1, 2, 0, 0, 0, 0, 1, 1, 1, 2, "am");
                    }
                    if (delay.getdelay() >= 110)
                    {
                        car.Settime(0, 5, 0, 9, 1, 9, 5, 5, 1, 1, 1, 2, "am");
                    }
                }
                else if (delay.getdelay() == 124)
                {
                    car.toggletimecurcuits = false;
                    delay.Stop();
                    delay.Reset();
                    reentry = false;
                    Libeadsappear = true;
                    Doc.Task.LeaveVehicle(car.Deloreon, true);
                }
            }
            else if (Libeadsappear)
            {

            }
        }
    }
}
