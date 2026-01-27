using Eto.Forms;
using System;

namespace OfflineRadio.Wpf
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.WinForms).Run(new RadioForm());
        }
    }
}
