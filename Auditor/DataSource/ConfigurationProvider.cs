using System;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace DataSource
{
    public class ConfigurationProvider
    {
        private static IConfigurationRoot _configuration;

        public static IConfigurationRoot GetConfiguration()
        {

            // Build configuration
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();


            return _configuration;
        }
    }
}