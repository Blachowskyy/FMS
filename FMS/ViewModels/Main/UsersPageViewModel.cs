using FMS.Models.Main;
using FMS.Services.Common;
using FMS.Services.Common.DataServices;
using FMS.ViewModels.Common;
using Serilog;
using System.Windows.Input;

namespace FMS.ViewModels.Main
{
    public class UsersPageViewModel : BaseViewModel
    {
        #region Variables
        private User? _editededUser;
        public User EditedUser
        {
            get
            {
                return _editededUser ?? new();
            }
            set
            {
                _editededUser = value;
                OnPropertyChanged(nameof(EditedUser));
            }
        }
        private string? _checkPassword;
        public string CheckPassword
        {
            get
            {
                return _checkPassword ?? string.Empty;
            }
            set
            {
                _checkPassword = value;
                OnPropertyChanged(nameof(CheckPassword));
            }
        }
        private IEnumerable<User>? _users;
        public IEnumerable<User> Users
        {
            get
            {
                return _users ?? Enumerable.Empty<User>();
            }
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
        private readonly UserStore _userStore;
        private readonly UserDataService _userDataService;
        #endregion
        #region Constructor
        public UsersPageViewModel(UserDataService userDataService, UserStore userStore)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            _userDataService = userDataService;
            _userStore = userStore;

            AddNewUserButtonClick = new RelayCommand(AddNewUser);
            UpdateUserButtonClick = new RelayCommand(UpdateUserData);
            DeleteUserButtonClick = new RelayCommand(DeleteUser);
            SelectUserFromList = new RelayCommand(SelectUser);
            RefreshUsers();
        }
        #endregion
        #region Program logic
        private async void RefreshUsers()
        {
            if (_userDataService != null)
            {
                Users = await _userDataService.GetAll();
            }
        }
        private bool CheckUserData()
        {
            bool result = true;
            if (_editededUser != null && _userDataService != null)
            {
                if (_editededUser.Username == null)
                {
                    result = false;
                    Log.Error("Username is empty!");
                }
                if (_editededUser.Password == null)
                {
                    result = false;
                    Log.Error("Password is empty!");
                }
                if (_checkPassword == null)
                {
                    result = false;
                    Log.Error("Password confirmation is empty!");
                }
                if (_editededUser.Password != _checkPassword)
                {
                    result = false;
                    Log.Error("Password and password confirmation don't match!");
                }
                /*if (!_editededUser.Client && !_editededUser.Installator && !_editededUser.Admin)
                {
                    result = false;
                    Log.Error("User is lack of privileges!");
                }*/
            }
            return result;
        }
        private bool CheckPrivileges(User checkedUser)
        {
            bool result = true;
            if (_userStore != null && checkedUser != null && _userDataService != null)
            {
                
                if (_userStore.CurrentUser.Client)
                {
                    if (checkedUser.Installator || checkedUser.Admin)
                    {
                        result = false;
                        Log.Information("Current user has not sufficient privileges");
                    }
                }
                if (_userStore.CurrentUser.Installator)
                {
                    if (checkedUser.Admin)
                    {
                        result = false;
                        Log.Information("Current user has not sufficient privileges");
                    }
                }
                /*if (!_userStore.CurrentUser.Installator && !_userStore.CurrentUser.Admin && !_userStore.CurrentUser.Client)
                {
                    result = false;
                    Log.Information("Current user has not sufficient privileges");
                }*/
            }
            return result;
        }
        #endregion
        #region Button logic
        private async void AddNewUser(object? param)
        {
            bool result = CheckUserData();
            if (result)
            {
                User addedUser = new();
                if (_editededUser != null && addedUser != null)
                {
                    addedUser = _editededUser;
                    addedUser.Id = 0;
                    if (_userDataService != null)
                    {
                        bool privilegesCheck = CheckPrivileges(addedUser);
                        if (privilegesCheck)
                        {
                            await _userDataService.Create(addedUser);
                        }
                    }
                    if (_userDataService == null)
                    {
                        Log.Error("User data service is null!");
                    }
                }
                if (_editededUser == null)
                {
                    Log.Error("Edited user is null!");
                }
                if (addedUser == null)
                {
                    Log.Error("Added user is null!");
                }
            }
            if (!result)
            {
                Log.Error("Result after checking user data:" + result);
            }
            RefreshUsers();
        }
        private async void UpdateUserData(object? param)
        {
            bool result = CheckUserData();
            if (result)
            {
                if (_editededUser != null && _userDataService != null)
                {
                    bool privilegesCheck = CheckPrivileges(_editededUser);
                    if (privilegesCheck)
                    {
                        await _userDataService.Update(_editededUser.Id, _editededUser);
                    }
                }
                if (_editededUser == null)
                {
                    Log.Error("Edited user is null");
                }
                if (_userDataService == null)
                {
                    Log.Error("User data service is null");
                }
            }
            if (!result)
            {
                Log.Error("Check user data result is: " + result);
            }
            RefreshUsers();
        }
        private async void DeleteUser(object? param)
        {
            if (_editededUser != null)
            {
                if (_userDataService != null)
                {
                    bool privilegesCheck = CheckPrivileges(_editededUser);
                    if (privilegesCheck)
                    {
                        await _userDataService.Delete(_editededUser.Id);
                    }
                }
                if (_userDataService == null)
                {
                    Log.Error("User data service is null");
                }
            }
            if (_editededUser == null)
            {
                Log.Error("Edited user is null!");
            }
            RefreshUsers();
        }
        private async void SelectUser(object? param)
        {
            if (param != null && _userDataService != null)
            {
                EditedUser ??= new();
                EditedUser = await _userDataService.Get(Convert.ToInt32(param));
            }
        }
        #endregion
        #region ICommands declarations
        public ICommand? AddNewUserButtonClick { get; private set; }
        public ICommand? UpdateUserButtonClick { get; private set; }
        public ICommand? DeleteUserButtonClick { get; private set; }
        public ICommand? SelectUserFromList { get; private set; }
        #endregion
    }
}
