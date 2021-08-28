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
    [Name("ConsoleCommander")]
    public class commanderModule : ModuleBase<SocketCommandContext>
    {
        [Command("terraria")]
        [Summary("command the Server")]
        [RequireUserPermission(GuildPermission.Administrator)]
        public async Task Command(string args)
        {
            MainServices.MainService.Instance.GetDiscordSendCommand(args);
            await ReplyAsync("Maybe Accepted.");
        }
    }
}
