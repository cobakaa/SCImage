using System.Collections.Generic;

namespace SCImage
{
    public class UndoRedoManager
    {
        /// <summary>
        /// Список выполненных команд для отмены
        /// </summary>
        List<ICommand> undoList = new List<ICommand> ();

        public bool IsEmptyUndoList
        {
            get
            {
                return undoList.Count == 0;
            }
        }

        /// <summary>
        /// Список отмененных команд для возврата
        /// </summary>
        List<ICommand> redoList = new List<ICommand> ();

        public bool IsEmptyRedoList
        {
            get
            {
                return redoList.Count == 0;
            }
        }

        ComDocument doc;

        public UndoRedoManager (ComDocument doc)
        {
            this.doc = doc;
        }

        public void RunCommand (ICommand command)
        {
            undoList.Add(command);
            redoList.Clear();

            command.Save(doc);
            command.Run(doc);
        }

        public void Undo ()
        {
            if (IsEmptyUndoList) return;
            ICommand command = undoList[undoList.Count - 1];

            redoList.Add(command);
            undoList.RemoveAt(undoList.Count - 1);

            command.Undo(doc);

        }

        public void Redo ()
        {
            if (IsEmptyRedoList) return;
            int index = redoList.Count - 1;

            ICommand command = redoList[index];

            undoList.Add (command);
            redoList.RemoveAt(index);

            command.Save(doc);
            command.Run(doc);

        }
    }
}