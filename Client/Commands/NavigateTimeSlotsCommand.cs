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
    public class NavigateTimeSlotsCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly StageListingViewModel _stageListingViewModel;

        public NavigateTimeSlotsCommand(StageListingViewModel viewModel)
        {
            _navigationService = DependencyResolver.Resolve<INavigationService>();
            _stageListingViewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationService.NavigateToTimeStamps(_stageListingViewModel.Selected.StageId);
        }

        public override bool CanExecute(object parameter)
        {
            return _stageListingViewModel.Selected != null;
        }
    }
}
