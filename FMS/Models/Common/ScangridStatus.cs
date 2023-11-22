using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Models.Common
{
    public class ScangridStatus : CommonBaseModel
    {
        #region Variables
        private bool _isActive;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }
        private bool _safetyOutput;
        public bool SafetyOutput
        {
            get
            {
                return _safetyOutput;
            }
            set
            {
                _safetyOutput = value;
                OnPropertyChanged(nameof(SafetyOutput));
            }
        }
        private bool _protectiveFieldStatus;
        public bool ProtectiveFieldStatus
        {
            get
            {
                return _protectiveFieldStatus;
            }
            set
            {
                _protectiveFieldStatus = value;
                OnPropertyChanged(nameof(ProtectiveFieldStatus));
            }
        }
        private bool _warningFieldStatus;
        public bool WarningFieldStatus
        {
            get
            {
                return _warningFieldStatus;
            }
            set
            {
                _warningFieldStatus = value;
                OnPropertyChanged(nameof(WarningFieldStatus));
            }
        }
        private bool _contaminationWarning;
        public bool ContaminationWarning
        {
            get
            {
                return _contaminationWarning;
            }
            set
            {
                _contaminationWarning = value;
                OnPropertyChanged(nameof(ContaminationWarning));
            }
        }
        private bool _contaminationError;
        public bool ContaminationError
        {
            get
            {
                return _contaminationError;
            }
            set
            {
                _contaminationError = value;
                OnPropertyChanged(nameof(ContaminationError));
            }
        }
        private bool _monitoringCaseSwitchInputStatus;
        public bool MonitoringCaseSwitchInputStatus
        {
            get
            {
                return _monitoringCaseSwitchInputStatus;
            }
            set
            {
                _monitoringCaseSwitchInputStatus = value;
                OnPropertyChanged(nameof(MonitoringCaseSwitchInputStatus));
            }
        }
        private bool _monitoringCaseCanInputStatus;
        public bool MonitoringCaseCanInputStatus
        {
            get
            {
                return _monitoringCaseCanInputStatus;
            }
            set
            {
                _monitoringCaseCanInputStatus = value;
                OnPropertyChanged(nameof(MonitoringCaseCanInputStatus));
            }
        }
        private bool _voltageError;
        public bool VoltageError
        {
            get
            {
                return _voltageError;
            }
            set
            {
                _voltageError = value;
                OnPropertyChanged(nameof(VoltageError));
            }
        }
        private bool _resistanceToExternalLightError;
        public bool ResistanceToExternalLightError
        {
            get
            {
                return _resistanceToExternalLightError;
            }
            set
            {
                _resistanceToExternalLightError = value;
                OnPropertyChanged(nameof(ResistanceToExternalLightError));
            }
        }
        private bool _sleepModeStatus;
        public bool SleepModeStatus
        {
            get
            {
                return _sleepModeStatus;
            }
            set
            {
                _sleepModeStatus = value;
                OnPropertyChanged(nameof(SleepModeStatus));
            }
        }
        #endregion
    }
}
