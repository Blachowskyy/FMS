using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Models.Common
{
    public class LiveData : CommonBaseModel
    {
        #region Variables
        private string? _positionX;
        public string PositionX
        {
            get
            {
                return _positionX ?? string.Empty;
            }
            set
            {
                _positionX = value;
                OnPropertyChanged(nameof(PositionX));
            }
        }
        private string? _positionY;
        public string PositionY
        {
            get
            {
                return _positionY ?? string.Empty;
            }
            set
            {
                _positionY = value;
                OnPropertyChanged(nameof(PositionY));
            }
        }
        private string? _positionR;
        public string PositionR
        {
            get
            {
                return _positionR ?? string.Empty;
            }
            set
            {
                _positionR = value;
                OnPropertyChanged(nameof(PositionR));
            }
        }
        private string? _batteryVoltage;
        public string BatteryVoltage
        {
            get
            {
                return _batteryVoltage ?? string.Empty;
            }
            set
            {
                _batteryVoltage = value;
                OnPropertyChanged(nameof(BatteryVoltage));
            }
        }
        private string? _batteryPercentage;
        public string BatteryPercentage
        {
            get
            {
                return _batteryPercentage ?? string.Empty;
            }
            set
            {
                _batteryPercentage = value;
                OnPropertyChanged(nameof(BatteryPercentage));
            }
        }
        private bool _batteryCritical;
        public bool BatteryCritical
        {
            get
            {
                return _batteryCritical;
            }
            set
            {
                _batteryCritical = value;
                OnPropertyChanged(nameof(BatteryCritical));
            }
        }
        private string? _actualForksHeight;
        public string ActualForksHeight
        {
            get
            {
                return _actualForksHeight ?? string.Empty;
            }
            set
            {
                _actualForksHeight = value;
                OnPropertyChanged(nameof(ActualForksHeight));
            }
        }
        private bool _forksHeightLimiter;
        public bool ForksHeightLimiter
        {
            get
            {
                return _forksHeightLimiter;
            }
            set
            {
                _forksHeightLimiter = value;
                OnPropertyChanged(nameof(ForksHeightLimiter));
            }
        }
        private string? _liveWeight;
        public string LiveWeight
        {
            get
            {
                return _liveWeight ?? string.Empty;
            }
            set
            {
                _liveWeight = value;
                OnPropertyChanged(nameof(LiveWeight));
            }
        }
        private string? _savedCargoWeight;
        public string SavedCargoWeight
        {
            get
            {
                return _savedCargoWeight ?? string.Empty;
            }
            set
            {
                _savedCargoWeight = value;
                OnPropertyChanged(nameof(SavedCargoWeight));
            }
        }
        private string? _tiltAxis1;
        public string TiltAxis1
        {
            get
            {
                return _tiltAxis1 ?? string.Empty;
            }
            set
            {
                _tiltAxis1 = value;
                OnPropertyChanged(nameof(TiltAxis1));
            }
        }
        private string? _tiltAxis2;
        public string TiltAxis2
        {
            get
            {
                return _tiltAxis2 ?? string.Empty;
            }
            set
            {
                _tiltAxis2 = value;
                OnPropertyChanged(nameof(TiltAxis2));
            }
        }
        private string? _overallDistanceMiliMeters;
        public string OverallDistanceMiliMeters
        {
            get
            {
                return _overallDistanceMiliMeters ?? string.Empty;
            }
            set
            {
                _overallDistanceMiliMeters = value;
                OnPropertyChanged(nameof(OverallDistanceMiliMeters));
            }
        }
        private string? _overallDistanceMeters;
        public string OverallDistanceMeters
        {
            get
            {
                return _overallDistanceMeters ?? string.Empty;
            }
            set
            {
                _overallDistanceMeters = value;
                OnPropertyChanged(nameof(OverallDistanceMeters));
            }
        }
        private string? _overallDistanceKiloMeters;
        public string OverallDistanceKiloMeters
        {
            get
            {
                return _overallDistanceKiloMeters ?? string.Empty;
            }
            set
            {
                _overallDistanceKiloMeters = value;
                OnPropertyChanged(nameof(OverallDistanceKiloMeters));
            }
        }
        private string? _servoAngle;
        public string ServoAngle
        {
            get
            {
                return _servoAngle ?? string.Empty;
            }
            set
            {
                _servoAngle = value;
                OnPropertyChanged(nameof(ServoAngle));
            }
        }
        private string? _currentPWM;
        public string CurrentPWM
        {
            get
            {
                return _currentPWM ?? string.Empty;
            }
            set
            {
                _currentPWM = value;
                OnPropertyChanged(nameof(CurrentPWM));
            }
        }
        private string? _speed;
        public string Speed
        {
            get
            {
                return _speed ?? string.Empty;
            }
            set
            {
                _speed = value;
                OnPropertyChanged(nameof(Speed));
            }
        }
        #endregion
        #region Constructors
        public LiveData() { }
        #endregion
    }
}
