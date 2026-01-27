using Eto.Drawing;
using Eto.Forms;
using System;

namespace OfflineRadio
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            new Application().Run(new RadioForm());
        }
    }
}
