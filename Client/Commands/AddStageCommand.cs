﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client.Commands
{
    internal class AddStageCommand:UndoBaseCommand
    {
        public override Task ExecuteAsync(object parameter)
        {
            throw new NotImplementedException();
        }

        public override Task Undo(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
