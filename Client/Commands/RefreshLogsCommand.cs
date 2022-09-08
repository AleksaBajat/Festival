using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.State.Logging;

namespace Client.Commands
{
    internal class RefreshLogsCommand:AsyncBaseCommand
    {
        private readonly ObservableCollection<string> _collection;
        public RefreshLogsCommand(ObservableCollection<string> collection)
        {
            _collection = collection;
        }
        public override Task ExecuteAsync(object parameter)
        {
            LogHelper.GetLogs(_collection);
            return Task.CompletedTask;
        }
    }
}
