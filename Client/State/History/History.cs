using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Client.Commands;

namespace Client.State.History
{
    public static class History
    {
        public static List<UndoBaseCommand> ReadyToUndo = new();
        public static List<UndoBaseCommand> ReadyToRedo = new();


        public static void AddToUndo(UndoBaseCommand command)
        {
            ReadyToRedo.Clear();

            ReadyToUndo.Add(command);
        }

        public static void Undo()
        {
            if (ReadyToUndo.Count != 0)
            {
                var command = ReadyToUndo.Last();

                ReadyToUndo.Remove(command);

                command.Execute(0);

                ReadyToRedo.Add(command);
            }
        }

        public static void Redo()
        {
            if (ReadyToRedo.Count != 0)
            {
                var command = ReadyToRedo.Last();

                ReadyToRedo.Remove(command);

                command.Execute(0);

                ReadyToUndo.Add(command);
            }    
        }
    }
}
