using System.Diagnostics;

namespace Library2305
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += (sender, e) =>
            {
                // Обработка исключения
                Exception exception = (Exception)e.ExceptionObject;
                // Выполните необходимые действия при возникновении исключения
                // например, выведите сообщение об ошибке или сохраните информацию о ней

                // Опционально, вы можете завершить приложение или выполнить другие действия
                MessageBox.Show(exception.Message);
                Debug.WriteLine(exception.StackTrace);
            };

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new StartForm());
        }
    }
}