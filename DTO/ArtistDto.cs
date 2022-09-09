using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public class ArtistDto
    {
        [DataMember]
        public Guid ArtistId { get; set; }

        [DataMember]
        public Guid TimeSlotId { get; set; }

        [DataMember]
        public string Genre { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public DateTime Version { get; set; } = DateTime.Now;
    }
}
