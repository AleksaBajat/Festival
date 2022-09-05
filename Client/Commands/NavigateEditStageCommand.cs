using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    internal class NavigateEditStageCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly StageListingViewModel _stageListingViewModel;

        public NavigateEditStageCommand(INavigationService navigationService,StageListingViewModel viewModel)
        {
            _navigationService = navigationService;
            _stageListingViewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _navigationService.NavigateToEditStage(_stageListingViewModel.Selected);
        }

        public override bool CanExecute(object parameter)
        {
            return _stageListingViewModel.Selected != null && base.CanExecute(parameter);
        }
    }
}
