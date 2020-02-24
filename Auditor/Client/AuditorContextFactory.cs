using DataSource;
using Microsoft.EntityFrameworkCore.Design;

namespace Client
{
    public class AuditorContextFactory : IDesignTimeDbContextFactory<AuditorDbContext>
    {
        public AuditorDbContext CreateDbContext(string[] args)
        {
            ContextProvider.SetContextOptions();
            return new AuditorDbContext(ContextProvider.ContextOptions);
        }
    }
}