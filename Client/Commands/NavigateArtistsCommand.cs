using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    public class NavigateArtistsCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly TimeSlotListingViewModel _timeSlotListingViewModel;
        public NavigateArtistsCommand(INavigationService navigationService,TimeSlotListingViewModel timeSlotListingViewModel)
        {
            _navigationService = navigationService;
            _timeSlotListingViewModel = timeSlotListingViewModel;
        }
        public override void Execute(object parameter)
        {
            _navigationService.NavigateToArtists(_timeSlotListingViewModel.Selected.TimeSlotId);
        }

        public override bool CanExecute(object parameter)
        {
            return _timeSlotListingViewModel.Selected != null && base.CanExecute(parameter);
        }
    }
}
