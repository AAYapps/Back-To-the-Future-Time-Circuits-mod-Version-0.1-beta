using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using GTA;
using System.Media;
using System.Timers;

namespace Real_car_sounds
{
    public class Realcarsounds : Script
    {
#region needed variables
        Random rand = new Random();

        int counter = 0;
        bool starts = false;
        bool starterbegan = false;
        bool starterloopstart = false;
#endregion

        public Realcarsounds() 
        {
            this.Interval = 100;
            this.Tick += new EventHandler(tickEvent);
            this.KeyDown += new GTA.KeyEventHandler(kdHandler);
            this.KeyUp += new GTA.KeyEventHandler(kphandler);
        }

        private void kphandler(object sender, GTA.KeyEventArgs e)
        {
            if (Keys.I == e.Key)
            {
                if (stalled == true)
                {
                    if (starts == true)
                    {
                        crank = false;
                        audioplayed2 = false;
                        audioplayed = false;
                    }
                    else
                    {
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Real_car_sounds.Properties.Resources.starter);
                        player.Play();
                        player.Stop();
                        audioplayed2 = false;
                        audioplayed = false;
                        crank = false;
                    }
                }
            } 
        }

        public void kdHandler(object sender, GTA.KeyEventArgs  e)
        {
            if (Keys.I == e.Key)
            {
                if (Player.Character.isInVehicle())
                {
                    if (enginestarted)
                    {
                        enginestarted = false;
                        audioplayed = false;
                    }
                    else if (!enginestarted)
                    {
                        startsounddelay = true;
                        audioplayed = false;
                    }
                }
            }
        }

        #region starter
        bool stalled = false;
        bool starteron = false;
        bool audioplayed2 = false;
        bool crank = false;
        void starter()
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
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Real_car_sounds.Properties.Resources.starter);
                            player.PlayLooping();
                            audioplayed2 = true;
                        }
                        int n = rand.Next(1, 350);
                        if (n == 347)
                        {
                            System.Media.SoundPlayer player = new System.Media.SoundPlayer(Real_car_sounds.Properties.Resources.starter_starts);
                            player.Play();
                            starts = true;
                            enginestarted = true;
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
        bool enginestarted = false;
        bool check = false;
        void checkenginestats()
        {
            if (check)
            {
                if (!enginestarted)
                {
                    if (Player.Character.CurrentVehicle.EngineRunning == true)
                    {
                        Player.Character.CurrentVehicle.EngineRunning = false;
                    }

                }
                else
                {
                    Player.Character.CurrentVehicle.EngineRunning = true;
                }
            }
            else
            {
                if (Player.Character.CurrentVehicle.isAlive)
                {
                    if (!Player.Character.CurrentVehicle.EngineRunning)
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
        bool startsounddelay = false;
        bool audioplayed = false;
        void startenginedelay()
        {
            if (startsounddelay)
            {
                if (Player.Character.CurrentVehicle.EngineHealth <= 300 && Player.Character.CurrentVehicle.EngineHealth > 2)
                {
                    if (audioplayed == false)
                    {
                        SoundPlayer startengine = new SoundPlayer(Real_car_sounds.Properties.Resources.Car_start_up_damaged);
                        startengine.Play();
                        audioplayed = true;
                    }
                    counter++;
                    if (counter == 50)
                    {
                        enginestarted = true;
                        counter = 0;
                        startsounddelay = false;
                        audioplayed = false;
                    }

                }
                else if (Player.Character.CurrentVehicle.EngineHealth <= 2)
                {
                    if (audioplayed == false)
                    {
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Real_car_sounds.Properties.Resources.starter_begining);
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
                        audioplayed = false;
                        audioplayed2 = false;
                    }
                }
                else
                {
                    if (audioplayed == false)
                    {
                        System.Media.SoundPlayer player = new System.Media.SoundPlayer(Real_car_sounds.Properties.Resources.Car_start_up);
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
        public void tickEvent(object sender, EventArgs e)
        {
            if (Player.Character.isInVehicle())
            {
                checkenginestats();
                startenginedelay();
                starter();
                 

                if (Player.Character.CurrentVehicle.EngineHealth <= 2)
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
