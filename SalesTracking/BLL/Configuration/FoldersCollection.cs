namespace BLL.Configuration
{
    using System.Configuration;

    [ConfigurationCollection(typeof(FolderElement))]
    public class FoldersCollection : ConfigurationElementCollection
    {
        public string this[string folderType]
        {
            get
            {
                var folder = (FolderElement)BaseGet(folderType);
                return folder.Path;
            }
        }

        protected override ConfigurationElement CreateNewElement()
        {
            return new FolderElement();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((FolderElement)(element)).FolderType;
        }
    }
}