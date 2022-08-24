using System.Collections.Generic;

namespace Client.Models
{
    public class Stage
    {
        public string Name { get; set; }

        public List<TimeSlot> TimeSlots { get; set; }

        public Stage()
        {
            TimeSlots = new List<TimeSlot>();
        }
    }
}