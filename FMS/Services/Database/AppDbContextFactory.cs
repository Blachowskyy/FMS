using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Services.Database
{
    public class AppDbContextFactory(Action<DbContextOptionsBuilder> configure)
    {
        private readonly Action<DbContextOptionsBuilder> _configure = configure;

        public AppDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<AppDbContext> options = new();
            options.UseSqlite("Data Source=Models/ApplicationData/AppData.db");
            _configure(options);
            return new AppDbContext(options.Options);
        }
    }
}
