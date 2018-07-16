using System;
using NrsCl.Consoles;

namespace NrsCl.Prompts
{
    public class YesNoPrompt
    {
        public enum Result
        {
            Yes,
            No,
        }

        public Result Show(string message, Result? optResult = Result.Yes)
        {
            string promptText;
            if (optResult.HasValue)
            {
                promptText = optResult.Value == Result.Yes ? "[y] >" : "[n] >";
            }
            else
            {
                promptText = ">";
            }

            CLIConsole.Write(message, PromptConfig.PromptColor);
            CLIConsole.WriteLine("(y/n)");
            CLIConsole.Write(promptText);
            while (true)
            {
                var rawInput = Console.ReadLine();
                var input = rawInput.ToLower().Trim();
                if (optResult.HasValue && input == "")
                {
                    var result = optResult.Value;
                    return result;
                }

                switch (input)
                {
                    case "y":
                    case "yes":
                        return Result.Yes;
                    case "n":
                    case "no":
                        return Result.No;
                }

                CLIConsole.WriteLine("type 'y' or 'n'");
                CLIConsole.Write(promptText);
            }
        }
    }
}
