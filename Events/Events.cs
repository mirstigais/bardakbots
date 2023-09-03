using Bardakbots.Data;
using Bardakbots.Models;
using DSharpPlus;

namespace Bardakbots.Events
{
    internal class Events
    {
        BotContext dbContext = new BotContext();

        public Events(DiscordClient client) 
        {
            //Should store all server users in DB on bot startup
            client.GuildAvailable += async (s, e) =>
            {
                var guildUsers = await e.Guild.GetAllMembersAsync();

                foreach (var guildUser in guildUsers) {
                    if (guildUser.IsBot) continue;
                    var u = dbContext.User.FirstOrDefault(user => user.Id == guildUser.Id);

                    if (u == null)
                    {
                        User user = new User(guildUser.Id, guildUser.Username);
                        dbContext.User.Add(user);
                        dbContext.SaveChanges();
                    }
                }
            };

            //Shold be called when user joins server, adds user to DB
            client.GuildMemberAdded += (s, e) => {
                var guildUser = e.Member;
                ulong guildUserId = guildUser.Id;

                if (!guildUser.IsBot)
                {
                    var u = dbContext.User.FirstOrDefault(user => user.Id == guildUserId);

                    if (u == null)
                    {
                        User user = new User(e.Member.Id, e.Member.Username);
                        dbContext.User.Add(user);
                        dbContext.SaveChanges();
                    }
                }

                return Task.CompletedTask;
            };
        }
    }
}
