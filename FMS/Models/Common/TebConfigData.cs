namespace FMS.Models.Common
{
    public class TebConfigData : CommonBaseModel
    {
        #region Variables
        private string? _forwardMaxVelocity;
        public string ForwardMaxVelocity
        {
            get
            {
                return _forwardMaxVelocity ?? string.Empty;
            }
            set
            {
                _forwardMaxVelocity = value;
                OnPropertyChanged(nameof(ForwardMaxVelocity));
            }
        }
        private string? _backwardMaxVelocity;
        public string BackwardMaxVelocity
        {
            get
            {
                return _backwardMaxVelocity ?? string.Empty;
            }
            set
            {
                _backwardMaxVelocity = value;
                OnPropertyChanged(nameof(BackwardMaxVelocity));
            }
        }
        private string? _turningMaxVelocity;
        public string TurningMaxVelocity
        {
            get
            {
                return _turningMaxVelocity ?? string.Empty;
            }
            set
            {
                _turningMaxVelocity = value;
                OnPropertyChanged(nameof(TurningMaxVelocity));
            }
        }
        private string? _accelerationLimitX;
        public string AccelerationLimitX
        {
            get
            {
                return _accelerationLimitX ?? string.Empty;
            }
            set
            {
                _accelerationLimitX = value;
                OnPropertyChanged(nameof(AccelerationLimitX));
            }
        }
        private string? _turningAccelerationLimit;
        public string TurningAccelerationLimit
        {
            get
            {
                return _turningAccelerationLimit ?? string.Empty;
            }
            set
            {
                _turningAccelerationLimit = value;
                OnPropertyChanged(nameof(TurningAccelerationLimit));
            }
        }
        private string? _turningRadius;
        public string TurningRadius
        {
            get
            {
                return _turningRadius ?? string.Empty;
            }
            set
            {
                _turningRadius = value;
                OnPropertyChanged(nameof(TurningRadius));
            }
        }
        private string? _wheelBase;
        public string WheelBase
        {
            get
            {
                return _wheelBase ?? string.Empty;
            }
            set
            {
                _wheelBase = value;
                OnPropertyChanged(nameof(WheelBase));
            }
        }
        private string? _goalToleranceXY;
        public string GoalToleranceXY
        {
            get
            {
                return _goalToleranceXY ?? string.Empty;
            }
            set
            {
                _goalToleranceXY = value;
                OnPropertyChanged(nameof(GoalToleranceXY));
            }
        }
        private string? _goalToleranceYaw;
        public string GoalToleranceYaw
        {
            get
            {
                return _goalToleranceYaw ?? string.Empty;
            }
            set
            {
                _goalToleranceYaw = value;
                OnPropertyChanged(nameof(GoalToleranceYaw));
            }
        }
        private string? _minimalObstacleDistance;
        public string MinimalObstacleDistance
        {
            get
            {
                return _minimalObstacleDistance ?? string.Empty;
            }
            set
            {
                _minimalObstacleDistance = value;
                OnPropertyChanged(nameof(MinimalObstacleDistance));
            }
        }
        private string? _staticObstacleInflationRadius;
        public string StaticObstacleInflationRadius
        {
            get
            {
                return _staticObstacleInflationRadius ?? string.Empty;
            }
            set
            {
                _staticObstacleInflationRadius = value;
                OnPropertyChanged(nameof(StaticObstacleInflationRadius));
            }
        }
        private string? _dynamicObstacleInflationRadius;
        public string DynamicObstacleInflationRadius
        {
            get
            {
                return _dynamicObstacleInflationRadius ?? string.Empty;
            }
            set
            {
                _dynamicObstacleInflationRadius = value;
                OnPropertyChanged(nameof(DynamicObstacleInflationRadius));
            }
        }
        private string? _dtRef;
        public string DtRef
        {
            get
            {
                return _dtRef ?? string.Empty;
            }
            set
            {
                _dtRef = value;
                OnPropertyChanged(nameof(DtRef));
            }
        }
        private string? _dtHysteresis;
        public string DtHysteresis
        {
            get
            {
                return _dtHysteresis ?? string.Empty;
            }
            set
            {
                _dtHysteresis = value;
                OnPropertyChanged(nameof(DtHysteresis));
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
        private bool _includeCostmapObstacles;
        public bool IncludeCostmapObstacles
        {
            get
            {
                return _includeCostmapObstacles;
            }
            set
            {
                _includeCostmapObstacles = value;
                OnPropertyChanged(nameof(IncludeCostmapObstacles));
            }
        }
        private bool _oscillationRecovery;
        public bool OscillationRecovery
        {
            get
            {
                return _oscillationRecovery;
            }
            set
            {
                _oscillationRecovery = value;
                OnPropertyChanged(nameof(OscillationRecovery));
            }
        }
        private bool _allowInitializeWithBackwardMotion;
        public bool AllowInitializeWithBackwardMotion
        {
            get
            {
                return _allowInitializeWithBackwardMotion;
            }
            set
            {
                _allowInitializeWithBackwardMotion = value;
                OnPropertyChanged(nameof(AllowInitializeWithBackwardMotion));
            }
        }
        private bool _saveSettings;
        public bool SaveSettings
        {
            get
            {
                return _saveSettings;
            }
            set
            {
                _saveSettings = value;
                OnPropertyChanged(nameof(SaveSettings));
            }
        }
        #endregion
    }
}
