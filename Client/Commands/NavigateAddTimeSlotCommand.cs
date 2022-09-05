using System;
using Client.Models;
using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    internal class NavigateAddTimeSlotCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;
        public Guid StageId { get; set; }
        public NavigateAddTimeSlotCommand(INavigationService navigationService,Guid stageId)
        {
            _navigationService = navigationService;
            StageId = stageId;
        }

        public override void Execute(object parameter)
        {
            _navigationService.NavigateToAddTimeStamps(new TimeSlotViewModel(new TimeSlot
            {
                StageId = StageId,
                From = DateTime.Now,
                To = DateTime.Now
            }));
        }
    }
}
