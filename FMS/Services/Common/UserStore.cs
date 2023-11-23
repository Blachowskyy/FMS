using FMS.Models.Main;
using FMS.Services.Common.Interfaces;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
