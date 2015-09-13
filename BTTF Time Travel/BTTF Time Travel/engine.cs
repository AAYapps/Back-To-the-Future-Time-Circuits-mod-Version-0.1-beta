using GTA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace BTTF_Time_Travel
{
    class engine
    {
        #region needed variables
        static Random rand = new Random();

        static int counter = 0;
        public static bool starts = false;
        static bool starterbegan = false;
        static bool starterloopstart = false;
        #endregion

        #region starter
        public static bool stalled = false;
        public static bool starteron = false;
        public static bool audioplayed2 = false;
        public static bool crank = false;
        public static void starter()
        {
            if (starteron)
            {
                if (!stalled)
                {
                    if (enginestarted == true)
                    {
                        int n = rand.Next(1, 500);
                        if (n == 347)
                        {
                            enginestarted = false;
                            starts = false;
                            stalled = true;
                            audioplayed2 = false;
                        }
                    }
                }
                else
                {
                    if (crank)
                    {
                        if (audioplayed2 == false)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.restart_engine);
                            player.PlayLooping();
                            audioplayed2 = true;
                        }
                        int n = rand.Next(1, 350);
                        if (n == 347)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.engine_on);
                            player.Play();
                            starts = true;
                            enginestarted = true;
                            audioplayed = false;
                            audioplayed2 = false;
                            stalled = false;
                            crank = false;
                        }
                    }
                }
            }
        }
        #endregion

        #region checkengine stats
        public static bool enginestarted = false;
        public static bool check = false;
        public static void checkenginestats()
        {
            if (check)
            {
                if (!enginestarted)
                {
                    if (Game.Player.Character.CurrentVehicle.EngineRunning == true)
                    {
                        Game.Player.Character.CurrentVehicle.EngineRunning = false;
                    }
                }
                else
                {
                    Game.Player.Character.CurrentVehicle.EngineRunning = true;
                }
            }
            else
            {
                if (Game.Player.Character.CurrentVehicle.IsDriveable)
                {
                    if (!Game.Player.Character.CurrentVehicle.EngineRunning)
                    {
                        enginestarted = false;
                    }
                    else
                    {
                        enginestarted = true;
                    }
                    check = true;
                }
            }
        }
        #endregion

        #region starteginedelay
        public static bool startsounddelay = false;
        public static bool audioplayed = false;
        static void startenginedelay()
        {
            if (startsounddelay)
            {
                if (Game.Player.Character.CurrentVehicle.EngineHealth <= 300 && Game.Player.Character.CurrentVehicle.EngineHealth > 2)
                {
                    if (audioplayed == false)
                    {
                        SoundPlayer startengine = new SoundPlayer(Properties.Resources.restart_engine);
                        startengine.Play();
                        audioplayed = true;
                    }
                    counter++;
                    if (counter >= 50)
                    {
                        enginestarted = true;
                        counter = 0;
                        startsounddelay = false;
                        audioplayed = false;
                        SoundPlayer startengine = new SoundPlayer(Properties.Resources.engine_on);
                        startengine.Play();
                    }

                }
                else if (Game.Player.Character.CurrentVehicle.EngineHealth <= 2)
                {
                    if (audioplayed == false)
                    {
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.restart_engine);
                        player.Play();
                        audioplayed = true;
                    }
                    counter++;
                    if (counter == 7)
                    {
                        counter = 0;
                        startsounddelay = false;
                        stalled = true;
                        crank = true;
                        audioplayed2 = false;
                    }
                }
                else
                {
                    if (audioplayed == false)
                    {
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Properties.Resources.engine_on);
                        player.Play();
                        audioplayed = true;
                    }
                    counter++;
                    if (counter == 20)
                    {
                        enginestarted = true;
                        counter = 0;
                        startsounddelay = false;
                        audioplayed = false;
                    }
                }
            }
        }
        #endregion

        #region feul
        float gastank = 2000;
        bool outofgas = false;
        void feulgadge()
        {
            if (!outofgas)
            {
                gastank -= 1;
            }
        }
        #endregion

        #region timer
        public static void tickEvent()
        {
            if (Game.Player.Character.IsInVehicle())
            {
                checkenginestats();
                startenginedelay();
                starter();


                if (Game.Player.Character.CurrentVehicle.EngineHealth <= 2)
                {
                    starteron = true;
                }
                else
                {
                    starteron = false;
                }
            }
            else
            {
                check = false;
                enginestarted = false;
            }

        }
        #endregion
    }
}
