using FMS.ViewModels.Main;
using FMS.Views.Main;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FMS.Services.HostBuilders
{
    public static class AddViewsHBE
    {
        public static IHostBuilder AddViews(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices(services =>
            {
                services.AddSingleton<MainWindow>(s =>
                new MainWindow(s.GetRequiredService<MainWindowViewModel>()));
                services.AddSingleton<LoginPage>(s =>
                new LoginPage(s.GetRequiredService<LoginPageViewModel>()));
                services.AddSingleton<ForkliftManagementPage>(s =>
                new ForkliftManagementPage(s.GetRequiredService<ForkliftManagementPageViewModel>()));
            });
            return hostBuilder;
        }
    }
}
