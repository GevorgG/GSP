using System.Threading.Tasks;
using OmniSenseNetwork.GSP.Common.Configurations;
using StackExchange.Redis;

namespace OmniSenseNetwork.GSP.BLL.Redis
{
    public class RedisCoreBL : IRedisCoreBL
    {
        #region Members
        private readonly RedisConfiguration _configuration;
        private readonly ConnectionMultiplexer _redisConnection;
        private readonly IDatabase _database;
        private readonly ISubscriber _subscriber;

        private static class SubscriptionType
        {
            public const string Keyspace = "keyspace";
            public const string Keyevent = "keyevent";
        }
        #endregion

        #region Properties
        protected RedisConfiguration Configuration => _configuration;
        protected IDatabase Database => _database;
        #endregion

        #region Ctors
        public RedisCoreBL(ConnectionMultiplexer connection, RedisConfiguration configuration)
        {
            _redisConnection = connection;
            _configuration = configuration;
            _database = _redisConnection.GetDatabase(_configuration.DatabaseId);
            _subscriber = _redisConnection.GetSubscriber();
        }
        #endregion

        #region IRedisCoreBL
        public void SubscribeToKeySpaceNotifications(string key, IRedisCallbackBL bl)
        {
            Subscribe(SubscriptionType.Keyevent, key, bl);
        }

        public void SubscribeToKeyEventNotifications(RedisEventType eventType, IRedisCallbackBL bl)
        {
            Subscribe(SubscriptionType.Keyspace, eventType.ToString(), bl);
        }
        #endregion

        #region private methods
        private void Subscribe(string subscriptionType, string channelParam, IRedisCallbackBL bl)
        {
            _subscriber.Subscribe($"__{subscriptionType}@{Configuration.DatabaseId}__:{channelParam}", (channel, value) =>
            {
                Task.Run(() => bl.HandleEvent(channelParam, value))
                    .ContinueWith(task =>
                    {
                        if (task.IsFaulted)
                        {
                            //TODO: write a log for error
                        }
                    })
                    .ConfigureAwait(false);
            });
        }
        #endregion
    }
}
