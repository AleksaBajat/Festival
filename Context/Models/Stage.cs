using System.Collections.Generic;

namespace Context.Models
{
    public class Stage
    {
        public string Name { get; set; }

        public List<TimeSlot> TimeSlots { get; set; }

        public Stage()
        {
        }

        ~Stage()
        {
        }
    }
} 