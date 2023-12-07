using FMS.Models.Main;
using FMS.ViewModels.Common;

namespace FMS.ViewModels.LiveForkliftsPages
{
    public class SafetyDataPageViewModel : BaseViewModel
    {
        #region Variables
        private ForkliftData? _dataset;
        public ForkliftData Dataset
        {
            get
            {
                return _dataset ??= new();
            }
            set
            {
                _dataset = value;
                OnPropertyChanged(nameof(Dataset));
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
        public SafetyDataPageViewModel(Forklift selectedForklift)
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
                    ForkliftData tmp = new();
                    if (_selectedForklift.Data.MainSafetyData != null && tmp.MainSafetyData != null)
                    {
                        tmp.MainSafetyData.CpuStatus = _selectedForklift.Data.MainSafetyData.CpuStatus;
                        tmp.MainSafetyData.EncoderStatus = _selectedForklift.Data.MainSafetyData.EncoderStatus;
                        tmp.MainSafetyData.SafetyStandstillStatus = _selectedForklift.Data.MainSafetyData.SafetyStandstillStatus;
                        tmp.MainSafetyData.OverspeedGuardStatus = _selectedForklift.Data.MainSafetyData.OverspeedGuardStatus;
                        tmp.MainSafetyData.LeftEmergencyStopButtonStatus = _selectedForklift.Data.MainSafetyData.LeftEmergencyStopButtonStatus;
                        tmp.MainSafetyData.RightEmergencyStopButtonStatus = _selectedForklift.Data.MainSafetyData.RightEmergencyStopButtonStatus;
                    }
                    if (_selectedForklift.Data.LeftLidar != null && tmp.LeftLidar != null)
                    {
                        tmp.LeftLidar.IsActive = _selectedForklift.Data.LeftLidar.IsActive;
                        tmp.LeftLidar.EmergencyStopZoneStatus = _selectedForklift.Data.LeftLidar.EmergencyStopZoneStatus;
                        tmp.LeftLidar.SoftStopZoneStatus = _selectedForklift.Data.LeftLidar.SoftStopZoneStatus;
                        tmp.LeftLidar.ReducedSpeedZoneStatus = _selectedForklift.Data.LeftLidar.ReducedSpeedZoneStatus;
                        tmp.LeftLidar.MonitoringCaseValid = _selectedForklift.Data.LeftLidar.IsActive;
                        tmp.LeftLidar.ContaminationWarning = _selectedForklift.Data.LeftLidar.IsActive;
                        tmp.LeftLidar.ContaminationError = _selectedForklift.Data.LeftLidar.IsActive;
                        tmp.LeftLidar.AppError = _selectedForklift.Data.LeftLidar.IsActive;
                        tmp.LeftLidar.DeviceError = _selectedForklift.Data.LeftLidar.IsActive;
                    }
                    if (_selectedForklift.Data.RightLidar != null && tmp.RightLidar != null)
                    {
                        tmp.RightLidar.IsActive = _selectedForklift.Data.RightLidar.IsActive;
                        tmp.RightLidar.EmergencyStopZoneStatus = _selectedForklift.Data.RightLidar.EmergencyStopZoneStatus;
                        tmp.RightLidar.SoftStopZoneStatus = _selectedForklift.Data.RightLidar.SoftStopZoneStatus;
                        tmp.RightLidar.ReducedSpeedZoneStatus = _selectedForklift.Data.RightLidar.ReducedSpeedZoneStatus;
                        tmp.RightLidar.MonitoringCaseValid = _selectedForklift.Data.RightLidar.IsActive;
                        tmp.RightLidar.ContaminationWarning = _selectedForklift.Data.RightLidar.IsActive;
                        tmp.RightLidar.ContaminationError = _selectedForklift.Data.RightLidar.IsActive;
                        tmp.RightLidar.AppError = _selectedForklift.Data.RightLidar.IsActive;
                        tmp.RightLidar.DeviceError = _selectedForklift.Data.RightLidar.IsActive;
                    }
                    if (_selectedForklift.Data.LeftScangrid != null && tmp.LeftScangrid != null)
                    {
                        tmp.LeftScangrid.IsActive = _selectedForklift.Data.LeftScangrid.IsActive;
                        tmp.LeftScangrid.MonitoringCaseCanInputStatus = _selectedForklift.Data.LeftScangrid.MonitoringCaseCanInputStatus;
                        tmp.LeftScangrid.MonitoringCaseSwitchInputStatus = _selectedForklift.Data.LeftScangrid.MonitoringCaseSwitchInputStatus;
                        tmp.LeftScangrid.ProtectiveFieldStatus = _selectedForklift.Data.LeftScangrid.ProtectiveFieldStatus;
                        tmp.LeftScangrid.WarningFieldStatus = _selectedForklift.Data.LeftScangrid.WarningFieldStatus;
                        tmp.LeftScangrid.SafetyOutputStatus = _selectedForklift.Data.LeftScangrid.SafetyOutputStatus;
                        tmp.LeftScangrid.SleepModeStatus = _selectedForklift.Data.LeftScangrid.SleepModeStatus;
                        tmp.LeftScangrid.ContaminationWarning = _selectedForklift.Data.LeftScangrid.ContaminationWarning;
                        tmp.LeftScangrid.ContaminationError = _selectedForklift.Data.LeftScangrid.ContaminationError;
                        tmp.LeftScangrid.ResistanceToExternalLightError = _selectedForklift.Data.LeftScangrid.ResistanceToExternalLightError;
                        tmp.LeftScangrid.VoltageError = _selectedForklift.Data.LeftScangrid.VoltageError;
                    }
                    if (_selectedForklift.Data.RightScangrid != null && tmp.RightScangrid != null)
                    {
                        tmp.RightScangrid.IsActive = _selectedForklift.Data.RightScangrid.IsActive;
                        tmp.RightScangrid.MonitoringCaseCanInputStatus = _selectedForklift.Data.RightScangrid.MonitoringCaseCanInputStatus;
                        tmp.RightScangrid.MonitoringCaseSwitchInputStatus = _selectedForklift.Data.RightScangrid.MonitoringCaseSwitchInputStatus;
                        tmp.RightScangrid.ProtectiveFieldStatus = _selectedForklift.Data.RightScangrid.ProtectiveFieldStatus;
                        tmp.RightScangrid.WarningFieldStatus = _selectedForklift.Data.RightScangrid.WarningFieldStatus;
                        tmp.RightScangrid.SafetyOutputStatus = _selectedForklift.Data.RightScangrid.SafetyOutputStatus;
                        tmp.RightScangrid.SleepModeStatus = _selectedForklift.Data.RightScangrid.SleepModeStatus;
                        tmp.RightScangrid.ContaminationWarning = _selectedForklift.Data.RightScangrid.ContaminationWarning;
                        tmp.RightScangrid.ContaminationError = _selectedForklift.Data.RightScangrid.ContaminationError;
                        tmp.RightScangrid.ResistanceToExternalLightError = _selectedForklift.Data.RightScangrid.ResistanceToExternalLightError;
                        tmp.RightScangrid.VoltageError = _selectedForklift.Data.RightScangrid.VoltageError;
                    }
                    Dataset = tmp;
                    await Task.Delay(100);
                }
            }
        }
        #endregion
        #region Buttons logic

        #endregion
        #region ICommands declarations

        #endregion
    }
}
