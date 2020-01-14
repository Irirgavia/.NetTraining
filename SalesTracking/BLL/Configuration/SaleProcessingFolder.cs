namespace BLL.Configuration
{
    public class SaleProcessingFolder
    {
        public SaleProcessingFolder()
        {
            InitialFolder = string.Empty;
            ProcessedFolder = string.Empty;
            FaultedFolder = string.Empty;
        }

        public string InitialFolder { get; set; }

        public string ProcessedFolder { get; set; }

        public string FaultedFolder { get; set; }
    }
}