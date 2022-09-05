using System;

namespace Client.Models
{
    public class Artist
    {
        public Guid ArtistId { get; set; }

        public Guid TimeSlotId { get; set; }
        public string Genre { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public Artist(){

        }
    }
}