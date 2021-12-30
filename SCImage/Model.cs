using System;
using System.ComponentModel;
using System.Drawing;
using OpenCvSharp;
using Point = System.Drawing.Point;

namespace SCImage
{

    public class Model
    {
        public ImgMask Mask = null;
        public Image ResizeImage(Image img, int dwidth, int dheight, BackgroundWorker bgw)
        {
            
            var sci = new LiquidResize(img, Mask);
            // Mask = null;
            return (Bitmap) sci.Retarget(dwidth, dheight, bgw);
        }

        public Image GetGrayImage(Image img)
        {
            var sci = new LiquidResize(img, Mask);
            return sci.GrayMap();
        }
    }
}