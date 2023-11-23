using FMS.Models.Main;

namespace FMS.Services.Common.Interfaces
{
    public interface IUserStore
    {
        User CurrentUser { get; set; }

        event Action? StateChanged;
    }
}