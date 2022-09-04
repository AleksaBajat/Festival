using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Context.Models
{
    public class Stage
    {
        [Key]
        public Guid StageId { get; set; }

        public string Name { get; set; }

        public DateTime Version { get; set; }

        public virtual List<TimeSlot> TimeSlots { get; set; }

        public bool IsDeleted { get; set; } = false;

        public Stage()
        {
        }

        ~Stage()
        {
        }
    }
} 