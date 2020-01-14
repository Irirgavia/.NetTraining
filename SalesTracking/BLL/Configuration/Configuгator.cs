namespace BLL.Configuration
{
    public class Configuгator
    {
        public (string InitialFolder, string ProcessedFolder, string FaultedFolder) Configure()
        {
            string initialFolder = "";
            string processedFolder = "";
            string faultedFolder = "";

            var section = (StartupFoldersConfigSection)System.Configuration.ConfigurationManager.GetSection("StartupFolders");
            if (section != null)
            {
                if (section.FolderItems[Constants.InitialFolder] != null)
                {
                    initialFolder = section.FolderItems[Constants.InitialFolder];
                }

                if (section.FolderItems[Constants.ProcessedFolder] != null)
                {
                    processedFolder = section.FolderItems[Constants.ProcessedFolder];
                }

                if (section.FolderItems[Constants.FaultedFolder] != null)
                {
                    faultedFolder = section.FolderItems[Constants.FaultedFolder];
                }
            }

            return (initialFolder, processedFolder, faultedFolder);
        }
    }
}