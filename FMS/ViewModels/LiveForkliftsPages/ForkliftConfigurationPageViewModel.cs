using FMS.Models.Common;
using FMS.Models.Main;
using FMS.Services.Common.DataServices;
using FMS.ViewModels.Common;
using Microsoft.VisualBasic.Logging;
using Serilog;
using System.Windows.Input;

namespace FMS.ViewModels.LiveForkliftsPages
{
    public class ForkliftConfigurationPageViewModel : BaseViewModel
    {
        #region Variables
        private TebConfigData? _displayedTebConfig;
        public TebConfigData DisplayedTebConfig
        {
            get
            {
                return _displayedTebConfig ??= new();
            }
            set
            {
                _displayedTebConfig = value;
                OnPropertyChanged(nameof(DisplayedTebConfig));
            }
        }
        private TebConfigData? _tebConfigFromForklift;
        private string? _refreshDate;
        public string RefreshDate
        {
            get
            {
                return _refreshDate ??= string.Empty;
            }
            set
            {
                _refreshDate = value;
                OnPropertyChanged(nameof(RefreshDate));
            }
        }
        private Forklift? _selectedForklift;
        public Forklift SelectedForklift
        {
            get
            {
                return _selectedForklift ??= new();
            }
            set
            {
                _selectedForklift = value;
                OnPropertyChanged(nameof(SelectedForklift));
            }
        }
        private ForklfitDataService _forkliftDataService;
        #endregion
        #region Constructor
        public ForkliftConfigurationPageViewModel(Forklift selectedForklift, ForklfitDataService forklfitDataService)
        {
            Serilog.Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            SelectedForklift = selectedForklift;
            _forkliftDataService = forklfitDataService;
            /*if (_selectedForklift != null)
            {
                if (_selectedForklift.Client != null)
                {
                    Task.Run(() => { DataRefresh(); });
                }
            }*/
            LoadTebConfigFromForkliftButtonClick = new RelayCommand(LoadTebConfigFromForklift);
            LoadTebConfigFromDatabaseButtonClick = new RelayCommand(LoadTebConfigFromDatabase);
            SaveTebConfigToDatabaseButtonClick = new RelayCommand(SaveTebConfigToDatabase);
            SendTebConfigToForkliftButtonClick = new RelayCommand(SendTebConfigToForklift);
        }
        #endregion
        #region Program logic
        /*private async void DataRefresh()
        {
            if (_selectedForklift != null)
            {
                while (_selectedForklift.Client.Connected)
                {
                    _tebConfigFromForklift = _selectedForklift.Data.ActualTebConfig;
                    await Task.Delay(100);
                }
            }
        }*/
        #endregion
        #region Button logic
        private void LoadTebConfigFromForklift(object? param)
        {
            if (_selectedForklift != null)
            {
                DisplayedTebConfig = _selectedForklift.Data.ActualTebConfig;
            }
        }
        private async void LoadTebConfigFromDatabase(object? param)
        {
            if (_selectedForklift != null)
            {
                Forklift loadedForklift = new();
                loadedForklift = await _forkliftDataService.Get(_selectedForklift.Id);
                DisplayedTebConfig = loadedForklift.BackedUpTebConfig;
            }
        }
        private async void SaveTebConfigToDatabase(object? param)
        {
            if (_displayedTebConfig != null && _selectedForklift != null)
            {
                SelectedForklift.BackedUpTebConfig = _displayedTebConfig;
                if (_forkliftDataService != null)
                {
                    await _forkliftDataService.Update(_selectedForklift.Id, _selectedForklift);
                }
            }
        }
        private void SendTebConfigToForklift(object? param)
        {
            if (_selectedForklift != null && _displayedTebConfig != null)
            {
                SelectedForklift.Data.TebConfig = _displayedTebConfig;
                SelectedForklift.Data.TebConfig.SaveSettings = true;
                int sendTime = DateTime.Now.Second;
                while (!_selectedForklift.Data.ActualTebConfig.SaveSettings)
                {
                    if ((sendTime - DateTime.Now.Second) > 10)
                    {
                        SelectedForklift.Data.TebConfig.SaveSettings = false;
                        Serilog.Log.Error("Timeout error while sending teb config");
                        break;
                    }
                    if (_selectedForklift.Data.ActualTebConfig.SaveSettings )
                    {
                        SelectedForklift.Data.TebConfig.SaveSettings = false;
                        Serilog.Log.Information("Teb config sended successfully!");
                        break;
                    }
                }
            }
        }
        #endregion
        #region ICommands declarations
        public ICommand? LoadTebConfigFromForkliftButtonClick { get; private set; }
        public ICommand? LoadTebConfigFromDatabaseButtonClick { get; private set; }
        public ICommand? SaveTebConfigToDatabaseButtonClick { get; private set; }
        public ICommand? SendTebConfigToForkliftButtonClick { get; private set; }
        #endregion
    }
}
