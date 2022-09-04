using System;
using System.Threading.Tasks;

namespace Client.Commands
{
    public abstract class UndoBaseCommand:AsyncBaseCommand
    {
        public abstract override Task ExecuteAsync(object parameter);

        public abstract Task Undo(object parameter);

        public Guid StageId { get; set; }
    }
}