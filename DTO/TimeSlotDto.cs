using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TimeSlotDto
    {
        public int TimeSlotId { get; set; }

        public string Description { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public DateTime Version { get; set; } = DateTime.Now;
    }
}
