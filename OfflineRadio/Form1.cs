using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OfflineRadio.UI.Buttons;

namespace OfflineRadio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine("Initialized form");

            UICloseButton closeButton = new UICloseButton(ref BT_CloseProgram);
            UIPlayButton playButton = new UIPlayButton(ref BT_Play);
        }

        private void BT_CloseProgram_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}