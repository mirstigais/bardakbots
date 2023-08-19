using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using Bardakbots.commands;

namespace Bardakbots.providers
{
    public class CommandProvider
    {
        public CommandsNextExtension Commands;

        public CommandProvider(CommandsNextExtension commandsNextExtension)
        {
            Commands = commandsNextExtension;
        }

        public void RegisterCommands()
        {
            Commands.RegisterCommands<Commands>();
        }
    }
}
