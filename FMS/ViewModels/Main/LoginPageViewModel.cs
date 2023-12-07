using FMS.Models.Main;
using FMS.Services.Common;
using FMS.Services.Common.DataServices;
using FMS.ViewModels.Common;
using Serilog;
using System.Diagnostics.Tracing;
using System.Windows.Input;

namespace FMS.ViewModels.Main
{
    public class LoginPageViewModel : BaseViewModel
    {
        #region Variables
        private string? _username;
        public string Username
        {
            get
            {
                return _username ?? string.Empty;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private string? _password;
        public string Password
        {
            get
            {
                return _password ?? string.Empty;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private User? _loggingUser;
        public User LoggingUser
        {
            get
            {
                return _loggingUser ??= new();
            }
            set
            {
                _loggingUser = value;
                OnPropertyChanged(nameof(LoggingUser));
            }
        }
        private IEnumerable<User>? _avaibleUsers;
        public IEnumerable<User> AvaibleUsers
        {
            get
            {
                return _avaibleUsers ??= Enumerable.Empty<User>();
            }
            set
            {
                _avaibleUsers = value;
                OnPropertyChanged(nameof(AvaibleUsers));
            }
        }
        private bool _loginVisible;
        public bool LoginVisible
        {
            get
            {
                return _loginVisible;
            }
            set
            {
                _loginVisible = value;
                OnPropertyChanged(nameof(LoginVisible));
            }
        }
        private bool _logoutVisible;
        public bool LogoutVisible
        {
            get
            {
                return _logoutVisible;
            }
            set
            {
                _logoutVisible = value;
                OnPropertyChanged(nameof(LogoutVisible));
            }
        }
        private readonly UserDataService _userDataService;
        private readonly UserStore _userStore;
        #endregion
        #region Constructors
        public LoginPageViewModel(UserDataService userDataService, UserStore userStore)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            _userDataService = userDataService;
            _userStore = userStore;
            GetUserList();
            SetUserButton();
            LoginButtonClick = new RelayCommand(Login);
            LogoutButtonClick = new RelayCommand(Logout);
        }
        #endregion
        #region Page logic
        private async void GetUserList()
        {
            AvaibleUsers = await _userDataService.GetAll();
        }
        private bool CheckUser()
        {
            foreach (User user in AvaibleUsers)
            {
                if (user.Username == _username)
                {
                    if (user.Password == _password)
                    {
                        LoggingUser = user;
                        Log.Information("User correctly logged:" + _loggingUser);
                        return true;

                    }
                }
            }
            Log.Warning("Incorrect user name or password!");
            return false;
        }
        private void SetUserButton()
        {
            if (_userStore.CurrentUser.IsLogged)
            {
                LoginVisible = false;
                LogoutVisible = true;
            }
            else
            {
                LoginVisible = true;
                LogoutVisible = false;
            }
        }
        #endregion
        #region Buttons logic
        private void Login(object param)
        {
            if (_password != null && _username != null && param != null)
            {
                bool result;
                result = CheckUser();
                if (result && _loggingUser != null)
                {
                    _loggingUser.IsLogged = true;
                    _userStore.CurrentUser = _loggingUser;
                    SetUserButton();
                }
            }
        }
        private void Logout(object param)
        {
            if (_userStore.CurrentUser != null && param != null)
            {
                _userStore.CurrentUser = new();
                SetUserButton();
            }
        }

        #endregion
        #region ICommand declarations
        public ICommand LoginButtonClick { get; private set; }
        public ICommand LogoutButtonClick { get; private set; }
        #endregion
    }
}
