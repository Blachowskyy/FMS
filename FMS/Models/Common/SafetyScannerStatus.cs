using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Models.Common
{
    public class SafetyScannerStatus : CommonBaseModel
    {
        #region Variables
        private bool _reducedSpeedZoneStatus;
        public bool ReducedSpeedZoneStatus
        {
            get
            {
                return _reducedSpeedZoneStatus;
            }
            set
            {
                _reducedSpeedZoneStatus = value;
                OnPropertyChanged(nameof(ReducedSpeedZoneStatus));
            }
        }
        private bool _softStopZoneStatus;
        public bool SoftStopZoneStatus
        {
            get
            {
                return _softStopZoneStatus;
            }
            set
            {
                _softStopZoneStatus = value;
                OnPropertyChanged(nameof(SoftStopZoneStatus));
            }
        }
        private bool _emergencyZoneStatus;
        public bool EmergencyZoneStatus
        {
            get
            {
                return _emergencyZoneStatus;
            }
            set
            {
                _emergencyZoneStatus = value;
                OnPropertyChanged(nameof(EmergencyZoneStatus));
            }
        }
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
        private bool _monitoringCaseValid;
        public bool MonitoringCaseValid
        {
            get
            {
                return _monitoringCaseValid;
            }
            set
            {
                _monitoringCaseValid = value;
                OnPropertyChanged(nameof(MonitoringCaseValid));
            }
        }
        private bool _appError;
        public bool AppError
        {
            get
            {
                return _appError;
            }
            set
            {
                _appError = value;
                OnPropertyChanged(nameof(AppError));
            }
        }
        private bool _deviceError;
        public bool DeviceError
        {
            get
            {
                return _deviceError;
            }
            set
            {
                _deviceError = value;
                OnPropertyChanged(nameof(DeviceError));
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
        #endregion
        #region Constructors
        public SafetyScannerStatus() { }
        #endregion

    }
}
