using GTA;
using GTA.Math;
using GTA.Native;
using NativeUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BTTF_Time_Travel
{
    class TTTFmenu:Script
    {
        private MenuPool _myMenuPool = new MenuPool();
        UIMenu myMenu = new UIMenu("Theft to the Future", "Mod Menu");
        UIMenuItem RC = new UIMenuItem("RC mode: Car " + Variableclass.RCfeqency);

        public TTTFmenu()
        {
            if (File.Exists("Scripts\\menu images\\THEFT-FUTURE-LOGO-BLACK.png"))
            {
                myMenu.SetBannerType("Scripts\\menu images\\THEFT-FUTURE-LOGO-BLACK.png");
            }
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (DMC 12)"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (DMC 13)"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (BTTF 1)"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (BTTF 2)"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (BTTF 3)"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (BTTF 3 railroad)"));
            myMenu.AddItem(new UIMenuItem("Display Adjustment"));
            myMenu.AddItem(new UIMenuItem("Turn current car into a Time Machine"));
            myMenu.AddItem(new UIMenuItem("Remove Time Travel from current car"));
            myMenu.AddItem(new UIMenuItem("Delete car"));
            myMenu.AddItem(new UIMenuCheckboxItem("Invicible", false));
            myMenu.AddItem(RC);
            myMenu.AddItem(new UIMenuCheckboxItem("Real Engine", false));
            myMenu.AddItem(new UIMenuItem("Play as Marty Mcfly"));
            myMenu.AddItem(new UIMenuItem("Play as Doc Brown"));
            myMenu.AddItem(new UIMenuItem("Tutorial mode"));
            myMenu.AddItem(new UIMenuItem("Exit"));
            myMenu.RefreshIndex();
            myMenu.OnItemSelect += ItemSelectHandler;
            myMenu.OnCheckboxChange += (sender, item, checked_) =>
            {
                Variableclass.sendinvincible = checked_;
            };
            _myMenuPool.Add(myMenu);
        }

        public void Show()
        {
            myMenu.Visible = !myMenu.Visible;
        }

        public void ItemSelectHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if (selectedItem.Text == "Spawn Delorean (DMC 12)")
            {
                Model Deloreanmodel = new Model("DMC12");
                if (Deloreanmodel.IsValid)
                {
                    Vehicle Deloreon = null;

                    Vector3 position = Game.Player.Character.Position;

                    // At 90 degrees to the players heading
                    float heading = Game.Player.Character.Heading - 90;
                    while (Deloreon == null)
                        Deloreon = World.CreateVehicle(Deloreanmodel, position, heading);
                    Deloreon.Rotation = Game.Player.Character.Rotation;

                    Deloreon.DirtLevel = 0;
                    Deloreon.NumberPlate = "OutATime";
                    Deloreon.PlaceOnGround();
                    // Set the vehicle mods
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                    Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                    Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                    Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                    Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                }
            }
            if (selectedItem.Text == "Spawn Delorean (DMC 13)")
            {
                Model Deloreanmodel = new Model("DMC13");
                if (Deloreanmodel.IsValid)
                {
                    Vehicle Deloreon = null;

                    Vector3 position = Game.Player.Character.Position;

                    // At 90 degrees to the players heading
                    float heading = Game.Player.Character.Heading - 90;
                    while (Deloreon == null)
                        Deloreon = World.CreateVehicle(Deloreanmodel, position, heading);
                    Deloreon.Rotation = Game.Player.Character.Rotation;

                    Deloreon.DirtLevel = 0;
                    Deloreon.NumberPlate = "OutATime";
                    Deloreon.PlaceOnGround();
                    // Set the vehicle mods
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                    Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                    Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                    Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                    Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                }
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 1)")
            {
                Model Deloreanmodel = new Model("BTTF");
                if (Deloreanmodel.IsValid)
                {
                    Vehicle Deloreon = null;

                    Vector3 position = Game.Player.Character.Position;

                    // At 90 degrees to the players heading
                    float heading = Game.Player.Character.Heading - 90;
                    while (Deloreon == null)
                        Deloreon = World.CreateVehicle(Deloreanmodel, position, heading);
                    Deloreon.Rotation = Game.Player.Character.Rotation;

                    Deloreon.DirtLevel = 0;
                    Deloreon.NumberPlate = "OutATime";
                    Deloreon.PlaceOnGround();
                    // Set the vehicle mods
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                    Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                    Deloreon.SetMod(VehicleMod.Frame, -1, true);
                    Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                    TimeTravel.instantDelorean.CreateDeloreanfromcurrentcar(Deloreon, false);
                    Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                    Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                    if (!Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 10 }))
                    {
                        Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 10, 0 });
                    }
                }
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 2)")
            {
                Model Deloreanmodel = new Model("BTTF2");
                if (Deloreanmodel.IsValid)
                {
                    Vehicle Deloreon = null;

                    Vector3 position = Game.Player.Character.Position;

                    // At 90 degrees to the players heading
                    float heading = Game.Player.Character.Heading - 90;
                    while (Deloreon == null)
                        Deloreon = World.CreateVehicle(Deloreanmodel, position, heading);
                    Deloreon.Rotation = Game.Player.Character.Rotation;

                    Deloreon.DirtLevel = 0;
                    Deloreon.NumberPlate = "OutATime";
                    Deloreon.PlaceOnGround();
                    // Set the vehicle mods
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                    Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                    Deloreon.SetMod(VehicleMod.Frame, -1, true);
                    Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                    TimeTravel.instantDelorean.CreateDeloreanfromcurrentcar(Deloreon, true);
                    Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                    Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                    if (!Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 10 }))
                    {
                        Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 10, 0 });
                    }
                }
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 3)")
            {
                Model Deloreanmodel = new Model("BTTF3");
                if (Deloreanmodel.IsValid)
                {
                    Vehicle Deloreon = null;

                    Vector3 position = Game.Player.Character.Position;

                    // At 90 degrees to the players heading
                    float heading = Game.Player.Character.Heading - 90;
                    while (Deloreon == null)
                        Deloreon = World.CreateVehicle(Deloreanmodel, position, heading);
                    Deloreon.Rotation = Game.Player.Character.Rotation;

                    Deloreon.DirtLevel = 0;
                    Deloreon.NumberPlate = "OutATime";
                    Deloreon.PlaceOnGround();
                    // Set the vehicle mods
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                    Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                    Deloreon.SetMod(VehicleMod.Frame, -1, true);
                    Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                    TimeTravel.instantDelorean.CreateDeloreanfromcurrentcar(Deloreon, false);
                    Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                    Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                    if (!Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 10 }))
                    {
                        Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 10, 0 });
                    }
                }
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 3 railroad)")
            {
                Model Deloreanmodel = new Model("BTTF3rr");
                if (Deloreanmodel.IsValid)
                {
                    Vehicle Deloreon = null;

                    Vector3 position = Game.Player.Character.Position;

                    // At 90 degrees to the players heading
                    float heading = Game.Player.Character.Heading - 90;
                    while (Deloreon == null)

                        Deloreon = World.CreateVehicle(Deloreanmodel, position, heading);
                    Deloreon.Rotation = Game.Player.Character.Rotation;

                    Deloreon.DirtLevel = 0;
                    Deloreon.NumberPlate = "OutATime";
                    Deloreon.PlaceOnGround();
                    // Set the vehicle mods
                    Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                    Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                    Deloreon.SetMod(VehicleMod.Frame, -1, true);
                    Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
                    TimeTravel.instantDelorean.CreateDeloreanfromcurrentcar(Deloreon, false);
                    Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                    Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                    if (!Function.Call<bool>(Hash.IS_VEHICLE_EXTRA_TURNED_ON, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 10 }))
                    {
                        Function.Call(Hash.SET_VEHICLE_EXTRA, new InputArgument[] { TimeTravel.instantDelorean.Deloreanlist[index].Deloreon, 10, 0 });
                    }
                }
            }
            else if (selectedItem.Text == "Turn current car into a Time Machine")
            {
                TimeTravel.instantDelorean.CreateDeloreanfromcurrentcar(Game.Player.Character.CurrentVehicle, false);
            }
            else if (selectedItem.Text == "Delete car")
            {
                TimeTravel.instantDelorean.RemoveDelorean();
            }
            else if (selectedItem.Text == "Remove Time Travel from current car")
            {
                TimeTravel.instantDelorean.RemoveTimeCircuits();
            }
            else if (selectedItem.Text == "Display Adjustment")
            {
                TimeTravel.Displayadjustment = true;
                Show();
            }
            else if (selectedItem.Text.Contains("RC mode: "))
            {
                if (!(TimeTravel.instantDelorean.Deloreanlist.Count == 0))
                {
                    TimeTravel.menu = false;
                    myMenu.Visible = false;
                    Variableclass.rcmode_send = true;
                }
            }
            else if (selectedItem.Text == "Play as Marty Mcfly")
            {
                UI.Notify("Not Avalible untill skins can be modded");
            }
            else if (selectedItem.Text == "Play as Doc Brown")
            {
                UI.Notify("Not Avalible untill skins can be modded");
            }
            else if (selectedItem.Text == "Tutorial mode")
            {
                startingscene.Start();
            }
            else if (selectedItem.Text == "Exit")
            {
                TimeTravel.menu = false;
                myMenu.Visible = false;
            }
        }

        public void OnTick()
        {
            if (Variableclass.RCfeqency < 0)
            {
                if (!(TimeTravel.instantDelorean.Deloreanlist.Count == 0))
                {
                    Variableclass.RCfeqency = TimeTravel.instantDelorean.Deloreanlist.Count - 1;
                }
                else
                {
                    Variableclass.RCfeqency = TimeTravel.instantDelorean.Deloreanlist.Count;
                }
            }
            else if (Variableclass.RCfeqency > TimeTravel.instantDelorean.Deloreanlist.Count - 1)
            {
                Variableclass.RCfeqency = 0;
            }
            RC.Text = "RC mode: Car " + (Variableclass.RCfeqency + 1);
            _myMenuPool.ProcessMenus();
        }
    }
}
