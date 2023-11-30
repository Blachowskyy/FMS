using FMS.Models.Main;
using FMS.Services.Common;
using FMS.Services.Common.DataServices;
using FMS.Services.Common.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Wpf.Ui.Mvvm.Contracts;
using Wpf.Ui.Mvvm.Services;

namespace FMS.Services.HostBuilders
{
    public static class AddServicesHBE
    {
        public static IHostBuilder AddServices(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<User>();
                services.AddScoped<Forklift>();
                services.AddSingleton<JobStepType>();
                services.AddSingleton<Location>();
                services.AddSingleton<JobStep>();
                services.AddSingleton<Job>();
                services.AddScoped<UserDataService>();
                services.AddScoped<ForklfitDataService>();
                services.AddSingleton<ForkliftConnection>();
                services.AddSingleton<List<Forklift>>(provider => new List<Forklift>());
                services.AddSingleton<List<Location>>(provider => new List<Location>());
                services.AddSingleton<ISnackbarService, SnackbarService>();
                services.AddTransient<IDataService<JobStepType>, JobStepTypeDataService>();
                services.AddTransient<IDataService<JobStep>, JobStepDataService>();
                services.AddTransient<IDataService<Job>, JobDataService>();
                services.AddTransient<IDataService<User>, UserDataService>();
                services.AddTransient<IDataService<Location>, LocationDataService>();
                services.AddTransient<IDataService<Forklift>, ForklfitDataService>();
                services.AddSingleton<IUserStore, UserStore>();
                services.AddTransient<IForkliftConnection, ForkliftConnection>(provider => new ForkliftConnection());
                services.AddSingleton<UserStore>();
            });
            return hostBuilder;
        }
    }
}
