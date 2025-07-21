namespace Seker_kutuphane
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
            // Form1 yerine Form2'yi (Dashboard) başlangıç formu yapıyoruz.
            // Test için kullanıcı adı ve rolü geçici olarak kodda belirtilmiştir.
            Application.Run(new Form2("Admin", "Yönetici"));
        }
    }
}