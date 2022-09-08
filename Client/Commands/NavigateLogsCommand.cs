using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services.Abstractions;

namespace Client.Commands
{
    public class NavigateLogsCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;

        public NavigateLogsCommand(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object parameter)
        {
            _navigationService.NavigateToLogs();
        }
    }
}
