using System.Threading.Tasks;
using Client.Models;
using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    public class UpdateTimeSlotCommand:AsyncBaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly ITimeSlotService _timeSlotService;
        private readonly AddUpdateTimeSlotViewModel _addUpdateTimeSlotViewModel;
        public UpdateTimeSlotCommand(INavigationService navigationService,ITimeSlotService timeSlotService,AddUpdateTimeSlotViewModel viewModel)
        {
            _navigationService = navigationService;
            _timeSlotService = timeSlotService;
            _addUpdateTimeSlotViewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            await _timeSlotService.Update(new TimeSlotViewModel(new TimeSlot
            {
                Description = _addUpdateTimeSlotViewModel.Description,
                From = _addUpdateTimeSlotViewModel.From,
                To = _addUpdateTimeSlotViewModel.To,
                TimeSlotId = _addUpdateTimeSlotViewModel.ViewModel.TimeSlotId,
                StageId = _addUpdateTimeSlotViewModel.ViewModel.StageId,
                Version = _addUpdateTimeSlotViewModel.ViewModel.Version
            }));

            _navigationService.NavigateToTimeStamps(_addUpdateTimeSlotViewModel.ViewModel.StageId);
        }
    }
}
