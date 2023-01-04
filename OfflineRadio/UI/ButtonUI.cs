using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OfflineRadio.UI
{
    class ButtonUI
    {

        private int _buttonsX, _buttonsY;//how many buttons there are. | how many states each button has
        private Point _topLeftStart, _bottomRightEnd;//where the button(s) start and end
        private Bitmap _buttonImage;

        private int _buttonWidth, _buttonHeight;
        private Point _buttonImageCenter;

        /// <param name="image">Image to use for the buttons</param>
        /// <param name="buttonsX">The amount of button images on the horizontal axis of the image. this will be unique buttons.</param>
        /// <param name="buttonsY">The amount of button images on the vertical axis of the image. this will be used for the states</param>
        /// <param name="topLeftStart">The top left pixel of the first button's first state.</param>
        /// <param name="bottomRightEnd">The bottom right pixel of the last button's last state.</param>
        public ButtonUI(Bitmap image, int buttonsX, int buttonsY, Point topLeftStart, Point bottomRightEnd)
        {
            _buttonImage = image;
            _buttonsX = buttonsX;
            _buttonsY = buttonsY;
            _topLeftStart = topLeftStart;
            _bottomRightEnd = bottomRightEnd;
            SetImageDimensions();
        }
        /// <param name="image">Image to use for the buttons</param>
        /// <param name="buttonsX">The amount of button images on the horizontal axis of the image. this will be unique buttons.</param>
        /// <param name="buttonsY">The amount of button images on the vertical axis of the image. this will be used for the states</param>
        /// <remarks>this constructor sets the Start and End as the top-left and bottom-right of the image.</remarks>
        public ButtonUI(Bitmap image, int buttonsX, int buttonsY)
        {
            _buttonImage = image;
            _buttonsX = buttonsX;
            _buttonsY = buttonsY;
            _topLeftStart = Point.Empty;
            _bottomRightEnd = new Point(image.Width, image.Height);
            SetImageDimensions();
        }

        private void SetImageDimensions()
        {
            _buttonWidth = (_bottomRightEnd.X - _topLeftStart.X) / _buttonsX;
            _buttonHeight = (_bottomRightEnd.Y - _topLeftStart.Y) / _buttonsY;
            _buttonImageCenter = new Point(_buttonWidth / 2, _buttonHeight / 2);
        }

        /// <summary>Sets the button image based on the index and state</summary>
        /// <param name="button">button to set the image of</param>
        /// <param name="index">the X position of the button in the <see cref="ButtonImage"/>. (as defined by <see cref="TopLeftStart"/> and <see cref="BottomRightEnd"/>)</param>
        /// <param name="state">the Y position of the button in the <see cref="ButtonImage"/>. (as defined by <see cref="TopLeftStart"/> and <see cref="BottomRightEnd"/>)</param>
        /// <remarks>If this button only has two states, use the override with the "isPressed" parameter instead.</remarks>
        public void SetButtonImage(ref System.Windows.Controls.Button button, int index, int state)
        {
            Point imageLocation = new Point((_topLeftStart.X + (_buttonWidth * index)) + _buttonImageCenter.X, _topLeftStart.Y + (_buttonHeight * state) + _buttonImageCenter.Y);
            System.Windows.Int32Rect imageRect = new System.Windows.Int32Rect(imageLocation.X, imageLocation.Y, _buttonWidth, _buttonHeight);

            //Bitmap btImg = _buttonImage.Clone(imageRect, _buttonImage.PixelFormat);

            BitmapSource imageSrc = Imaging.CreateBitmapSourceFromHBitmap(_buttonImage.GetHbitmap(), IntPtr.Zero, imageRect, BitmapSizeOptions.FromEmptyOptions());

            button.Background = new ImageBrush(imageSrc);
        }

        /// <summary>Sets the button image based on the index and state</summary>
        /// <param name="button">button to set the image of</param>
        /// <param name="index">the X position of the button in the <see cref="ButtonImage"/>. (as defined by <see cref="TopLeftStart"/> and <see cref="BottomRightEnd"/>)</param>
        /// <param name="isPressed">sets the Y to the second position of the buttonstates</param>
        public void SetButtonImage(ref System.Windows.Controls.Button button, int index, bool isPressed)
        {
            int state = isPressed == true ? 1 : 0;
            SetButtonImage(ref button, index, state);
        }

        public int ButtonsX => _buttonsX;
        public int ButtonsY => _buttonsY;
        public Point TopLeftStart => _topLeftStart;
        public Point BottomRightEnd => _bottomRightEnd;
        public Bitmap ButtonImage => _buttonImage;

    }
}
