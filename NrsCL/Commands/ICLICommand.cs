using System;

namespace NrsCl.Commands {
    public interface ICLICommand : IDisposable
    {
        void Run();
    }
}
