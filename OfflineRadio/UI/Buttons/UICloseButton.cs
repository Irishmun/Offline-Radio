using OfflineRadio.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfflineRadio.UI.Buttons
{
    internal class UICloseButton : UIButton
    {
        private Point _topLeftNorm = new Point(18, 0), _topLeftPress = new Point(18, 9);
        private Size _size = new Size(9, 9);
        public UICloseButton(ref Button button)
        {
            button.MouseDown += Button_MouseDown;
            button.MouseUp += Button_MouseUp;
            Rectangle norm = new Rectangle(_topLeftNorm, _size);
            Rectangle press = new Rectangle(_topLeftPress, _size);
            base.Init(ref button, Resources.titlebar, norm, press);
            base.SetNormal();
        }

        private void Button_MouseUp(object? sender, MouseEventArgs e)
        {
            base.SetNormal();
        }

        private void Button_MouseDown(object? sender, EventArgs e)
        {
            base.SetPressed();
        }
    }
}
