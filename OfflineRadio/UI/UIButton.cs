using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OfflineRadio.UI
{
    internal class UIButton : UIBase
    {
        private Bitmap _buttonNormal, _buttonPressed;
        private Button _button;


        protected void Init(ref Button button, Bitmap source, Rectangle normal, Rectangle Pressed)
        {
            base.SourceImage = source;
            _button = button;
            _buttonNormal = CreateBitmap(normal);
            _buttonPressed = CreateBitmap(Pressed);
        }
        /// <summary>Sets the button's background image to the given image. used for special situations</summary>
        public void SetImage(Bitmap img)
        {
            _button.BackgroundImage = img;
        }

        /// <summary>Sets the button's background image to the Normal state</summary>
        public void SetNormal()
        {
            SetImage(_buttonNormal);
        }

        /// <summary>Sets the button's background image to the Pressed state</summary>
        public void SetPressed()
        {
            SetImage(_buttonPressed);
        }
    }
}
