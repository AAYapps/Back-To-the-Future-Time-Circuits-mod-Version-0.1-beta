using GTA;
using GTA.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTF_Time_Travel
{
    class freezing : Variableclass
    {
        public static bool started = false;
        public static void start()
        {
            Constanttimerclass.Start();
            started = true;
        }

        static int eplode = (int)ExplosionType.BZGas;
        public static void tick()
        {
            if (started)
            {
                if (Constanttimerclass.getdelay() == 3)
                {
                    cold.Play();
                }
                else if (Constanttimerclass.getdelay() == 4)
                {
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                    Vent.Play();
                }
                else if (Constanttimerclass.getdelay() == 6)
                {
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                }
                else if (Constanttimerclass.getdelay() == 7)
                {
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3((float)0.5, -2, 0)), ExplosionType.Steam, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-(float)0.5, -2, 0)), ExplosionType.Steam, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                }
                else if (Constanttimerclass.getdelay() == 11)
                {
                    empty.Play();
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                }
                else if (Constanttimerclass.getdelay() == 16)
                {
                    engine.stalled = true;
                    engine.starteron = true;
                    engine.tempstall = true;
                    engine.enginestarted = false;
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, 2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                    World.AddExplosion(Deloreon.GetOffsetInWorldCoords(new Vector3(-1, -2, 0)), (ExplosionType)eplode, (float)2, 0);
                    Constanttimerclass.Stop();
                    Constanttimerclass.Reset();
                    started = false;
                }
            }
        }
    }
}
