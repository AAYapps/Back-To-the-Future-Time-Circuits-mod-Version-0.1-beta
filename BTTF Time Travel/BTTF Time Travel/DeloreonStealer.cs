using GTA;
using GTA.Math;
using GTA.Native;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTF_Time_Travel
{
    class DeloreonStealer: Variableclass
    {
        public static void Start()
        {
            Deloreonstealer = World.GetClosestPed(Deloreon.GetOffsetInWorldCoords(new Vector3(20, 0, 0)), 10); //.CreatePed(PedHash.Robber01SMY, Deloreon.GetOffsetInWorldCoords(new Vector3(20, 0, 0)));
            Deloreonstealer.DrivingStyle = DrivingStyle.Rushed;
            Deloreonstealer.DrivingSpeed = 100;
            Deloreonstealer.IsEnemy = true;
            Deloreonstealer.Task.RunTo(Deloreon.GetOffsetInWorldCoords(new Vector3(-1,0,0)));
            Deloreonstealer.CanBeDraggedOutOfVehicle = true;
            deloreonstealergoingincar = false;
            deloreonstealerincar = false;
            Deloreonstealer.AddBlip();
            Deloreonstealer.Task.CruiseWithVehicle(Deloreon, 150, (int)DrivingStyle.Rushed);
        }
    }
}
