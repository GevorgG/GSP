using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using OmniSenseNetwork.GSP.Common.Exceptions;
using StackExchange.Redis;
using static OmniSenseNetwork.GSP.Common.CommonUtils.Exceptions;

namespace OmniSenseNetwork.GSP.BLL.Redis
{
    public static class RedisBLFactory
    {
        #region Members
        private static readonly Lazy<ConnectionMultiplexer> Connection;
        private static readonly string _redisConfigName = "redisConfig";
        #endregion

        #region Ctors
        static RedisBLFactory()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString(_redisConfigName);

            if (connectionString == null)
            {
                throw CreateException<BllException>($"Configuration section {_redisConfigName} was not found.");
            }

            var options = ConfigurationOptions.Parse(connectionString);

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
}
