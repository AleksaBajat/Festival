using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Resolver;
using Client.ViewModels;

namespace Client.Commands
{
    public class RefreshTimeSlotsCommand:AsyncBaseCommand
    {
        private ObservableCollection<TimeSlotViewModel> _collection;
        private ITimeSlotService _timeSlotService;
        public Guid StageId { get; set; }

        public RefreshTimeSlotsCommand(ObservableCollection<TimeSlotViewModel> collection, Guid stageId)
        {
            _collection = collection;
            _timeSlotService = DependencyResolver.Resolve<ITimeSlotService>();
            StageId = stageId;
        }

        public override Task ExecuteAsync(object parameter)
        {
            return _timeSlotService.GetAll(_collection,StageId);
        }
    }
}
