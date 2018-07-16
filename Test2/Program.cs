using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NrsCl;
using NrsCl.Commands;
using NrsCl.Environment;
using Test;

namespace Test2 {
    class Program {
        static void Main(string[] args) {
            var context = new CLIContext(Environment.CurrentDirectory);
            var commandContainer = new CLICommandsContainer
            {
                { new CLICommandConfig("my command"), new MyCommand() },
                { new CLICommandConfig("with initialize"), new MyCommandWithInitialize()}
            };
            using (var driver = new Driver(commandContainer, context)) {
                driver.Run();
            }
        }
    }
}
