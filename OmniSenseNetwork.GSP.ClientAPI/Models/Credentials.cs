using System.Runtime.Serialization;

namespace OmniSenseNetwork.GSP.ClientAPI.Models
{
    [DataContract]
    public class Credentials
    {
        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }
    }
}