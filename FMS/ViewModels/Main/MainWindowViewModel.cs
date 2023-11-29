using FMS.Models.Main;
using FMS.Services.Common;
using FMS.Services.Common.DataServices;
using FMS.Services.Common.Interfaces;
using FMS.ViewModels.Common;
using FMS.Views.Main;
using Serilog;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FMS.ViewModels.Main
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region Variables
        #region Page
        private Page? _currentPage;
        public Page CurrentPage
        {
            get
            {
                return _currentPage ??= new Page();
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }
        private bool _showSideMenu;
        public bool ShowSideMenu
        {
            get
            {
                return _showSideMenu;
            }
            set
            {
                _showSideMenu = value;
                OnPropertyChanged(nameof(ShowSideMenu));
            }
        }
        private bool _openShutdownDialogBox;
        public bool OpenShutdownDialogBox
        {
            get
            {
                return _openShutdownDialogBox;
            }
            set
            {
                _openShutdownDialogBox = value;
                OnPropertyChanged(nameof(OpenShutdownDialogBox));
            }
        }
        private User? _currentUser;
        public User CurrentUser
        {
            get
            {
                return _currentUser ??= new User();
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        private string? _loginPageIcon;
        public string LoginPageIcon
        {
            get
            {
                return _loginPageIcon ??= "Models/Resources/Icons/LoginPageWhite.png";
            }
            set
            {
                _loginPageIcon = value;
                OnPropertyChanged(nameof(LoginPageIcon));
            }
        }
        private bool _clientMenuVisible;
        public bool ClientMenuVisible
        {
            get
            {
                return _clientMenuVisible;
            }
            set
            {
                _clientMenuVisible = value;
                OnPropertyChanged(nameof(ClientMenuVisible));
            }
        }
        private bool _installatorMenuVisible;
        public bool InstallatorMenuVisible
        {
            get
            {
                return _installatorMenuVisible;
            }
            set
            {
                _installatorMenuVisible = value;
                OnPropertyChanged(nameof(InstallatorMenuVisible));
            }
        }
        private bool _adminMenuVisible;
        public bool AdminMenuVisible
        {
            get
            {
                return _adminMenuVisible;
            }
            set
            {
                _adminMenuVisible = value;
                OnPropertyChanged(nameof(AdminMenuVisible));
            }
        }
        private List<Forklift>? _connectedForklifts;
        public List<Forklift> ConnectedForklifts
        {
            get
            {
                return _connectedForklifts ??= [];
            }
            set
            {
                _connectedForklifts = value;
                OnPropertyChanged(nameof(ConnectedForklifts));
            }
        }
        #endregion
        #region Privates
        private readonly UserDataService _userDataService;
        private readonly IDataService<JobStepType> _jobStepTypeDataService;
        private readonly IDataService<JobStep> _jobStepDataService;
        private readonly IDataService<Job> _jobDataService;
        private readonly IDataService<Location> _locationDataService;
        private readonly ForklfitDataService _forkliftDataService;
        private readonly ForkliftConnection _forkliftConnectionService;
        private readonly UserStore _userStore;
        private IEnumerable<Forklift>? _readedForklifts;
        public bool ShowMenu { get; set; }
        #endregion
        #endregion
        #region Constructors
        public MainWindowViewModel(UserDataService userDataService,
        IDataService<JobStepType> jobStepTypeDataService,
        IDataService<JobStep> jobStepDataService,
        IDataService<Job> jobDataService,
        IDataService<Location> locationDataService,
        ForklfitDataService forkliftDataService,
        UserStore userStore,
        ForkliftConnection forkliftConnectionService)

        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            _userDataService = userDataService;
            _jobStepTypeDataService = jobStepTypeDataService;
            _jobStepDataService = jobStepDataService;
            _jobDataService = jobDataService;
            _locationDataService = locationDataService;
            _forkliftDataService = forkliftDataService;
            _userStore = userStore;
            _forkliftConnectionService = forkliftConnectionService;
            SetMenuVisibility();
            _userStore.StateChanged += OnUserChanged;
            ShutdownAppButtonClick = new RelayCommand(ExecuteShutdownAppButtonClick);
            LoginPageButtonClick = new RelayCommand(ExecuteLoginPageButtonClick);
            ForkliftManagementPageButtonClick = new RelayCommand(ExecuteForkliftManagementPageButtonClick);
            ConnectToForklifts();
        }
        #endregion
        #region ProgramLogic
        private void OnUserChanged()
        {
            if (_userStore.CurrentUser != null)
            {
                CurrentUser = _userStore.CurrentUser;
                LoginPageIcon = "Models/Resources/Icons/LogoutPageWhite.png";
            }
            SetMenuVisibility();
        }
        private void SetMenuVisibility()
        {
            if (_userStore.CurrentUser.Client)
            {
                ClientMenuVisible = true;
                InstallatorMenuVisible = false;
                AdminMenuVisible = false;
            }
            else if (_userStore.CurrentUser.Installator)
            {
                ClientMenuVisible = true;
                InstallatorMenuVisible = true;
                AdminMenuVisible = false;
            }
            else if (_userStore.CurrentUser.Admin)
            {
                ClientMenuVisible = true;
                InstallatorMenuVisible = true;
                AdminMenuVisible = true;
            }
            else
            {
                ClientMenuVisible = false;
                InstallatorMenuVisible = false;
                AdminMenuVisible = true;
            }
        }
        private async void ConnectToForklifts()
        {
            _readedForklifts ??= await _forkliftDataService.GetAll();
            foreach (Forklift fork in _readedForklifts)
            {
                if (!fork.IsConnected)
                {
                    await Task.Run(() => { Task<bool> connect = _forkliftConnectionService.Connect(fork); });
                    await Task.Delay(100);
                }
                if (fork.Client.Connected)
                {
                    fork.Data ??= new();
                    await Task.Run(() =>
                    {
                        Task communication = _forkliftConnectionService.HandleDataExchange(fork);
                    });
                    if (_connectedForklifts != null)
                    {
                        if (_connectedForklifts.Count > 0)
                        {
                            int lenghtCheck = _connectedForklifts.Count;
                            if (lenghtCheck >= fork.Id)
                            {
                                if (_connectedForklifts.ElementAt(fork.Id - 1) == null)
                                {
                                    _connectedForklifts.Insert(fork.Id, fork);
                                }
                            }
                            else
                            {
                                _connectedForklifts.Add(fork);
                            }
                        }

                    }
                    else
                    {
                        _connectedForklifts = [];
                        ConnectedForklifts.Add(fork);
                    }

                }
            }

        }
        #endregion
        #region Buttons logic
        private void ExecuteShutdownAppButtonClick(object? param)
        {
            Application.Current.Shutdown();
        }
        private void ExecuteLoginPageButtonClick(object? param)
        {
            Log.Information("Clicked login page button...");
            CurrentPage = new LoginPage(new LoginPageViewModel(_userDataService, _userStore));

        }
        private void ExecuteForkliftManagementPageButtonClick(object? param)
        {
            Log.Information("Clicked forklift management page button...");
            _connectedForklifts ??= [];
            CurrentPage = new ForkliftManagementPage(new ForkliftManagementPageViewModel(_forkliftDataService, _connectedForklifts));
        }
        #endregion
        #region ICommand declarations
        public ICommand? ShutdownAppButtonClick { get; private set; }
        public ICommand? LoginPageButtonClick { get; private set; }
        public ICommand? ForkliftManagementPageButtonClick { get; private set; }
        #endregion
    }
}
