using System.Collections.Generic;
using System.Drawing;

namespace SCImage
{
    public class DocumentData
    {
        public Image img;
        public ImgMask mask;

        public DocumentData(Image img)
        {
            this.img = (Image)img.Clone();
            mask = ImgMask.GetZeroData(img);
        }
        
        public DocumentData(Image img, ImgMask mask)
        {
            this.img = (Image)img.Clone();
            this.mask = mask.Clone();
        }

        public DocumentData Clone()
        {
            var res = new DocumentData((Image)img.Clone());
            res.mask = this.mask.Clone();
            return res;
        }
    }
    
    /// <summary>
    /// Класс для хранения данных без права их изменения
    /// </summary>
    public abstract class DocumentReader
    {
        protected DocumentData data;

        protected UndoRedoManager manager;

        public DocumentData GetData ()
        {
            if (data != null)
            {
                return data.Clone();
            }

            return null;
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="command"></param>
        public void RunCommand (ICommand command)
        {
            manager.RunCommand(command);
        }

        public void Undo ()
        {
            manager.Undo();
        }

        public void Redo ()
        {
            manager.Redo();
        }

        public delegate void DataUpdatedDelegate (DocumentReader sender);

        /// <summary>
        /// Событие, которое срабатывает, когда изменяются данные
        /// </summary>
        public event DataUpdatedDelegate DataUpdated;

        protected void OnDataUpdated()
        {
            if (DataUpdated != null)
            {
                DataUpdated (this);
            }
        }
    }
    
    
    /// <summary>
    /// Класс для хранения данных и их изменения через команды
    /// </summary>
    public class ComDocument : DocumentReader
    {


            public ComDocument ()
            {
                manager = new UndoRedoManager(this);
            }

            public void SetData(DocumentData newdata)
            {
                if (newdata != null)
                {
                    data = newdata.Clone();
                }
                else
                {
                    data = null;
                }

                OnDataUpdated();
            }
        }
}