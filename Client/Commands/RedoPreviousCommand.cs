using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.State.History;

namespace Client.Commands
{
    internal class RedoPreviousCommand:AsyncBaseCommand
    {
        public override Task ExecuteAsync(object parameter)
        {
            History.Redo();

            return Task.CompletedTask;
        }

        public override bool CanExecute(object parameter)
        {
            return History.ReadyToRedo.Count != 0 && base.CanExecute(parameter);
        }
    }
}
