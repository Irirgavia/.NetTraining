namespace WindowsServiceClient
{
    partial class Installer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.salesTrackingService2 = new WindowsServiceClient.SalesTrackingService();
            this.salesTrackingService1 = new WindowsServiceClient.SalesTrackingService();
            // 
            // salesTrackingService2
            // 
            this.salesTrackingService2.ExitCode = 0;
            this.salesTrackingService2.ServiceName = "Service1";
            // 
            // salesTrackingService1
            // 
            this.salesTrackingService1.ExitCode = 0;
            this.salesTrackingService1.ServiceName = "Service1";

        }

        #endregion
        private SalesTrackingService salesTrackingService2;
        private SalesTrackingService salesTrackingService1;
    }
}