using FMS.Models.Main;
using FMS.Services.Common.Interfaces;

namespace FMS.Services.Common
{
    public class UserStore : IUserStore
    {
        private User? _currentUser;
        public User CurrentUser
        {
            get
            {
                _currentUser ??= new User();
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                StateChanged?.Invoke();
            }
        }
        public event Action? StateChanged;
    }
}
