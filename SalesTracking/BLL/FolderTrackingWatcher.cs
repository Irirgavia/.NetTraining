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

        public FolderTrackingWatcher(SaleProcessingFolders saleProcessingFolders)
        {
            SaleProcessingFolders = saleProcessingFolders;
            CreateIfNotExistsFolder(SaleProcessingFolders.InitialFolder);
            CreateIfNotExistsFolder(SaleProcessingFolders.ProcessedFolder);
            CreateIfNotExistsFolder(SaleProcessingFolders.FaultedFolder);

            SalesService = new SalesService(new CSVParser());

            Watcher = new FileSystemWatcher(SaleProcessingFolders.InitialFolder);
            Watcher.Created += AddWatcher;
        }

        private SaleProcessingFolders SaleProcessingFolders { get; }

        private FileSystemWatcher Watcher { get; }

        private SalesService SalesService { get; }

        public void Start()
        {
            this.FilesPreprocessing();
            Watcher.EnableRaisingEvents = true;
        }

        public void Stop()
        {
            Watcher.EnableRaisingEvents = false;
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
                Watcher?.Dispose();
                SalesService?.Dispose();
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
            this.FileProcessing(e.FullPath);
        }

        private void FilesPreprocessing()
        {
            foreach (var file in Directory.EnumerateFiles(SaleProcessingFolders.ProcessedFolder))
            {
                this.FileProcessing(file);
            }
        }

        private void FileProcessing(string filePath)
        {
            try
            {
                var task = Task.Factory.StartNew(() => SalesService.CreateSales(filePath));
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
                File.Move(filePath, Path.Combine(SaleProcessingFolders.ProcessedFolder, fileName));

                logger.Info($"{filePath} - Successful file processing.");
                return;
            }

            File.Move(filePath, Path.Combine(SaleProcessingFolders.FaultedFolder, fileName));

            logger.Info($"{filePath} - File processing failed. Error lines :");
            foreach (var line in faultedLines)
            {
                logger.Info($"{line} ");
            }
        }
    }
}