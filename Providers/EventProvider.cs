using DSharpPlus;

namespace Bardakbots.Provider
{
    public class EventProvider
    {
        public DiscordClient client;

        public EventProvider(DiscordClient discordClient)
        {
            client = discordClient;
        }

        public void RegisterEvents()
        {
            new Events.Events(client);
        }
    }
}
