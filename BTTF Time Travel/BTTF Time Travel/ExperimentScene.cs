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
        static Blip posblip;
        public static bool possiondisplay = false;
        #endregion

        static public void tick()
        {
            try
            {
                if (possiondisplay)
                {
                    UIText Instruct = new UIText("delay: " + Constanttimerclass.getdelay() + "X: " + Deloreon.Position.X.ToString() + " Y: " + Deloreon.Position.Y.ToString() + " Z: " + Deloreon.Position.Z.ToString() , new Point(400, 400), (float)0.9);
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
                    if (Game.Player.Character.IsInRangeOf(Deloreon.GetOffsetInWorldCoords(new Vector3(0, 0, 0)), (float)30.8))
                    {
                        if (!runonce)
                        {
                            loction.Remove();
                            loction = null;
                            tasksent = true;
                            runonce = true;
                            Constanttimerclass.Start();
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
                    Deloreon.Repair();
                }

                if (Constanttimerclass.getdelay() == 18)
                {

                }
                else if (Constanttimerclass.getdelay() >= 45)
                {
                    Deloreon.EngineRunning = false;
                    if (Constanttimerclass.getdelay() >= 52)
                    {
                        Doc.Task.LeaveVehicle(Deloreon, false);
                        DocsExparamentstart = false;
                        runonce = false;
                        sayshi = true;
                        Constanttimerclass.Stop();
                        Constanttimerclass.Reset();
                    }
                }
                else if (Constanttimerclass.getdelay() >= 28)
                {
                    Deloreon.Speed = (float)-0.9;
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
                        Constanttimerclass.Start();
                    }
                }

                if (Constanttimerclass.getdelay() >= 7)
                {
                    Constanttimerclass.Stop();
                    Constanttimerclass.Reset();
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
                        Constanttimerclass.Start();
                    }
                }

                if (Constanttimerclass.getdelay() == 0)
                {
                    UIText Instruct2 = new UIText("Take out phone and open the camera app", new Point(400, 300), (float)0.9);
                    Instruct2.Draw();
                }
                else if (Constanttimerclass.getdelay() == 5)
                {
                    Experimentstartintro.Play();
                }
                else if (Constanttimerclass.getdelay() < 35)
                {
                    if (Constanttimerclass.getdelay() == 18)
                    {
                        Einstein.Task.RunTo(Deloreon.GetOffsetInWorldCoords(new Vector3(-5, -4, 0)), true, 10);
                        Einstein.Task.RunTo(Deloreon.GetOffsetInWorldCoords(new Vector3(-3,0,0)), true, 10);
                    }
                    else if (Constanttimerclass.getdelay() == 24)
                    {
                        if (Einstein.IsInVehicle(Deloreon))
                        {
                            Constanttimerclass.Resume();
                            Einstein.Task.ClearAll();
                        }
                        else
                        {
                            Constanttimerclass.Pause();
                            Einstein.Task.ClearAll();
                            Einstein.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                        }
                    }
                }
                else if (Constanttimerclass.getdelay() >= 36)
                {

                    Constanttimerclass.Stop();
                    Constanttimerclass.Reset();
                    runonce = false;
                    Docwithremote = true;
                    ExperimentwithEinstein = false;
                    Einstein.Task.ClearAll();
                    Deloreon.EngineRunning = true;
                    RCmodeenabled = false;
                }
            }
            else if (Docwithremote)
            {
                if (posblip == null)
                {
                    if (RCmode)
                    {
                        if (!runonce)
                        {
                            posblip = World.CreateBlip(Deloreon.GetOffsetInWorldCoords(new Vector3(-250, 0, 0)), 30);
                            posblip.Color = BlipColor.Yellow;
                            runonce = true;
                        }
                    }
                    else
                    {
                        UIText Instruct2 = new UIText("Switch to Remote Control Mode \"T\"", new Point(400, 300), (float)0.9);
                        Instruct2.Draw();
                    }
                }
                else if (Game.Player.Character.IsInRangeOf(Deloreon.GetOffsetInWorldCoords(new Vector3(-250, 0, 0)), 30))
                {
                    if (runonce)
                    {
                        runonce = false;
                        Experimentstartwithremote.Play();
                        Constanttimerclass.Start();
                    }
                }
                else if (Constanttimerclass.getdelay() >= 10 && Constanttimerclass.getdelay() <= 24)
                {
                    Deloreon.Speed = 0;
                }
                else if (Constanttimerclass.getdelay() >= 25 && Constanttimerclass.getdelay() <= 62)
                {
                    if (Deloreon.Speed < 46)
                    {
                        Deloreon.PlaceOnGround();
                        Deloreon.Speed += (float)0.1;
                    }
                }
                else if (Constanttimerclass.getdelay() == 58)
                {
                    Deloreon.IsVisible = false;
                }
                else if (Constanttimerclass.getdelay() == 59)
                {
                    Deloreon.Speed = 0;
                    ifwentoutoffcar = true;
                    RCmode = false;
                }
                else if (Constanttimerclass.getdelay() == 60)
                {
                    Experimentsuccess.Play();
                }
                else if (Constanttimerclass.getdelay() == 62)
                {
                    RCmodeenabled = true;
                }
                else if (Constanttimerclass.getdelay() == 114)
                {
                    Einstein = Deloreon.CreatePedOnSeat(VehicleSeat.Driver, PedHash.Chop);
                    Constanttimerclass.Stop();
                    Constanttimerclass.Reset();
                    Experimentstartwithreentry.Play();
                    Docwithremote = false;
                    reentry = true;
                }
            }
            else if (reentry)
            {
                if (Constanttimerclass.getdelay() == 0)
                {
                    Constanttimerclass.Start();
                }
                else if (Constanttimerclass.getdelay() == 3)
                {
                    Deloreon.Position = Doc.GetOffsetInWorldCoords(new Vector3(3,-18,0));
                    Deloreon.Rotation = Doc.Rotation;
                    Deloreon.Speed = 30;
                    Deloreon.IsVisible = true;
                }
                else if (Constanttimerclass.getdelay() < 4 && Constanttimerclass.getdelay() > 26)
                {
                    if (Deloreon.Speed > 0)
                    {
                        Deloreon.Speed -= (float)0.1;
                    }
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), ExplosionType.SmokeG, 10, 0);
                }
                else if (Constanttimerclass.getdelay() == 26)
                {
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), ExplosionType.SmokeG, 14, 0);

                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), ExplosionType.SmokeG, 14, 0);

                }
                else if (Constanttimerclass.getdelay() < 40)
                {
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), ExplosionType.SmokeG, 10, 0);
                }
                else if (Constanttimerclass.getdelay() == 40)
                {
                    Doc.Task.RunTo(Deloreon.GetOffsetInWorldCoords(new Vector3((float)-2.5,0,0)));
                }
                else if (Constanttimerclass.getdelay() == 51)
                {
                    Doc.Task.EnterVehicle(Deloreon, VehicleSeat.Driver);
                }
                else if (Constanttimerclass.getdelay() == 52)
                {
                    Doc.Task.ClearAll();
                }
                else if (Constanttimerclass.getdelay() == 58)
                {
                    Einstein.Task.LeaveVehicle();
                }
                else if (Constanttimerclass.getdelay() == 80)
                {
                    Doc.Task.EnterVehicle(Deloreon, VehicleSeat.Driver);
                }
                else if (Constanttimerclass.getdelay() >= 84 && Constanttimerclass.getdelay() < 124)
                {
                    toggletimecurcuits = true;

                    if (Constanttimerclass.getdelay() >= 98)
                    {
                        TimeCircuits.Settime(0, 4, 0, 7, 1, 7, 7, 6, 0, 8, 1, 2, "am");
                    }
                    if (Constanttimerclass.getdelay() >= 103)
                    {
                        TimeCircuits.Settime(2, 5, 1, 2, 0, 0, 0, 0, 1, 1, 1, 2, "am");
                    }
                    if (Constanttimerclass.getdelay() >= 110)
                    {
                        TimeCircuits.Settime(0, 5, 0, 9, 1, 9, 5, 5, 1, 1, 1, 2, "am");
                    }
                }
                else if (Constanttimerclass.getdelay() == 124)
                {
                    toggletimecurcuits = false;
                    Constanttimerclass.Stop();
                    Constanttimerclass.Reset();
                    reentry = false;
                    Libeadsappear = true;
                    Doc.Task.LeaveVehicle(Deloreon, true);
                }
            }
            else if (Libeadsappear)
            {

            }
        }
    }
}
