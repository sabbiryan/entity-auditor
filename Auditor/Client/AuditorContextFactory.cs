using DataSource;
using Microsoft.EntityFrameworkCore.Design;

namespace Client
{
    public class AuditorContextFactory : IDesignTimeDbContextFactory<AuditorDbContext>
    {
        public AuditorDbContext CreateDbContext(string[] args)
        {
            return new AuditorDbContext(ContextProvider.GetContextOptions());
        }
    }
}