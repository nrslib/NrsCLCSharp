using System;
using NrsCl.Commands;

namespace Test
{
    class MyCommand : ICLICommand
    {
        public void Dispose()
        {
            Console.WriteLine("My command disposing.");
        }

        public void Run()
        {
            Console.WriteLine("My command running.");
        }
    }
}
