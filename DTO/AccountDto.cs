using System.Runtime.Serialization;
using static Common.Enums.CommonEnumerations;

namespace DTO
{
    [DataContract]
    public class AccountDto
    {
        [DataMember]
        public string Username;
        
        [DataMember]
        public UserRole Role;
    }
}