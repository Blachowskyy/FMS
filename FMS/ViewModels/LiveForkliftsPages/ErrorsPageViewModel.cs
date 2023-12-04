using FMS.Models.Common;
using FMS.Models.Main;
using FMS.ViewModels.Common;

namespace FMS.ViewModels.LiveForkliftsPages
{
    public class ErrorsPageViewModel : BaseViewModel
    {
        #region Variables
        private DeltaErrors? _displayedData;
        public DeltaErrors DisplayedData
        {
            get
            {
                return _displayedData ??= new();
            }
            set
            {
                _displayedData = value;
                OnPropertyChanged(nameof(DisplayedData));
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
        public ErrorsPageViewModel(Forklift selectedForklift)
        {

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
                    DeltaErrors tmp = new();
                    if (_selectedForklift.Data.PlcErrors != null)
                    {
                        tmp.ErrorStatus.BatteryRead = _selectedForklift.Data.PlcErrors.ErrorStatus.BatteryRead;
                        tmp.ErrorStatus.ForksHeightSensor = _selectedForklift.Data.PlcErrors.ErrorStatus.ForksHeightSensor;
                        tmp.ErrorStatus.PressureSensor = _selectedForklift.Data.PlcErrors.ErrorStatus.PressureSensor;
                        tmp.ErrorStatus.TiltSensorAxis1 = _selectedForklift.Data.PlcErrors.ErrorStatus.TiltSensorAxis1;
                        tmp.ErrorStatus.TiltSensorAxis2 = _selectedForklift.Data.PlcErrors.ErrorStatus.TiltSensorAxis2;
                        tmp.ErrorStatus.ManualHandleSpeedRegulator = _selectedForklift.Data.PlcErrors.ErrorStatus.ManualHandleSpeedRegulator;
                        tmp.ErrorStatus.CurtisSpeedWriteError = _selectedForklift.Data.PlcErrors.ErrorStatus.CurtisSpeedWriteError;
                        tmp.ErrorStatus.ScangridLeftError = _selectedForklift.Data.PlcErrors.ErrorStatus.ScangridLeftError;
                        tmp.ErrorStatus.ScangridRightError = _selectedForklift.Data.PlcErrors.ErrorStatus.ScangridRightError;
                        tmp.ErrorStatus.ServoHaltError = _selectedForklift.Data.PlcErrors.ErrorStatus.ServoHaltError;
                        tmp.ErrorStatus.ServoMoveError = _selectedForklift.Data.PlcErrors.ErrorStatus.ServoMoveError;
                        tmp.ErrorStatus.ServoPositionReadError = _selectedForklift.Data.PlcErrors.ErrorStatus.ServoPositionReadError;
                        tmp.ErrorCodes.BatteryReadErrorCode = _selectedForklift.Data.PlcErrors.ErrorCodes.BatteryReadErrorCode;
                        tmp.ErrorCodes.ForksHeightErrorCode = _selectedForklift.Data.PlcErrors.ErrorCodes.ForksHeightErrorCode;
                        tmp.ErrorCodes.TiltSensorAxis1ErrorCode = _selectedForklift.Data.PlcErrors.ErrorCodes.TiltSensorAxis1ErrorCode;
                        tmp.ErrorCodes.TiltSensorAxis2ErrorCode = _selectedForklift.Data.PlcErrors.ErrorCodes.TiltSensorAxis2ErrorCode;
                        tmp.ErrorCodes.ManualHandleSpeedRegulatorErrorCode = _selectedForklift.Data.PlcErrors.ErrorCodes.ManualHandleSpeedRegulatorErrorCode;
                        tmp.ErrorCodes.CurtisSpeedWriteErrorCode = _selectedForklift.Data.PlcErrors.ErrorCodes.CurtisSpeedWriteErrorCode;
                        tmp.ErrorCodes.ScangridLeftErrorCode = _selectedForklift.Data.PlcErrors.ErrorCodes.ScangridLeftErrorCode;
                        tmp.ErrorCodes.ScangridRightErrorCode = _selectedForklift.Data.PlcErrors.ErrorCodes.ScangridRightErrorCode;
                        tmp.ErrorCodes.PressureSensorErrorCode = _selectedForklift.Data.PlcErrors.ErrorCodes.PressureSensorErrorCode;
                        tmp.ErrorCodes.ServoMoveErrorCode = _selectedForklift.Data.PlcErrors.ErrorCodes.ServoMoveErrorCode;
                        tmp.ErrorCodes.ServoHaltErrorCode = _selectedForklift.Data.PlcErrors.ErrorCodes.ServoHaltErrorCode;
                        tmp.ErrorCodes.ServoPositionReadErrorCode = _selectedForklift.Data.PlcErrors.ErrorCodes.ServoPositionReadErrorCode;
                    }
                    DisplayedData = tmp;
                    await Task.Delay(100);
                }
            }
        }
        #endregion
    }
}
