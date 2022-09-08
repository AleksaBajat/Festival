using System;
using Client.Models;
using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    internal class NavigateAddTimeSlotCommand:BaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
        private readonly INavigationService _navigationService;
        public Guid StageId { get; set; }
        public NavigateAddTimeSlotCommand(INavigationService navigationService,Guid stageId)
        {
            _navigationService = navigationService;
            StageId = stageId;
        }

        public override void Execute(object parameter)
        {
            _log.Info("Executed Navigate Add Time Slot Command.");

            _navigationService.NavigateToAddTimeStamps(new TimeSlotViewModel(new TimeSlot
            {
                StageId = StageId,
                From = DateTime.Now,
                To = DateTime.Now
            }));
        }
    }
}
