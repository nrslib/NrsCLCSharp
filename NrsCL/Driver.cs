using System;
using System.Collections.Generic;
using System.Linq;
using NrsCl.Commands;
using NrsCl.Consoles;
using NrsCl.Environment;
using NrsCl.Prompts;

namespace NrsCl
{
    public class Driver : IDisposable
    {
        private readonly CLICommandsContainer commandContainer;
        private readonly CLIContext context;

        public Driver(CLICommandsContainer commandContainer, CLIContext context = null)
        {
            this.commandContainer = commandContainer;
            this.context = context;
        }

        public void Dispose()
        {
            commandContainer.Dispose();
        }

        public void Run()
        {
            var commands = commandContainer.ToArray();
            var commandOrders = commandContainer.BindToConfig(ToCommandText).ToList();
            commandOrders.Add("[Q]uit");
            var commandTexts = string.Join(System.Environment.NewLine, commandOrders);

            var firstLetters = commandContainer.BindToConfig(x => x.FirstLetter.ToString().ToUpper()).ToList();
            firstLetters.Add("Q");
            var firstLetterForPrompts = string.Join("/", firstLetters);

            InitializeCommands(commands);

            while (true)
            {
                CLIConsole.WriteLine("Available commands:");
                CLIConsole.WriteLine();
                CLIConsole.WriteLine(commandTexts);
                
                var (isQuit, input) = Prompt.ShowQuitable($"What would you like a command? ({firstLetterForPrompts})");
                if (isQuit)
                {
                    CLIConsole.WriteLine("Quit");
                    return;
                }

                var target = commandContainer.Find(input);
                if (target == null)
                {
                    CLIConsole.WriteLine($"Not matched({input})");
                }
                else
                {
                    target.Run();
                }
                CLIConsole.WriteLine();
            }
        }

        private void InitializeCommands(IEnumerable<ICLICommand> commands)
        {
            var targets = commands.OfType<ICLICommandWithInitialize>().ToArray();
            if (targets.Any())
            {
                CLIConsole.WriteLine("Initialize...");
                foreach (var command in targets)
                {
                    command.Initialize(context);
                }
                CLIConsole.WriteLine("End Initialize...");
                CLIConsole.WriteLine();
            }
        }

        private string ToCommandText(CLICommandConfig config)
        {
            var head = config.CommandName.First();
            var tail = config.CommandName.Skip(1);

            return "[" + head.ToString().ToUpper() + "]" + string.Join("", tail);
        }
    }
}
