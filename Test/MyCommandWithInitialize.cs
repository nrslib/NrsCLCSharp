using System;
using NrsCl.Commands;
using NrsCl.Environment;

namespace Test
{
    public class MyCommandWithInitialize : ICLICommandWithInitialize
    {
        public void Dispose()
        {
            Console.WriteLine("My command with initialize disposing.");
        }

        public void Run()
        {
            Console.WriteLine("My command with initialize running.");
        }

        public void Initialize(CLIContext context)
        {
            Console.WriteLine("My command initialize...");
        }
    }
}
