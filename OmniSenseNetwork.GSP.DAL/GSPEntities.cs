using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OmniSenseNetwork.GSP.DAL.Entities
{
    public partial class GSPEntities
    {
        private string _connectionString;

        public GSPEntities(string connectionString = null)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (string.IsNullOrEmpty(_connectionString))
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                var configuration = builder.Build();
                _connectionString = configuration.GetConnectionString("GSPDatabase");
            }
            optionsBuilder.UseMySql(_connectionString);
        }
    }
}