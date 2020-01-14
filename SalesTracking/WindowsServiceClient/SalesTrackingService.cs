namespace WindowsServiceClient
{
    using System.ServiceProcess;
    using System.Threading.Tasks;

    using BLL;
    using BLL.Configuration;

    public partial class SalesTrackingService : ServiceBase
    {
        public SalesTrackingService()
        {
            InitializeComponent();
        }

        private FolderTrackingWatcher Watcher { get; set; }

        public void OnDebug()
        {
            OnStart(null);
        }

        protected override void OnStart(string[] args)
        {
            var manager = new Configuгator();
            var folders = manager.Configure();

            Watcher = new FolderTrackingWatcher( 
                folders.InitialFolder,
                folders.ProcessedFolder,
                folders.FaultedFolder);
            Task task = Task.Factory.StartNew(() => Watcher.Start());
        }

        protected override void OnStop()
        {
            Watcher.Dispose();
        }
    }
}
