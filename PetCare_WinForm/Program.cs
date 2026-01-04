namespace PetCare_WinForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.SetHighDpiMode(HighDpiMode.PerMonitorV2); // Dùng để điều chỉnh kích thước data grid

            // Application.Run(new FormPOS());
            Application.Run(new FrmLogin());
        }
    }
}