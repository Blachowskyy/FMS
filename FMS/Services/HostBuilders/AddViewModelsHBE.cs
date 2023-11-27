﻿using FMS.ViewModels.Main;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
