using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using OmniSenseNetwork.GSP.Common.DataContracts;

namespace OmniSenseNetwork.GSP.BLL.Redis
{
    public interface IClientAuthenticationRedisBL
    {
        Task AddSession(string token, ClientSessionDto session, bool ignoreIfExists = false);

        Task<ClientSessionDto> GetSession(string token);

        Task<List<string>> GetClientTokens(string clientLogin);

        Task RefreshToken(string token);

        Task RemoveSession(string token);

        Task RemoveAllSessions(string clientLogin);
    }
}
