namespace WindowsServiceClient
{
    using System.ServiceProcess;

    public static class Program
    {
        public static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] { new SalesTrackingService() };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
