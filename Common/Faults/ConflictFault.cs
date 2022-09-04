using System.Runtime.Serialization;

namespace Common.Faults
{
    [DataContract]
    public class ConflictFault
    {
        private string _message;

        [DataMember]
        public string Message { get; set; }

        public ConflictFault(string message)
        {
            _message = message;
        }
    }
}
