using DSharpPlus.CommandsNext;

namespace Bardakbots.Provider
{
    public class CommandProvider
    {
        public CommandsNextExtension coreCommands;

        public CommandProvider(CommandsNextExtension commandsNextExtension)
        {
            coreCommands = commandsNextExtension;
        }

        public void RegisterCommands()
        {
            coreCommands.RegisterCommands<Commands.Commands>();
            coreCommands.RegisterCommands<Modules.Bank.Commands.Commands>();
        }
    }
}
