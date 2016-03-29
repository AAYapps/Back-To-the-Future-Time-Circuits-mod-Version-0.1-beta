using System;
using System.Windows.Forms;
using GTA;
using System.Media;
using GTA.Native;
using GTA.Math;
using System.Drawing;
using System.IO;
using System.Threading;
using NativeUI;
using System.Collections.Generic;
using System.Reflection;

namespace BTTF_Time_Travel
{
    class TimeTravel : Script
    {
        public static Delorean_class instantDelorean;

        #region variables
        TTTFmenu TTTF = new TTTFmenu();
        #endregion

        public TimeTravel()
        {
            try
            {
                instantDelorean = new Delorean_class();
                Interval = 1;
                Tick += onTick;
                KeyUp += onKeyUp;
                KeyDown += onKeyDown;
                //loadscriptsettings();
                Game.Player.CanControlCharacter = true;
                if (Game.Player.Character.IsInVehicle())
                {
                    Game.Player.Character.CurrentVehicle.IsVisible = true;
                }
            }
            catch (Exception e)
            {
                while(true)
                {
                    UIText debug2 = new UIText(e.Message, new Point(200, 100), (float)0.6);
                    debug2.Draw();
                    Application.DoEvents();
                }
            }
        }

        void effect(string root, string effect)
        {
            Function.Call(Hash._0xDD19FA1C6D657305, new InputArgument[] { Game.Player.Character.Position.X, Game.Player.Character.Position.Y, Game.Player.Character.Position.Z, 10 });
            Function.Call(Hash._0xB80D8756B4668AB6, new InputArgument[] { root });
            Function.Call(Hash._0x6C38AF3693A69A91, new InputArgument[] { root });
            Function.Call(Hash._0x0D53A3B8DA0809D2, new InputArgument[] { effect, Game.Player.Character, 0.0, 3.0, 0.5, 0.0, 0.0, 0.0, 3.0, 0, 0, 0 });
        }

        System.Speech.Synthesis.SpeechSynthesizer Timeteller = new System.Speech.Synthesis.SpeechSynthesizer();
        private void onKeyDown(object sender, KeyEventArgs e)
        {
            if (Displayadjustment)
            {
                if (e.KeyCode == Keys.Up)
                {
                    Variableclass.Displayy -= 10;
                }
                else if (e.KeyCode == Keys.Down)
                {
                    Variableclass.Displayy += 10;
                }
                else if (e.KeyCode == Keys.Left)
                {
                    Variableclass.Displayx -= 10;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    Variableclass.Displayx += 10;
                }
                else if (e.KeyCode == Keys.Enter)
                {
                    Displayadjustment = false;
                    TTTF.Show();
                }
                Delorean_class.change_time_display_location(Variableclass.Displayx, Variableclass.Displayy);
            }
            else
            {
                Delorean_class.keystring = e.KeyCode.ToString();
            }
        }

        void loadscriptsettings()
        {
            try
            {

            }
            catch
            {

            }


            //startingscene.Start();
        }

        public static bool Displayadjustment = false;

        public static bool menu = false;
        bool effectcommand = false;
        bool effectcommand2 = false;
        string command = "";
        string command1 = "";
        string command2 = "";
        private void onKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F8)
            {
                effectcommand = !effectcommand;
                Game.Player.CanControlCharacter = !Game.Player.CanControlCharacter;
            }
            if (e.KeyCode == Keys.F5)
            {
                menu = true;
                TTTF.Show();
                for (int index = 0; index < instantDelorean.Deloreanlist.Count; index++)
                {
                    instantDelorean.Deloreanlist[index].toggletimecurcuits = false;
                }
            }

