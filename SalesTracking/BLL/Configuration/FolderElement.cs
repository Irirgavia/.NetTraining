namespace BLL.Configuration
{
    using System.Configuration;

    public class FolderElement : ConfigurationElement
    {
        [ConfigurationProperty(Constants.FolderTypeName, DefaultValue = "", IsKey = true, IsRequired = true)]
        public string FolderType
        {
            get => (string)base[Constants.FolderTypeName];
            set => base[Constants.FolderTypeName] = value;
        }

        [ConfigurationProperty(Constants.PathName, DefaultValue = "", IsKey = false, IsRequired = false)]
        public string Path
        {
            get => (string) base[Constants.PathName];
            set => base[Constants.PathName] = value;
        }
    }
}