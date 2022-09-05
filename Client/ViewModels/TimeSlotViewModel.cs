using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Client.Models;

namespace Client.ViewModels
{
    public class TimeSlotViewModel:BaseViewModel
    {
        private readonly TimeSlot _timeSlot;

        public string Description => _timeSlot.Description;

        public DateTime From => _timeSlot.From;

        public DateTime To => _timeSlot.To;

        public Guid StageId => _timeSlot.StageId;

        public Guid TimeSlotId => _timeSlot.TimeSlotId;

        public DateTime Version => _timeSlot.Version;

        public TimeSlotViewModel(TimeSlot timeSlot)
        {
            _timeSlot = timeSlot;
        }
    }
}
