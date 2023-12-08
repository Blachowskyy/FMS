using FMS.ViewModels.LiveForkliftsPages;
using FMS.ViewModels.Main;
using FMS.Views;
using FMS.Views.LiveForklifsPages;
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
                services.AddSingleton<UsersPage>(s =>
                new UsersPage(s.GetRequiredService<UsersPageViewModel>()));
                services.AddSingleton<LiveForklfitsPage>(s =>
                new LiveForklfitsPage(s.GetRequiredService<LiveForkliftsPageViewModel>()));
                services.AddSingleton<ActualParametersPage>(s =>
                new ActualParametersPage(s.GetRequiredService<ActualParametersPageViewModel>()));
                services.AddSingleton<AutoModeStartupPage>(s =>
                new AutoModeStartupPage(s.GetRequiredService<AutoModeStartupPageViewModel>()));
                services.AddSingleton<ErrorsPage>(s =>
                new ErrorsPage(s.GetRequiredService<ErrorsPageViewModel>()));
                services.AddSingleton<ForkliftConfigurationPage>(s =>
                new ForkliftConfigurationPage(s.GetRequiredService<ForkliftConfigurationPageViewModel>()));
                services.AddSingleton<SickPage>(s =>
                new SickPage(s.GetRequiredService<SickPageViewModel>()));
                services.AddSingleton<SafetyDataPage>(s =>
                new SafetyDataPage(s.GetRequiredService<SafetyDataPageViewModel>()));
                services.AddSingleton<WorkstatesPage>(s =>
                new WorkstatesPage(s.GetRequiredService<WorkstatesPageViewModel>()));
                /*services.AddSingleton<LocationsManagementPage>(s =>
                new LocationsManagementPage(s.GetRequiredService<LocationsManagementPageViewModel>()));*/
            });
            return hostBuilder;
        }
    }
}
