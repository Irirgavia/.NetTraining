namespace BLL
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Threading.Tasks;

    using BLL.Writer;

    public class FolderTrackingWatcher
    {
        public FolderTrackingWatcher(IWriter logger, string initialFolder, string processedFolder, string faultedFolder)
        {
            Logger = logger;
            InitialDirectory = initialFolder;
            ProcessedDirectory = processedFolder;
            FaultedDirectory = faultedFolder;

            CreateIfNotExistsFolders(initialFolder, processedFolder, faultedFolder);

            Service = new SellingService(new CSVParser());

            Watcher = new FileSystemWatcher(initialFolder);
            Watcher.Created += WatcherCreated;
        }

        FileSystemWatcher Watcher { get; }

        ISellingService Service { get; }

        IWriter Logger { get; }

        string InitialDirectory { get; }

        string ProcessedDirectory { get; }

        string FaultedDirectory { get; }

        public void Start()
        {
            ProcessInitialFiles();
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
                if (Service != null)
                {
                    Service.Dispose();
                }
            }
        }

        private void WatcherCreated(object sender, FileSystemEventArgs e)
        {
            string filePath = e.FullPath;
            ProcessFile(filePath);
        }

        private void ProcessFile(string filePath)
        {
            try
            {
                Task<List<int>> task = Task.Factory.StartNew(() => Service.CreateSellings(filePath));
                if (task.Exception == null)
                {
                    task.ContinueWith(t => { AfterProcessFile(filePath, t.Result); });
                }
                else
                {
                    foreach (var ex in task.Exception.InnerExceptions)
                    {
                        Logger.WriteLine(ex.Message);
                    }

                    task.ContinueWith(t => { AfterProcessFile(filePath, new List<int>() { -1 }); });
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLine(ex.Message);
            }
        }

        private void AfterProcessFile(string filePath, List<int> faultedLines)
        {
            if (faultedLines.Count == 0)
            {
                var fileName = Path.GetFileName(filePath);
                File.Move(filePath, Path.Combine(ProcessedDirectory, fileName));
                Logger.WriteLine($"File {filePath} parsed successfully.");
            }
            else
            {
                var fileName = Path.GetFileName(filePath);
                File.Move(filePath, Path.Combine(FaultedDirectory, fileName));
                Logger.WriteLine($"File {filePath} parsed with errors. Number of faulted strings are ");
                foreach (var faultLine in faultedLines)
                {
                    Logger.Write($"{faultLine} ");
                }
            }
        }

        private void ProcessInitialFiles()
        {
            var files = Directory.EnumerateFiles(InitialDirectory);
            foreach (var file in files)
            {
                ProcessFile(file);
            }
        }

        private void CreateIfNotExistsFolders(string initialFolder, string processedFolder, string faultedFolder)
        {
            if (!Directory.Exists(initialFolder))
            {
                Directory.CreateDirectory(initialFolder);
            }

            if (!Directory.Exists(processedFolder))
            {
                Directory.CreateDirectory(processedFolder);
            }

            if (!Directory.Exists(faultedFolder))
            {
                Directory.CreateDirectory(faultedFolder);
            }
        }
    }
}