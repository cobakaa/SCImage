using System;
using System.ComponentModel;
using System.Drawing;

namespace SCImage
{
    public class Controller
    {
        public event EventHandler<string> ChangeImage;
        private Model model = new Model();
        private DocumentReader bmp = new ComDocument();

        public void LoadImage(Image img)
        {
            bmp.RunCommand(new LoadData(img, ImgMask.GetZeroData(img)));
        }

        public void LoadMask(Image img, ImgMask mask = null)
        {
            bmp.RunCommand(new DrawRectangles(img, model.Mask));
        }
        
        public void Undo()
        {
            bmp.Undo();
            if (bmp.GetData() == null || bmp.GetData().mask == null) return;
            model.Mask = bmp.GetData().mask;
        }

        public void Redo()
        {
            bmp.Redo();
            if (bmp.GetData() == null || bmp.GetData().mask == null) return;
            model.Mask = bmp.GetData().mask;
        }
        public void CreateMask(Image img)
        {
            model.Mask = new ImgMask(img);
        }

        public ImgMask GetMask()
        {
            return bmp.GetData().mask;
        }

        public Image GetImage()
        {
            if (bmp.GetData() == null)
            {
                return null;
            }
            return bmp.GetData().img;
        }
        
        public void AddRectangle(Point pc, int width, int height)
        {
            model.Mask.AddRectangle(pc, width, height);
        }
        
        private void OnChangeImage(string filename)
        {
            if (ChangeImage != null)
            {
                ChangeImage.Invoke(null, filename);
            }
        }
        public void OpenFile(string filename)
        {
            AddImage(filename);
        }

        private void AddImage(string filename)
        {
            OnChangeImage(filename);
        }

        public Image DeleteLines(Image img, int dwidth, int dheight, BackgroundWorker bgw)
        {
            if (!model.Mask.IsDataEmpty())
            {
                if (GetMask().GetDeletedHeight() >= GetMask().GetDeletedWidth())
                {
                    dwidth = img.Width - model.Mask.GetDeletedWidth();
                }
                else
                {
                    dheight = img.Height - model.Mask.GetDeletedHeight();
                }
            }

            var oldWidth = img.Width;
            var oldHeight = img.Height;
            var tmp = model.ResizeImage(img, dwidth, dheight, bgw);
            model.Mask = ImgMask.GetZeroData(tmp);
            tmp = model.ResizeImage((Bitmap)tmp.Clone(), oldWidth, oldHeight, bgw);

            return tmp;
        }
        
        public Image GetGrayImage(Image img)
        {
            return model.GetGrayImage(img);
        }
    }
}