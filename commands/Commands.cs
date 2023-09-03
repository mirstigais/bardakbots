using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;

namespace Bardakbots.Commands
{
    internal class Commands : BaseCommandModule
    {
        [Command("sample")]
        public async Task SampleCommand(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("This is a sample command");
        }
    }
}
