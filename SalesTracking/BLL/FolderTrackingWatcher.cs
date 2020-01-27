namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using BLL.Configuration;
    using BLL.Parser;

    using NLog;

    public class FolderTrackingWatcher : IDisposable
    {
        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        private SaleProcessingFolders saleProcessingFolders;

        private FileSystemWatcher watcher;

        private SalesService salesService;

        public FolderTrackingWatcher(SaleProcessingFolders saleProcessingFolders, SalesService salesService)
        {
            this.saleProcessingFolders = saleProcessingFolders;
            CreateIfNotExistsFolder(this.saleProcessingFolders.InitialFolder);
            CreateIfNotExistsFolder(this.saleProcessingFolders.ProcessedFolder);
            CreateIfNotExistsFolder(this.saleProcessingFolders.FaultedFolder);

            this.salesService = salesService;//new salesService(new CSVParser());

            this.watcher = new FileSystemWatcher(this.saleProcessingFolders.InitialFolder);
            this.watcher.Created += AddWatcher;
        }

        public void Start()
        {
            FilesPreprocessing();
            watcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            watcher.EnableRaisingEvents = false;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                watcher?.Dispose();
                salesService?.Dispose();
            }
        }

        private void CreateIfNotExistsFolder(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        private void AddWatcher(object sender, FileSystemEventArgs e)
        {
            FileProcessing(e.FullPath);
        }

        private void FilesPreprocessing()
        {
            foreach (var file in Directory.EnumerateFiles(saleProcessingFolders.ProcessedFolder))
            {//ex
                FileProcessing(file);
            }
        }

        private void FileProcessing(string filePath)
        {
            try
            {
                var task = Task.Factory.StartNew(() => salesService.CreateSales(filePath));
                if (task.Exception == null)
                {
                    task.ContinueWith(t => { FilePostProcessing(filePath, t.Result); });
                    return;
                }

                foreach (var exception in task.Exception.InnerExceptions)
                {
                    logger.Error(exception.Message);
                }

                task.ContinueWith(t => { FilePostProcessing(filePath, new List<int>() { -1 }); });
               
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
        }

        private void FilePostProcessing(string filePath, List<int> faultedLines)
        {
            var fileName = Path.GetFileName(filePath);
            if (fileName == null)
            {
                logger.Error($"File {fileName} is not found.");
                return;
            }

            if (faultedLines.Count == 0)
            {
                File.Move(filePath, Path.Combine(saleProcessingFolders.ProcessedFolder, fileName));

                logger.Info($"{filePath} - Successful file processing.");
                return;
            }

            File.Move(filePath, Path.Combine(saleProcessingFolders.FaultedFolder, fileName));

            logger.Info($"{filePath} - File processing failed. Error lines :");
            foreach (var line in faultedLines)
            {
                logger.Warn($"{line} ");
            }
        }
    }
}