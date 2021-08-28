using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariaServerWrapper.Configs;
using System.Windows.Forms;

namespace TerrariaServerWrapper
{
    public static class EnvVar
    {
        public static string TSWversion { get; } = "0.1.0.1";
        public static string AbsolutePath { get; } = Application.StartupPath;
        public static string ConfigPath { get; } = Path.Combine(Application.StartupPath, "configs");
        public static string myGamesPath { get; } = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "\\My Games\\Terraria");
        public static TSWConfig TSWconfig { get; set; }
        public static string ServerPath { get; set; }
    }
}
