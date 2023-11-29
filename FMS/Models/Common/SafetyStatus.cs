namespace FMS.Models.Common
{
    public class SafetyStatus : CommonBaseModel
    {
        #region Variables
        private bool _cpuStatus;
        public bool CpuStatus
        {
            get
            {
                return _cpuStatus;
            }
            set
            {
                _cpuStatus = value;
                OnPropertyChanged(nameof(CpuStatus));
            }
        }
        private bool _encoderStatus;
        public bool EncoderStatus
        {
            get
            {
                return _encoderStatus;
            }
            set
            {
                _encoderStatus = value;
                OnPropertyChanged(nameof(EncoderStatus));
            }
        }
        private bool _standstill;
        public bool Standstill
        {
            get
            {
                return _standstill;
            }
            set
            {
                _standstill = value;
                OnPropertyChanged(nameof(Standstill));
            }
        }
        private bool _overpseedGuardStatus;
        public bool OverpseedGuardStatus
        {
            get
            {
                return _overpseedGuardStatus;
            }
            set
            {
                _overpseedGuardStatus = value;
                OnPropertyChanged(nameof(OverpseedGuardStatus));
            }
        }
        private bool _leftEmergencyStopButtonStatus;
        public bool LeftEmergencyStopButtonStatus
        {
            get
            {
                return _leftEmergencyStopButtonStatus;
            }
            set
            {
                _leftEmergencyStopButtonStatus = value;
                OnPropertyChanged(nameof(LeftEmergencyStopButtonStatus));
            }
        }
        private bool _rightEmergencyStopButtonStatus;
        public bool RightEmergencyStopButtonStatus
        {
            get
            {
                return _rightEmergencyStopButtonStatus;
            }
            set
            {
                _rightEmergencyStopButtonStatus = value;
                OnPropertyChanged(nameof(RightEmergencyStopButtonStatus));
            }
        }
        #endregion
        #region Constructors
        public SafetyStatus() { }
        #endregion
    }
}
