using DSharpPlus;
using DSharpPlus.CommandsNext;
using Bardakbot.Config;
using DSharpPlus.EventArgs;
using Bardakbots.Provider;

namespace BardakBots
{
    class Bot
    {
        private static DiscordClient client { get; set; }
        private static CommandsNextExtension commands {get; set;}

        static async Task Main(String[] args)
        {
            ConfigReader config = new ConfigReader();

            var disocrdConfig = new DiscordConfiguration()
            {
                Intents = DiscordIntents.All,
                Token = config.token,
                TokenType = TokenType.Bot,
                AutoReconnect = true
            };

            client = new DiscordClient(disocrdConfig);

            client.Ready += Client_Ready;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { config.prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
            };

            commands = client.UseCommandsNext(commandsConfig);

            CommandProvider commandProvider = new CommandProvider(commands);
            commandProvider.RegisterCommands();
            EventProvider eventProvider = new EventProvider(client);
            eventProvider.RegisterEvents();

            await client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
