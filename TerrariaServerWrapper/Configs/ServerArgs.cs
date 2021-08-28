using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaServerWrapper.Configs
{
    class ServerArgs : TemplateConfig<ServerArgs>
    {
        public override string ConfigName { get; set; } = "serverarguments.json";
        public string configVersion { get; set; } = EnvVar.TSWversion;
        public string config { get; set; } = "serverconfig.txt";
    }
}
