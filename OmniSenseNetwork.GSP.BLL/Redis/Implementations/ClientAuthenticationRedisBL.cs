using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using OmniSenseNetwork.GSP.Common;
using OmniSenseNetwork.GSP.Common.Configurations;
using OmniSenseNetwork.GSP.Common.DataContracts;
using OmniSenseNetwork.GSP.Common.Exceptions;
using StackExchange.Redis;
using static OmniSenseNetwork.GSP.Common.CommonUtils.Exceptions;

namespace OmniSenseNetwork.GSP.BLL.Redis
{
    public class ClientAuthenticationRedisBL : RedisCoreBL, IClientAuthenticationRedisBL
    {
        #region Members
        private readonly TimeSpan _sessionExpirationTime;
        #endregion

        #region Ctors
        public ClientAuthenticationRedisBL(ConnectionMultiplexer connection, RedisConfiguration configuration)
            : base(connection, configuration)
        {
            _sessionExpirationTime = TimeSpan.FromMinutes(Configuration.Timeout);
        }
        #endregion

        #region IClientAuthenticationRedisBL
        public async Task AddSession(string token, ClientSessionDto session, bool ignoreIfExists = false)
        {
            RedisValue value = await Database.StringGetAsync(token);
            if (!value.IsNull)
            {
                if (ignoreIfExists)
                    return;
                throw CreateException<BllException>(Constants.Errors.TokenAlreadyExists);
            }
            var data = JsonConvert.SerializeObject(session);

            await Database.StringSetAsync(token, data, _sessionExpirationTime);

            string tokenKey = session.Client.Login;
            await Database.SetAddAsync(tokenKey, token);
            await Database.KeyExpireAsync(tokenKey, _sessionExpirationTime);
        }

        public async Task<ClientSessionDto> GetSession(string token)
        {
            RedisValue value = await Database.StringGetAsync(token);
            if (value.IsNull)
                throw CreateException<BllException>(Constants.Errors.WrongSessionToken);

            await Database.KeyExpireAsync(token, _sessionExpirationTime);

            var session = JsonConvert.DeserializeObject<ClientSessionDto>(value);
            var keyToken = session.Client.Login;
            await Database.KeyExpireAsync(keyToken, _sessionExpirationTime);

            return session;
        }

        public async Task<List<string>> GetClientTokens(string clientLogin)
        {
            var tokenKey = clientLogin;
            RedisValue[] values = await Database.SetMembersAsync(tokenKey);
            if (!values.Any())
                return null;

            //Checking the tokens
            var tokens = new List<string>();
            foreach (var value in values)
            {
                var token = value.ToString();
                if (!Database.KeyExists(token))
                {
                    await Database.SetRemoveAsync(tokenKey, token);
                }
                tokens.Add(token);
            }

            await Database.KeyExpireAsync(clientLogin, _sessionExpirationTime);

            return tokens;
        }

        public async Task RefreshToken(string token)
        {
            RedisValue value = await Database.StringGetAsync(token);
            if (value.IsNull)
                throw CreateException<BllException>(Constants.Errors.WrongSessionToken);

            await Database.KeyExpireAsync(token, _sessionExpirationTime);

            var session = JsonConvert.DeserializeObject<ClientSessionDto>(value);
            var keyToken = session.Client.Login;
            await Database.KeyExpireAsync(keyToken, _sessionExpirationTime);
        }

        public async Task RemoveAllSessions(string clientLogin)
        {
            var tokenKey = clientLogin;
            RedisValue[] values = await Database.SetMembersAsync(tokenKey);
            if (!values.Any())
                return;
            
            foreach (var value in values)
            {
                await Database.SetRemoveAsync(tokenKey, value.ToString());
            }

            await Database.KeyDeleteAsync(tokenKey);
        }

        public async Task RemoveSession(string token)
        {
            RedisValue value = await Database.StringGetAsync(token);
            if (value.IsNull)
                return;
            
            await Database.KeyDeleteAsync(token);
            var session = JsonConvert.DeserializeObject<ClientSessionDto>(value);
            var tokenkey = session.Client.Login;
            await Database.SetRemoveAsync(tokenkey, token);
            await Database.KeyExpireAsync(tokenkey, _sessionExpirationTime);
        }
        #endregion
    }
}
