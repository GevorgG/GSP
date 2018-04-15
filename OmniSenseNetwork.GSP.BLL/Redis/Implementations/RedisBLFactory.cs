using System;
using System.Net;
using OmniSenseNetwork.GSP.Common;
using OmniSenseNetwork.GSP.Common.Configurations;
using OmniSenseNetwork.GSP.Common.Exceptions;
using StackExchange.Redis;
using static OmniSenseNetwork.GSP.Common.CommonUtils.Exceptions;

namespace OmniSenseNetwork.GSP.BLL.Redis
{
    public static class RedisBLFactory
    {
        #region Members
        private static readonly Lazy<ConnectionMultiplexer> Connection;
        private static readonly RedisConfiguration configuration;
        #endregion

        #region Private Methods
        private static ConnectionMultiplexer GetConnection() => Connection.Value;
        #endregion

        #region Ctors
        static RedisBLFactory()
        {
            configuration = new RedisConfiguration();

            if (!IPAddress.TryParse(configuration.Host, out IPAddress ipAddress))
            {
                throw CreateException<BllException>(Constants.Errors.ConfigurationError);
            }
            var options = new ConfigurationOptions
            {
                EndPoints = { new IPEndPoint(ipAddress, configuration.Port) }
            };

            Connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(options));
        }
        #endregion

        public static void CloseConnection()
        {
            if (Connection.IsValueCreated)
                Connection.Value.Dispose();
        }

        public static IRedisCoreBL CreateRedisCoreBL()
        {
            return new RedisCoreBL(GetConnection(), configuration);
        }

        public static IClientAuthenticationRedisBL CreateClientAuthenticationRedisBL()
        {
            return new ClientAuthenticationRedisBL(GetConnection(), configuration);
        }
    }
}
