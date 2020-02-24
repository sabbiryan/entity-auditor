using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataSource
{
    public class ContextProvider
    {
        public static DbContextOptions<AuditorDbContext> ContextOptions;
        public static string ConnectionString;

        public static void SetContextOptions(string connectionStringName = "Default")
        {
            var configuration = ConfigurationProvider.GetConfiguration();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<AuditorDbContext>();
            var connectionString = configuration.GetConnectionString(connectionStringName);
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            ContextOptions = dbContextOptionsBuilder.Options;
            ConnectionString = connectionString;
        }


        public static void SwitchContextOptions(string connectionString)
        {
            var dbContextOptionsBuilder = new DbContextOptionsBuilder<AuditorDbContext>();
            dbContextOptionsBuilder.UseSqlServer(connectionString);

            ContextOptions = dbContextOptionsBuilder.Options;
            ConnectionString = connectionString;
        }
    }
}