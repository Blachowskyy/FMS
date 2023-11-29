using FMS.ViewModels.Main;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FMS.Services.HostBuilders
{
    public static class AddViewModelsHBE
    {
        public static IHostBuilder AddViewModels(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddTransient<MainWindowViewModel>();
                services.AddTransient<LoginPageViewModel>();
                services.AddTransient<ForkliftManagementPageViewModel>();
            });
            return hostBuilder;
        }
    }
}
