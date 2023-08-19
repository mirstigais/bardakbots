
using DSharpPlus;
using DSharpPlus.CommandsNext;
using Bardakbot.config;
using DSharpPlus.EventArgs;
using Bardakbots.providers;

namespace BardakBots
{
    class Bot
    {
        private static DiscordClient Client { get; set; }
        private static CommandsNextExtension Commands {get; set;}

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

            Client = new DiscordClient(disocrdConfig);

            Client.Ready += Client_Ready;

            var commandsConfig = new CommandsNextConfiguration()
            {
                StringPrefixes = new string[] { config.prefix },
                EnableMentionPrefix = true,
                EnableDms = true,
                EnableDefaultHelp = false,
            };

            Commands = Client.UseCommandsNext(commandsConfig);

            CommandProvider commandProvider = new CommandProvider(Commands);
            commandProvider.RegisterCommands();

            await Client.ConnectAsync();
            await Task.Delay(-1);
        }

        private static Task Client_Ready(DiscordClient sender, ReadyEventArgs args)
        {
            return Task.CompletedTask;
        }
    }
}
