using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    public class DeleteTimeSlotCommand:AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
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
            _log.Info("Executed Delete Time Slot Command.");
            _navigationService.NavigateToTimeStamps(_timeSlotListingViewModel.Selected.StageId);
        }

        public override bool CanExecute(object parameter)
        {
            return _timeSlotListingViewModel.Selected != null && base.CanExecute(parameter);
        }
    }
}
