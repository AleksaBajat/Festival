using System.Threading.Tasks;
using Client.Models;
using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    public class AddTimeSlotCommand:AsyncBaseCommand
    {
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

            _navigationService.NavigateToTimeStamps(_addUpdateTimeSlotViewModel.ViewModel.StageId);
        }
    }
}
