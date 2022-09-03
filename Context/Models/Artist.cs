using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Context.Models {
	public class Artist {

		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ArtistId { get; set; }

		public int TimeSlotId { get; set; }

        public string Genre { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public bool IsDeleted { get; set; } = false;

		public DateTime Version { get; set; } = DateTime.Now;

        public Artist(){

		}

		~Artist(){

		}

	}
}	