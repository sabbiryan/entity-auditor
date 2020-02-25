using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataSource
{
    public class DatabaseService
    {

        public static async Task Ensure()
        {
            ContextProvider.SetContextOptions();
            Console.WriteLine($"Connecting database to: {ContextProvider.ConnectionString}");

            using (var context = new AuditorDbContext(ContextProvider.ContextOptions))
            {
                Console.WriteLine($"Ensuring database...");

                try
                {
                    await context.Database.MigrateAsync();

                    await context.Database.EnsureCreatedAsync();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"Connection string is not valid. Please check the connection string at appsettings.json, then try again");
                    throw;
                }

                Console.WriteLine($"Database confirmed...");
            }
        }


        public static IEnumerable<IEntityType> GetEntityTypes()
        {
            IEnumerable<IEntityType> entityTypes;
            using (var context = new AuditorDbContext(ContextProvider.ContextOptions))
            {
                entityTypes = context.Model.GetEntityTypes();
            }

            return entityTypes;
        }

    }
}
