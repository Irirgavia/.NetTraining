namespace BLL.Configuration
{
    using System.Configuration;

    public class StartupFoldersConfigSection : ConfigurationSection
    {
        [ConfigurationProperty(Constants.FolderItemsName)]
        public FoldersCollection FolderItems
        {
            get => (FoldersCollection)base[Constants.FolderItemsName]; 
        }
    }
}