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
    internal class NavigateAddTimeSlotCommand:BaseCommand
    {
        private readonly INavigationService _navigationService;
        public Guid StageId { get; set; }
        public NavigateAddTimeSlotCommand(Guid stageId)
        {
            _navigationService = DependencyResolver.Resolve<INavigationService>();
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
