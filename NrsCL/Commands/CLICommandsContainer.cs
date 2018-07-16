using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NrsCl.Commands
{
    public class CLICommandsContainer : IDisposable, IEnumerable<ICLICommand>
    {
        private readonly Dictionary<CLICommandConfig, ICLICommand> commands = new Dictionary<CLICommandConfig, ICLICommand>();

        public void Dispose()
        {
        }

        public void Add(CLICommandConfig config, ICLICommand command)
        {
            if (config.FirstLetter == 'q')
            {
                throw new ArgumentOutOfRangeException(nameof(command), "'q' is reserved.");
            }

            if (commands.ContainsKey(config))
            {
                throw new ArgumentException("duplicated key");
            }

            if (commands.Keys.Select(x => x.FirstLetter).Any(c => c == config.FirstLetter))
            {
                throw new ArgumentException("duplicated first letter");
            }

            commands.Add(config, command);
        }

        public ICLICommand Find(string input)
        {
            foreach (var kv in commands)
            {
                if (kv.Key.IsMatched(input))
                {
                    return kv.Value;
                }
            }

            return null;
        }

        public IEnumerable<T> BindToConfig<T>(Func<CLICommandConfig, T> selector)
        {
            return commands.Keys.Select(selector);
        }

        public IEnumerator<ICLICommand> GetEnumerator()
        {
            return commands.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
