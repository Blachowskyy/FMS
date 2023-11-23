using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
