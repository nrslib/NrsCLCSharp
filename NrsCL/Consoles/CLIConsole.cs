using System;
using System.Collections.Generic;

namespace NrsCl.Consoles
{
    public static class CLIConsole
    {
        public static void WriteSeparator()
        {
            Console.WriteLine("--------------------------------------------------");
        }

        public static void WriteLine()
        {
            Console.WriteLine();
        }

        public static void WriteLine(string message, ConsoleColor? color = null)
        {
            ChangeColorThen(color, () => Console.WriteLine(message));
        }

        public static void WriteLine(IEnumerable<string> messages, ConsoleColor? color = null)
        {
            ChangeColorThen(color, () =>
            {
                foreach (var message in messages)
                {
                    Console.WriteLine(message);
                }
            });
        }

        public static void Write(string message, ConsoleColor? color = null)
        {
            ChangeColorThen(color, () => Console.Write(message));
        }

        private static void ChangeColorThen(ConsoleColor? color, Action predicate)
        {
            if (color != null)
            {
                Console.ForegroundColor = color.Value;
            }

            predicate();

            if (color != null)
            {
                Console.ResetColor();
            }
        }
    }
}
