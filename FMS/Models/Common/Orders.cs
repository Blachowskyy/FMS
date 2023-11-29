namespace FMS.Models.Common
{
    public class Orders : CommonBaseModel
    {
        #region Variables
        private bool _startAutoMode;
        public bool StartAutoMode
        {
            get
            {
                return _startAutoMode;
            }
            set
            {
                _startAutoMode = value;
                OnPropertyChanged(nameof(StartAutoMode));
            }
        }
        private bool _startManualMode;
        public bool StartManualMode
        {
            get
            {
                return _startManualMode;
            }
            set
            {
                _startManualMode = value;
                OnPropertyChanged(nameof(StartManualMode));
            }
        }
        private bool _startWork;
        public bool StartWork
        {
            get
            {
                return _startWork;
            }
            set
            {
                _startWork = value;
                OnPropertyChanged(nameof(StartWork));
            }
        }
        private bool _pause;
        public bool Pause
        {
            get
            {
                return _pause;
            }
            set
            {
                _pause = value;
                OnPropertyChanged(nameof(Pause));
            }
        }
        private bool _emergencyStop;
        public bool EmergencyStop
        {
            get
            {
                return _emergencyStop;
            }
            set
            {
                _emergencyStop = value;
                OnPropertyChanged(nameof(EmergencyStop));
            }
        }
        private bool _continue;
        public bool Continue
        {
            get
            {
                return _continue;
            }
            set
            {
                _continue = value;
                OnPropertyChanged(nameof(Continue));
            }
        }
        private bool _stop;
        public bool Stop
        {
            get
            {
                return _stop;
            }
            set
            {
                _stop = value;
                OnPropertyChanged(nameof(Stop));
            }
        }
        private bool _startTask;
        public bool StartTask
        {
            get
            {
                return _startTask;
            }
            set
            {
                _startTask = value;
                OnPropertyChanged(nameof(StartTask));
            }
        }
        private bool _cancelTask;
        public bool CancelTask
        {
            get
            {
                return _cancelTask;
            }
            set
            {
                _cancelTask = value;
                OnPropertyChanged(nameof(CancelTask));
            }
        }
        #endregion
        #region Constructors
        public Orders() { }
        #endregion
    }
}
