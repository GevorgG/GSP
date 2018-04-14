using System;

namespace OmniSenseNetwork.GSP.Common.DataContracts
{
    public class ClientSessionDto
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTimeOffset StartTime { get; set; }
        public string LoginIP { get; set; }
        public string Token { get; set; }

        public ClientDto Client { get; set; }
    }
}
