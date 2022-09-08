using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    internal class NavigateEditStageCommand:BaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;
        private readonly StageListingViewModel _stageListingViewModel;

        public NavigateEditStageCommand(INavigationService navigationService,StageListingViewModel viewModel)
        {
            _navigationService = navigationService;
            _stageListingViewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _log.Info("Navigate To Edit Stage View Command");
            _navigationService.NavigateToEditStage(_stageListingViewModel.Selected);
        }

        public override bool CanExecute(object parameter)
        {
            return _stageListingViewModel.Selected != null && base.CanExecute(parameter);
        }
    }
}
