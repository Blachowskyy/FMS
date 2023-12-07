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
                    if (_selectedForklift.Data.Errors.PlcErrors != null)
                    {
                        tmp.Status.BatteryReadError = _selectedForklift.Data.Errors.PlcErrors.Status.BatteryReadError;
                        tmp.Status.ForksHeightError = _selectedForklift.Data.Errors.PlcErrors.Status.ForksHeightError;
                        tmp.Status.PressureSensorError = _selectedForklift.Data.Errors.PlcErrors.Status.PressureSensorError;
                        tmp.Status.TiltSensorAxis1Error = _selectedForklift.Data.Errors.PlcErrors.Status.TiltSensorAxis1Error;
                        tmp.Status.TiltSensorAxis2Error = _selectedForklift.Data.Errors.PlcErrors.Status.TiltSensorAxis2Error;
                        tmp.Status.ManualHandleSpeedRegulatorError = _selectedForklift.Data.Errors.PlcErrors.Status.ManualHandleSpeedRegulatorError;
                        tmp.Status.CurtisSpeedWriteError = _selectedForklift.Data.Errors.PlcErrors.Status.CurtisSpeedWriteError;
                        tmp.Status.ScangridLeftError = _selectedForklift.Data.Errors.PlcErrors.Status.ScangridLeftError;
                        tmp.Status.ScangridRightError = _selectedForklift.Data.Errors.PlcErrors.Status.ScangridRightError;
                        tmp.Status.ServoHaltError = _selectedForklift.Data.Errors.PlcErrors.Status.ServoHaltError;
                        tmp.Status.ServoMoveError = _selectedForklift.Data.Errors.PlcErrors.Status.ServoMoveError;
                        tmp.Status.ServoPositionReadError = _selectedForklift.Data.Errors.PlcErrors.Status.ServoPositionReadError;
                        tmp.ErrorCodes.BatteryReadErrorCode = _selectedForklift.Data.Errors.PlcErrors.ErrorCodes.BatteryReadErrorCode;
                        tmp.ErrorCodes.ForksHeightErrorCode = _selectedForklift.Data.Errors.PlcErrors.ErrorCodes.ForksHeightErrorCode;
                        tmp.ErrorCodes.TiltSensorAxis1ErrorCode = _selectedForklift.Data.Errors.PlcErrors.ErrorCodes.TiltSensorAxis1ErrorCode;
                        tmp.ErrorCodes.TiltSensorAxis2ErrorCode = _selectedForklift.Data.Errors.PlcErrors.ErrorCodes.TiltSensorAxis2ErrorCode;
                        tmp.ErrorCodes.ManualHandleSpeedRegulatorErrorCode = _selectedForklift.Data.Errors.PlcErrors.ErrorCodes.ManualHandleSpeedRegulatorErrorCode;
                        tmp.ErrorCodes.CurtisSpeedWriteErrorCode = _selectedForklift.Data.Errors.PlcErrors.ErrorCodes.CurtisSpeedWriteErrorCode;
                        tmp.ErrorCodes.ScangridLeftErrorCode = _selectedForklift.Data.Errors.PlcErrors.ErrorCodes.ScangridLeftErrorCode;
                        tmp.ErrorCodes.ScangridRightErrorCode = _selectedForklift.Data.Errors.PlcErrors.ErrorCodes.ScangridRightErrorCode;
                        tmp.ErrorCodes.PressureSensorErrorCode = _selectedForklift.Data.Errors.PlcErrors.ErrorCodes.PressureSensorErrorCode;
                        tmp.ErrorCodes.ServoMoveErrorCode = _selectedForklift.Data.Errors.PlcErrors.ErrorCodes.ServoMoveErrorCode;
                        tmp.ErrorCodes.ServoHaltErrorCode = _selectedForklift.Data.Errors.PlcErrors.ErrorCodes.ServoHaltErrorCode;
                        tmp.ErrorCodes.ServoPositionReadErrorCode = _selectedForklift.Data.Errors.PlcErrors.ErrorCodes.ServoPositionReadErrorCode;
                    }
                    DisplayedData = tmp;
                    await Task.Delay(100);
                }
            }
        }
        #endregion
    }
}
