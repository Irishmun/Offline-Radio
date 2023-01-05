using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfflineRadio.UI
{
    internal abstract class UIBase
    {
        private Bitmap _sourceImage;

        protected Bitmap CreateBitmap(Rectangle rect)
        {
            return _sourceImage.Clone(rect, _sourceImage.PixelFormat);
        }
        protected Bitmap CreateBitmap(Point topLeft, Point bottomRight)
        {
            Rectangle rect = new Rectangle(topLeft, new Size(bottomRight.X - topLeft.X, bottomRight.Y - topLeft.Y));
            return CreateBitmap(rect);
        }

        public void SetImage(ref System.Windows.Forms.Control control, Bitmap imageToSet)
        {
            control.BackgroundImage = imageToSet;
        }
        public Bitmap SourceImage { get => _sourceImage; protected set => _sourceImage = value; }

    }
}
