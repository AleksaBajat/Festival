using System;
using System.Collections.Generic;

namespace Client.Models
{
    public class TimeSlot
    {
        public string Description { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
        public List<Artist> Artists { get; set; }

        public TimeSlot()
        {
            Artists = new List<Artist>();
        }
    }
}