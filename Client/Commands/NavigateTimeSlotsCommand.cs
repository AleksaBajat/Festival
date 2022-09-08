using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    public class NavigateTimeSlotsCommand:BaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;
        private readonly StageListingViewModel _stageListingViewModel;

        public NavigateTimeSlotsCommand(INavigationService navigationService,StageListingViewModel viewModel)
        {
            _navigationService = navigationService;
            _stageListingViewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _log.Info("Executed Navigate To Time Slots View Command");
            _navigationService.NavigateToTimeStamps(_stageListingViewModel.Selected.StageId);
        }

        public override bool CanExecute(object parameter)
        {
            return _stageListingViewModel.Selected != null;
        }
    }
}
