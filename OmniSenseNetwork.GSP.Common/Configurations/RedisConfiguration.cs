using System.IO;
using Microsoft.Extensions.Configuration;

namespace OmniSenseNetwork.GSP.Common.Configurations
{
    public class RedisConfiguration
    {
        public RedisConfiguration()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            Host = configuration[$"Configurations:redisConfig:host"] ?? string.Empty;
            var port = configuration[$"Configurations:redisConfig:port"] ?? string.Empty;
            if (int.TryParse(port, out int tmpPort))
            {
                Port = tmpPort;
            }
            var databaseId = configuration[$"Configurations:redisConfig:databaseId"] ?? string.Empty;
            if (int.TryParse(databaseId, out int tmpDatabaseId))
            {
                DatabaseId = tmpDatabaseId;
            }
            var timeout = configuration[$"Configurations:redisConfig:timeout"] ?? string.Empty;
            if (int.TryParse(timeout, out int tmpTimeout))
            {
                Timeout = tmpTimeout;
            }
            Password = configuration[$"Configurations:redisConfig:password"] ?? string.Empty;
        }

        public string Host { get; set; }

        public int Port { get; set; }

        public int DatabaseId { get; set; }

        public int Timeout { get; set; }

        public string Password { get; set; }
    }
}
