using System.Configuration;
using System.Data;
using System.Windows;
using FMS.Models.Main;
using FMS.Services.Common.Interfaces;
using FMS.Services.HostBuilders;
using FMS.ViewModels.Main;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace FMS
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        private readonly IDataService<Forklift>? _ForkliftDataService;
        private IEnumerable<Forklift>? _forkliftsList;
        public App()
        {
            Console.WriteLine("Console started...");
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            Log.Information("Logger started");
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            _host = CreateHostBuilder().Build();
        }
        public static IHostBuilder CreateHostBuilder(string[]? args = null)
        {
            return Host.CreateDefaultBuilder(args)
                .AddConfig()
                .AddContext()
                .AddServices()
                .AddViewModels()
                .AddViews();
        }
        protected override async void OnStartup(StartupEventArgs e)
        {
            await _host.StartAsync();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.DataContext = _host.Services.GetRequiredService<MainWindowViewModel>();
            if(!MainWindow.IsLoaded)
            {
                MainWindow.Show();
            }
            base.OnStartup(e);
        }
        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }

}
