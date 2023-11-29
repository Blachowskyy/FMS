using FMS.Models.Main;

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
