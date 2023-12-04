using FMS.Models.Common;
using FMS.Models.Main;
using FMS.ViewModels.Common;
using Serilog;

namespace FMS.ViewModels.LiveForkliftsPages
{
    public class AutoModeStartupPageViewModel : BaseViewModel
    {
        #region Variables
        private StartupStatuses? _displayedData;
        public StartupStatuses DiplayedData
        {
            get
            {
                return _displayedData ??= new();
            }
            set
            {
                _displayedData = value;
                OnPropertyChanged(nameof(DiplayedData));
            }
        }
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
        #endregion
        #region Constructor
        public AutoModeStartupPageViewModel(Forklift selectedForklift)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            SelectedForklift = selectedForklift;
            if (_selectedForklift != null)
            {
                if (_selectedForklift.Client != null)
                {
                    Task.Run(() => { DataRefresh(); });
                }
            }
        }
        #endregion
        #region Program logic
        private async void DataRefresh()
        {
            if (_selectedForklift != null)
            {
                while (_selectedForklift.Client.Connected)
                {
                    StartupStatuses tmp = new()
                    {
                        GatewayStart = _selectedForklift.Data.Startup.GatewayStart,
                        GatewayEnd = _selectedForklift.Data.Startup.GatewayEnd,
                        Plc = _selectedForklift.Data.Startup.Plc,
                        Fms = _selectedForklift.Data.Startup.Fms,
                        FlexiGatewayEthernet = _selectedForklift.Data.Startup.FlexiGatewayEthernet,
                        FlexiGatewayModbus = _selectedForklift.Data.Startup.FlexiGatewayModbus,
                        LidarLoc = _selectedForklift.Data.Startup.LidarLoc,
                        SafetyScannerLeft = _selectedForklift.Data.Startup.SafetyScannerLeft,
                        SafetyScannerRight = _selectedForklift.Data.Startup.SafetyScannerRight,
                        OverallResult = _selectedForklift.Data.Startup.OverallResult,
                        EthernetTest = _selectedForklift.Data.Startup.EthernetTest,
                        ScangridsTest = _selectedForklift.Data.Startup.ScangridsTest,
                        ServoTest = _selectedForklift.Data.Startup.ServoTest,
                        CurtisTest = _selectedForklift.Data.Startup.CurtisTest,
                        ForksTest = _selectedForklift.Data.Startup.ForksTest
                    };
                    DiplayedData = tmp;
                    await Task.Delay(100);
                }
            }
        }
        #endregion
    }
}
