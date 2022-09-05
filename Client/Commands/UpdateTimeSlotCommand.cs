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
    public class UpdateTimeSlotCommand:AsyncBaseCommand
    {
        private readonly INavigationService _navigationService;
        private readonly ITimeSlotService _timeSlotService;
        private readonly AddUpdateTimeSlotViewModel _addUpdateTimeSlotViewModel;
        public UpdateTimeSlotCommand(AddUpdateTimeSlotViewModel viewModel)
        {
            _navigationService = DependencyResolver.Resolve<INavigationService>();
            _timeSlotService = DependencyResolver.Resolve<ITimeSlotService>();
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
