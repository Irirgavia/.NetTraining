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
                if (section.FolderItems["InitialFolder"] != null)
                {
                    initialFolder = section.FolderItems["InitialFolder"];
                }
                if (section.FolderItems["ProcessedFolder"] != null)
                {
                    processedFolder = section.FolderItems["ProcessedFolder"];
                }
                if (section.FolderItems["FaultedFolder"] != null)
                {
                    faultedFolder = section.FolderItems["FaultedFolder"];
                }
            }

            return (initialFolder, processedFolder, faultedFolder);
        }
    }
}