using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Resolver;
using Client.ViewModels;

namespace Client.Commands
{
    internal class NavigateAddStageCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;

        public NavigateAddStageCommand()
        {
            _navigationService = DependencyResolver.Resolve<INavigationService>();
        }

        public override void Execute(object parameter)
        {
            _navigationService.NavigateToAddStage();
        }
    }
}
