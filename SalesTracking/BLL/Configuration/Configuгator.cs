namespace BLL.Configuration
{
    using System;
    using System.Configuration;

    public class Configuгator
    {
        public SaleProcessingFolders Configure()
        {
            var saleProcessingFolder = new SaleProcessingFolders();
            var section = (StartupFoldersConfigSection)ConfigurationManager.GetSection("StartupFolders");
            if (section != null)
            {
                saleProcessingFolder.InitialFolder = GetFolder(section, Constants.InitialFolder);
                saleProcessingFolder.ProcessedFolder = GetFolder(section, Constants.ProcessedFolder);
                saleProcessingFolder.FaultedFolder = GetFolder(section, Constants.FaultedFolder);
            }

            return saleProcessingFolder;
        }

        private string GetFolder(StartupFoldersConfigSection section, string folder)
        {
            if (section.FolderItems[folder] == null)
            {
                return string.Empty;
            }

            return section.FolderItems[folder];
        }
    }
}