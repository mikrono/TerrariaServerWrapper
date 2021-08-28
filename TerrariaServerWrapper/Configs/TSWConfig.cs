using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaServerWrapper.Configs
{
    public class TSWConfig : TemplateConfig<TSWConfig>
    {
        public override string ConfigName { get; set; } = "TSWConfig.json";
        public string configVersion { get; set; } = EnvVar.TSWversion;
        public string BotToken { get; set; } = "";
        public string ChannelID { get; set; } = "";
        public string CommandPrefix { get; set; } = "!";
    }
}
