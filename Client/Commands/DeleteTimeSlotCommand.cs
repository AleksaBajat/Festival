using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    public class DeleteTimeSlotCommand:AsyncBaseCommand
    {
        private readonly ITimeSlotService _timeSlotService;
        private readonly INavigationService _navigationService;
        private readonly TimeSlotListingViewModel _timeSlotListingViewModel;

        public DeleteTimeSlotCommand(ITimeSlotService timeSlotService, INavigationService navigationService,TimeSlotListingViewModel timeSlotListingViewModel)
        {
            _navigationService = navigationService;
            _timeSlotService = timeSlotService;
            _timeSlotListingViewModel = timeSlotListingViewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _timeSlotService.Delete(_timeSlotListingViewModel.Selected);
            _navigationService.NavigateToTimeStamps(_timeSlotListingViewModel.Selected.StageId);
        }

        public override bool CanExecute(object parameter)
        {
            return _timeSlotListingViewModel.Selected != null && base.CanExecute(parameter);
        }
    }
}
