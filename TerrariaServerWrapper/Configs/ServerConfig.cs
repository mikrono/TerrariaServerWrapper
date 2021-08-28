using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TerrariaServerWrapper.Configs
{
    class ServerConfig : TemplateConfig<ServerConfig>
    {
        public override string ConfigName { get; set; } = "serverconfig.txt";
        public string world { get; set; } = "Path to the .wld file";
        public byte autocreate { get; set; } = 0;
        public string seed { get; set; } = "";
        public string worldname { get; set; } = "sets the name of the world when using autocreate";
        /// <summary>
        /// Sets the difficulty of the world when using autocreate 0(classic), 1(expert), 2(master), 3(journey)
        /// </summary>
        public byte difficulty { get; set; } = 2;
        public ushort maxplayers { get; set; } = 16;
        public ushort port { get; set; } = 7777;
        public string password { get; set; } = "Sets the server password";
        public string motd { get; set; } = "Sets the server motd";
        public string worldpath { get; set; } = "Sets the folder where world files will be stored";
        public ushort worldrollbackstokeep { get; set; } = 2;
        public string banlist { get; set; } = "Path to the Banlist.txt";
        public bool secure { get; set; } = true;
        public bool upnp { get; set; } = true;
    }
}
