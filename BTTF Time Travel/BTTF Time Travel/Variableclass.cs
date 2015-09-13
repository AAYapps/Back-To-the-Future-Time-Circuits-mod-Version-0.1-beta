using GTA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTTF_Time_Travel
{
    class Variableclass
    {

        #region Timetravelsounds
        static public SoundPlayer Mrfrefill = new SoundPlayer(Properties.Resources.mrfreload);
        static public SoundPlayer Beep = new SoundPlayer(Properties.Resources.beep);
        static public SoundPlayer hoveron = new SoundPlayer(Properties.Resources.HoverOn);
        static public SoundPlayer hoveroff = new SoundPlayer(Properties.Resources.HoverOff);
        static public SoundPlayer hoverboost = new SoundPlayer(Properties.Resources.HoverBoost);
        static public SoundPlayer hoverup = new SoundPlayer(Properties.Resources.HoverUp);
        static public SoundPlayer plate = new SoundPlayer(Properties.Resources.plate);
        static public SoundPlayer pr0load = new SoundPlayer(Properties.Resources.preload);
        static public SoundPlayer ready = new SoundPlayer(Properties.Resources.ready);
        static public SoundPlayer trend = new SoundPlayer(Properties.Resources.trend);
        static public SoundPlayer cold = new SoundPlayer(Properties.Resources.cold);
        static public SoundPlayer doorcold = new SoundPlayer(Properties.Resources.door_cold);
        static public SoundPlayer dooropen = new SoundPlayer(Properties.Resources.door_open);
        static public SoundPlayer empty = new SoundPlayer(Properties.Resources.empty);
        static public SoundPlayer engineoff = new SoundPlayer(Properties.Resources.engine_off);
        static public SoundPlayer engineon = new SoundPlayer(Properties.Resources.engine_on);
        static public SoundPlayer curerror = new SoundPlayer(Properties.Resources.Error);
        static public SoundPlayer curerrorbttf3 = new SoundPlayer(Properties.Resources.Error_BTTF3);
        static public SoundPlayer inputenterbttf3 = new SoundPlayer(Properties.Resources.input_enter_bttf3);
        static public SoundPlayer inputoff = new SoundPlayer(Properties.Resources.input_off);
        static public SoundPlayer inputon = new SoundPlayer(Properties.Resources.input_on);
        static public SoundPlayer inputoffbttf3 = new SoundPlayer(Properties.Resources.input_off_bttf3);
        static public SoundPlayer inputonbttf2error = new SoundPlayer(Properties.Resources.input_on_bttf2_error);
        static public SoundPlayer inputonbttf3 = new SoundPlayer(Properties.Resources.input_on_bttf3);
        static public SoundPlayer inputonfeul = new SoundPlayer(Properties.Resources.input_on_fuel);
        static public SoundPlayer Lightningbttf2 = new SoundPlayer(Properties.Resources.Lightning_bttf2);
        static public SoundPlayer Lightningcuttscene = new SoundPlayer(Properties.Resources.time_travel_BTTF2_lightning_cutscene);
        static public SoundPlayer Timetravelreentery = new SoundPlayer(Properties.Resources.time_travel);
        static public SoundPlayer Timetravelreenterycutscene = new SoundPlayer(Properties.Resources.time_travel_BTTF2_cutscene);
        static public SoundPlayer reenterybttf1 = new SoundPlayer(Properties.Resources.REENTRY_BTTF1);
        static public SoundPlayer reenterybttf1incar = new SoundPlayer(Properties.Resources.REENTRY_BTTF1_in_car);
        static public SoundPlayer reenterybttf2 = new SoundPlayer(Properties.Resources.REENTRY_BTTF2);
        static public SoundPlayer reenterybttf3 = new SoundPlayer(Properties.Resources.REENTRY_BTTF3);
        static public SoundPlayer sparks = new SoundPlayer(Properties.Resources.sparks);
        static public SoundPlayer sparksbttf3 = new SoundPlayer(Properties.Resources.sparks_bttf3);
        static public SoundPlayer sparksfeul = new SoundPlayer(Properties.Resources.sparks_fuel);
        static public SoundPlayer RCcontrolstart = new SoundPlayer(Properties.Resources.start_RC_control);
        static public SoundPlayer RCcontrolstop = new SoundPlayer(Properties.Resources.stop_RC_control);
        static public SoundPlayer RCcontrol = new SoundPlayer(Properties.Resources.RC_control);
        static public SoundPlayer RCcontrolhandbreak = new SoundPlayer(Properties.Resources.RC_control_handbrake);
        static public SoundPlayer Vent = new SoundPlayer(Properties.Resources.vent);
        static public SoundPlayer Plut = new SoundPlayer(Properties.Resources.Plutonium);
        #endregion

        #region Doc's truck
        static public Blip loction;
        #endregion

        #region Doc
        static public Ped Doc;
        static public Ped Einstein;
        #endregion

        #region Doc's Exparament
        static public bool DocsExparamentstart = false;
        #endregion

        #region Deloreon
        public static bool invicible = true;
        public static bool enginerunning = false;
        static public bool RCmodeenabled = true;
        static public bool MrFusionfilltask = false;
        static public bool RCmodeactive = false;
        static public Ped RCped;
        static public Ped playerped;
        static public double flyheight = 0;
        static public bool flyingison = false;
        static public bool deloreonspoawned = false;
        static public bool ifegnineturnedon = false;
        static public bool ifwentoutoffcar = true;
        static public bool past84 = false;
        static public bool engineturningon = false;
        static public bool RCmode = false;
        static public float RCspeed = 0;
        static public int flycount = 0;
        static public bool engineison = false;
        static public bool mrfopened = false;
        static public bool refilltimecurcuits = false;
        static public bool toggletimecurcuits = false;
        static public UIText Timedisplayf;
        static public UIText Timedisplaypres;
        static public UIText Timedisplaypast;
        static public UIText Timedisplayinput; 

        static public bool carjustdied = false;
        static public bool retreive = false;
        static public bool deloreonstealergoingincar = false;
        static public bool deloreonstealerincar = false;

        static public Vehicle Deloreon;
        static public Vehicle Deloreon2;
        static public Ped Deloreonretreiver;

        static public Ped Deloreonstealer;
        #endregion

        #region Deloreon2
        static public int flyheight2 = 0;
        static public bool flyingison2 = false;
        static public bool deloreonspoawned2 = false;
        static public bool ifegnineturnedon2 = false;
        static public bool ifwentoutoffcar2 = true;
        static public bool past842 = false;
        static public int timemrfisopen2 = 70;
        static public bool engineturningon2 = false;
        static public bool RCmode2 = false;
        static public float RCspeed2 = 0;
        static public int flycount2 = 0;
        static public bool engineison2 = false;
        static public bool mrfopened2 = false;
        static public bool refilltimecurcuits2 = false;
        static public bool toggletimecurcuits2 = false;
        static public UIText Timedisplayf2;
        static public UIText Timedisplaypres2;
        static public UIText Timedisplaypast2;
        static public bool carjustdied2 = false;
        static public bool retreive2 = false;
        static public Ped Deloreonretreiver2;
        #endregion
    }
}
