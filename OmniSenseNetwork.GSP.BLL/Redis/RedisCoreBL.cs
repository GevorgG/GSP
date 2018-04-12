using StackExchange.Redis;

namespace OmniSenseNetwork.GSP.BLL.Redis
{
    public class RedisCoreBL : IRedisCoreBL
    {
        protected static IDatabase _database;

        public RedisCoreBL(IDatabase database)
        {
            _database = database;
        }

        public string GetStringValue(string key)
        {
            return _database.StringGet(key);
        }

        public void SetStringValue(string key, string value)
        {
            _database.StringSet(key, value);
        }

        public void DeleteStringValue(string key)
        {
            _database.KeyDelete(key);
        }
    }
}
