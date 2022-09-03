using Client.Services.Abstractions;
using Client.State.Resolver;
using Client.ViewModels;

namespace Client.Commands
{
    internal class NavigateEditStageCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly StageListingViewModel _stageListingViewModel;

        public NavigateEditStageCommand(StageListingViewModel viewModel)
        {
            _navigationService = DependencyResolver.Resolve<INavigationService>();
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
