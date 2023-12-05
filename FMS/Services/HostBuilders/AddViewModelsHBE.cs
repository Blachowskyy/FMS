using FMS.ViewModels.LiveForkliftsPages;
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
                services.AddTransient<UsersPageViewModel>();
                services.AddTransient<LiveForkliftsPageViewModel>();
                services.AddTransient<ActualParametersPageViewModel>();
                services.AddTransient<AutoModeStartupPageViewModel>();
                services.AddTransient<ErrorsPageViewModel>();
                services.AddTransient<SickPageViewModel>();
                services.AddTransient<SafetyDataPageViewModel>();
                services.AddTransient<ForkliftConfigurationPageViewModel>();
                services.AddTransient<SafetyDataPageViewModel>();
            });
            return hostBuilder;
        }
    }
}
