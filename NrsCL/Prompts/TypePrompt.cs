using System;
using NrsCl.Consoles;

namespace NrsCl.Prompts
{
    public class TypePrompt
    {
        public (bool, string) ShowQuitable(string message)
        {
            CLIConsole.WriteLine(message, ConsoleColor.Magenta);
            while (true)
            {
                CLIConsole.Write(">");
                var rawInput = Console.ReadLine();
                var input = rawInput.ToLower().Trim();
                if (input.Length > 0)
                {
                    var isQuit = input == "q" || input == "quit";
                    return (isQuit, rawInput);
                }
                CLIConsole.WriteLine("type any word.", PromptConfig.PromptColor);
            }
        }

        public string Show(string message)
        {
            CLIConsole.WriteLine(message, PromptConfig.PromptColor);
            while (true)
            {
                CLIConsole.Write(">");
                var input = Console.ReadLine();
                if (input.Length > 0)
                {
                    return input;
                }

                CLIConsole.WriteLine("type any word.", PromptConfig.PromptColor);
            }
        }
    }
}
