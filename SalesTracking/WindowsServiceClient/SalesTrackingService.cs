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
            Watcher = new FolderTrackingWatcher(new Configuгator().Configure());
            var task = Task.Factory.StartNew(() => Watcher.Start());
        }

        protected override void OnStop()
        {
            Watcher.Dispose();
        }
    }
}
