using GTA;
using GTA.Math;
using System;
using System.Collections.Generic;
using System.IO;
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

        public static int Displayx = 0, Displayy = 0;

        public static void write_in_log(string log)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("");
            sb.AppendLine("Logged at " + DateTime.Now);
            sb.AppendLine("Task that was preformed: " + log);
            sb.AppendLine("-------------------------------------------------------------");
            sb.AppendLine("");

            // flush every 20 seconds as you do it
            File.AppendAllText(Application.StartupPath + "\\scripts\\BTTF Time Travel.log", sb.ToString());
            sb.Clear();
        } 

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
