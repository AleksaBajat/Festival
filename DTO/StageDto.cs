using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public class StageDto
    {
        [DataMember]
        public int StageId { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]

        public DateTime Version { get; set; }
    }
}
