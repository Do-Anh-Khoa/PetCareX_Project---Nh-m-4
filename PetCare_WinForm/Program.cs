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
           /* Application.Run(new FormPOS());
            Application.Run(new FormThanhToan());
            Application.Run(new FrmBaoCao());
            Application.Run(new FrmDuyetLich());
            Application.Run(new Kham_Benh());
            Application.Run(new Lich_Hen());*/

            Application.Run(new FrmHome());
        }
    }
}