﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.State.History;

namespace Client.Commands
{
    internal class UndoPreviousCommand:AsyncBaseCommand
    {
        public override Task ExecuteAsync(object parameter)
        {
            History.Undo();

            return Task.CompletedTask;
        }

        public override bool CanExecute(object parameter)
        {
            return History.ReadyToUndo.Count != 0 && base.CanExecute(parameter);
        }
    }
}
