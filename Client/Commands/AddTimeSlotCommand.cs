using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;
using Client.Services.Abstractions;
using Client.State.Resolver;
using Client.ViewModels;

namespace Client.Commands
{
    public class AddTimeSlotCommand:AsyncBaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly ITimeSlotService _timeSlotService;
        private readonly AddUpdateTimeSlotViewModel _addUpdateTimeSlotViewModel;
        public AddTimeSlotCommand(AddUpdateTimeSlotViewModel viewModel)
        {
            _navigationService = DependencyResolver.Resolve<INavigationService>();
            _timeSlotService = DependencyResolver.Resolve<ITimeSlotService>();
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
