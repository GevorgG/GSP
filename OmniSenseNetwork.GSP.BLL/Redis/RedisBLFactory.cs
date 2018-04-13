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
        #endregion

        #region Ctors
        static RedisBLFactory()
        {
            var redisConfigs = new RedisConfiguration();

            if(!IPAddress.TryParse(redisConfigs.Host, out IPAddress ipAddress))
            {
                throw CreateException<BllException>(Constants.Errors.ConfigurationError);
            }
            var options = new ConfigurationOptions
            {
                EndPoints = { new IPEndPoint(ipAddress, redisConfigs.Port) }
            };

            Connection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(options));
        }
        #endregion
		
        public static ConnectionMultiplexer GetConnection() => Connection.Value;

        public static void CloseConnection()
        {
            if (Connection.IsValueCreated)
                Connection.Value.Dispose();
        }

        public static IRedisCoreBL CreateRedisCoreBL()
        {
            return new RedisCoreBL(GetConnection().GetDatabase());
        }
        
    }

    public class Config
    {
        public string Host { get; set; }

        public int Post { get; set; }
    }
}
