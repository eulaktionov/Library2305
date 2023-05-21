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
                // ��������� ����������
                Exception exception = (Exception)e.ExceptionObject;
                // ��������� ����������� �������� ��� ������������� ����������
                // ��������, �������� ��������� �� ������ ��� ��������� ���������� � ���

                // �����������, �� ������ ��������� ���������� ��� ��������� ������ ��������
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