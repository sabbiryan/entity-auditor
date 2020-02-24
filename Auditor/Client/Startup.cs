using System;
using System.IO;
using DataSource;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ConfigurationProvider = DataSource.ConfigurationProvider;

namespace Client
{
    public class Startup
    {
        private static IConfigurationRoot _configuration;

        public static IConfigurationRoot ConfigureServices(IServiceCollection services)
        {

            // Build configuration
            _configuration = ConfigurationProvider.GetConfiguration();


            //Add dbContext
            services.AddDbContext<AuditorDbContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("Default"),
                    x => x.MigrationsAssembly(nameof(DataSource))));

            // Add access to generic IConfigurationRoot
            services.AddSingleton<IConfigurationRoot>(_configuration);


            return _configuration;
        }
    }
}