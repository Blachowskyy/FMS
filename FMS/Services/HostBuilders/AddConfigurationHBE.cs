using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Services.HostBuilders
{
    public static class AddConfigurationHBE
    {
        public static IHostBuilder AddConfig(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureAppConfiguration(c =>
            {
                c.AddJsonFile("Models/AppSettings/appsettings.json");
                c.AddEnvironmentVariables();
            });
            return hostBuilder;
        }
    }
}
