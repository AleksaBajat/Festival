using System.Threading.Tasks;
using Client.Models;
using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    public class AddTimeSlotCommand:AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;
        private readonly ITimeSlotService _timeSlotService;
        private readonly AddUpdateTimeSlotViewModel _addUpdateTimeSlotViewModel;
        public AddTimeSlotCommand(INavigationService navigationService,ITimeSlotService timeSlotService,AddUpdateTimeSlotViewModel viewModel)
        {
            _navigationService = navigationService;
            _timeSlotService = timeSlotService;
            _addUpdateTimeSlotViewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _timeSlotService.Add(new TimeSlotViewModel(new TimeSlot
            {
                Description = _addUpdateTimeSlotViewModel.Description,
                From = _addUpdateTimeSlotViewModel.From,
                To = _addUpdateTimeSlotViewModel.To,
                StageId = _addUpdateTimeSlotViewModel.ViewModel.StageId
            }));

            _log.Info("Executed Add Time Slot Command");

            _navigationService.NavigateToTimeStamps(_addUpdateTimeSlotViewModel.ViewModel.StageId);
        }
    }
}
