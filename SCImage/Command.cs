using System.Drawing;

namespace SCImage
{
    public interface ICommand
    {
        void Run(ComDocument doc);
        void Undo(ComDocument doc);
        void Save(ComDocument doc);
    }
    
    class DrawRectangles: ICommand
    {
        DocumentData oldData;
        private DocumentData loadedData;

        public DrawRectangles(Image img, ImgMask mask)
        {
            loadedData = new DocumentData(img, mask);
        }

        #region ICommand Members

        public void Run(ComDocument doc)
        {
            DocumentData data = null;

            if (loadedData != null)
            {
                data = loadedData.Clone();
            }

            doc.SetData(data);
        }

        public void Undo (ComDocument doc)
        {
            doc.SetData(oldData);
        }

        public void Save (ComDocument doc)
        {
            oldData = doc.GetData();
        }

        #endregion
    }
    
    class LoadData: ICommand
    {
        DocumentData oldData;
        private DocumentData loadedData;

        public LoadData(Image img, ImgMask mask)
        {
            loadedData = new DocumentData((Bitmap)img.Clone(), mask);
        }

        #region ICommand Members

        public void Save(ComDocument doc)
        {
            oldData = doc.GetData();
        }

        public void Run (ComDocument doc)
        {
            doc.SetData(loadedData);
        }

        public void Undo (ComDocument doc)
        {
            doc.SetData(oldData);
        }

        #endregion
    }
    
}