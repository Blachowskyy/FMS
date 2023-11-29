using FMS.Services.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
namespace FMS.Services.HostBuilders
{
    public static class AddDbContextHBE
    {
        public static IHostBuilder AddContext(this IHostBuilder hostBuilder)
        {
            _ = hostBuilder.ConfigureServices((context, services) =>
            {
#pragma warning disable CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
                string connectionString = context.Configuration.GetConnectionString("sqlite");
#pragma warning restore CS8600 // Konwertowanie literału null lub możliwej wartości null na nienullowalny typ.
                void configuteDbContext(DbContextOptionsBuilder o) => o.UseSqlite(connectionString);
                services.AddDbContext<AppDbContext>(configuteDbContext);
                services.AddSingleton<AppDbContextFactory>(new AppDbContextFactory(configuteDbContext));
            });
            return hostBuilder;
        }
    }
}
