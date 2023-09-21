using Microsoft.VisualBasic.Logging;

namespace AjudanteDBA
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

            try
            {
                App.Initialize();
                ApplicationConfiguration.Initialize();
                Application.Run(new frmMain());
            }
            catch (Exception ex)
            {
               // Log.Fatal(ex, "Erro fatal ao inicializar a aplicação.");

                MessageBox.Show("Erro ao inicializar a aplicação.", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}