using FMS.Models.Main;
using FMS.Services.Common.DataServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Services.Common.Interfaces
{
    public interface IForkliftConnection
    {
        Task<bool> Connect(Forklift fork);
        Task HandleDataExchange(Forklift fork);
        Task<bool> Disconnect(Forklift fork);
        Task<bool> Reconnect(Forklift fork, int retryIntervalMillisecond, int maxRetries);
    }
}
