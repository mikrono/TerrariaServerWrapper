using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TerrariaServerWrapper.DiscordModule
{
    public partial class Discord : Form
    {
        public bool discordForm1Size = true;
        public Discord()
        {
            InitializeComponent();
        }

        private void Discord_Load(object sender, EventArgs e)
        {

        }

        private void DiscordForm1SizeControl_Click(object sender, EventArgs e)
        {
            if (discordForm1Size)
            {
                this.Size += new Size(0, 300);
                discordForm1Size = !discordForm1Size;
                DiscordForm1SizeControl.Text = "▲";
            }
            else
            {
                this.Size -= new Size(0, 300);
                discordForm1Size = !discordForm1Size;
                DiscordForm1SizeControl.Text = "▼";
            }
        }

        private void DiscordConnect_Click(object sender, EventArgs e)
        {
            EnvVar.TSWconfig.BotToken = DiscordBotToken.Text;
            MainServices.MainService.Instance.RunDiscord();
        }
    }
}
