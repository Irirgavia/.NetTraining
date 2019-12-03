namespace TextProcessing.Configuration
{
    using System.Configuration;
    using System.IO;

    public class Section : ConfigurationSection
    {
        [ConfigurationProperty("Files")]
        public FilesCollection FileItems => (FilesCollection)base["Files"];

        public (string concordanceFile, string textFile) Configure()
        {
            string concordanceFilePath = string.Empty;
            string textFilePath = string.Empty;

            var section = (Section)ConfigurationManager.GetSection("StartupFiles");
            if (section != null)
            {
                if (section.FileItems[0].FileType == "ConcordanceFile")
                {
                    concordanceFilePath = section.FileItems[0].FilePath;
                }

                if (section.FileItems[1].FileType == "InitialTextFile")
                {
                    textFilePath = section.FileItems[1].FilePath;
                }
            }

            if (File.Exists(concordanceFilePath))
            {
                File.Delete(concordanceFilePath);
            }

            if (!File.Exists(textFilePath))
            {
                throw new FileNotFoundException("File to read is not found.");
            }

            return (concordanceFilePath, textFilePath);
        }
    }
}
