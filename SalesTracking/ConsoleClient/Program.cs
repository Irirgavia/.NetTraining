namespace ConsoleClient
{
    using System;
    using System.Threading.Tasks;

    using BLL;
    using BLL.Configuration;

    public class Program
    {
        public static void Main(string[] args)
        {
            var manager = new Configuгator();
            var folders = manager.Configure();

            FolderTrackingWatcher watcher = new FolderTrackingWatcher(
                folders.InitialFolder,
                folders.ProcessedFolder,
                folders.FaultedFolder);

            Task task = Task.Factory.StartNew(() => watcher.Start());

            Console.ReadKey();
            watcher.Dispose();
        }
    }
}
