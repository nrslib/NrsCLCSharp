using System;
using System.Linq;

namespace NrsCl.Commands
{
    public class CLICommandConfig : IEquatable<CLICommandConfig>
    {
        public CLICommandConfig(string commandName)
        {
            if(commandName == null) throw new ArgumentNullException(nameof(commandName));
            if (commandName.Length == 0) throw new ArgumentOutOfRangeException(nameof(commandName));

            CommandName = commandName;
            FirstLetter = commandName.ToLower().First();
        }

        public string CommandName { get; }
        public Char FirstLetter { get; }

        public bool IsMatched(string input)
        {
            var argFirstLetter = input.ToList().First();
            return argFirstLetter == FirstLetter;
        }

        public bool Equals(CLICommandConfig other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(CommandName, other.CommandName) && FirstLetter == other.FirstLetter;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CLICommandConfig) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((CommandName != null ? CommandName.GetHashCode() : 0) * 397) ^ FirstLetter.GetHashCode();
            }
        }
    }
}
