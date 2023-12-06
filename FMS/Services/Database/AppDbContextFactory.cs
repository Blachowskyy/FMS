using Microsoft.EntityFrameworkCore;

namespace FMS.Services.Database
{
    public class AppDbContextFactory(Action<DbContextOptionsBuilder> configure)
    {
        private readonly Action<DbContextOptionsBuilder> _configure = configure;

        public AppDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<AppDbContext> options = new();
            options.UseSqlite("Dataset Source=Models/ApplicationData/AppData.db");
            
            _configure(options);
            return new AppDbContext(options.Options);
        }
    }
}
