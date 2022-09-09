using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public class TimeSlotDto
    {
        [DataMember]
        public Guid TimeSlotId { get; set; }

        [DataMember]
        public Guid StageId { get; set; }
        [DataMember]
        public string Description { get; set; }
        [DataMember]
        public DateTime From { get; set; }
        [DataMember]
        public DateTime To { get; set; }
        [DataMember]
        public DateTime Version {
            get
            {
                return DateTime.Now;
            } set; } 
    }
}
