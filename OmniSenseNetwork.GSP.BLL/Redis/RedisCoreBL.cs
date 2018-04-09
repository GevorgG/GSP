using StackExchange.Redis;

namespace OmniSenseNetwork.GSP.BLL.Redis
{
    public class RedisCoreBL
    {
        protected static IDatabase _database;

        public RedisCoreBL()
        {
            var connection = RedisConnectionFactory.GetConnection();

            _database = connection.GetDatabase();
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
