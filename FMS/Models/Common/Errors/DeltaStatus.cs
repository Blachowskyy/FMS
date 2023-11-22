using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Models.Common.Errors
{
    public class DeltaStatus : CommonBaseModel
    {
        #region Variables
        private bool _pressureSensor;
        public bool PressureSensor
        {
            get
            {
                return _pressureSensor;
            }
            set
            {
                _pressureSensor = value;
                OnPropertyChanged(nameof(PressureSensor));
            }
        }
        private bool _forksHeightSensor;
        public bool ForksHeightSensor
        {
            get
            {
                return _forksHeightSensor;
            }
            set
            {
                _forksHeightSensor = value;
                OnPropertyChanged(nameof(ForksHeightSensor));
            }
        }
        private bool _tiltSensorAxis1;
        public bool TiltSensorAxis1
        {
            get
            {
                return _tiltSensorAxis1;
            }
            set
            {
                _tiltSensorAxis1 = value;
                OnPropertyChanged(nameof(TiltSensorAxis1));
            }
        }
        private bool _tiltSensorAxis2;
        public bool TiltSensorAxis2
        {
            get
            {
                return _tiltSensorAxis2;
            }
            set
            {
                _tiltSensorAxis2 = value;
                OnPropertyChanged(nameof(TiltSensorAxis2));
            }
        }
        private bool _batteryRead;
        public bool BatteryRead
        {
            get
            {
                return _batteryRead;
            }
            set
            {
                _batteryRead = value;
                OnPropertyChanged(nameof(BatteryRead));
            }
        }
        private bool _manualHandleSpeedRegulator;
        public bool ManualHandleSpeedRegulator
        {
            get
            {
                return _manualHandleSpeedRegulator;
            }
            set
            {
                _manualHandleSpeedRegulator = value;
                OnPropertyChanged(nameof(ManualHandleSpeedRegulator));
            }
        }
        private bool _curtisSpeedWriteError;
        public bool CurtisSpeedWriteError
        {
            get
            {
                return _curtisSpeedWriteError;
            }
            set
            {
                _curtisSpeedWriteError = value;
                OnPropertyChanged(nameof(CurtisSpeedWriteError));
            }
        }
        private bool _servoPositionReadError;
        public bool ServoPositionReadError
        {
            get
            {
                return _servoPositionReadError;
            }
            set
            {
                _servoPositionReadError = value;
                OnPropertyChanged(nameof(ServoPositionReadError));
            }
        }
        private bool _servoMoveError;
        public bool ServoMoveError
        {
            get
            {
                return _servoMoveError;
            }
            set
            {
                _servoMoveError = value;
                OnPropertyChanged(nameof(ServoMoveError));
            }
        }
        private bool _servoHaltError;
        public bool ServoHaltError
        {
            get
            {
                return _servoHaltError;
            }
            set
            {
                _servoHaltError = value;
                OnPropertyChanged(nameof(ServoHaltError));
            }
        }
        private bool _scangridLeftError;
        public bool ScangridLeftError
        {
            get
            {
                return _scangridLeftError;
            }
            set
            {
                _scangridLeftError = value;
                OnPropertyChanged(nameof(ScangridLeftError));
            }
        }
        private bool _scangridRightError;
        public bool ScangridRightError
        {
            get
            {
                return _scangridRightError;
            }
            set
            {
                _scangridRightError = value;
                OnPropertyChanged(nameof(ScangridRightError));
            }
        }
        #endregion
        #region Constructors
        public DeltaStatus() { }
        #endregion
    }
}
