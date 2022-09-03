using System;
using System.Collections.Generic;

namespace Client.Models
{
    public class Stage
    {
        public int StageId { get; set; }
        public string Name { get; set; }
        public List<TimeSlot> TimeSlots { get; set; }
        public DateTime Version { get; set; }

        public Stage()
        {
            TimeSlots = new List<TimeSlot>();
        }
    }
}