using FleetManagementSystem.ViewModels.Common;
using FMS.Models.Main;
using FMS.Services.Common.DataServices;
using FMS.ViewModels.Common;
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
        private ForklfitDataService? _forkliftDataService;

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
                if (_currentForklfit.IpAdress == null)
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
        #endregion
        #region Button logic
        private async void AddForkliftAsync(object param)
        {
            bool verify;
            verify = VerifyForklift();
            if (verify && _forkliftDataService != null && _currentForklfit != null)
            {
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
                Log.Error("Forklift deleted successfully");
            }
            if (!result)
            {
                Log.Error("Forklift not deleted!!!");
            }
        }
        private async void SelectForklift(object param)
        {
            try
            {
                if (Convert.ToInt32(param) > 0 && _forkliftDataService != null)
                {
                    CurrentForklift = await _forkliftDataService.Get(Convert.ToInt32(param));
                    Log.Error("Selected forklift: " + CurrentForklift.Name);
                }
                else
                {
                    Log.Error("Forklift not found!");
                }
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
                if (!string.IsNullOrEmpty(_currentForklfit.IpAdress))
                {
                    Ping pingSender = new();
                    try
                    {
                        PingReply reply = pingSender.Send(_currentForklfit.IpAdress);
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
                    Log.Warning("Something wrong with Ip address: " + _currentForklfit.IpAdress.ToString());
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
