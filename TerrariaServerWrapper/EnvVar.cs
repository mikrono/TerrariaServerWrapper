using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TerrariaServerWrapper.Config;
using System.Windows.Forms;

namespace TerrariaServerWrapper
{
    public class EnvVar
    {
        public static string TSWversion { get; } = "0.0.0.1";
        public static string AbsolutePath { get; } = Path.Combine(Application.StartupPath + "\\configs");
        public static TSWConfig TSWconfig { get; set; }
    }
}
