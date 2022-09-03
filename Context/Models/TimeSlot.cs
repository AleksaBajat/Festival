using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Context.Models {
	public class TimeSlot {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int TimeSlotId { get; set; }

        public int StageId { get; set; }

        public string Description { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public DateTime Version { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;

        public virtual List<Artist> Artists { get; set; }

        public TimeSlot(){

		}

		~TimeSlot(){

		}
	}
}