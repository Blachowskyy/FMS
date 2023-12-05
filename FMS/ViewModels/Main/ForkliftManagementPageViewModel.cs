using FMS.ViewModels.Common;
using FMS.Models.Main;
using FMS.Services.Common.DataServices;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FMS.ViewModels.Main
{
    public class ForkliftManagementPageViewModel : BaseViewModel
    {
        #region Variables
        private string? _connectionStatusIconPath;
        public string ConnectionStatusIconPath
        {
            get
            {
                return _connectionStatusIconPath ??= "/Models/Resources/Icons/OfflineRed.png";
            }
            set
            {
                if (_connectionStatusIconPath != value)
                {
                    _connectionStatusIconPath = value;
                    OnPropertyChanged(nameof(ConnectionStatusIconPath));
                }
            }
        }
        private List<Forklift>? _onlineForklifts;
        public List<Forklift> OnlineForklifts
        {
            get
            {
                return _onlineForklifts ??= [];
            }
            set
            {
                _onlineForklifts = value;
                OnPropertyChanged(nameof(OnlineForklifts));
            }
        }
        private IEnumerable<Forklift>? _savedForklifts;
        public IEnumerable<Forklift> SavedForklifts
        {
            get
            {
                return _savedForklifts ??= Enumerable.Empty<Forklift>();
            }
            set
            {
                _savedForklifts = value;
                OnPropertyChanged(nameof(SavedForklifts));
            }

        }
        private Forklift? _currentForklfit;
        public Forklift CurrentForklift
        {
            get
            {
                return _currentForklfit ??= new Forklift();
            }
            set
            {
                _currentForklfit = value;
                OnPropertyChanged(nameof(CurrentForklift));
            }
        }
        private readonly ForklfitDataService? _forkliftDataService;
        #endregion
        #region Constructors
        public ForkliftManagementPageViewModel(ForklfitDataService forkliftDataService, List<Forklift> onlineForklifts)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            _forkliftDataService = forkliftDataService;
            OnlineForklifts = onlineForklifts;
            LoadSavedForklifts();
            ConnectionStatusIconsSteering();
            AddForkliftButtonClick = new RelayCommand(AddForkliftAsync);
            UpdateForkliftButtonClick = new RelayCommand(UpdateForklift);
            DeleteForkliftButtonClick = new RelayCommand(DeleteForklift);
            SelectForklfitFromList = new RelayCommand(SelectForklift);
            PingForkliftButtonCLick = new RelayCommand(PingForklift);
        }
        #endregion
        #region Logic
        private async void LoadSavedForklifts()
        {
            if (_forkliftDataService != null)
            {
                SavedForklifts = await _forkliftDataService.GetAll();
            }
        }
        private bool VerifyForklift()
        {
            bool verify = true;
            if (_currentForklfit != null)
            {
                if (_currentForklfit.IpAddress == null)
                {
                    verify = false;
                    Log.Error("Forklift IP Adress is null");
                }
                if (_currentForklfit.Port == 0)
                {
                    verify = false;
                    Log.Error("Forklift Port is null");
                }
                if (_currentForklfit.Name == null)
                {
                    verify = false;
                    Log.Error("Forklift Name is null");
                }
                if (_currentForklfit.LidarLocAddress == null)
                {
                    verify = false;
                    Log.Error("Forklift LidarLoc Adress is null");
                }
            }
            if (_currentForklfit == null)
            {
                verify = false;
                Log.Error("Forklift is null");
            }

            return verify;
        }
        private void ConnectionStatusIconsSteering()
        {
            if (_currentForklfit != null)
            {
                if (_currentForklfit.IsConnected)
                {
                    ConnectionStatusIconPath = "/Models/Resources/Icons/OnlineGreen.png";
                }
                else
                {
                    ConnectionStatusIconPath = "/Models/Resources/Icons/OfflineRed.png";
                }
            }
            else
            {
                ConnectionStatusIconPath = "/Models/Resources/Icons/OfflineRed.png";
            }
        }
        #endregion
        #region Button logic
        private async void AddForkliftAsync(object param)
        {
            bool verify;
            verify = VerifyForklift();
            if (verify && _forkliftDataService != null && _currentForklfit != null)
            {
                CurrentForklift.Id = 0;
                await _forkliftDataService.Create(_currentForklfit);
                
            }
            LoadSavedForklifts();
        }
        private async void UpdateForklift(object param)
        {
            bool verify = false;
            if (_currentForklfit != null && _forkliftDataService != null)
            {
                LoadSavedForklifts();
                if (_savedForklifts != null)
                {
                    foreach(Forklift forklift in _savedForklifts)
                    {
                        if (forklift.Id == _currentForklfit.Id)
                        {
                            verify = VerifyForklift();
                            break;
                        }
                    }
                }
                if (verify)
                {
                    await _forkliftDataService.Update(_currentForklfit.Id, _currentForklfit);
                }
            }
        }
        private async void DeleteForklift(object param)
        {
            bool verify = false;
            bool result = false;
            if (_currentForklfit != null && _forkliftDataService != null)
            {
                LoadSavedForklifts();
                if (_savedForklifts != null)
                {
                    foreach (Forklift forklift in _savedForklifts)
                    {
                        if (forklift.Id == _currentForklfit.Id)
                        {
                            verify = true;
                            break;
                        }
                    }
                }
                if (verify)
                {
                   result =  await _forkliftDataService.Delete(_currentForklfit.Id);
                }
            }
            if (result)
            {
                Log.Information("Forklift deleted successfully");
            }
            if (!result)
            {
                Log.Error("Forklift not deleted!!!");
            }
            LoadSavedForklifts();
        }
        private async void SelectForklift(object param)
        {
            try
            {
                if (Convert.ToInt32(param) > 0 && _forkliftDataService != null)
                {
                    CurrentForklift = await _forkliftDataService.Get(Convert.ToInt32(param));
                    Log.Information("Selected forklift: " + CurrentForklift.Name);
                    if (_onlineForklifts != null && _currentForklfit != null)
                    {
                        foreach (Forklift fork in _onlineForklifts)
                        {
                            if (fork.Id == _currentForklfit.Id) 
                            {
                                CurrentForklift.IsConnected = true;
                            }
                        }
                    }
                }
                else
                {
                    Log.Error("Forklift not found!");
                }
                ConnectionStatusIconsSteering();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex.ToString());
            }  
        }
        private void PingForklift()
        {
            if (_currentForklfit != null)
            {
                if (!string.IsNullOrEmpty(_currentForklfit.IpAddress))
                {
                    Ping pingSender = new();
                    try
                    {
                        PingReply reply = pingSender.Send(_currentForklfit.IpAddress);
                        if (reply.Status == IPStatus.Success)
                        {
                            Log.Information("Ping successfull: " + reply.RoundtripTime.ToString());
                        }
                        else
                        {
                            Log.Warning("Ping test failed: " + reply.Status.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Log.Fatal(ex.ToString());
                    }
                }
                else
                {
                    Log.Warning("Something wrong with Ip address: " + _currentForklfit.IpAddress.ToString());
                }
            }
            else
            {
                Log.Error("Current forklift is null or empty");
            }
        }
        #endregion
        #region ICommand declarations
        public ICommand? AddForkliftButtonClick { get; private set; }
        public ICommand? UpdateForkliftButtonClick { get; private set; }
        public ICommand? DeleteForkliftButtonClick { get; private set; }
        public ICommand? SelectForklfitFromList {  get; private set; }
        public ICommand? PingForkliftButtonCLick { get; private set; }

        #endregion
    }
}
