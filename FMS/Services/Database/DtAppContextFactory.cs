using Microsoft.EntityFrameworkCore;

namespace FMS.Services.Database
{
    public class DtAppContextFactory
    {
        public static AppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            
            optionsBuilder.UseSqlite("Dataset Source=Models/ApplicationData/AppDatabase.db");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