            if (effectcommand)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!effectcommand2)
                    {
                        command1 = command;
                        command = "";
                    }
                    else
                    {
                        command2 = command;
                        command = "";
                    }
                }
                else if (e.KeyCode == Keys.F9)
                {

                }
                else if (e.KeyCode >= Keys.A && e.KeyCode <= Keys.Z)
                {
                    if (e.Shift)
                    {
                        command = command + e.KeyCode.ToString();
                    }
                    else
                    {
                        command = command + e.KeyCode.ToString().ToLower();
                    }
                }
                else if (e.KeyCode == Keys.Oem5)
                {
                    if (e.Shift)
                    {
                        command = command + "|";
                    }
                    else
                    {
                        command = command + "\\";
                    }
                }
                else if (e.KeyCode == Keys.OemPeriod)
                {
                    if (e.Shift)
                    {
                        command = command + ">";
                    }
                    else
                    {
                        command = command + ".";
                    }
                }
                else if (e.KeyCode == Keys.Oemcomma)
                {
                    if (e.Shift)
                    {
                        command = command + "<";
                    }
                    else
                    {
                        command = command + ",";
                    }
                }
                else if (e.KeyCode == Keys.OemBackslash)
                {
                    if (e.Shift)
                    {
                        command = command + "?";
                    }
                    else
                    {
                        command = command + "/";
                    }
                }
                else if (e.KeyCode == Keys.D0)
                {
                    if (e.Shift)
                    {
                        command = command + ")";
                    }
                    else
                    {
                        command = command + "0";
                    }
                }
                else if (e.KeyCode == Keys.D1)
                {
                    if (e.Shift)
                    {
                        command = command + "!";
                    }
                    else
                    {
                        command = command + "1";
                    }
                }
                else if (e.KeyCode == Keys.D2)
                {
                    if (e.Shift)
                    {
                        command = command + "@";
                    }
                    else
                    {
                        command = command + "2";
                    }
                }
                else if (e.KeyCode == Keys.D3)
                {
                    if (e.Shift)
                    {
                        command = command + "#";
                    }
                    else
                    {
                        command = command + "3";
                    }
                }
                else if (e.KeyCode == Keys.D4)
                {
                    if (e.Shift)
                    {
                        command = command + "$";
                    }
                    else
                    {
                        command = command + "4";
                    }
                }
                else if (e.KeyCode == Keys.D5)
                {
                    if (e.Shift)
                    {
                        command = command + "%";
                    }
                    else
                    {
                        command = command + "5";
                    }
                }
                else if (e.KeyCode == Keys.D6)
                {
                    if (e.Shift)
                    {
                        command = command + "^";
                    }
                    else
                    {
                        command = command + "6";
                    }
                }
                else if (e.KeyCode == Keys.D7)
                {
                    if (e.Shift)
                    {
                        command = command + "&";
                    }
                    else
                    {
                        command = command + "7";
                    }
                }
                else if (e.KeyCode == Keys.D8)
                {
                    if (e.Shift)
                    {
                        command = command + "*";
                    }
                    else
                    {
                        command = command + "8";
                    }
                }
                else if (e.KeyCode == Keys.D9)
                {
                    if (e.Shift)
                    {
                        command = command + "(";
                    }
                    else
                    {
                        command = command + "9";
                    }
                }
                else if (e.KeyCode == Keys.OemMinus)
                {
                    if (e.Shift)
                    {
                        command = command + "_";
                    }
                    else
                    {
                        command = command + "-";
                    }
                }
                else if (e.KeyCode == Keys.Oemplus)
                {
                    if (e.Shift)
                    {
                        command = command + "+";
                    }
                    else
                    {
                        command = command + "=";
                    }
                }
                else if (e.KeyCode == Keys.Space)
                {
                    command = command + " ";
                }
                else if (e.KeyCode == Keys.Back)
                {
                    if (command.Length > 0)
                    {
                        command = command.Substring(0, command.Length - 1);
                    }
                }
            }
            else if (menu)
            {
                if (e.KeyCode == Keys.Left)
                {
                    Variableclass.RCfeqency--;
                }
                else if (e.KeyCode == Keys.Right)
                {
                    Variableclass.RCfeqency++;
                }
            }
            else if (e.KeyCode == Keys.F7)
            {
                startingscene.Start();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                Variableclass.resetall = true;
            }
            else if (e.KeyCode == Keys.F10)
            {
                ExperimentScene.possiondisplay = !ExperimentScene.possiondisplay;
            }
            Variableclass.keypressed = false;
            UI.ShowSubtitle(e.KeyCode.ToString(), 5);
        }

        public void display_menu(string file, string extention)
        {
            string img = file;
            if (File.Exists(Application.StartupPath + "\\scripts\\menu images\\" + img + extention))
            {
                Sprite.DrawTexture(Application.StartupPath + "\\scripts\\menu images\\" + img + extention, new Point(50,50), new Size(1920, 1080));
            }
            else
            {
                if (img == "time-circuits")
                {
                    UIText menu = new UIText("Theft to the Future Mod menu", new Point(100, 100), (float)0.6, Color.Yellow);
                    menu.Draw();
                    UIText menu1 = new UIText("Activate Time Circuits", new Point(100, 150), (float)0.6, Color.LightGreen);
                    menu1.Draw();
                    UIText menu2 = new UIText("Spawn Delorean", new Point(100, 200), (float)0.6);
                    menu2.Draw();
                    UIText menu3 = new UIText("Play as Marty Mcfly", new Point(100, 250), (float)0.6);
                    menu3.Draw();
                    UIText menu4 = new UIText("Play as Doc Brown", new Point(100, 300), (float)0.6);
                    menu4.Draw();
                    UIText menu5 = new UIText("Exit", new Point(100, 350), (float)0.6);
                    menu5.Draw();
                }
                else if (img == "delorean")
                {
                    UIText menu = new UIText("Theft to the Future Mod menu", new Point(100, 100), (float)0.6, Color.Yellow);
                    menu.Draw();
                    UIText menu1 = new UIText("Activate Time Circuits", new Point(100, 150), (float)0.6);
                    menu1.Draw();
                    UIText menu2 = new UIText("Spawn Delorean", new Point(100, 200), (float)0.6, Color.LightGreen);
                    menu2.Draw();
                    UIText menu3 = new UIText("Play as Marty Mcfly", new Point(100, 250), (float)0.6);
                    menu3.Draw();
                    UIText menu4 = new UIText("Play as Doc Brown", new Point(100, 300), (float)0.6);
                    menu4.Draw();
                    UIText menu5 = new UIText("Exit", new Point(100, 350), (float)0.6);
                    menu5.Draw();
                }
                else if (img == "marty-mcfly")
                {
                    UIText menu = new UIText("Theft to the Future Mod menu", new Point(100, 100), (float)0.6, Color.Yellow);
                    menu.Draw();
                    UIText menu1 = new UIText("Activate Time Circuits", new Point(100, 150), (float)0.6);
                    menu1.Draw();
                    UIText menu2 = new UIText("Spawn Delorean", new Point(100, 200), (float)0.6);
                    menu2.Draw();
                    UIText menu3 = new UIText("Play as Marty Mcfly", new Point(100, 250), (float)0.6, Color.LightGreen);
                    menu3.Draw();
                    UIText menu4 = new UIText("Play as Doc Brown", new Point(100, 300), (float)0.6);
                    menu4.Draw();
                    UIText menu5 = new UIText("Exit", new Point(100, 350), (float)0.6);
                    menu5.Draw();
                }
                else if (img == "DOC-BROWN")
                {
                    UIText menu = new UIText("Theft to the Future Mod menu", new Point(100, 100), (float)0.6, Color.Yellow);
                    menu.Draw();
                    UIText menu1 = new UIText("Activate Time Circuits", new Point(100, 150), (float)0.6);
                    menu1.Draw();
                    UIText menu2 = new UIText("Spawn Delorean", new Point(100, 200), (float)0.6);
                    menu2.Draw();
                    UIText menu3 = new UIText("Play as Marty Mcfly", new Point(100, 250), (float)0.6);
                    menu3.Draw();
                    UIText menu4 = new UIText("Play as Doc Brown", new Point(100, 300), (float)0.6, Color.LightGreen);
                    menu4.Draw();
                    UIText menu5 = new UIText("Exit", new Point(100, 350), (float)0.6);
                    menu5.Draw();
                }
                else if (img == "exit")
                {
                    UIText menu = new UIText("Theft to the Future Mod menu", new Point(100, 100), (float)0.6, Color.Yellow);
                    menu.Draw();
                    UIText menu1 = new UIText("Activate Time Circuits", new Point(100, 150), (float)0.6);
                    menu1.Draw();
                    UIText menu2 = new UIText("Spawn Delorean", new Point(100, 200), (float)0.6);
                    menu2.Draw();
                    UIText menu3 = new UIText("Play as Marty Mcfly", new Point(100, 250), (float)0.6);
                    menu3.Draw();
                    UIText menu4 = new UIText("Play as Doc Brown", new Point(100, 300), (float)0.6);
                    menu4.Draw();
                    UIText menu5 = new UIText("Exit", new Point(100, 350), (float)0.6, Color.LightGreen);
                    menu5.Draw();
                }
            }
        }

        int temptick = 0;
        int explodecount = 0;

        void riot()
        {
            int tick2 = DateTime.Now.Second;
            //tick
            if (tick2 != temptick)
            {
                //Start Ped Despawning
                Ped[] peds = World.GetNearbyPeds(Game.Player.Character, 1000);
                Vehicle[] pedVehicles = World.GetNearbyVehicles(Game.Player.Character, 1000);
                for (int i = 0; i < peds.Length; i++)
                {
                    if (peds[i] != Game.Player.Character)
                    {
                        try
                        {
                            peds[i].RelationshipGroup = (int)Relationship.Hate;
                            peds[i].Weapons.Give(WeaponHash.HeavyPistol, 9999, true, true);
                            peds[i].Task.FightAgainst(World.GetClosestPed(peds[i + 1].Position, 1000));
                        }
                        catch
                        {

                        }
                    }
                    Application.DoEvents();
                    //GTA.Native.Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, peds[i], 0, 0, 0, 0, 0, 1);
                }
                Array.Clear(peds, 0, peds.Length);

                for (int i = 0; i < pedVehicles.Length; i++)
                {
                    if (pedVehicles[i] != Game.Player.Character.CurrentVehicle)
                    {
                        try
                        {
                            pedVehicles[i].GetPedOnSeat(VehicleSeat.Driver).RelationshipGroup = (int)Relationship.Hate;
                            pedVehicles[i].GetPedOnSeat(VehicleSeat.Driver).Weapons.Give(WeaponHash.HeavyPistol, 9999, true, true);
                            pedVehicles[i].GetPedOnSeat(VehicleSeat.Driver).Task.FightAgainst(World.GetClosestPed(peds[i + 1].Position, 1000));
                            if (explodecount == 20)
                            {
                                pedVehicles[i].Explode();
                                explodecount = 0;
                            }
                            explodecount++;
                        }
                        catch
                        {

                        }
                    }
                    Application.DoEvents();
                    //GTA.Native.Function.Call(GTA.Native.Hash.SET_ENTITY_COORDS_NO_OFFSET, pedVehicles[i], 0, 0, 0, 0, 0, 1);
                }
                Array.Clear(pedVehicles, 0, pedVehicles.Length);
                //End Ped Despawning
                temptick = tick2;
            }
        }
        Constanttimerclass sounddelay = new Constanttimerclass();

        int preloadtime = 0;
        bool preload = false;
        public void onTick(object sender, EventArgs e)
        {
            try
            {
                if (effectcommand)
                {
                    UI.ShowSubtitle("Command effect: " + command);
                }
                TTTF.OnTick();
                instantDelorean.Check(sender, e);

                if (!preload)
                {
                    if (DateTime.Now.Millisecond % 60 > 30 && DateTime.Now.Millisecond % 60 <= 60)
                    {
                        UI.ShowSubtitle("preload " + preloadtime);
                        if (preloadtime == 50)
                        {
                            while (!preload)
                            {
                                Vehicle dmc12 = null;
                                while (dmc12 == null)
                                {
                                    try
                                    {
                                        dmc12 = World.CreateVehicle(new Model("dmc12"), new Vector3(0, 0, 0));
                                        break;
                                    }
                                    catch
                                    {

                                    }
                                }
                                dmc12.Delete();
                                Vehicle dmc13 = null;
                                while (dmc13 == null)
                                {
                                    try
                                    {
                                        dmc13 = World.CreateVehicle(new Model("dmc13"), new Vector3(0, 0, 0));
                                        break;
                                    }
                                    catch
                                    {

                                    }
                                }
                                dmc13.Delete();
                                Vehicle gmcvan = null;
                                while (gmcvan == null)
                                {
                                    try
                                    {
                                        gmcvan = World.CreateVehicle(new Model("gmcvan"), new Vector3(0, 0, 0));
                                        break;
                                    }
                                    catch
                                    {

                                    }
                                }
                                gmcvan.Delete();
                                Vehicle bttf3rr = null;
                                while (bttf3rr == null)
                                {
                                    try
                                    {
                                        bttf3rr = World.CreateVehicle(new Model("bttf3rr"), new Vector3(0, 0, 0));
                                        break;
                                    }
                                    catch
                                    {

                                    }
                                }
                                bttf3rr.Delete();
                                Vehicle bttf3 = null;
                                while (bttf3 == null)
                                {
                                    try
                                    {
                                        bttf3 = World.CreateVehicle(new Model("bttf3"), new Vector3(0, 0, 0));
                                        break;
                                    }
                                    catch
                                    {

                                    }
                                }
                                bttf3.Delete();
                                Vehicle bttf = null;
                                while (bttf == null)
                                {
                                    try
                                    {
                                        bttf = World.CreateVehicle(new Model("bttf"), new Vector3(0, 0, 0));
                                        break;
                                    }
                                    catch
                                    {

                                    }
                                }
                                bttf.Delete();
                                Vehicle bttf2 = null;
                                while (bttf2 == null)
                                {
                                    try
                                    {
                                        bttf2 = World.CreateVehicle(new Model("bttf2"), new Vector3(0, 0, 0));
                                        break;
                                    }
                                    catch
                                    {

                                    }
                                }
                                bttf2.Delete();
                                Vehicle bttf2f = null;
                                while (bttf2f == null)
                                {
                                    try
                                    {
                                        bttf2f = World.CreateVehicle(new Model("bttf2f"), new Vector3(0, 0, 0));
                                        break;
                                    }
                                    catch
                                    {

                                    }
                                }
                                bttf2f.Delete();
                                preload = true;
                            }
                        }
                    }
                    else
                    {
                        if (preloadtime < 50)
                            preloadtime++;
                    }
                }
                

                if (Displayadjustment)
                {
                    UIText debug2 = new UIText("Display Adjustment. Use arrow keys to move display, and enter to Apply change.", new Point(200, 100), (float)0.6);
                    debug2.Draw();
                }


                if (Player_time_class.presday1 == 2 && Player_time_class.presday2 == 9 && Player_time_class.presmonth1 == 0 && Player_time_class.presmonth2 == 4 && Player_time_class.presy1 == 1 && Player_time_class.presy2 == 9 && Player_time_class.presy3 == 9 && Player_time_class.presy4 == 2)
                {
                    riot();
                }
                else if (Player_time_class.presday1 == 3 && Player_time_class.presday2 == 0 && Player_time_class.presmonth1 == 0 && Player_time_class.presmonth2 == 4 && Player_time_class.presy1 == 1 && Player_time_class.presy2 == 9 && Player_time_class.presy3 == 9 && Player_time_class.presy4 == 2)
                {
                    riot();
                }
                else if (Player_time_class.presday1 == 0 && Player_time_class.presday2 == 1 && Player_time_class.presmonth1 == 0 && Player_time_class.presmonth2 == 5 && Player_time_class.presy1 == 1 && Player_time_class.presy2 == 9 && Player_time_class.presy3 == 9 && Player_time_class.presy4 == 2)
                {
                    riot();
                }
                else if (Player_time_class.presday1 == 0 && Player_time_class.presday2 == 2 && Player_time_class.presmonth1 == 0 && Player_time_class.presmonth2 == 5 && Player_time_class.presy1 == 1 && Player_time_class.presy2 == 9 && Player_time_class.presy3 == 9 && Player_time_class.presy4 == 2)
                {
                    riot();
                }
                else if (Player_time_class.presday1 == 0 && Player_time_class.presday2 == 3 && Player_time_class.presmonth1 == 0 && Player_time_class.presmonth2 == 5 && Player_time_class.presy1 == 1 && Player_time_class.presy2 == 9 && Player_time_class.presy3 == 9 && Player_time_class.presy4 == 2)
                {
                    riot();
                }
                else if (Player_time_class.presday1 == 0 && Player_time_class.presday2 == 4 && Player_time_class.presmonth1 == 0 && Player_time_class.presmonth2 == 5 && Player_time_class.presy1 == 1 && Player_time_class.presy2 == 9 && Player_time_class.presy3 == 9 && Player_time_class.presy4 == 2)
                {
                    riot();
                }

                int tick = DateTime.Now.Second;
                //tick
                if (tick != temptick)
                {
                    Player_time_class.timetick();
                    temptick = tick;
                }
                startingscene.scene(Game.Player.Character.Model);
                ExperimentScene.tick();
            }
            catch(Exception d)
            {
                if (instantDelorean.Deloreanlist.Count < 1)
                {
                    try
                    {
                        instantDelorean.CreateDeloreon();
                    }
                    catch
                    {

                    }
                }
                else
                {
                    UI.ShowSubtitle("Error: " + d.Message);
                }
            }
        }

    }
}
