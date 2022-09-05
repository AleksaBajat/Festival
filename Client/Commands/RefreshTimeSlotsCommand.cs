using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.ViewModels;

namespace Client.Commands
{
    public class RefreshTimeSlotsCommand:AsyncBaseCommand
    {
        private ObservableCollection<TimeSlotViewModel> _collection;
        private ITimeSlotService _timeSlotService;
        public Guid StageId { get; set; }

        public RefreshTimeSlotsCommand(ITimeSlotService timeSlotService,ObservableCollection<TimeSlotViewModel> collection, Guid stageId)
        {
            _collection = collection;
            _timeSlotService = timeSlotService;
            StageId = stageId;
        }

        public override Task ExecuteAsync(object parameter)
        {
            return _timeSlotService.GetAll(_collection,StageId);
        }
    }
}
