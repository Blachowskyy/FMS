namespace FMS.Models.Common.Errors
{
    public class DeltaErrorCodes : CommonBaseModel
    {
        #region Variables
        private string? _pressureSensorErrorCode;
        public string PressureSensorErrorCode
        {
            get
            {
                return _pressureSensorErrorCode ?? string.Empty;
            }
            set
            {
                _pressureSensorErrorCode = value;
                OnPropertyChanged(nameof(PressureSensorErrorCode));
            }
        }
        private string? _forksHeightErrorCode;
        public string ForksHeightErrorCode
        {
            get
            {
                return _forksHeightErrorCode ?? string.Empty;
            }
            set
            {
                _forksHeightErrorCode = value;
                OnPropertyChanged(nameof(ForksHeightErrorCode));
            }
        }
        private string? _tiltSensorAxis1ErrorCode;
        public string TiltSensorAxis1ErrorCode
        {
            get
            {
                return _tiltSensorAxis1ErrorCode ?? string.Empty;
            }
            set
            {
                _tiltSensorAxis1ErrorCode = value;
                OnPropertyChanged(nameof(TiltSensorAxis1ErrorCode));
            }
        }
        private string? _tiltSensorAxis2ErrorCode;
        public string TiltSensorAxis2ErrorCode
        {
            get
            {
                return _tiltSensorAxis2ErrorCode ?? string.Empty;
            }
            set
            {
                _tiltSensorAxis2ErrorCode = value;
                OnPropertyChanged(nameof(TiltSensorAxis2ErrorCode));
            }
        }
        private string? _batteryReadErrorCode;
        public string BatteryReadErrorCode
        {
            get
            {
                return _batteryReadErrorCode ?? string.Empty;
            }
            set
            {
                _batteryReadErrorCode = value;
                OnPropertyChanged(nameof(BatteryReadErrorCode));
            }
        }
        private string? _manualHanldeSpeedRegulatorErrorCode;
        public string ManualHandleSpeedRegulatorErrorCode
        {
            get
            {
                return _manualHanldeSpeedRegulatorErrorCode ?? string.Empty;
            }
            set
            {
                _manualHanldeSpeedRegulatorErrorCode = value;
                OnPropertyChanged(nameof(ManualHandleSpeedRegulatorErrorCode));
            }
        }
        private string? _curtisSpeedWriteErrorCode;
        public string CurtisSpeedWriteErrorCode
        {
            get
            {
                return _curtisSpeedWriteErrorCode ?? string.Empty;
            }
            set
            {
                _curtisSpeedWriteErrorCode = value;
                OnPropertyChanged(nameof(CurtisSpeedWriteErrorCode));
            }
        }
        private string? _servoPositionReadErrorCode;
        public string ServoPositionReadErrorCode
        {
            get
            {
                return _servoPositionReadErrorCode ?? string.Empty;
            }
            set
            {
                _servoPositionReadErrorCode = value;
                OnPropertyChanged(nameof(ServoPositionReadErrorCode));
            }
        }
        private string? _servoMoveErrorCode;
        public string ServoMoveErrorCode
        {
            get
            {
                return _servoMoveErrorCode ?? string.Empty;
            }
            set
            {
                _servoMoveErrorCode = value;
                OnPropertyChanged(nameof(ServoMoveErrorCode));
            }
        }
        private string? _servoHaltErrorCode;
        public string ServoHaltErrorCode
        {
            get
            {
                return _servoHaltErrorCode ?? string.Empty;
            }
            set
            {
                _servoHaltErrorCode = value;
                OnPropertyChanged(nameof(ServoHaltErrorCode));
            }
        }
        private string? _scangridLeftErrorCode;
        public string ScangridLeftErrorCode
        {
            get
            {
                return _scangridLeftErrorCode ?? string.Empty;
            }
            set
            {
                _scangridLeftErrorCode = value;
                OnPropertyChanged(nameof(ScangridLeftErrorCode));
            }
        }
        private string? _scangridRightErrorCode;
        public string ScangridRightErrorCode
        {
            get
            {
                return _scangridRightErrorCode ?? string.Empty;
            }
            set
            {
                _scangridRightErrorCode = value;
                OnPropertyChanged(nameof(ScangridRightErrorCode));
            }
        }
        #endregion
        #region Constructors
        public DeltaErrorCodes() { }
        #endregion
    }
}
