using GTA;
using GTA.Math;
using GTA.Native;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace BTTF_Time_Travel
{
    class Delorean_class
    {
        public Delorean_class()
        {
            Deloreanlist = new List<TimeCircuits>();
        }

        Constanttimerclass delay = new Constanttimerclass();
        public static Constanttimerclass Mrfusionrefilltimer = new Constanttimerclass();

        public List<TimeCircuits> Deloreanlist;

        #region Timetravelsounds
        public static SoundPlayer Mrfrusionfill = new SoundPlayer(Properties.Resources.mrfrusionload);
        public static SoundPlayer Beep = new SoundPlayer(Properties.Resources.beep);
        public static SoundPlayer hoveron = new SoundPlayer(Properties.Resources.HoverOn);
        public static SoundPlayer hoveroff = new SoundPlayer(Properties.Resources.HoverOff);
        public static SoundPlayer hoverboost = new SoundPlayer(Properties.Resources.HoverBoost);
        public static SoundPlayer hoverup = new SoundPlayer(Properties.Resources.HoverUp);
        public static SoundPlayer plate = new SoundPlayer(Properties.Resources.plate);
        public static SoundPlayer pr0load = new SoundPlayer(Properties.Resources.preload);
        public static SoundPlayer trend = new SoundPlayer(Properties.Resources.trend);
        public static SoundPlayer cold = new SoundPlayer(Properties.Resources.cold);
        public static SoundPlayer doorcold = new SoundPlayer(Properties.Resources.door_cold);
        public static SoundPlayer dooropen = new SoundPlayer(Properties.Resources.door_open);
        public static SoundPlayer empty = new SoundPlayer(Properties.Resources.empty);
        public static SoundPlayer engineoff = new SoundPlayer(Properties.Resources.engine_off);
        public static SoundPlayer engineon = new SoundPlayer(Properties.Resources.engine_on);
        public static SoundPlayer curerror = new SoundPlayer(Properties.Resources.Error);
        public static SoundPlayer curerrorbttf3 = new SoundPlayer(Properties.Resources.Error_BTTF3);
        public static SoundPlayer inputenterbttf3 = new SoundPlayer(Properties.Resources.input_enter_bttf3);
        public static SoundPlayer inputoff = new SoundPlayer(Properties.Resources.input_off);
        public static SoundPlayer inputon = new SoundPlayer(Properties.Resources.input_on);
        public static SoundPlayer inputoffbttf3 = new SoundPlayer(Properties.Resources.input_off_bttf3);
        public static SoundPlayer inputonbttf2error = new SoundPlayer(Properties.Resources.input_on_bttf2_error);
        public static SoundPlayer inputonbttf3 = new SoundPlayer(Properties.Resources.input_on_bttf3);
        public static SoundPlayer inputonfeul = new SoundPlayer(Properties.Resources.input_on_fuel);
        public static SoundPlayer Lightningbttf2 = new SoundPlayer(Properties.Resources.Lightning_bttf2);
        public static SoundPlayer Lightningcuttscene = new SoundPlayer(Properties.Resources.time_travel_BTTF2_lightning_cutscene);
        public static SoundPlayer Timetravelreentery = new SoundPlayer(Properties.Resources.time_travel);
        public static SoundPlayer Timetravelreenterycutscene = new SoundPlayer(Properties.Resources.time_travel_BTTF2_cutscene);
        public static SoundPlayer reenterybttf1 = new SoundPlayer(Properties.Resources.REENTRY_BTTF1);
        public static SoundPlayer reenterybttf1incar = new SoundPlayer(Properties.Resources.REENTRY_BTTF1_in_car);
        public static SoundPlayer reenterybttf2 = new SoundPlayer(Properties.Resources.REENTRY_BTTF2);
        public static SoundPlayer reenterybttf3 = new SoundPlayer(Properties.Resources.REENTRY_BTTF3);
        public static SoundPlayer sparks = new SoundPlayer(Properties.Resources.sparks);
        public static SoundPlayer sparksbttf3 = new SoundPlayer(Properties.Resources.sparks_bttf3);
        public static SoundPlayer sparksfeul = new SoundPlayer(Properties.Resources.sparks_fuel);
        public static SoundPlayer RCcontrolstart = new SoundPlayer(Properties.Resources.start_RC_control);
        public static SoundPlayer RCcontrolstop = new SoundPlayer(Properties.Resources.stop_RC_control);
        public static SoundPlayer RCcontrol = new SoundPlayer(Properties.Resources.RC_control);
        public static SoundPlayer RCcontrolhandbreak = new SoundPlayer(Properties.Resources.RC_control_handbrake);
        public static SoundPlayer Vent = new SoundPlayer(Properties.Resources.vent);
        public static SoundPlayer Plut = new SoundPlayer(Properties.Resources.Plutonium);
        #endregion

        public void CreateDeloreon()
        {
            Model Deloreanmodel = new Model("BTTF3");
            if (Deloreanmodel.IsValid)
            {
                Deloreanlist.Add(new TimeCircuits());

                Vector3 position = new Vector3((float)-449.9992, (float)2056.684, (float)121.6992);

                // At 90 degrees to the players heading

                Deloreanlist[0].Deloreon = World.CreateVehicle(Deloreanmodel, position, 0);
                Deloreanlist[0].Deloreon.Rotation = new Vector3((float)3.419171, (float)3.125508, (float)118.2247);

                Deloreanlist[0].Deloreon.IsInvincible = true;
                Deloreanlist[0].Deloreon.CanBeVisiblyDamaged = false;

                Deloreanlist[0].Deloreon.DirtLevel = 0;
                Deloreanlist[0].Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                Deloreanlist[0].Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                Deloreanlist[0].Deloreon.NumberPlate = "OutATime";
                Deloreanlist[0].Deloreon.PlaceOnGround();
                // Set the vehicle mods
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[0].Deloreon.Handle, 0);
                Deloreanlist[0].Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
            }
        }

        public void CreateDeloreanfromcurrentcar(Vehicle car, bool BTTF2)
        {
            Deloreanlist.Add(new TimeCircuits());
            Deloreanlist[Deloreanlist.Count - 1].Deloreon = car;
            Deloreanlist[Deloreanlist.Count - 1].canfly = BTTF2;
        }

        public void RemoveDelorean()
        {
            if (Deloreanlist.Count - 1 <= 0)
            {
                Game.Player.Character.CurrentVehicle.Delete();
            }
            else
            {
                for (int i = 0; i < Deloreanlist.Count; i++)
                {
                    if (Deloreanlist[i].Deloreon == Game.Player.Character.CurrentVehicle)
                    {
                        Deloreanlist[i].Deloreon.Delete();
                        Deloreanlist.Remove(Deloreanlist[i]);
                    }
                }
                if (Game.Player.Character.IsInVehicle())
                {
                    Game.Player.Character.CurrentVehicle.Delete();
                }
            }
        }

        public void RemoveTimeCircuits()
        {
            for (int i = 0; i < Deloreanlist.Count; i++)
            {
                if (Deloreanlist[i].Deloreon == Game.Player.Character.CurrentVehicle)
                {
                    Deloreanlist[i].Deloreon.MarkAsNoLongerNeeded();
                    Deloreanlist.Remove(Deloreanlist[i]);
                }
            }
        }

        public void ToggleRCmode(int index)
        {
            Deloreanlist[index].RCmode = !Deloreanlist[index].RCmode;

            if (Deloreanlist[index].RCmode)
            {
                RCcontrolstart.Play();
                Deloreanlist[index].Deloreon.EngineRunning = true;
                if (!Deloreanlist[index].RCmodeactive)
                {
                    if (!Deloreanlist[index].Deloreon.IsSeatFree(VehicleSeat.Driver))
                    {
                        
                        while (Deloreanlist[index].playerped != Game.Player.Character)
                            Deloreanlist[index].playerped = Game.Player.Character;
                        Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, Deloreanlist[index].Deloreon.GetPedOnSeat(VehicleSeat.Driver), true, true);
                    }
                    else
                    {
                        while (Deloreanlist[index].playerped != Game.Player.Character)
                            Deloreanlist[index].playerped = Game.Player.Character;
                        Deloreanlist[index].RCped = Deloreanlist[index].Deloreon.CreatePedOnSeat(VehicleSeat.Driver, Game.Player.Character.Model);
                        Deloreanlist[index].RCped.IsVisible = false;
                        Deloreanlist[index].RCped.CanBeDraggedOutOfVehicle = true;
                        Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, Deloreanlist[index].RCped, true, true);
                    }
                }
                Deloreanlist[index].RCmodeenabled = true;
            }
            else if (!Deloreanlist[index].RCmode)
            {
                RCcontrolstop.Play();
                Deloreanlist[index].Deloreon.EngineRunning = false;
                if (!(Deloreanlist[index].RCped == null))
                {
                    if (!(Game.Player.Character == Deloreanlist[index].playerped))
                    {
                        Function.Call(Hash.CHANGE_PLAYER_PED, Game.Player, Deloreanlist[index].playerped, true, true);
                        Deloreanlist[index].RCmodeactive = false;
                        Deloreanlist[index].RCped.Delete();
                        Deloreanlist[index].RCped = null;
                        Deloreanlist[index].RCmodeenabled = false;
                    }
                }
                Deloreanlist[index].RCmodeenabled = true;
            }
        }

        public void Toggleflight(int index)
        {
            if (Deloreanlist[index].canfly)
            {
                if (Deloreanlist[index].flyingison)
                {
                    try
                    {
                        Vector3 temppos = Deloreanlist[index].Deloreon.Position;
                        Vector3 temprot = Deloreanlist[index].Deloreon.Rotation;
                        Vehicle tempv = Deloreanlist[index].Deloreon;
                        int speed = (int)Deloreanlist[index].Deloreon.Speed;
                        Ped driver;
                        Ped passenger = null;
                        driver = Game.Player.Character;
                        if (Deloreanlist[index].Deloreon.GetPedOnSeat(VehicleSeat.Passenger).Exists())
                            passenger = Deloreanlist[index].Deloreon.GetPedOnSeat(VehicleSeat.Passenger);
                        driver.Task.WarpOutOfVehicle(Deloreanlist[index].Deloreon);
                        if (passenger != null)
                            passenger.Task.WarpOutOfVehicle(Deloreanlist[index].Deloreon);
                        tempv.Delete();
                        Model bttf2 = new Model("BTTF2");

                        while(Deloreanlist[index].Deloreon.Model != new Model("BTTF2"))
                            Deloreanlist[index].Deloreon = World.CreateVehicle(bttf2, temppos);
                        Deloreanlist[index].Deloreon.Rotation = temprot;
                        //    Deloreanlist[index].flycount = 0;
                        driver.Task.WarpIntoVehicle(Deloreanlist[index].Deloreon, VehicleSeat.Driver);
                        if (passenger != null)
                            passenger.Task.WarpIntoVehicle(Deloreanlist[index].Deloreon, VehicleSeat.Passenger);
                        Deloreanlist[index].flyingison = false;
                        hoveroff.Play();
                        Deloreanlist[index].Deloreon.Speed = speed;
                        tempv.Delete();
                    }
                    catch
                    {
                        UI.ShowSubtitle("Model does not exist", 5);
                    }
                    //    flyingturnedon = false;
                    //    hoveroff.Play();
                    //    Deloreanlist[index].flyheight = 0;
                }
                else
                {
                    try
                    {
                        Vector3 temppos = Deloreanlist[index].Deloreon.Position;
                        Vector3 temprot = Deloreanlist[index].Deloreon.Rotation;
                        Vehicle tempv = Deloreanlist[index].Deloreon;
                        int speed = (int)Deloreanlist[index].Deloreon.Speed;
                        Ped driver;
                        Ped passenger = null;
                        driver = Game.Player.Character;
                        if (Deloreanlist[index].Deloreon.GetPedOnSeat(VehicleSeat.Passenger).Exists())
                            passenger = Deloreanlist[index].Deloreon.GetPedOnSeat(VehicleSeat.Passenger);
                        driver.Task.WarpOutOfVehicle(Deloreanlist[index].Deloreon);
                        if (passenger != null)
                            passenger.Task.WarpOutOfVehicle(Deloreanlist[index].Deloreon);
                        tempv.Delete();
                        Model bttf2f = new Model("BTTF2F");
                        while (Deloreanlist[index].Deloreon.Model != new Model("BTTF2F"))
                            Deloreanlist[index].Deloreon = World.CreateVehicle(bttf2f, temppos);
                        Deloreanlist[index].Deloreon.Rotation = temprot;
                        //    Deloreanlist[index].flycount = 0;
                        driver.Task.WarpIntoVehicle(Deloreanlist[index].Deloreon, VehicleSeat.Driver);
                        if (passenger != null)
                            passenger.Task.WarpIntoVehicle(Deloreanlist[index].Deloreon, VehicleSeat.Passenger);
                        Deloreanlist[index].flyingison = true;
                        hoveron.Play();
                        Deloreanlist[index].Deloreon.Speed = speed;
                    }
                    catch
                    {
                        UI.ShowSubtitle("Model does not exist", 5);
                    }
                }
            }
            UI.ShowSubtitle("Flying mode: " + Deloreanlist[index].flyingison, 5);
        }

        public void ToggleMrfusion(int index)
        {
            if (!Game.Player.Character.IsInVehicle(Deloreanlist[index].Deloreon))
            {
                if (Game.Player.Character.IsInRangeOf(Deloreanlist[index].Deloreon.Position, 10))
                {
                    Game.Player.Character.Task.GoTo(Deloreanlist[index].Deloreon, new Vector3(0, -3, 0), 5);
                    Deloreanlist[index].MrFusionfilltask = true;
                }
            }
        }


        #region time circuits display

        static string image = Application.StartupPath + "\\scripts\\images";
        static Point loc = new Point(1370, 670);
        static int temptick = 0;
        static bool ticktock = false;
        static string img = "";

        enum time
        {
            Future,
            Present,
            Past
        }

        public static void change_time_display_location(int X, int Y)
        {
            loc = new Point(X, Y);
        }

        string displaymonth(int month, time display)
        {
            switch (month)
            {
                case 1:
                    if (display == time.Future)
                    {
                        int num = 10;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 10;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 10;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 2:
                    if (display == time.Future)
                    {
                        int num = 11;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 11;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 11;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 3:
                    if (display == time.Future)
                    {
                        int num = 12;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 12;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 12;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 4:
                    if (display == time.Future)
                    {
                        int num = 13;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 13;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 13;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 5:
                    if (display == time.Future)
                    {
                        int num = 14;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 14;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 14;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 6:
                    if (display == time.Future)
                    {
                        int num = 15;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 15;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 15;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 7:
                    if (display == time.Future)
                    {
                        int num = 16;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 16;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 16;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 8:
                    if (display == time.Future)
                    {
                        int num = 17;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 17;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 17;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 9:
                    if (display == time.Future)
                    {
                        int num = 18;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 18;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 18;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 10:
                    if (display == time.Future)
                    {
                        int num = 19;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 19;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 19;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 11:
                    if (display == time.Future)
                    {
                        int num = 20;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 20;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 20;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 12:
                    if (display == time.Future)
                    {
                        int num = 21;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 21;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 21;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
            }
            return "nothing";
        }

        string displaymunber(int number1, time display)
        {
            switch (number1)
            {
                case 0:
                    if (display == time.Future)
                    {
                        int num = 0;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 0;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 0;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 1:
                    if (display == time.Future)
                    {
                        int num = 1;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 1;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 1;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 2:
                    if (display == time.Future)
                    {
                        int num = 2;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 2;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 2;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 3:
                    if (display == time.Future)
                    {
                        int num = 3;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 3;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 3;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 4:
                    if (display == time.Future)
                    {
                        int num = 4;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 4;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 4;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 5:
                    if (display == time.Future)
                    {
                        int num = 5;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 5;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 5;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 6:
                    if (display == time.Future)
                    {
                        int num = 6;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 6;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 6;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 7:
                    if (display == time.Future)
                    {
                        int num = 7;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 7;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 7;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 8:
                    if (display == time.Future)
                    {
                        int num = 8;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 8;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 8;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
                case 9:
                    if (display == time.Future)
                    {
                        int num = 9;
                        return "\\red " + num + ".jpg";
                    }
                    else if (display == time.Present)
                    {
                        int num = 9;
                        return "\\green " + num + ".jpg";
                    }
                    else if (display == time.Past)
                    {
                        int num = 9;
                        return "\\amber " + num + ".jpg";
                    }
                    break;
            }
            return "nothing";
        }


        public void display_background()
        {
            img = "\\background.jpg";
            if (File.Exists(image + img))
            {
                Sprite.DrawTexture(image + img, loc, new Size(520, 360));
            }
            else
            {

            }
        }

        public bool displaycheck = false;

        public void tick(int index)
        {
            int tick = DateTime.Now.Second;
            if (Directory.Exists(image))
            {
                #region future

                //month display
                img = displaymonth((Deloreanlist[index].fmonth1 * 10) + Deloreanlist[index].fmonth2, time.Future);
                if (File.Exists(image + img))
                {
                    Sprite.DrawTexture(image + img, new Point(loc.X + 27, loc.Y + 65), new Size(88, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //Day display
                img = displaymunber(Deloreanlist[index].fday1, time.Future);
                if (File.Exists(image + "\\day\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\day\\1" + img, new Point(loc.X + 140, loc.Y + 65), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].fday2, time.Future);
                if (File.Exists(image + "\\day\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\day\\2" + img, new Point(loc.X + 166, loc.Y + 65), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //yeardisplay
                img = displaymunber(Deloreanlist[index].fy1, time.Future);
                if (File.Exists(image + "\\year\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\1" + img, new Point(loc.X + 220, loc.Y + 65), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].fy2, time.Future);
                if (File.Exists(image + "\\year\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\2" + img, new Point(loc.X + 249, loc.Y + 65), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].fy3, time.Future);
                if (File.Exists(image + "\\year\\3" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\3" + img, new Point(loc.X + 278, loc.Y + 65), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].fy4, time.Future);
                if (File.Exists(image + "\\year\\4" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\4" + img, new Point(loc.X + 307, loc.Y + 65), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                int h1 = 1, h2 = 2;
                if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 0)
                {
                    h1 = 1;
                    h2 = 2;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 1)
                {
                    h1 = 0;
                    h2 = 1;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 2)
                {
                    h1 = 0;
                    h2 = 2;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 3)
                {
                    h1 = 0;
                    h2 = 3;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 4)
                {
                    h1 = 0;
                    h2 = 4;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 5)
                {
                    h1 = 0;
                    h2 = 5;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 6)
                {
                    h1 = 0;
                    h2 = 6;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 7)
                {
                    h1 = 0;
                    h2 = 7;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 8)
                {
                    h1 = 0;
                    h2 = 8;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 9)
                {
                    h1 = 0;
                    h2 = 9;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 10)
                {
                    h1 = 1;
                    h2 = 0;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 11)
                {
                    h1 = 1;
                    h2 = 1;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 12)
                {
                    h1 = 1;
                    h2 = 2;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 13)
                {
                    h1 = 0;
                    h2 = 1;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 14)
                {
                    h1 = 0;
                    h2 = 2;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 15)
                {
                    h1 = 0;
                    h2 = 3;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 16)
                {
                    h1 = 0;
                    h2 = 4;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 17)
                {
                    h1 = 0;
                    h2 = 5;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 18)
                {
                    h1 = 0;
                    h2 = 6;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 19)
                {
                    h1 = 0;
                    h2 = 7;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 20)
                {
                    h1 = 0;
                    h2 = 8;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 21)
                {
                    h1 = 0;
                    h2 = 9;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 22)
                {
                    h1 = 1;
                    h2 = 0;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 23)
                {
                    h1 = 1;
                    h2 = 1;
                }


                //hour display
                img = displaymunber(h1, time.Future);
                if (File.Exists(image + "\\hour\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\hour\\1" + img, new Point(loc.X + 366, loc.Y + 65), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(h2, time.Future);
                if (File.Exists(image + "\\hour\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\hour\\2" + img, new Point(loc.X + 388, loc.Y + 65), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) > 12)
                {
                    Deloreanlist[index].fampm = "pm";
                }
                else
                {
                    Deloreanlist[index].fampm = "am";
                }

                //ampm
                img = "\\red " + Deloreanlist[index].fampm + ".jpg";
                if (File.Exists(image + img))
                {
                    Sprite.DrawTexture(image + img, new Point(loc.X + 340, loc.Y + 36), new Size(20, 28));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //tick
                if (tick != temptick)
                {
                    if (ticktock)
                    {
                        ticktock = false;
                    }
                    else
                    {
                        ticktock = true;
                    }
                    temptick = tick;
                }
                else
                {
                    if (ticktock)
                    {
                        img = "\\red colon on.jpg";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(loc.X + 427, loc.Y + 65), new Size(10, 14));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                    else
                    {
                        img = "\\red colon off.jpg";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(loc.X + 427, loc.Y + 65), new Size(10, 14));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                }

                //minute display
                img = displaymunber(Deloreanlist[index].fm1, time.Future);
                if (File.Exists(image + "\\min\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\min\\1" + img, new Point(loc.X + 447, loc.Y + 65), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].fm2, time.Future);
                if (File.Exists(image + "\\min\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\min\\2" + img, new Point(loc.X + 474, loc.Y + 65), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                #endregion

                #region present

                img = displaymonth((Deloreanlist[index].presmonth1 * 10) + Deloreanlist[index].presmonth2, time.Present);
                if (File.Exists(image + img))
                {
                    Sprite.DrawTexture(image + img, new Point(loc.X + 27, loc.Y + 157), new Size(88, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //Day display
                img = displaymunber(Deloreanlist[index].presday1, time.Present);
                if (File.Exists(image + "\\day\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\day\\1" + img, new Point(loc.X + 140, loc.Y + 157), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].presday2, time.Present);
                if (File.Exists(image + "\\day\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\day\\2" + img, new Point(loc.X + 166, loc.Y + 157), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //yeardisplay
                img = displaymunber(Deloreanlist[index].presy1, time.Present);
                if (File.Exists(image + "\\year\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\1" + img, new Point(loc.X + 220, loc.Y + 157), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].presy2, time.Present);
                if (File.Exists(image + "\\year\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\2" + img, new Point(loc.X + 249, loc.Y + 157), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].presy3, time.Present);
                if (File.Exists(image + "\\year\\3" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\3" + img, new Point(loc.X + 278, loc.Y + 157), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].presy4, time.Present);
                if (File.Exists(image + "\\year\\4" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\4" + img, new Point(loc.X + 307, loc.Y + 157), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                Deloreanlist[index].presampm = "am";
                int hour = World.CurrentDayTime.Hours;
                if (hour == 0)
                {
                    h1 = 1;
                    h2 = 2;
                }
                else if (hour == 1)
                {
                    h1 = 0;
                    h2 = 1;
                }
                else if (hour == 2)
                {
                    h1 = 0;
                    h2 = 2;
                }
                else if (hour == 3)
                {
                    h1 = 0;
                    h2 = 3;
                }
                else if (hour == 4)
                {
                    h1 = 0;
                    h2 = 4;
                }
                else if (hour == 5)
                {
                    h1 = 0;
                    h2 = 5;
                }
                else if (hour == 6)
                {
                    h1 = 0;
                    h2 = 6;
                }
                else if (hour == 7)
                {
                    h1 = 0;
                    h2 = 7;
                }
                else if (hour == 8)
                {
                    h1 = 0;
                    h2 = 8;
                }
                else if (hour == 9)
                {
                    h1 = 0;
                    h2 = 9;
                }
                else if (hour == 10)
                {
                    h1 = 1;
                    h2 = 0;
                }
                else if (hour == 11)
                {
                    h1 = 1;
                    h2 = 1;
                }
                else if (hour == 12)
                {
                    h1 = 1;
                    h2 = 2;
                }
                else if (hour == 13)
                {
                    h1 = 0;
                    h2 = 1;
                }
                else if (hour == 14)
                {
                    h1 = 0;
                    h2 = 2;
                }
                else if (hour == 15)
                {
                    h1 = 0;
                    h2 = 3;
                }
                else if (hour == 16)
                {
                    h1 = 0;
                    h2 = 4;
                }
                else if (hour == 17)
                {
                    h1 = 0;
                    h2 = 5;
                }
                else if (hour == 18)
                {
                    h1 = 0;
                    h2 = 6;
                }
                else if (hour == 19)
                {
                    h1 = 0;
                    h2 = 7;
                }
                else if (hour == 20)
                {
                    h1 = 0;
                    h2 = 8;
                }
                else if (hour == 21)
                {
                    h1 = 0;
                    h2 = 9;
                }
                else if (hour == 22)
                {
                    h1 = 1;
                    h2 = 0;
                }
                else if (hour == 23)
                {
                    h1 = 1;
                    h2 = 1;
                }

                if (hour > 12)
                {
                    Deloreanlist[index].fampm = "pm";
                }
                else
                {
                    Deloreanlist[index].fampm = "am";
                }

                //ampm
                img = "\\green " + Deloreanlist[index].presampm + ".jpg";
                if (File.Exists(image + img))
                {
                    Sprite.DrawTexture(image + img, new Point(loc.X + 340, loc.Y + 157), new Size(20, 32));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //hour display
                img = displaymunber(h1, time.Present);
                if (File.Exists(image + "\\hour\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\hour\\1" + img, new Point(loc.X + 366, loc.Y + 157), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(h2, time.Present);
                if (File.Exists(image + "\\hour\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\hour\\2" + img, new Point(loc.X + 388, loc.Y + 157), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //tick
                if (tick != temptick)
                {
                    if (ticktock)
                    {
                        ticktock = false;
                    }
                    else
                    {
                        ticktock = true;
                    }
                    temptick = tick;
                }
                else
                {
                    if (ticktock)
                    {
                        img = "\\green colon on.jpg";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(loc.X + 427, loc.Y + 157), new Size(10, 14));
                            Deloreanlist[index].Deloreon.SetMod(VehicleMod.Grille, 0, true);
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                    else
                    {
                        img = "\\green colon off.jpg";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(loc.X + 427, loc.Y + 157), new Size(10, 14));
                            Deloreanlist[index].Deloreon.SetMod(VehicleMod.Grille, -1, true);
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                }

                //minute display
                int presmin = World.CurrentDayTime.Minutes;
                if (presmin < 10)
                {
                    Deloreanlist[index].presm1 = 0;
                    Deloreanlist[index].presm2 = presmin;
                }
                else
                {
                    if (presmin < 20)
                    {
                        Deloreanlist[index].presm1 = 1;
                        Deloreanlist[index].presm2 = presmin - 10;
                    }
                    else if (presmin < 30)
                    {
                        Deloreanlist[index].presm1 = 2;
                        Deloreanlist[index].presm2 = presmin - 20;
                    }
                    else if (presmin < 40)
                    {
                        Deloreanlist[index].presm1 = 3;
                        Deloreanlist[index].presm2 = presmin - 30;
                    }
                    else if (presmin < 50)
                    {
                        Deloreanlist[index].presm1 = 4;
                        Deloreanlist[index].presm2 = presmin - 40;
                    }
                    else if (presmin < 60)
                    {
                        Deloreanlist[index].presm1 = 5;
                        Deloreanlist[index].presm2 = presmin - 50;
                    }
                }

                img = displaymunber(Deloreanlist[index].presm1, time.Present);
                if (File.Exists(image + "\\min\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\min\\1" + img, new Point(loc.X + 447, loc.Y + 157), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].presm2, time.Present);
                if (File.Exists(image + "\\min\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\min\\2" + img, new Point(loc.X + 474, loc.Y + 157), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                #endregion

                #region past
                //month display
                img = displaymonth((Deloreanlist[index].pastmonth1 * 10) + Deloreanlist[index].pastmonth2, time.Past);
                if (File.Exists(image + img))
                {
                    Sprite.DrawTexture(image + img, new Point(loc.X + 27, loc.Y + 243), new Size(88, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //Day display
                img = displaymunber(Deloreanlist[index].pastday1, time.Past);
                if (File.Exists(image + "\\day\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\day\\1" + img, new Point(loc.X + 140, loc.Y + 243), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].pastday2, time.Past);
                if (File.Exists(image + "\\day\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\day\\2" + img, new Point(loc.X + 166, loc.Y + 243), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //yeardisplay
                img = displaymunber(Deloreanlist[index].pasty1, time.Past);
                if (File.Exists(image + "\\year\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\1" + img, new Point(loc.X + 220, loc.Y + 243), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].pasty2, time.Past);
                if (File.Exists(image + "\\year\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\2" + img, new Point(loc.X + 249, loc.Y + 243), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].pasty3, time.Past);
                if (File.Exists(image + "\\year\\3" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\3" + img, new Point(loc.X + 278, loc.Y + 243), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].pasty4, time.Past);
                if (File.Exists(image + "\\year\\4" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\4" + img, new Point(loc.X + 307, loc.Y + 243), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //ampm
                img = "\\amber " + Deloreanlist[index].pastampm + ".jpg";
                if (File.Exists(image + img))
                {
                    Sprite.DrawTexture(image + img, new Point(loc.X + 340, loc.Y + 243), new Size(20, 32));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //hour display
                img = displaymunber(Deloreanlist[index].pasth1, time.Past);
                if (File.Exists(image + "\\hour\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\hour\\1" + img, new Point(loc.X + 366, loc.Y + 243), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].pasth2, time.Past);
                if (File.Exists(image + "\\hour\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\hour\\2" + img, new Point(loc.X + 388, loc.Y + 243), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //tick
                if (tick != temptick)
                {
                    if (ticktock)
                    {
                        ticktock = false;
                    }
                    else
                    {
                        ticktock = true;
                    }
                    temptick = tick;
                }
                else
                {
                    if (ticktock)
                    {
                        img = "\\amber colon on.jpg";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(loc.X + 427, loc.Y + 243), new Size(10, 17));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                    else
                    {
                        img = "\\amber colon off.jpg";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(loc.X + 427, loc.Y + 243), new Size(10, 17));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                }

                //minute display
                img = displaymunber(Deloreanlist[index].pastm1, time.Past);
                if (File.Exists(image + "\\min\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\min\\1" + img, new Point(loc.X + 447, loc.Y + 243), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].pastm2, time.Past);
                if (File.Exists(image + "\\min\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\min\\2" + img, new Point(loc.X + 474, loc.Y + 243), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                #endregion
            }
            else
            {
                if (!Deloreanlist[index].refilltimecurcuits)
                {
                    UIResText Mrfusion = new UIResText("Empty", new Point(1600, 900), (float)0.6, Color.Orange);
                    Mrfusion.Draw();
                }
                UIResText Timedisplayf = new UIResText(Deloreanlist[index].timedisplayfuture(), new Point(1450, 940), (float)0.6, Color.Red);
                UIResText Timedisplaypres = new UIResText(Deloreanlist[index].timedisplaypresent(), new Point(1450, 980), (float)0.6, Color.Green);
                UIResText Timedisplaypast = new UIResText(Deloreanlist[index].timedisplaypast(), new Point(1450, 1020), (float)0.6, Color.Yellow);
                Timedisplayf.DropShadow = true;
                Timedisplaypres.DropShadow = true;
                Timedisplaypast.DropShadow = true;
                Timedisplayf.Draw();
                Timedisplaypres.Draw();
                Timedisplaypast.Draw();
            }
        }

        public void tick(int X, int Y, int index)
        {
            int tick = DateTime.Now.Second;
            Application.DoEvents();
            if (Directory.Exists(image))
            {
                #region future

                //month display
                img = displaymonth((Deloreanlist[index].fmonth1 * 10) + Deloreanlist[index].fmonth2, time.Future);
                if (File.Exists(image + img))
                {
                    Sprite.DrawTexture(image + img, new Point(loc.X + X, loc.Y + Y), new Size(88, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //Day display
                img = displaymunber(Deloreanlist[index].fday1, time.Future);
                if (File.Exists(image + "\\day\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\day\\1" + img, new Point(loc.X + X + 90, loc.Y + Y), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].fday2, time.Future);
                if (File.Exists(image + "\\day\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\day\\2" + img, new Point(loc.X + X + 110, loc.Y + Y), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //yeardisplay
                img = displaymunber(Deloreanlist[index].fy1, time.Future);
                if (File.Exists(image + "\\year\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\1" + img, new Point(loc.X + X + 140, loc.Y + Y), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].fy2, time.Future);
                if (File.Exists(image + "\\year\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\2" + img, new Point(loc.X + X + 160, loc.Y + Y), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].fy3, time.Future);
                if (File.Exists(image + "\\year\\3" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\3" + img, new Point(loc.X + X + 180, loc.Y + Y), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].fy4, time.Future);
                if (File.Exists(image + "\\year\\4" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\4" + img, new Point(loc.X + X + 200, loc.Y + Y), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                #region ampm
                int h1 = 1, h2 = 2;
                if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 0)
                {
                    h1 = 1;
                    h2 = 2;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 1)
                {
                    h1 = 0;
                    h2 = 1;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 2)
                {
                    h1 = 0;
                    h2 = 2;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 3)
                {
                    h1 = 0;
                    h2 = 3;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 4)
                {
                    h1 = 0;
                    h2 = 4;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 5)
                {
                    h1 = 0;
                    h2 = 5;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 6)
                {
                    h1 = 0;
                    h2 = 6;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 7)
                {
                    h1 = 0;
                    h2 = 7;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 8)
                {
                    h1 = 0;
                    h2 = 8;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 9)
                {
                    h1 = 0;
                    h2 = 9;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 10)
                {
                    h1 = 1;
                    h2 = 0;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 11)
                {
                    h1 = 1;
                    h2 = 1;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 12)
                {
                    h1 = 1;
                    h2 = 2;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 13)
                {
                    h1 = 0;
                    h2 = 1;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 14)
                {
                    h1 = 0;
                    h2 = 2;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 15)
                {
                    h1 = 0;
                    h2 = 3;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 16)
                {
                    h1 = 0;
                    h2 = 4;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 17)
                {
                    h1 = 0;
                    h2 = 5;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 18)
                {
                    h1 = 0;
                    h2 = 6;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 19)
                {
                    h1 = 0;
                    h2 = 7;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 20)
                {
                    h1 = 0;
                    h2 = 8;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 21)
                {
                    h1 = 0;
                    h2 = 9;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 22)
                {
                    h1 = 1;
                    h2 = 0;
                }
                else if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) == 23)
                {
                    h1 = 1;
                    h2 = 1;
                }
                #endregion
                Application.DoEvents();
                //hour display
                img = displaymunber(h1, time.Future);
                if (File.Exists(image + "\\hour\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\hour\\1" + img, new Point(loc.X + X + 250, loc.Y + Y), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(h2, time.Future);
                if (File.Exists(image + "\\hour\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\hour\\2" + img, new Point(loc.X + X + 270, loc.Y + Y), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) > 12)
                {
                    Deloreanlist[index].fampm = "pm";
                }
                else
                {
                    Deloreanlist[index].fampm = "am";
                }

                UIResText Timedisplayf = new UIResText(Deloreanlist[index].timedisplayfuture(), new Point(1100, 570), (float)0.6, Color.Red);
                Timedisplayf.DropShadow = true;
                Timedisplayf.Draw();
                //ampm
                img = "\\red " + Deloreanlist[index].fampm + ".jpg";
                if (File.Exists(image + img))
                {
                    Sprite.DrawTexture(image + img, new Point(loc.X + X + 220, loc.Y + Y + 2), new Size(20, 28));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(loc.X + X, loc.Y + Y), (float)0.6);
                    debug2.Draw();
                }

                //tick
                if (tick != temptick)
                {
                    Application.DoEvents();
                    if (ticktock)
                    {
                        ticktock = false;
                    }
                    else
                    {
                        ticktock = true;
                    }
                    temptick = tick;
                }
                else
                {
                    Application.DoEvents();
                    if (ticktock)
                    {
                        img = "\\red colon on.jpg";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(loc.X + X + 287, loc.Y + Y + 10), new Size(10, 14));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                    else
                    {
                        img = "\\red colon off.jpg";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(loc.X + X + 287, loc.Y + Y + 10), new Size(10, 14));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                }

                //minute display
                img = displaymunber(Deloreanlist[index].fm1, time.Future);
                if (File.Exists(image + "\\min\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\min\\1" + img, new Point(loc.X + X + 300, loc.Y + Y), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].fm2, time.Future);
                if (File.Exists(image + "\\min\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\min\\2" + img, new Point(loc.X + X + 320, loc.Y + Y), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                #endregion

                #region Present

                //month display
                img = displaymonth((Deloreanlist[index].presmonth1 * 10) + Deloreanlist[index].presmonth2, time.Present);
                if (File.Exists(image + img))
                {
                    Sprite.DrawTexture(image + img, new Point(loc.X + X, loc.Y + Y + 30), new Size(88, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //Day display
                img = displaymunber(Deloreanlist[index].presday1, time.Present);
                if (File.Exists(image + "\\day\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\day\\1" + img, new Point(loc.X + X + 90, loc.Y + Y + 30), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].presday2, time.Present);
                if (File.Exists(image + "\\day\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\day\\2" + img, new Point(loc.X + X + 110, loc.Y + Y + 30), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //yeardisplay
                img = displaymunber(Deloreanlist[index].presy1, time.Present);
                if (File.Exists(image + "\\year\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\1" + img, new Point(loc.X + X + 140, loc.Y + Y + 30), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].presy2, time.Present);
                if (File.Exists(image + "\\year\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\2" + img, new Point(loc.X + X + 160, loc.Y + Y + 30), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].presy3, time.Present);
                if (File.Exists(image + "\\year\\3" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\3" + img, new Point(loc.X + X + 180, loc.Y + Y + 30), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].presy4, time.Present);
                if (File.Exists(image + "\\year\\4" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\4" + img, new Point(loc.X + X + 200, loc.Y + Y + 30), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                #region ampm
                Deloreanlist[index].presampm = "am";
                int hour = World.CurrentDayTime.Hours;
                if (hour == 0)
                {
                    h1 = 1;
                    h2 = 2;
                }
                else if (hour == 1)
                {
                    h1 = 0;
                    h2 = 1;
                }
                else if (hour == 2)
                {
                    h1 = 0;
                    h2 = 2;
                }
                else if (hour == 3)
                {
                    h1 = 0;
                    h2 = 3;
                }
                else if (hour == 4)
                {
                    h1 = 0;
                    h2 = 4;
                }
                else if (hour == 5)
                {
                    h1 = 0;
                    h2 = 5;
                }
                else if (hour == 6)
                {
                    h1 = 0;
                    h2 = 6;
                }
                else if (hour == 7)
                {
                    h1 = 0;
                    h2 = 7;
                }
                else if (hour == 8)
                {
                    h1 = 0;
                    h2 = 8;
                }
                else if (hour == 9)
                {
                    h1 = 0;
                    h2 = 9;
                }
                else if (hour == 10)
                {
                    h1 = 1;
                    h2 = 0;
                }
                else if (hour == 11)
                {
                    h1 = 1;
                    h2 = 1;
                }
                else if (hour == 12)
                {
                    h1 = 1;
                    h2 = 2;
                }
                else if (hour == 13)
                {
                    h1 = 0;
                    h2 = 1;
                }
                else if (hour == 14)
                {
                    h1 = 0;
                    h2 = 2;
                }
                else if (hour == 15)
                {
                    h1 = 0;
                    h2 = 3;
                }
                else if (hour == 16)
                {
                    h1 = 0;
                    h2 = 4;
                }
                else if (hour == 17)
                {
                    h1 = 0;
                    h2 = 5;
                }
                else if (hour == 18)
                {
                    h1 = 0;
                    h2 = 6;
                }
                else if (hour == 19)
                {
                    h1 = 0;
                    h2 = 7;
                }
                else if (hour == 20)
                {
                    h1 = 0;
                    h2 = 8;
                }
                else if (hour == 21)
                {
                    h1 = 0;
                    h2 = 9;
                }
                else if (hour == 22)
                {
                    h1 = 1;
                    h2 = 0;
                }
                else if (hour == 23)
                {
                    h1 = 1;
                    h2 = 1;
                }
                Application.DoEvents();
                if (hour > 12)
                {
                    Deloreanlist[index].fampm = "pm";
                }
                else
                {
                    Deloreanlist[index].fampm = "am";
                }

                //ampm
                img = "\\green " + Deloreanlist[index].fampm + ".jpg";
                if (File.Exists(image + img))
                {
                    Sprite.DrawTexture(image + img, new Point(loc.X + X + 220, loc.Y + Y + 32), new Size(20, 28));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(loc.X + X, loc.Y + Y), (float)0.6);
                    debug2.Draw();
                }
                #endregion

                //hour display
                img = displaymunber(h1, time.Present);
                if (File.Exists(image + "\\hour\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\hour\\1" + img, new Point(loc.X + X + 250, loc.Y + Y + 30), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(h2, time.Present);
                if (File.Exists(image + "\\hour\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\hour\\2" + img, new Point(loc.X + X + 270, loc.Y + Y + 30), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //tick
                if (tick != temptick)
                {
                    if (ticktock)
                    {
                        ticktock = false;
                    }
                    else
                    {
                        ticktock = true;
                    }
                    temptick = tick;
                }
                else
                {
                    if (ticktock)
                    {
                        img = "\\green colon on.jpg";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(loc.X + X + 287, loc.Y + Y + 40), new Size(10, 14));
                            Deloreanlist[index].Deloreon.SetMod(VehicleMod.Grille, 0, true);
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                    else
                    {
                        img = "\\green colon off.jpg";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(loc.X + X + 287, loc.Y + Y + 40), new Size(10, 14));
                            Deloreanlist[index].Deloreon.SetMod(VehicleMod.Grille, -1, true);
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                }

                //minute display
                int presmin = World.CurrentDayTime.Minutes;
                if (presmin < 10)
                {
                    Deloreanlist[index].presm1 = 0;
                    Deloreanlist[index].presm2 = presmin;
                }
                else
                {
                    if (presmin < 20)
                    {
                        Deloreanlist[index].presm1 = 1;
                        Deloreanlist[index].presm2 = presmin - 10;
                    }
                    else if (presmin < 30)
                    {
                        Deloreanlist[index].presm1 = 2;
                        Deloreanlist[index].presm2 = presmin - 20;
                    }
                    else if (presmin < 40)
                    {
                        Deloreanlist[index].presm1 = 3;
                        Deloreanlist[index].presm2 = presmin - 30;
                    }
                    else if (presmin < 50)
                    {
                        Deloreanlist[index].presm1 = 4;
                        Deloreanlist[index].presm2 = presmin - 40;
                    }
                    else if (presmin < 60)
                    {
                        Deloreanlist[index].presm1 = 5;
                        Deloreanlist[index].presm2 = presmin - 50;
                    }
                }

                //minute display
                img = displaymunber(Deloreanlist[index].presm1, time.Present);
                if (File.Exists(image + "\\min\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\min\\1" + img, new Point(loc.X + X + 300, loc.Y + Y + 30), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].presm2, time.Present);
                if (File.Exists(image + "\\min\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\min\\2" + img, new Point(loc.X + X + 320, loc.Y + Y + 30), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                #endregion

                #region Past

                //month display
                img = displaymonth((Deloreanlist[index].pastmonth1 * 10) + Deloreanlist[index].pastmonth2, time.Past);
                if (File.Exists(image + img))
                {
                    Sprite.DrawTexture(image + img, new Point(loc.X + X, loc.Y + Y + 60), new Size(88, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //Day display
                img = displaymunber(Deloreanlist[index].pastday1, time.Past);
                if (File.Exists(image + "\\day\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\day\\1" + img, new Point(loc.X + X + 90, loc.Y + Y + 60), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].pastday2, time.Past);
                if (File.Exists(image + "\\day\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\day\\2" + img, new Point(loc.X + X + 110, loc.Y + Y + 60), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                //yeardisplay
                img = displaymunber(Deloreanlist[index].pasty1, time.Past);
                if (File.Exists(image + "\\year\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\1" + img, new Point(loc.X + X + 140, loc.Y + Y + 60), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].pasty2, time.Past);
                if (File.Exists(image + "\\year\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\2" + img, new Point(loc.X + X + 160, loc.Y + Y + 60), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].pasty3, time.Past);
                if (File.Exists(image + "\\year\\3" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\3" + img, new Point(loc.X + X + 180, loc.Y + Y + 60), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].pasty4, time.Past);
                if (File.Exists(image + "\\year\\4" + img))
                {
                    Sprite.DrawTexture(image + "\\year\\4" + img, new Point(loc.X + X + 200, loc.Y + Y + 60), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                #region ampm
                h1 = 1; h2 = 2;
                if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 0)
                {
                    h1 = 1;
                    h2 = 2;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 1)
                {
                    h1 = 0;
                    h2 = 1;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 2)
                {
                    h1 = 0;
                    h2 = 2;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 3)
                {
                    h1 = 0;
                    h2 = 3;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 4)
                {
                    h1 = 0;
                    h2 = 4;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 5)
                {
                    h1 = 0;
                    h2 = 5;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 6)
                {
                    h1 = 0;
                    h2 = 6;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 7)
                {
                    h1 = 0;
                    h2 = 7;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 8)
                {
                    h1 = 0;
                    h2 = 8;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 9)
                {
                    h1 = 0;
                    h2 = 9;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 10)
                {
                    h1 = 1;
                    h2 = 0;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 11)
                {
                    h1 = 1;
                    h2 = 1;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 12)
                {
                    h1 = 1;
                    h2 = 2;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 13)
                {
                    h1 = 0;
                    h2 = 1;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 14)
                {
                    h1 = 0;
                    h2 = 2;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 15)
                {
                    h1 = 0;
                    h2 = 3;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 16)
                {
                    h1 = 0;
                    h2 = 4;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 17)
                {
                    h1 = 0;
                    h2 = 5;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 18)
                {
                    h1 = 0;
                    h2 = 6;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 19)
                {
                    h1 = 0;
                    h2 = 7;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 20)
                {
                    h1 = 0;
                    h2 = 8;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 21)
                {
                    h1 = 0;
                    h2 = 9;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 22)
                {
                    h1 = 1;
                    h2 = 0;
                }
                else if (((Deloreanlist[index].pasth1 * 10) + Deloreanlist[index].pasth2) == 23)
                {
                    h1 = 1;
                    h2 = 1;
                }
                #endregion

                //hour display
                img = displaymunber(h1, time.Past);
                if (File.Exists(image + "\\hour\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\hour\\1" + img, new Point(loc.X + X + 250, loc.Y + Y + 60), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(h2, time.Past);
                if (File.Exists(image + "\\hour\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\hour\\2" + img, new Point(loc.X + X + 270, loc.Y + Y + 60), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }

                if (((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2) > 12)
                {
                    Deloreanlist[index].fampm = "pm";
                }
                else
                {
                    Deloreanlist[index].fampm = "am";
                }

                //ampm
                img = "\\amber " + Deloreanlist[index].pastampm + ".jpg";
                if (File.Exists(image + img))
                {
                    Sprite.DrawTexture(image + img, new Point(loc.X + X + 220, loc.Y + Y + 62), new Size(20, 28));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(loc.X + X, loc.Y + Y + 50), (float)0.6);
                    debug2.Draw();
                }

                //tick
                if (tick != temptick)
                {
                    if (ticktock)
                    {
                        ticktock = false;
                    }
                    else
                    {
                        ticktock = true;
                    }
                    temptick = tick;
                }
                else
                {
                    if (ticktock)
                    {
                        img = "\\amber colon on.jpg";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(loc.X + X + 287, loc.Y + Y + 70), new Size(10, 14));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                    else
                    {
                        img = "\\amber colon off.jpg";
                        if (File.Exists(image + img))
                        {
                            Sprite.DrawTexture(image + img, new Point(loc.X + X + 287, loc.Y + Y + 70), new Size(10, 14));
                        }
                        else
                        {
                            UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                            debug2.Draw();
                        }
                    }
                }

                //minute display
                img = displaymunber(Deloreanlist[index].pastm1, time.Past);
                if (File.Exists(image + "\\min\\1" + img))
                {
                    Sprite.DrawTexture(image + "\\min\\1" + img, new Point(loc.X + X + 300, loc.Y + Y + 60), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                img = displaymunber(Deloreanlist[index].pastm2, time.Past);
                if (File.Exists(image + "\\min\\2" + img))
                {
                    Sprite.DrawTexture(image + "\\min\\2" + img, new Point(loc.X + X + 320, loc.Y + Y + 60), new Size(20, 29));
                }
                else
                {
                    UIText debug2 = new UIText("File is not present: " + img, new Point(400, 100), (float)0.6);
                    debug2.Draw();
                }
                #endregion
            }
            else
            {
                UIText debug2 = new UIText("images folder not present. Please place images folder in the scripts folder" + image, new Point(400, 100), (float)0.6);
                debug2.Draw();
            }

        }

        #endregion

        public static bool runoncefeul = false;
        public static bool flyingturnedon = false;
        public static bool stoponce = false;
        public static float flyspeed = 0;
        public static int steer = 0;
        public bool sparkprotect = false;
        public void time_circuits_while_inside_another_car(int index)
        {
            if (!(Deloreanlist[index].Deloreon == null))
            {
                if (Deloreanlist[index].toggletimecurcuits)
                {
                    if (Deloreanlist[index].Deloreon.Speed * 2.4 > 84 && Deloreanlist[index].Deloreon.Speed * 2.4 < 88)
                    {
                        World.DrawLightWithRange(Deloreanlist[index].Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.Cyan, (float)1.2, 300);
                        if (!Deloreanlist[index].past84)
                        {
                            if (Deloreanlist[index].refilltimecurcuits)
                            {
                                sparksfeul.PlayLooping();
                                delay.Start();
                                Deloreanlist[index].Deloreon.IsInvincible = true;
                                Deloreanlist[index].Deloreon.CanBeVisiblyDamaged = false;
                            }
                            else
                            {
                                sparks.PlayLooping();
                            }
                            Deloreanlist[index].past84 = true;
                        }
                    }
                    else if (Deloreanlist[index].Deloreon.Speed * 2.4 >= 88)
                    {
                        World.DrawLightWithRange(Deloreanlist[index].Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.Cyan, (float)1.2, 300);
                        if (Deloreanlist[index].refilltimecurcuits)
                        {
                            if (delay.getdelay() < 5)
                            {
                                if (delay.getdelay() > 2)
                                {
                                    int eplode = (int)ExplosionType.FlameExplode;
                                    World.AddExplosion(Deloreanlist[index].Deloreon.GetOffsetInWorldCoords(new Vector3(1, 4, -2)), (ExplosionType)eplode, (float)1, 0);
                                    World.AddExplosion(Deloreanlist[index].Deloreon.GetOffsetInWorldCoords(new Vector3(-1, 4, -2)), (ExplosionType)eplode, (float)1, 0);
                                }
                            }
                            else
                            {
                                World.AddExplosion(Deloreanlist[index].Deloreon.Position, ExplosionType.Car, 10, 0);
                                Timetravelreentery.Play();

                                if (!stoponce)
                                {
                                    Deloreanlist[index].Deloreon.Speed = 0;
                                    stoponce = true;
                                }
                                if (!Variableclass.sendinvincible)
                                {
                                    Deloreanlist[index].Deloreon.IsInvincible = true;
                                    Deloreanlist[index].Deloreon.CanBeVisiblyDamaged = false;
                                }
                                Deloreanlist[index].Deloreon.IsVisible = false;
                                enterintime();
                                delay.Reset();
                                delay.Stop();
                            }
                        }
                    }
                    else
                    {
                        if (Deloreanlist[index].past84)
                        {
                            if (!entertime)
                            {
                                stoponce = false;
                                sparks.Stop();
                            }
                        }
                        delay.Stop();
                        delay.Reset();
                        Tickreentry(index);
                        tickfreeze(index);
                        Deloreanlist[index].past84 = false;
                    }
                }
            }
        }

        void make_effect(string root, string effect, int index)
        {
            Function.Call(Hash._0xDD19FA1C6D657305, new InputArgument[] { Deloreanlist[index].Deloreon.Position.X, Deloreanlist[index].Deloreon.Position.Y, Deloreanlist[index].Deloreon.Position.Z, 10 });
            Function.Call(Hash._0xB80D8756B4668AB6, new InputArgument[] { root });
            Function.Call(Hash._0x6C38AF3693A69A91, new InputArgument[] { root });
            Function.Call(Hash._0x0D53A3B8DA0809D2, new InputArgument[] { effect, Game.Player.Character.CurrentVehicle.Handle, 0.0, 3.0, 0.5, 0.0, 0.0, 0.0, 3.0, 0, 0, 0 });
        }

        Constanttimerclass timertodelete = new Constanttimerclass();
        List<Vehicle> deaddelorean = new List<Vehicle>();
        void setfordeletion(Vehicle delorean)
        {
            deaddelorean.Add(delorean);
        }

        int deletioncount = 0;
        void deletiontick()
        {
            timertodelete.Delay_changer();
            if (deaddelorean.Count > 0)
                if (DateTime.Now.Millisecond % 60 >= 30 && DateTime.Now.Millisecond % 60 <= 60)
                {
                    if (deletioncount == 1000)
                    {
                        foreach (Vehicle dead in deaddelorean)
                        {
                            dead.Delete();
                        }
                        deletioncount = 0;
                    }

                    deletioncount++;
                }
            //UI.ShowSubtitle("delete: " + deletioncount);
        }

        void Deloreonfunctioning(int index)
        {
            #region functions
            display_background();
            UIResText Deloreanlistnum = new UIResText("Number of Time Machines: " + Deloreanlist.Count.ToString(), new Point(loc.X, loc.Y - 50), (float)0.6, Color.Red);
            Deloreanlistnum.Draw();
            UIResText Deloreanspeed = new UIResText("Speed: " + (int)((Deloreanlist[index].Deloreon.Speed / .27777) / 1.60934), new Point(loc.X, loc.Y - 130), (float)0.6, Color.Red);
            Deloreanspeed.Draw();
            UIResText Deloreanpos = new UIResText(Deloreanlist[index].Deloreon.Rotation.ToString(), new Point(500, loc.Y - 130), (float)0.6, Color.Red);

            if (!Deloreanlist[index].engineturningon)
            {
                if (!Deloreanlist[index].engineison)
                {
                    if (!Deloreanlist[index].RCmode)
                    {
                        //engineon.Play();
                        Deloreanlist[index].Deloreon.EngineRunning = true;
                    }
                    Deloreanlist[index].engineison = true;
                    Deloreanlist[index].engineturningon = true;
                    Deloreanlist[index].ifwentoutoffcar = false;
                    Function.Call(Hash.SET_VEHICLE_ENGINE_ON, Game.Player.Character.CurrentVehicle, true);
                }
            }

            if (!Game.Player.Character.CurrentVehicle.IsDriveable)
            {
                if (!Deloreanlist[index].carjustdied)
                {
                    Deloreanlist[index].carjustdied = true;
                    trend.Play();
                    setfordeletion(Deloreanlist[index].Deloreon);
                    Deloreanlist[index].Deloreon.IsPersistent = false;
                    Deloreanlist[index].Deloreon = null;
                    Game.Player.Character.CurrentVehicle.Detach();
                    Deloreanlist[index].ifwentoutoffcar = true;
                    Deloreanlist.Remove(Deloreanlist[index]);
                }
            }

            if (Deloreanlist[index].refilltimecurcuits)
            {
                if (runoncefeul)
                {
                    if (Mrfusionrefilltimer.getdelay() >= 3)
                    {
                        Mrfusionrefilltimer.Stop();
                        Mrfusionrefilltimer.Reset();
                        inputonfeul.Play();
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                        Deloreanlist[index].Deloreon.SetMod(VehicleMod.FrontBumper, 0, true);
                        Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, -1, true);
                        runoncefeul = false;
                    }
                }
                if (Mrfusionrefilltimer.getdelay() < 3)
                {
                    if (!Deloreanlist[index].toggletimecurcuits)
                    {
                        if (!freezestarted)
                        {
                            Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                            Deloreanlist[index].Deloreon.SetMod(VehicleMod.FrontBumper, -1, true);
                            Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, -1, true);
                        }
                    }
                }
            }
            else
            {
                if (!freezestarted)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.FrontBumper, -1, true);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, -1, true);
                }
            }
            #endregion

            if (Deloreanlist[index].toggletimecurcuits)
            {
                //timedisplay
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                Deloreanlist[index].Deloreon.SetMod(VehicleMod.SideSkirt, 0, true);
                //Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 8, 0 });
                tick(index);
                int tempspeed = (int)((Deloreanlist[index].Deloreon.Speed / .27777) / 1.60934);
                
                if (tempspeed > 84 && tempspeed < 88)
                {
                    sparkprotect = true;
                    if (!below84)
                    {
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                        Deloreanlist[index].Deloreon.SetMod(VehicleMod.Spoilers, 0, true);
                        Deloreanlist[index].Deloreon.SetMod(VehicleMod.Frame, 5, true);
                        if (Deloreanlist[index].refilltimecurcuits)
                            make_effect("scr_martin1", "scr_sol1_sniper_impact", index);
                    }
                    World.DrawLightWithRange(Deloreanlist[index].Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.DodgerBlue, (float)1.2, 400);
                    if (!Deloreanlist[index].past84)
                    {
                        if (Deloreanlist[index].refilltimecurcuits)
                        {
                            sparksfeul.PlayLooping();
                            delay.Start();
                            Deloreanlist[index].Deloreon.IsInvincible = true;
                            Deloreanlist[index].Deloreon.CanBeVisiblyDamaged = false;
                        }
                        else
                        {
                            sparks.PlayLooping();
                        }
                        Deloreanlist[index].past84 = true;
                    }
                }
                else if (tempspeed >= 88)
                {
                    if (!below84)
                    {
                        Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                        Deloreanlist[index].Deloreon.SetMod(VehicleMod.Spoilers, 0, true);
                        Deloreanlist[index].Deloreon.SetMod(VehicleMod.Frame, 5, true);
                        if (Deloreanlist[index].refilltimecurcuits)
                            make_effect("scr_martin1", "scr_sol1_sniper_impact", index);
                    }
                    World.DrawLightWithRange(Deloreanlist[index].Deloreon.GetOffsetInWorldCoords(new Vector3(0, (float)2.2, (float)0.5)), Color.DodgerBlue, (float)1.2, 400);
                    if (Deloreanlist[index].refilltimecurcuits)
                    {
                        if (delay.getdelay() < 5)
                        {
                            if (delay.getdelay() > 2)
                            {

                            }
                        }
                        else
                        {
                            if (Function.Call<int>(Hash.GET_FOLLOW_VEHICLE_CAM_VIEW_MODE) == 4)
                            {
                                Deloreanlist[index].timetravelentry();
                                Timetravelreentery.Play();
                                Ped[] peds = World.GetNearbyPeds(Game.Player.Character, 1000);
                                Vehicle[] pedVehicles = World.GetNearbyVehicles(Game.Player.Character, 1000);
                                for (int i = 0; i < peds.Length; i++)
                                {
                                    if (peds[i] != Game.Player.Character)
                                        GTA.Native.Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, peds[i], 0, 0, 0, 0, 0, 1);
                                }
                                Array.Clear(peds, 0, peds.Length);
                                for (int i = 0; i < pedVehicles.Length; i++)
                                {
                                    if (pedVehicles[i] != Game.Player.Character.CurrentVehicle)
                                        GTA.Native.Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, pedVehicles[i], 0, 0, 0, 0, 0, 1);
                                }
                                Array.Clear(pedVehicles, 0, pedVehicles.Length);
                                //End Ped Despawning

                                GTA.Native.Function.Call(GTA.Native.Hash.SET_RANDOM_WEATHER_TYPE);
                                //Function.Call(Hash.SET_CLOCK_DATE, Deloreanlist[index].getmonth(), Deloreanlist[index].getday(), Deloreanlist[index].getyear());
                                Function.Call(Hash.SET_CLOCK_TIME, ((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2), Deloreanlist[index].getminute(), 0);

                                Game.Player.WantedLevel = 0;

                                Player_time_class.pastday1 = Deloreanlist[index].pastday1;
                                Player_time_class.pastday2 = Deloreanlist[index].pastday2;
                                Player_time_class.pastmonth1 = Deloreanlist[index].pastmonth1;
                                Player_time_class.pastmonth2 = Deloreanlist[index].pastmonth2;
                                Player_time_class.pasty1 = Deloreanlist[index].pasty1;
                                Player_time_class.pasty2 = Deloreanlist[index].pasty2;
                                Player_time_class.pasty3 = Deloreanlist[index].pasty3;
                                Player_time_class.pasty4 = Deloreanlist[index].pasty4;
                                Player_time_class.pasth1 = Deloreanlist[index].pasth1;
                                Player_time_class.pasth2 = Deloreanlist[index].pasth2;
                                Player_time_class.pastm1 = Deloreanlist[index].pastm1;
                                Player_time_class.pastm2 = Deloreanlist[index].pastm2;
                                Player_time_class.pastampm = Deloreanlist[index].pastampm;
                                Player_time_class.presday1 = Deloreanlist[index].presday1;
                                Player_time_class.presday2 = Deloreanlist[index].presday2;
                                Player_time_class.presmonth1 = Deloreanlist[index].presmonth1;
                                Player_time_class.presmonth2 = Deloreanlist[index].presmonth2;
                                Player_time_class.presy1 = Deloreanlist[index].presy1;
                                Player_time_class.presy2 = Deloreanlist[index].presy2;
                                Player_time_class.presy3 = Deloreanlist[index].presy3;
                                Player_time_class.presy4 = Deloreanlist[index].presy4;
                                Player_time_class.presh1 = Deloreanlist[index].presh1;
                                Player_time_class.presh2 = Deloreanlist[index].presh2;
                                Player_time_class.presm1 = Deloreanlist[index].presm1;
                                Player_time_class.presm2 = Deloreanlist[index].presm2;
                                Player_time_class.presampm = Deloreanlist[index].presampm;
                                Player_time_class.fday1 = Deloreanlist[index].fday1;
                                Player_time_class.fday2 = Deloreanlist[index].fday2;
                                Player_time_class.fmonth1 = Deloreanlist[index].fmonth1;
                                Player_time_class.fmonth2 = Deloreanlist[index].fmonth2;
                                Player_time_class.fy1 = Deloreanlist[index].fy1;
                                Player_time_class.fy2 = Deloreanlist[index].fy2;
                                Player_time_class.fy3 = Deloreanlist[index].fy3;
                                Player_time_class.fy4 = Deloreanlist[index].fy4;
                                Player_time_class.fh1 = Deloreanlist[index].fh1;
                                Player_time_class.fh2 = Deloreanlist[index].fh2;
                                Player_time_class.fm1 = Deloreanlist[index].fm1;
                                Player_time_class.fm2 = Deloreanlist[index].fm2;
                                Player_time_class.fampm = Deloreanlist[index].fampm;
                                Deloreanlist[index].refilltimecurcuits = false;
                                Deloreanlist[index].Deloreon.DirtLevel = 12;
                                below84 = true;
                                if (Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 10 }))
                                {
                                    Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 10, -1 });
                                }
                                startfreeze();
                                Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                                Deloreanlist[index].Deloreon.SetMod(VehicleMod.Spoilers, 1, true);
                                Deloreanlist[index].Deloreon.SetMod(VehicleMod.FrontBumper, -1, true);
                            }
                            else
                            {
                                enterintime();
                                make_effect("scr_rcpaparazzo1", "scr_rcpap1_camera", index);

                                Timetravelreenterycutscene.Play();
                                //Timetravelreentery.Play();
                                if (!stoponce)
                                {
                                    Deloreanlist[index].Deloreon.Speed = 0;
                                    stoponce = true;
                                }
                                if (!Variableclass.sendinvincible)
                                {
                                    Deloreanlist[index].Deloreon.IsInvincible = true;
                                }
                                Deloreanlist[index].Deloreon.IsVisible = false;

                                below48();
                                Game.Player.CanControlCharacter = false;

                                delay.Reset();
                                delay.Stop();
                                int tempcount = 0;
                                while (tempcount <= 30)
                                {
                                    int eplode = (int)ExplosionType.FlameExplode;
                                    World.AddExplosion(Deloreanlist[index].Deloreon.GetOffsetInWorldCoords(new Vector3(1, tempcount + 3, -2)), (ExplosionType)eplode, (float)1, 0);
                                    World.AddExplosion(Deloreanlist[index].Deloreon.GetOffsetInWorldCoords(new Vector3(-1, tempcount + 3, -2)), (ExplosionType)eplode, (float)1, 0);
                                    tempcount++;
                                    Application.DoEvents();
                                }
                                if (Game.Player.WantedLevel > 0)
                                {
                                    Game.Player.WantedLevel = 0;
                                }
                                rentry.Start();
                                if (Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 10 }))
                                {
                                    Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 10, -1 });
                                }
                                Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                                Deloreanlist[index].Deloreon.SetMod(VehicleMod.Spoilers, 1, true);
                                Deloreanlist[index].Deloreon.SetMod(VehicleMod.FrontBumper, -1, true);
                            }
                        }
                    }
                }
                else
                {
                    if (Deloreanlist[index].past84)
                    {
                        if (!entertime)
                        {
                            sparkprotect = false;
                            stoponce = false;
                            sparks.Stop();
                            Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                            Deloreanlist[index].Deloreon.SetMod(VehicleMod.Spoilers, 1, true);
                        }
                    }

                    if (Function.Call<int>(Hash.GET_FOLLOW_VEHICLE_CAM_VIEW_MODE) == 4)
                    {
                        below84 = false;
                    }
                    delay.Stop();
                    delay.Reset();
                    Deloreanlist[index].past84 = false;
                    flux_capcitor(index);
                }
            }
            else
            {
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                Deloreanlist[index].Deloreon.SetMod(VehicleMod.FrontBumper, -1, true);
                Deloreanlist[index].Deloreon.SetMod(VehicleMod.SideSkirt, -1, true);
                Deloreanlist[index].Deloreon.SetMod(VehicleMod.Spoilers, -1, true);
                Deloreanlist[index].Deloreon.SetMod(VehicleMod.Frame, -1, true);
                Deloreanlist[index].Deloreon.SetMod(VehicleMod.Grille, -1, true);
            }
        }
        bool startcar = false;
        int fluxanim = 0;
        bool timeonce = false;
        void flux_capcitor(int index)
        {
            //UIText debug2 = new UIText("Time: " + DateTime.Now.Millisecond % 500, new Point(200, 100), (float)0.6);
            //debug2.Draw();
            if (DateTime.Now.Millisecond % 120 >= 60 && DateTime.Now.Millisecond % 120 <= 120)
            {
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                
                if (!timeonce)
                {
                    fluxanim++;

                    if (fluxanim == 2)
                    {
                        fluxanim = 0;
                    }

                    if (fluxanim == 0)
                    {
                        Deloreanlist[index].Deloreon.SetMod(VehicleMod.Frame, 1, true);

                    }
                    else if (fluxanim == 1)
                    {
                        Deloreanlist[index].Deloreon.SetMod(VehicleMod.Frame, 2, true);
                    }
                    timeonce = true;
                }
            }
            else
            {
                timeonce = false;
            }
        }
        public static string keystring = "";
        public void Check(object sender, EventArgs e)
        {
            if (mrfusiontask.running())
                mrfusiontask.Delay_changer();

            if (delay.running())
                delay.Delay_changer();

            if (Mrfusionrefilltimer.running())
                Mrfusionrefilltimer.Delay_changer();

            deletiontick();
            if (rentry.running())
            {
                for (int i = 0; i < Deloreanlist.Count; i++)
                {
                    if (!(Deloreanlist[i].Deloreon == null))
                    {
                        if (Deloreanlist[i].Deloreon == Game.Player.Character.CurrentVehicle)
                        {
                            rentry.Delay_changer();
                            Tickreentry(i);
                        }
                    }
                    Application.DoEvents();
                }
            }
          
            if (freeze.running())
            {
                for (int i = 0; i < Deloreanlist.Count; i++)
                {
                    if (!(Deloreanlist[i].Deloreon == null))
                    {
                        tickfreeze(i);
                        freeze.Delay_changer();
                    }
                    Application.DoEvents();
                }
            }

            if (Variableclass.rcmode_send)
            {
                Variableclass.rcmode_send = false;
                if (!(Deloreanlist[Variableclass.RCfeqency].Deloreon == null))
                    ToggleRCmode(Variableclass.RCfeqency);
            }

            if (!(Deloreanlist[Variableclass.RCfeqency].Deloreon == null))
                if (Game.Player.Character.CurrentVehicle == Deloreanlist[Variableclass.RCfeqency].Deloreon)
                {
                    if (Deloreanlist[Variableclass.RCfeqency].RCmode)
                    {
                        if (!(Deloreanlist[Variableclass.RCfeqency].RCped == null))
                        {
                            if (!Deloreanlist[Variableclass.RCfeqency].RCped.IsInVehicle())
                            {
                                ToggleRCmode(Variableclass.RCfeqency);
                            }
                        }
                    }
                }

            if (Variableclass.resetall)
            {
                Variableclass.resetall = false;
                RemoveDelorean();
            }

            for (int index = 0; index < Deloreanlist.Count; index++)
            {
                if (Game.Player.Character.IsInVehicle() || Deloreanlist[index].RCmode)
                {
                    if (!(Deloreanlist[index].Deloreon == null))
                    {
                        if (Game.Player.Character.CurrentVehicle == Deloreanlist[index].Deloreon)
                        {
                            if (!startcar)
                            {
                                engineon.Play();
                                startcar = true;
                            }

                            if (Variableclass.sendinvincible)
                            {
                                Deloreanlist[index].Deloreon.IsInvincible = true;
                                Deloreanlist[index].Deloreon.CanBeVisiblyDamaged = false;
                            }
                            else
                            {
                                if (!sparkprotect)
                                {
                                    Deloreanlist[index].Deloreon.IsInvincible = false;
                                    Deloreanlist[index].Deloreon.CanBeVisiblyDamaged = true;
                                }
                                else
                                {
                                    Deloreanlist[index].Deloreon.IsInvincible = true;
                                    Deloreanlist[index].Deloreon.CanBeVisiblyDamaged = false;
                                }
                            }

                            if (Variableclass.sent_message_to_circuits)
                            {
                                Variableclass.sent_message_to_circuits = false;
                                Deloreanlist[index].timesurcuitsswitch();
                            }

                            if (Game.IsKeyPressed(Keys.Oemplus) || Game.IsKeyPressed(Keys.Add))
                            {
                                if (!Variableclass.keypressed)
                                {
                                    Deloreanlist[index].timesurcuitsswitch();
                                    Variableclass.keypressed = true;
                                }
                            }

                            if (Game.IsKeyPressed(Keys.L))
                            {
                                if (!Variableclass.keypressed)
                                {
                                    //UI.ShowSubtitle("Flying mode", 5);
                                    Toggleflight(index);
                                    //startfreeze();
                                    Variableclass.keypressed = true;
                                }
                            }
                            if (Game.IsKeyPressed(Keys.K))
                            {
                                if (!Variableclass.keypressed)
                                {

                                    Variableclass.keypressed = true;
                                }
                            }
                            if (Game.IsKeyPressed(Keys.J))
                            {
                                if (!Variableclass.keypressed)
                                {

                                    Variableclass.keypressed = true;
                                }
                            }
                            else if (Game.IsKeyPressed(Keys.Space))
                            {
                                if (Deloreanlist[index].flyingison)
                                {
                                    Deloreanlist[index].Deloreon.ApplyForceRelative(new Vector3(0, (float)1.8, 0));
                                    if (!Variableclass.keypressed)
                                    {
                                        //UI.ShowSubtitle("Flying mode", 5);
                                        hoverboost.Play();
                                        Variableclass.keypressed = true;
                                    }
                                }
                            }
                            else if (keystring == "ControlKey")
                            {
                                Deloreanlist[index].Deloreon.ApplyForceRelative(new Vector3(0, (float)-1.8, 0));
                                keystring = "";
                                if (!Variableclass.keypressed)
                                {
                                    //UI.ShowSubtitle("Flying mode", 5);
                                    hoverup.Play();
                                    Variableclass.keypressed = true;
                                }
                            }

                            if (Deloreanlist[index].toggletimecurcuits)
                            {
                                if (!Deloreanlist[index].refilltimecurcuits)
                                {
                                    UI.ShowSubtitle("Fill up Mr.Fusion to enable time travel.");
                                }

                                if (Game.Player.Character.CurrentVehicle == Deloreanlist[index].Deloreon)
                                {
                                    if (!Variableclass.keypressed)
                                    {
                                        if (Game.IsKeyPressed(Keys.D0) || Game.IsKeyPressed(Keys.NumPad0))
                                        {
                                            Deloreanlist[index].keyset(Keys.NumPad0);
                                            Variableclass.keypressed = true;
                                        }
                                        else if (Game.IsKeyPressed(Keys.D1) || Game.IsKeyPressed(Keys.NumPad1))
                                        {
                                            Deloreanlist[index].keyset(Keys.NumPad1);
                                            Variableclass.keypressed = true;
                                        }
                                        else if (Game.IsKeyPressed(Keys.D2) || Game.IsKeyPressed(Keys.NumPad2))
                                        {
                                            Deloreanlist[index].keyset(Keys.NumPad2);
                                            Variableclass.keypressed = true;
                                        }
                                        else if (Game.IsKeyPressed(Keys.D3) || Game.IsKeyPressed(Keys.NumPad3))
                                        {
                                            Deloreanlist[index].keyset(Keys.NumPad3);
                                            Variableclass.keypressed = true;
                                        }
                                        else if (Game.IsKeyPressed(Keys.D4) || Game.IsKeyPressed(Keys.NumPad4))
                                        {
                                            Deloreanlist[index].keyset(Keys.NumPad4);
                                            Variableclass.keypressed = true;
                                        }
                                        else if (Game.IsKeyPressed(Keys.D5) || Game.IsKeyPressed(Keys.NumPad5))
                                        {
                                            Deloreanlist[index].keyset(Keys.NumPad5);
                                            Variableclass.keypressed = true;
                                        }
                                        else if (Game.IsKeyPressed(Keys.D6) || Game.IsKeyPressed(Keys.NumPad6))
                                        {
                                            Deloreanlist[index].keyset(Keys.NumPad6);
                                            Variableclass.keypressed = true;
                                        }
                                        else if (Game.IsKeyPressed(Keys.D7) || Game.IsKeyPressed(Keys.NumPad7))
                                        {
                                            Deloreanlist[index].keyset(Keys.NumPad7);
                                            Variableclass.keypressed = true;
                                        }
                                        else if (Game.IsKeyPressed(Keys.D8) || Game.IsKeyPressed(Keys.NumPad8))
                                        {
                                            Deloreanlist[index].keyset(Keys.NumPad8);
                                            Variableclass.keypressed = true;
                                        }
                                        else if (Game.IsKeyPressed(Keys.D9) || Game.IsKeyPressed(Keys.NumPad9))
                                        {
                                            Deloreanlist[index].keyset(Keys.NumPad9);
                                            Variableclass.keypressed = true;
                                        }
                                        else if (Game.IsKeyPressed(Keys.Enter))
                                        {
                                            Deloreanlist[index].keyset(Keys.Enter);
                                            Variableclass.keypressed = true;
                                        }
                                    }
                                }
                            }
                            Deloreonfunctioning(index);
                        }
                        else
                        {
                            time_circuits_while_inside_another_car(index);
                        }
                    }
                }
                else
                {
                    startcar = false;
                    if (Game.IsKeyPressed(Keys.Subtract) || Game.IsKeyPressed(Keys.OemMinus))
                    {
                        if (!(Deloreanlist[index].Deloreon == null))
                        {
                            if (!Deloreanlist[index].MrFusionfilltask)
                            {
                                if (!Variableclass.keypressed)
                                {
                                    ToggleMrfusion(index);
                                    Variableclass.keypressed = false;
                                }
                            }
                        }
                    }
                    playerout(index);
                }
                Application.DoEvents(); 
            }
        }

        Constanttimerclass mrfusiontask = new Constanttimerclass();

        void playerout(int index)
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

            if (!(Deloreanlist[index].Deloreon == null))
            {
                #region functions

                if (!Deloreanlist[index].ifwentoutoffcar)
                {
                    if (!Deloreanlist[index].carjustdied)
                    {
                        if (!Deloreanlist[index].RCmode)
                        {
                            engineoff.Play();
                            Deloreanlist[index].Deloreon.EngineRunning = false;
                        }
                    }
                    Deloreanlist[index].ifwentoutoffcar = true;
                    Deloreanlist[index].engineturningon = false; ;
                }
                Deloreanlist[index].engineison = false;

                if (Deloreanlist[index].MrFusionfilltask)
                {
                    if (!Deloreanlist[index].refilltimecurcuits)
                    {
                        mrfusiontask.Start();
                        Mrfrusionfill.Play();
                        Deloreanlist[index].Deloreon.OpenDoor(VehicleDoor.Trunk, false, false);
                        Game.Player.CanControlCharacter = false;
                        Deloreanlist[index].refilltimecurcuits = true;
                    }

                    if (mrfusiontask.getdelay() >= 5)
                    {
                        Game.Player.CanControlCharacter = true;
                        Deloreanlist[index].Deloreon.CloseDoor(VehicleDoor.Trunk, false);
                        Deloreanlist[index].MrFusionfilltask = false;
                        //Deloreanlist[index].Mrfusionpower = 100;
                        mrfusiontask.Stop();
                        mrfusiontask.Reset();
                    }
                }

                if (!Deloreanlist[index].Deloreon.IsDriveable)
                {
                    if (!Deloreanlist[index].carjustdied)
                    {
                        Deloreanlist[index].carjustdied = true;
                        if (!(Deloreanlist[index].Deloreon == null))
                        {
                            if (!Variableclass.resetall)
                            {
                                trend.Play();
                            }
                        }
                        Deloreanlist[index].Deloreon.IsPersistent = false;
                        Deloreanlist[index].Deloreon.MarkAsNoLongerNeeded();
                        Deloreanlist[index].Deloreon = null;
                        Deloreanlist[index].engineison = false;
                        Deloreanlist[index].ifwentoutoffcar = true;
                        Deloreanlist.Remove(Deloreanlist[index]);
                    }
                }
                #endregion
            }
        }

        Constanttimerclass rentry = new Constanttimerclass();
        bool entertime = false;
        bool runonce = false;
        bool runonce2 = false;

        public void enterintime()
        {
            entertime = true;
        }

        public bool getenterintime()
        {
            return entertime;
        }

        public bool below84 = false;
        public void below48()
        {
            below84 = true;
        }
        bool timeentry = false;
        bool speedonce = false;

        int exploding = 0;

        public void Tickreentry(int index)
        {
            if (below84)
            {
                if (!runonce)
                {
                    if (Game.Player.Character.IsInVehicle(Deloreanlist[index].Deloreon))
                    {
                        rentry.Reset();
                    }
                    runonce = true;
                }

                if (rentry.getdelay() < 40)
                {
                    if (rentry.getdelay() > 2 && rentry.getdelay() < 3)
                    {
                        if (!entertime)
                        {
                            if (!Variableclass.sendinvincible)
                            {
                                Deloreanlist[index].Deloreon.IsInvincible = false;
                            }
                            below84 = false;
                            runonce = false;
                            sparks.Stop();
                            rentry.Stop();
                            rentry.Reset();
                            Game.Player.CanControlCharacter = true;
                            Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                            Deloreanlist[index].Deloreon.SetMod(VehicleMod.Spoilers, 1, true);
                        }
                    }
                    else if (rentry.getdelay() > 10 && rentry.getdelay() < 11)
                    {
                        Game.FadeScreenOut(600);
                    }
                    else if (rentry.getdelay() > 17 && rentry.getdelay() < 18)
                    {
                        if (!timeentry)
                        {
                            Deloreanlist[index].timetravelentry();
                            //Start Ped Despawning
                            Ped[] peds = World.GetNearbyPeds(Game.Player.Character, 1000);
                            Vehicle[] pedVehicles = World.GetNearbyVehicles(Game.Player.Character, 1000);
                            for (int i = 0; i < peds.Length; i++)
                            {
                                if (peds[i] != Game.Player.Character)
                                    GTA.Native.Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, peds[i], 0, 0, 0, 0, 0, 1);
                            }
                            Array.Clear(peds, 0, peds.Length);
                            for (int i = 0; i < pedVehicles.Length; i++)
                            {
                                if (pedVehicles[i] != Game.Player.Character.CurrentVehicle)
                                    GTA.Native.Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, pedVehicles[i], 0, 0, 0, 0, 0, 1);
                            }
                            Array.Clear(pedVehicles, 0, pedVehicles.Length);
                            //End Ped Despawning

                            GTA.Native.Function.Call(GTA.Native.Hash.SET_RANDOM_WEATHER_TYPE);
                            //Function.Call(Hash.SET_CLOCK_DATE, Deloreanlist[index].getmonth(), Deloreanlist[index].getday(), Deloreanlist[index].getyear());
                            Function.Call(Hash.SET_CLOCK_TIME, ((Deloreanlist[index].fh1 * 10) + Deloreanlist[index].fh2), Deloreanlist[index].getminute(), 0);
                            timeentry = true;
                        }
                    }
                    else if (rentry.getdelay() > 19 && rentry.getdelay() < 20)
                    {
                        timeentry = false;
                        if (Game.Player.Character.IsInVehicle(Deloreanlist[index].Deloreon))
                        {
                            Game.FadeScreenIn(300);
                        }
                    }
                    else if (rentry.getdelay() > 21 && rentry.getdelay() < 22)
                    {
                        if (!runonce2)
                        {
                            reenterybttf2.Play();
                            if (exploding == 0)
                            {
                                World.AddExplosion(Deloreanlist[index].Deloreon.Position, ExplosionType.SmokeG, 10, 0);
                                exploding = 1;
                            }
                            Game.Player.WantedLevel = 0;

                            Player_time_class.pastday1 = Deloreanlist[index].pastday1;
                            Player_time_class.pastday2 = Deloreanlist[index].pastday2;
                            Player_time_class.pastmonth1 = Deloreanlist[index].pastmonth1;
                            Player_time_class.pastmonth2 = Deloreanlist[index].pastmonth2;
                            Player_time_class.pasty1 = Deloreanlist[index].pasty1;
                            Player_time_class.pasty2 = Deloreanlist[index].pasty2;
                            Player_time_class.pasty3 = Deloreanlist[index].pasty3;
                            Player_time_class.pasty4 = Deloreanlist[index].pasty4;
                            Player_time_class.pasth1 = Deloreanlist[index].pasth1;
                            Player_time_class.pasth2 = Deloreanlist[index].pasth2;
                            Player_time_class.pastm1 = Deloreanlist[index].pastm1;
                            Player_time_class.pastm2 = Deloreanlist[index].pastm2;
                            Player_time_class.pastampm = Deloreanlist[index].pastampm;
                            Player_time_class.presday1 = Deloreanlist[index].presday1;
                            Player_time_class.presday2 = Deloreanlist[index].presday2;
                            Player_time_class.presmonth1 = Deloreanlist[index].presmonth1;
                            Player_time_class.presmonth2 = Deloreanlist[index].presmonth2;
                            Player_time_class.presy1 = Deloreanlist[index].presy1;
                            Player_time_class.presy2 = Deloreanlist[index].presy2;
                            Player_time_class.presy3 = Deloreanlist[index].presy3;
                            Player_time_class.presy4 = Deloreanlist[index].presy4;
                            Player_time_class.presh1 = Deloreanlist[index].presh1;
                            Player_time_class.presh2 = Deloreanlist[index].presh2;
                            Player_time_class.presm1 = Deloreanlist[index].presm1;
                            Player_time_class.presm2 = Deloreanlist[index].presm2;
                            Player_time_class.presampm = Deloreanlist[index].presampm;
                            Player_time_class.fday1 = Deloreanlist[index].fday1;
                            Player_time_class.fday2 = Deloreanlist[index].fday2;
                            Player_time_class.fmonth1 = Deloreanlist[index].fmonth1;
                            Player_time_class.fmonth2 = Deloreanlist[index].fmonth2;
                            Player_time_class.fy1 = Deloreanlist[index].fy1;
                            Player_time_class.fy2 = Deloreanlist[index].fy2;
                            Player_time_class.fy3 = Deloreanlist[index].fy3;
                            Player_time_class.fy4 = Deloreanlist[index].fy4;
                            Player_time_class.fh1 = Deloreanlist[index].fh1;
                            Player_time_class.fh2 = Deloreanlist[index].fh2;
                            Player_time_class.fm1 = Deloreanlist[index].fm1;
                            Player_time_class.fm2 = Deloreanlist[index].fm2;
                            Player_time_class.fampm = Deloreanlist[index].fampm;
                            runonce2 = true;
                        }
                    }
                    else if (rentry.getdelay() > 22 && rentry.getdelay() < 23)
                    {
                        if (exploding == 1)
                        {
                            World.AddExplosion(Deloreanlist[index].Deloreon.Position, ExplosionType.SmokeG, 10, 0);
                            exploding = 2;
                        }
                    }
                    else if (rentry.getdelay() > 23 && rentry.getdelay() < 24)
                    {
                        if (exploding == 2)
                        {
                            World.AddExplosion(Deloreanlist[index].Deloreon.Position, ExplosionType.SmokeG, 10, 0);
                        }
                        exploding = 0;

                        if (entertime)
                        {
                            if (Deloreanlist[index].Deloreon.IsDoorBroken(VehicleDoor.FrontLeftDoor))
                            {
                                Game.Player.Character.Kill();
                            }
                            if (Deloreanlist[index].Deloreon.IsDoorBroken(VehicleDoor.FrontRightDoor))
                            {
                                Game.Player.Character.Kill();
                            }
                        }
                        //Deloreon.ApplyForce(Deloreon.GetOffsetFromWorldCoords(new Vector3(0, 48, 0)));
                        if (!speedonce)
                        {
                            Deloreanlist[index].Deloreon.Speed = 30;
                            speedonce = true;
                        }
                        //Deloreanlist[index].Mrfusionpower -= 3;
                        Deloreanlist[index].refilltimecurcuits = false;
                        entertime = false;
                        runonce2 = false;
                        Deloreanlist[index].resetrunonce();
                        Deloreanlist[index].Deloreon.IsVisible = true;
                        Game.Player.CanControlCharacter = true;
                        Deloreanlist[index].Deloreon.DirtLevel = 12;
                    }
                    else if (rentry.getdelay() >= 27)
                    {
                        sparkprotect = false;
                        runonce = false;
                        below84 = false;
                        speedonce = false;
                        if (!Variableclass.sendinvincible)
                        {
                            Deloreanlist[index].Deloreon.IsInvincible = false;
                        }
                        else
                        {
                            Deloreanlist[index].Deloreon.Repair();
                        }
                        rentry.Stop();
                        rentry.Reset();
                        startfreeze();
                    }
                }
            }
        }

        Constanttimerclass freeze = new Constanttimerclass();

        public bool freezestarted = false;
        void make_effect_smoke(string root, string effect, int index)
        {
            Function.Call(Hash._0xDD19FA1C6D657305, new InputArgument[] { Deloreanlist[index].Deloreon.Position.X, Deloreanlist[index].Deloreon.Position.Y, Deloreanlist[index].Deloreon.Position.Z, 10 });
            Function.Call(Hash._0xB80D8756B4668AB6, new InputArgument[] { root });
            Function.Call(Hash._0x6C38AF3693A69A91, new InputArgument[] { root });
            Function.Call(Hash._0x0D53A3B8DA0809D2, new InputArgument[] { effect, Deloreanlist[index].Deloreon.Handle, 0.0, -2.5, 0.5, 0.0, 0.0, 0.0, 3.0, 0, 0, 0 });
        }
        public void startfreeze()
        {
            freeze.Start();
            freezestarted = true;
        }

        int ice = 0;
        public void tickfreeze(int index)
        {
            if (freezestarted)
            {
                //UIText Instruct = new UIText("delay: " + freeze.getdelay(), new Point(400, 300), (float)0.9);
                //Instruct.Draw();
                if (freeze.getdelay() <= 3)
                {
                    ice = 12;
                }
                else if (freeze.getdelay() > 5 && freeze.getdelay() < 6)
                {
                    cold.Play();
                }
                else if (freeze.getdelay() > 8 && freeze.getdelay() < 9)
                {
                    if (Deloreanlist[index].Deloreon.Model == "bttf")
                        Vent.Play();
                }
                else if (freeze.getdelay() > 10 && freeze.getdelay() < 11)
                {

                }
                else if (freeze.getdelay() > 11 && freeze.getdelay() < 12)
                {
                    if (Deloreanlist[index].Deloreon.Model == "bttf")
                        make_effect_smoke("scr_mp_creator", "scr_mp_plane_landing_tyre_smoke", index);
                    Application.DoEvents();
                }
                else if (freeze.getdelay() == 19.5)
                {
                    if (!Deloreanlist[index].refilltimecurcuits)
                        empty.Play();
                }
                else if (freeze.getdelay() == 20)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, 0, true);
                }
                else if (freeze.getdelay() == 20.5)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, -1, true);
                }
                else if (freeze.getdelay() == 21.5)
                {
                    if (!Deloreanlist[index].refilltimecurcuits)
                        //empty.Play();
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, 0, true);
                }
                else if (freeze.getdelay() == 22)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, -1, true);
                }
                else if (freeze.getdelay() == 22.5)
                {
                    if (!Deloreanlist[index].refilltimecurcuits)
                        //empty.Play();
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, 0, true);
                }
                else if (freeze.getdelay() == 23)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, -1, true);
                }
                else if (freeze.getdelay() == 24)
                {
                    if (!Deloreanlist[index].refilltimecurcuits)
                        //empty.Play();
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, 0, true);
                }
                else if (freeze.getdelay() == 24.5)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, -1, true);
                }
                else if (freeze.getdelay() == 25)
                {
                    if (!Deloreanlist[index].refilltimecurcuits)
                        //empty.Play();
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, 0, true);
                }
                else if (freeze.getdelay() == 25.5)
                {
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, -1, true);
                }
                else if (freeze.getdelay() == 26.5)
                {
                    if (!Deloreanlist[index].refilltimecurcuits)
                        //empty.Play();
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreanlist[index].Deloreon.Handle, 0);
                    Deloreanlist[index].Deloreon.SetMod(VehicleMod.Roof, 0, true);
                }
                else if (freeze.getdelay() == 27)
                {

                }
                else if (freeze.getdelay() == 31)
                {
                    cold.Play();
                }
                else if (freeze.getdelay() > 41 && freeze.getdelay() < 46)
                {
                    if (ice > 0)
                        ice--;
                    Deloreanlist[index].Deloreon.DirtLevel = ice;
                }
                else if (freeze.getdelay() == 48)
                {
                    freeze.Stop();
                    freeze.Reset();
                    freezestarted = false;
                }
            }
        }
    }
}
