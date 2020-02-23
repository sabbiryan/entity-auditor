using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataSource
{
    public class ContextProvider
    {
        public static DbContextOptions<AuditorDbContext> GetContextOptions(string connectionStringName = "Default")
        {
            var configuration = ConfigurationProvider.GetConfiguration();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<AuditorDbContext>();
            var connectionString = configuration.GetConnectionString(connectionStringName);
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            return dbContextOptionsBuilder.Options;
        }
    }
}