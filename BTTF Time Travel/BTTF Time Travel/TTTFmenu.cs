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
        public TTTFmenu()
        {
            if (File.Exists("Scripts\\menu images\\THEFT-FUTURE-LOGO-BLACK.png"))
            {
                myMenu.SetBannerType("Scripts\\menu images\\THEFT-FUTURE-LOGO-BLACK.png");
            }
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (BTTF 1)"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (BTTF 2)"));
            myMenu.AddItem(new UIMenuItem("Spawn Delorean (BTTF 3)"));
            myMenu.AddItem(new UIMenuItem("Display Adjustment"));
            myMenu.AddItem(new UIMenuItem("Turn current car into a Time Machine"));
            myMenu.AddItem(new UIMenuCheckboxItem("Invicible", false));
            myMenu.AddItem(new UIMenuItem("Play as Marty Mcfly"));
            myMenu.AddItem(new UIMenuItem("Play as Doc Brown"));
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

        Delorean_class instantDelorean = new Delorean_class();

        public void ItemSelectHandler(UIMenu sender, UIMenuItem selectedItem, int index)
        {
            if (selectedItem.Text == "Spawn Delorean (BTTF 1)")
            {
                Vehicle Deloreon;

                Vector3 position = Game.Player.Character.Position;

                // At 90 degrees to the players heading
                float heading = Game.Player.Character.Heading - 90;

                Deloreon = World.CreateVehicle(VehicleHash.Ruiner, position, heading);
                Deloreon.Rotation = Game.Player.Character.Rotation;

                Deloreon.DirtLevel = 0;
                Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                Deloreon.NumberPlate = "OutATime";
                Deloreon.PlaceOnGround();
                // Set the vehicle mods
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                Deloreon.ToggleMod(VehicleToggleMod.XenonHeadlights, true);
                Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 2)")
            {
                Vehicle Deloreon;

                Vector3 position = Game.Player.Character.Position;

                // At 90 degrees to the players heading
                float heading = Game.Player.Character.Heading - 90;

                Deloreon = World.CreateVehicle(VehicleHash.Dune2, position, heading);
                Deloreon.Rotation = Game.Player.Character.Rotation;

                Deloreon.DirtLevel = 0;
                Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                Deloreon.NumberPlate = "OutATime";
                Deloreon.PlaceOnGround();
                // Set the vehicle mods
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                Deloreon.ToggleMod(VehicleToggleMod.XenonHeadlights, true);
                Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
            }
            else if (selectedItem.Text == "Spawn Delorean (BTTF 3)")
            {
                Vehicle Deloreon;

                Vector3 position = Game.Player.Character.Position;

                // At 90 degrees to the players heading
                float heading = Game.Player.Character.Heading - 90;

                Deloreon = World.CreateVehicle(VehicleHash.Phoenix, position, heading);
                Deloreon.Rotation = Game.Player.Character.Rotation;

                Deloreon.DirtLevel = 0;
                Deloreon.PrimaryColor = VehicleColor.BrushedAluminium;
                Deloreon.SecondaryColor = VehicleColor.BrushedAluminium;
                Deloreon.NumberPlate = "OutATime";
                Deloreon.PlaceOnGround();
                // Set the vehicle mods
                Function.Call(Hash.SET_VEHICLE_MOD_KIT, Deloreon.Handle, 0);
                Deloreon.ToggleMod(VehicleToggleMod.Turbo, true);
                Deloreon.ToggleMod(VehicleToggleMod.XenonHeadlights, true);
                Game.Player.Character.Task.WarpIntoVehicle(Deloreon, VehicleSeat.Driver);
            }
            else if (selectedItem.Text == "Turn current car into a Time Machine")
            {
                instantDelorean.CreateDeloreonnearyou(Game.Player.Character.CurrentVehicle);
                Tick += instantDelorean.Check;
            }
            else if (selectedItem.Text == "Display Adjustment")
            {
                TimeTravel.Displayadjustment = true;
                Show();
            }
            else if (selectedItem.Text == "Play as Marty Mcfly")
            {
                UI.Notify("Not Avalible untill skin is tested");
            }
            else if (selectedItem.Text == "Play as Doc Brown")
            {
                UI.Notify("Not Avalible untill skin is tested");
            }
            else if (selectedItem.Text == "Tutorial mode")
            {
                startingscene.Start();
            }
            else if (selectedItem.Text == "Exit")
            {
                myMenu.Visible = false;
            }
        }

        public void OnTick()
        {
            _myMenuPool.ProcessMenus();
        }
    }
}
