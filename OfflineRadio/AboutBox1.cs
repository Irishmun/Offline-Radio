using OfflineRadio.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfflineRadio
{
    partial class AboutBox1 : Form
    {
        public AboutBox1()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyUtil.AssemblyTitle());
            this.labelProductName.Text = AssemblyUtil.AssemblyProduct();
            this.labelVersion.Text = String.Format("Version {0}", AssemblyUtil.AssemblyVersion());
            this.labelCopyright.Text = AssemblyUtil.AssemblyCopyright();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
