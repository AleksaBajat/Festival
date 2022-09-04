using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [DataContract]
    public class StageDuplicateDto:StageDto
    {
        [DataMember]
        public Guid NewId { get; set; }
    }
}
