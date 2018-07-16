using NrsCl.Environment;

namespace NrsCl.Commands
{
    public interface ICLICommandWithInitialize : ICLICommand
    {
        void Initialize(CLIContext context);
    }
}
