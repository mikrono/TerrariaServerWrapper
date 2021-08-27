using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;
using TerrariaServerWrapper;

namespace TerrariaServerWrapper.DiscordModule.CommandModules
{
    [Name("Restart")]
    public class ExampleModule : ModuleBase<SocketCommandContext>
    {
        [Command("restart")]
        [Summary("Restart the Server")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Restart()
        {
            MainServices.MainService.Instance.Restart();
            await ReplyAsync("Server restarted");
        }
    }
}
