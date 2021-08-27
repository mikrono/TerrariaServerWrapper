using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Commands;
using Discord.WebSocket;

namespace TerrariaServerWrapper.DiscordModule
{
    class DiscordMain
    {
        public async Task RunAsync()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var provider = services.BuildServiceProvider();
            provider.GetRequiredService<Services.LoggingService>();      // Start the logging service
            provider.GetRequiredService<Services.CommandHandler>();      // Start the command handler service

            await provider.GetRequiredService<Services.StartupService>().StartAsync();       // Start the startup service
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(new DiscordSocketClient(new DiscordSocketConfig
            {                                       // Add discord to the collection
                LogLevel = LogSeverity.Verbose,     // Tell the logger to give Verbose amount of info
                MessageCacheSize = 1000             // Cache 1,000 messages per channel
            }))
            .AddSingleton(new CommandService(new CommandServiceConfig
            {                                       // Add the command service to the collection
                LogLevel = LogSeverity.Verbose,     // Tell the logger to give Verbose amount of info
                DefaultRunMode = RunMode.Async,     // Force all commands to run async by default
            }))
            .AddSingleton<Services.CommandHandler>()         // Add the command handler to the collection
            .AddSingleton<Services.StartupService>()         // Add startupservice to the collection
            .AddSingleton<Services.LoggingService>();        // Add loggingservice to the collection
        }
    }
}
