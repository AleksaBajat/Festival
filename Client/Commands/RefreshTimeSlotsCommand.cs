using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Client.Services.Abstractions;
using Client.State.Logging;
using Client.ViewModels;
using log4net;

namespace Client.Commands
{
    public class RefreshTimeSlotsCommand:AsyncBaseCommand
    {
        private readonly ILog _log = LogHelper.GetLogger();
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
            _log.Info("Executed Refresh Time Slots Command");
            return _timeSlotService.GetAll(_collection,StageId);
        }
    }
}
