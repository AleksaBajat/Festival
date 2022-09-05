using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    public class NavigateTimeSlotsCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly StageListingViewModel _stageListingViewModel;

        public NavigateTimeSlotsCommand(INavigationService navigationService,StageListingViewModel viewModel)
        {
            _navigationService = navigationService;
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
