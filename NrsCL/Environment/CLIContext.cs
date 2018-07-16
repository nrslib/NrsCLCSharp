namespace NrsCl.Environment
{
    public class CLIContext
    {
        public CLIContext(string dataDirectoryFullPath)
        {
            DataDirectoryFullPath = dataDirectoryFullPath;
        }

        public string DataDirectoryFullPath { get; }
    }
}
