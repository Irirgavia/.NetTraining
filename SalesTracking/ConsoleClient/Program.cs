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
            var watcher = new FolderTrackingWatcher(new Configuгator().Configure());

            Task task = Task.Factory.StartNew(() => watcher.Start());

            Console.ReadKey();
            watcher.Dispose();
        }
    }
}
