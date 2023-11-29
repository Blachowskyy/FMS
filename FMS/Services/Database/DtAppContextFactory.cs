using Microsoft.EntityFrameworkCore;

namespace FMS.Services.Database
{
    public class DtAppContextFactory
    {
        public static AppDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlite("Data Source=Models/ApplicationData/AppData.db");
            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
