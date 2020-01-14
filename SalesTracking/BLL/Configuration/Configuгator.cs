namespace BLL.Configuration
{
    using System;

    public class Configuгator
    {
        public SaleProcessingFolder Configure()
        {
            var saleProcessingFolder = new SaleProcessingFolder();
            var section = (StartupFoldersConfigSection)System.Configuration.ConfigurationManager.GetSection("StartupFolders");
            if (section != null)
            {
                if (section.FolderItems[Constants.InitialFolder] != null)
                {
                    saleProcessingFolder.InitialFolder = section.FolderItems[Constants.InitialFolder];
                }

                if (section.FolderItems[Constants.ProcessedFolder] != null)
                {
                    saleProcessingFolder.ProcessedFolder = section.FolderItems[Constants.ProcessedFolder];
                }

                if (section.FolderItems[Constants.FaultedFolder] != null)
                {
                    saleProcessingFolder.FaultedFolder = section.FolderItems[Constants.FaultedFolder];
                }
            }

            return saleProcessingFolder;
        }
    }
}