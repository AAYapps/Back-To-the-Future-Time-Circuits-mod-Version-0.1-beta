using GTA;
using GTA.Math;
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
        public static bool keypressed = false;

        public static bool sent_message_to_circuits = false;
        public static bool resetall = false;
        public static bool rcmode_send = false;
        public static Ped playerped = Game.Player.Character;
        public static bool sendinvincible = false;

        #region Doc's truck
        static public Blip loction;
        #endregion

        #region Doc's Exparament
        static public bool DocsExparamentstart = false;
        #endregion

        public static Vector3 temp_light_pos;
        public static Vector3 temp_light_dir;

    }
}
