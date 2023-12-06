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
        private double _maxForwardSpeed;
        public double MaxForwardSpeed
        {
            get
            {
                return _maxForwardSpeed;
            }
            set
            {
                if (_maxForwardSpeed != value)
                {
                    if (value < 0.01)
                    {
                        _maxForwardSpeed = 0.01;
                    }
                    else if (value > 100.0)
                    {
                        _maxForwardSpeed = 100.0;
                    }
                    else
                    {
                        _maxForwardSpeed = value;
                    }
                    OnPropertyChanged(nameof(MaxForwardSpeed));
                }
            }
        }

        private double _maxBackwardSpeed;
        public double MaxBackwardSpeed
        {
            get
            {
                return _maxBackwardSpeed;
            }
            set
            {
                if (_maxBackwardSpeed != value)
                {
                    if (value < 0.01)
                    {
                        _maxBackwardSpeed = 0.01;
                    }
                    else if (value > 100.0)
                    {
                        _maxBackwardSpeed = 100.0;
                    }
                    else
                    {
                        _maxBackwardSpeed = value;
                    }
                    OnPropertyChanged(nameof(MaxBackwardSpeed));
                }
            }
        }

        private double _maxTurningSpeed;
        public double MaxTurningSpeed
        {
            get
            {
                return _maxTurningSpeed;
            }
            set
            {
                if (_maxTurningSpeed != value)
                {
                    if (value < 0.01)
                    {
                        _maxTurningSpeed = 0.01;
                    }
                    else if (value > 100.0)
                    {
                        _maxTurningSpeed = 100.0;
                    }
                    else
                    {
                        _maxTurningSpeed = value;
                    }
                    OnPropertyChanged(nameof(MaxTurningSpeed));
                }
            }
        }

        private double _maxLinearAcceleration;
        public double MaxLinearAcceleration
        {
            get
            {
                return _maxLinearAcceleration;
            }
            set
            {
                if (_maxLinearAcceleration != value)
                {
                    if (value < 0.01)
                    {
                        _maxLinearAcceleration = 0.01;
                    }
                    else if (value > 100.0)
                    {
                        _maxLinearAcceleration = 100.0;
                    }
                    else
                    {
                        _maxLinearAcceleration = value;
                    }
                    OnPropertyChanged(nameof(MaxLinearAcceleration));
                }
            }
        }

        private double _maxAngularAcceleration;
        public double MaxAngulatAcceleration
        {
            get
            {
                return _maxAngularAcceleration;
            }
            set
            {
                if (value != _maxAngularAcceleration)
                {
                    if (value < 0.01)
                    {
                        _maxAngularAcceleration = 0.01;
                    }
                    else if (value > 100.0)
                    {
                        _maxAngularAcceleration = 100.0;
                    }
                    else
                    {
                        _maxAngularAcceleration = value;
                    }
                    OnPropertyChanged(nameof(MaxAngulatAcceleration));
                }
            }
        }

        private double _turningRadius;
        public double TurningRadius
        {
            get
            {
                return _turningRadius;
            }
            set
            {
                if (_turningRadius != value)
                {
                    if (value < 0.0)
                    {
                        _turningRadius = 0.0;
                    }
                    else if (value > 50.0)
                    {
                        _turningRadius = 50.0;
                    }
                    else
                    {
                        _turningRadius = value;
                    }
                    OnPropertyChanged(nameof(TurningRadius));
                }
            }
        }

        private double _wheelBase;
        public double WheelBase
        {
            get
            {
                return _wheelBase;
            }
            set
            {
                if (_wheelBase != value)
                {
                    if (value < -10.0)
                    {
                        _wheelBase = -10.0;
                    }
                    else if (value > 10.0)
                    {
                        _wheelBase = 10.0;
                    }
                    else
                    {
                        _wheelBase = value;
                    }
                    OnPropertyChanged(nameof(WheelBase));
                }
            }
        }

        private double _maxGoalToleranceXY;
        public double MaxGoalToleranceXY
        {
            get
            {
                return _maxGoalToleranceXY;
            }
            set
            {
                if (_maxGoalToleranceXY != value)
                {
                    if (value < 0.001)
                    {
                        _maxGoalToleranceXY = 0.001;
                    }
                    else if (value > 10.0)
                    {
                        _maxGoalToleranceXY = 10.0;
                    }
                    else
                    {
                        _maxGoalToleranceXY = value;
                    }
                    OnPropertyChanged(nameof(MaxGoalToleranceXY));
                }
            }
        }

        private double _maxAngularGoalTolerance;
        public double MaxAngularGoalTolerance
        {
            get
            {
                return _maxAngularGoalTolerance;
            }
            set
            {
                if (_maxAngularGoalTolerance != value)
                {
                    if (value < 0.001)
                    {
                        _maxAngularGoalTolerance = 0.001;
                    }
                    else if (value > 360)
                    {
                        _maxAngularGoalTolerance = 360.0;
                    }
                    else
                    {
                        _maxAngularGoalTolerance = value;
                    }
                    OnPropertyChanged(nameof(MaxAngularGoalTolerance));
                }
            }
        }

        private double _minObstacleDistance;
        public double MinObstacleDistance
        {
            get
            {
                return _minObstacleDistance;
            }
            set
            {
                if (_minObstacleDistance != value)
                {
                    if (value < 0.0)
                    {
                        _minObstacleDistance = 0.0;
                    }
                    else if (value > 10.0)
                    {
                        _minObstacleDistance = 10.0;
                    }
                    else
                    {
                        _minObstacleDistance = value;
                    }
                    OnPropertyChanged(nameof(MinObstacleDistance));
                }
            }
        }

        private double _staticObstacleInflation;
        public double StaticObstacleInflation
        {
            get
            {
                return _staticObstacleInflation;
            }
            set
            {
                if (_staticObstacleInflation != value)
                {
                    if (value < 0.0)
                    {
                        _staticObstacleInflation = 0.0;
                    }
                    else if (value > 15.0)
                    {
                        _staticObstacleInflation = 15.0;
                    }
                    else
                    {
                        _staticObstacleInflation = value;
                    }
                    OnPropertyChanged(nameof(StaticObstacleInflation));
                }
            }
        }

        private double _dynamicObstacleInflation;
        public double DynamicObstacleInflation
        {
            get
            {
                return _dynamicObstacleInflation;
            }
            set
            {
                if (_dynamicObstacleInflation != value)
                {
                    if (value < 0.0)
                    {
                        _dynamicObstacleInflation = 0.0;
                    }
                    else if (value > 15.0)
                    {
                        _dynamicObstacleInflation = 15.0;
                    }
                    else
                    {
                        _dynamicObstacleInflation = value;
                    }
                    OnPropertyChanged(nameof(DynamicObstacleInflation));
                }
            }
        }

        private double _dtRef;
        public double DtRef
        {
            get
            {
                return _dtRef;
            }
            set
            {
                if (_dtRef != value)
                {
                    if (value < 0.01)
                    {
                        _dtRef = 0.01;
                    }
                    else if (value > 1.0)
                    {
                        _dtRef = 1.0;
                    }
                    else
                    {
                        _dtRef = value;
                    }
                    OnPropertyChanged(nameof(DtRef));
                }
            }
        }

        private double _dtHysteresis;
        public double DtHysteresis
        {
            get
            {
                return _dtHysteresis;
            }
            set
            {
                if (_dtHysteresis != value)
                {
                    if (value < 0.002)
                    {
                        _dtHysteresis = 0.002;
                    }
                    else if (value > 0.5)
                    {
                        _dtHysteresis = 0.5;
                    }
                    else
                    {
                        _dtHysteresis = value;
                    }
                    OnPropertyChanged(nameof(DtHysteresis));
                }
            }
        }
        private bool _includeDynamicObstacles;
        public bool IncludeDynamicObstacles
        {
            get
            {
                return _includeDynamicObstacles;
            }
            set
            {
                _includeDynamicObstacles = value;
                OnPropertyChanged(nameof(IncludeDynamicObstacles));
            }
        }
        private bool _includeStaticObstacles;
        public bool IncludeStaticObstacles
        {
            get
            {
                return _includeStaticObstacles;
            }
            set
            {
                _includeStaticObstacles = value;
                OnPropertyChanged(nameof(IncludeStaticObstacles));
            }
        }
        private bool _allowOsscilation;
        public bool AllowOsscilation
        {
            get
            {
                return _allowOsscilation;
            }
            set
            {
                _allowOsscilation = value;
                OnPropertyChanged(nameof(AllowOsscilation));
            }
        }
        private bool _allowInitializeWithBackwardMove;
        public bool AllowInitializeWithBackwardMove
        {
            get
            {
                return _allowInitializeWithBackwardMove;
            }
            set
            {
                _allowInitializeWithBackwardMove = value;
                OnPropertyChanged(nameof(AllowInitializeWithBackwardMove));
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
        private readonly ForklfitDataService _forkliftDataService;
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
            LoadDefaultsAtStartup();
            LoadTebConfigFromForkliftButtonClick = new RelayCommand(LoadTebConfigFromForklift);
            LoadTebConfigFromDatabaseButtonClick = new RelayCommand(LoadTebConfigFromDatabase);
            SaveTebConfigToDatabaseButtonClick = new RelayCommand(SaveTebConfigToDatabase);
            SendTebConfigToForkliftButtonClick = new RelayCommand(SendTebConfigToForklift);
        }
        #endregion
        #region Program logic
        private void LoadDefaultsAtStartup()
        {
            MaxForwardSpeed = 0.01;
            MaxBackwardSpeed = 0.01;
            MaxTurningSpeed = 0.01;
            MaxLinearAcceleration = 0.01;
            MaxAngulatAcceleration = 0.01;
            TurningRadius = 0.0;
            WheelBase = -10.0;
            MaxGoalToleranceXY = 0.001;
            MaxAngularGoalTolerance = 0.001;
            MinObstacleDistance = 0.0;
            StaticObstacleInflation = 0.0;
            DynamicObstacleInflation = 0.0;
            DtRef = 0.01;
            DtHysteresis = 0.002;
        }
        private void RefreshViewedData(TebConfigData tebConfig)
        {
            if (tebConfig != null)
            {
                try
                {
                    MaxForwardSpeed = Convert.ToDouble(tebConfig.ForwardMaxVelocity);
                    MaxBackwardSpeed = Convert.ToDouble(tebConfig.BackwardMaxVelocity);
                    MaxTurningSpeed = Convert.ToDouble(tebConfig.ForwardMaxVelocity);
                    MaxLinearAcceleration = Convert.ToDouble(tebConfig.BackwardMaxVelocity);
                    MaxAngulatAcceleration = Convert.ToDouble(tebConfig.ForwardMaxVelocity);
                    TurningRadius = Convert.ToDouble(tebConfig.BackwardMaxVelocity);
                    WheelBase = Convert.ToDouble(tebConfig.ForwardMaxVelocity);
                    MaxGoalToleranceXY = Convert.ToDouble(tebConfig.BackwardMaxVelocity);
                    MaxAngularGoalTolerance = Convert.ToDouble(tebConfig.ForwardMaxVelocity);
                    MinObstacleDistance = Convert.ToDouble(tebConfig.BackwardMaxVelocity);
                    StaticObstacleInflation = Convert.ToDouble(tebConfig.ForwardMaxVelocity);
                    DynamicObstacleInflation = Convert.ToDouble(tebConfig.BackwardMaxVelocity);
                    DtRef = Convert.ToDouble(tebConfig.ForwardMaxVelocity);
                    DtHysteresis = Convert.ToDouble(tebConfig.BackwardMaxVelocity);
                    IncludeDynamicObstacles = tebConfig.IncludeDynamicObstacles;
                    IncludeStaticObstacles = tebConfig.IncludeCostmapObstacles;
                    AllowOsscilation = tebConfig.OscillationRecovery;
                    AllowInitializeWithBackwardMove = tebConfig.OscillationRecovery;
                }
                catch (Exception ex)
                {
                    Serilog.Log.Error("Exception while trying to refresh viewed data: " + ex.Message);
                }
            }
        }
        private void SaveUserData(TebConfigData tebConfig)
        {
            if (tebConfig != null)
            {
                try
                {
                    tebConfig.ForwardMaxVelocity = Convert.ToString(MaxForwardSpeed);
                    tebConfig.BackwardMaxVelocity = Convert.ToString(MaxBackwardSpeed);
                    tebConfig.TurningMaxVelocity = Convert.ToString(MaxTurningSpeed);
                    tebConfig.AccelerationLimitX = Convert.ToString(MaxLinearAcceleration);
                    tebConfig.TurningAccelerationLimit = Convert.ToString(MaxAngulatAcceleration);
                    tebConfig.TurningRadius = Convert.ToString(TurningRadius);
                    tebConfig.WheelBase = Convert.ToString(WheelBase);
                    tebConfig.GoalToleranceXY = Convert.ToString(MaxGoalToleranceXY);
                    tebConfig.GoalToleranceYaw = Convert.ToString(MaxAngularGoalTolerance);
                    tebConfig.MinimalObstacleDistance = Convert.ToString(MinObstacleDistance);
                    tebConfig.StaticObstacleInflationRadius = Convert.ToString(StaticObstacleInflation);
                    tebConfig.DynamicObstacleInflationRadius = Convert.ToString(DynamicObstacleInflation);
                    tebConfig.DtRef = Convert.ToString(DtRef);
                    tebConfig.DtHysteresis = Convert.ToString(DtHysteresis);
                    tebConfig.IncludeCostmapObstacles = IncludeStaticObstacles;
                    tebConfig.IncludeDynamicObstacles = IncludeDynamicObstacles;
                    tebConfig.OscillationRecovery = AllowOsscilation;
                    tebConfig.AllowInitializeWithBackwardMotion = AllowInitializeWithBackwardMove;
                }
                catch (Exception ex)
                {
                    Serilog.Log.Error("Error while saving user data: " + ex.Message);
                }
            }
        }
        #endregion
        #region Button logic
        private void LoadTebConfigFromForklift(object? param)
        {
            if (_selectedForklift != null)
            {
                RefreshViewedData(_selectedForklift.Data.ActualTebConfig);
            }
        }
        private async void LoadTebConfigFromDatabase(object? param)
        {
            if (_selectedForklift != null)
            {
                
                Forklift loadedForklift = await _forkliftDataService.Get(_selectedForklift.Id);
                RefreshViewedData(loadedForklift.BackedUpTebConfig);
            }
        }
        private async void SaveTebConfigToDatabase(object? param)
        {
            if (_selectedForklift != null)
            {
                SaveUserData(_selectedForklift.BackedUpTebConfig);
                if (_forkliftDataService != null)
                {
                    await _forkliftDataService.Update(_selectedForklift.Id, _selectedForklift);
                }
            }
        }
        private void SendTebConfigToForklift(object? param)
        {
            if (_selectedForklift != null)
            {
                SaveUserData(SelectedForklift.Data.TebConfig);
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
