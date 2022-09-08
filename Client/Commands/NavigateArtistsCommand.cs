using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    public class NavigateArtistsCommand:BaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;
        private readonly TimeSlotListingViewModel _timeSlotListingViewModel;
        public NavigateArtistsCommand(INavigationService navigationService,TimeSlotListingViewModel timeSlotListingViewModel)
        {
            _navigationService = navigationService;
            _timeSlotListingViewModel = timeSlotListingViewModel;
        }
        public override void Execute(object parameter)
        {
            _log.Info("Executed Navigate To Artists Command");
            _navigationService.NavigateToArtists(_timeSlotListingViewModel.Selected.TimeSlotId);
        }

        public override bool CanExecute(object parameter)
        {
            return _timeSlotListingViewModel.Selected != null && base.CanExecute(parameter);
        }
    }
}
