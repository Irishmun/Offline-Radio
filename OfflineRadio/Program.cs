using System;
using System.Windows.Forms;

namespace OfflineRadio
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new RadioForm());
        }
    }
}
