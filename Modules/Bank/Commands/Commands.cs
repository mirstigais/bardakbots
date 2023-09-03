using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.CommandsNext;
using Bardakbots.Data;
using Microsoft.EntityFrameworkCore;

namespace Bardakbots.Modules.Bank.Commands
{
    internal class Commands : BaseCommandModule
    {
        BotContext dbContext = new BotContext();

        [Command("bilance")]
        public async Task GetBilance(CommandContext ctx)
        {
            ulong guildUserId = ctx.User.Id;
            var bAccount = dbContext.BankAccount.FirstOrDefault(user => user.UserId == guildUserId);

            if (bAccount != null)
            {
                await ctx.Channel.SendMessageAsync($"Your current 💸: {bAccount.Bilance}");
            }
            else
            {
                await ctx.Channel.SendMessageAsync($"Error retrieving 💸");
            }

        }

        //Commands for testing, should be disabled
        [Command("CheatAddBilance")]
        public async Task CheatAddBilance(CommandContext ctx, string amount)
        {
            ulong guildUserId = ctx.User.Id;
            double validAmount = 0;
            var bAccount = dbContext.BankAccount.FirstOrDefault(user => user.UserId == guildUserId);

            if (Double.TryParse(amount, out validAmount))
            {
                if (bAccount != null)
                {
                    bAccount.addMoney(validAmount);
                    dbContext.SaveChanges();
                    await ctx.Channel.SendMessageAsync($"Added 💸 to your account: {validAmount}");
                }
                else
                {
                    await ctx.Channel.SendMessageAsync($"Error retrieving account 💸");
                }
            } else
            {
                await ctx.Channel.SendMessageAsync($"Enter a valid amount of 💸 and try again.");
            }
        }

        [Command("CheatRemoveBilance")]
        public async Task CheatRemoveBilance(CommandContext ctx, string amount)
        {
            ulong guildUserId = ctx.User.Id;
            double validAmount = 0;
            var bAccount = dbContext.BankAccount.FirstOrDefault(user => user.UserId == guildUserId);

            if (Double.TryParse(amount, out validAmount))
            {
                if (bAccount != null)
                {
                    bAccount.subtractMoney(validAmount);
                    dbContext.SaveChanges();
                    await ctx.Channel.SendMessageAsync($"Removed 💸 from your account: {validAmount}");
                }
                else
                {
                    await ctx.Channel.SendMessageAsync($"Error retrieving account 💸");
                }
            } else
            {
                await ctx.Channel.SendMessageAsync($"Enter a valid amount of 💸 and try again.");
            }
        }
    }
}
