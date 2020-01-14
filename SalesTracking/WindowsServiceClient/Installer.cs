using System.ComponentModel;

namespace WindowsServiceClient
{
    using System.ServiceProcess;

    [RunInstaller(true)]
    public partial class Installer : System.Configuration.Install.Installer
    {
        public Installer()
        {
            InitializeComponent();

            var serviceInstaller = new ServiceInstaller();
            var processInstaller = new ServiceProcessInstaller();

            processInstaller.Account = ServiceAccount.LocalSystem;
            serviceInstaller.StartType = ServiceStartMode.Manual;
            serviceInstaller.ServiceName = "SalesTrackingService";
            Installers.Add(processInstaller);
            Installers.Add(serviceInstaller);
        }
    }
}
