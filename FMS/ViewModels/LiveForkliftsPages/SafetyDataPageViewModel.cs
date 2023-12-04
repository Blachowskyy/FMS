using FMS.Models.Common;
using FMS.Models.Main;
using FMS.ViewModels.Common;
using Serilog;

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
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("Logs/myapp.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
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
                    if (_selectedForklift.Data.SafetyData != null && tmp.SafetyData != null)
                    {
                        tmp.SafetyData.CpuStatus = _selectedForklift.Data.SafetyData.CpuStatus;
                        tmp.SafetyData.EncoderStatus = _selectedForklift.Data.SafetyData.EncoderStatus;
                        tmp.SafetyData.Standstill = _selectedForklift.Data.SafetyData.Standstill;
                        tmp.SafetyData.OverpseedGuardStatus = _selectedForklift.Data.SafetyData.OverpseedGuardStatus;
                        tmp.SafetyData.LeftEmergencyStopButtonStatus = _selectedForklift.Data.SafetyData.LeftEmergencyStopButtonStatus;
                        tmp.SafetyData.RightEmergencyStopButtonStatus = _selectedForklift.Data.SafetyData.RightEmergencyStopButtonStatus;
                    }
                    if (_selectedForklift.Data.LeftSafetyScanner != null && tmp.LeftSafetyScanner != null)
                    {
                        tmp.LeftSafetyScanner.IsActive = _selectedForklift.Data.LeftSafetyScanner.IsActive;
                        tmp.LeftSafetyScanner.EmergencyZoneStatus = _selectedForklift.Data.LeftSafetyScanner.EmergencyZoneStatus;
                        tmp.LeftSafetyScanner.SoftStopZoneStatus = _selectedForklift.Data.LeftSafetyScanner.SoftStopZoneStatus;
                        tmp.LeftSafetyScanner.ReducedSpeedZoneStatus = _selectedForklift.Data.LeftSafetyScanner.ReducedSpeedZoneStatus;
                        tmp.LeftSafetyScanner.MonitoringCaseValid = _selectedForklift.Data.LeftSafetyScanner.IsActive;
                        tmp.LeftSafetyScanner.ContaminationWarning = _selectedForklift.Data.LeftSafetyScanner.IsActive;
                        tmp.LeftSafetyScanner.ContaminationError = _selectedForklift.Data.LeftSafetyScanner.IsActive;
                        tmp.LeftSafetyScanner.AppError = _selectedForklift.Data.LeftSafetyScanner.IsActive;
                        tmp.LeftSafetyScanner.DeviceError = _selectedForklift.Data.LeftSafetyScanner.IsActive;
                    }
                    if (_selectedForklift.Data.RightSafetyScanner != null && tmp.RightSafetyScanner != null)
                    {
                        tmp.RightSafetyScanner.IsActive = _selectedForklift.Data.RightSafetyScanner.IsActive;
                        tmp.RightSafetyScanner.EmergencyZoneStatus = _selectedForklift.Data.RightSafetyScanner.EmergencyZoneStatus;
                        tmp.RightSafetyScanner.SoftStopZoneStatus = _selectedForklift.Data.RightSafetyScanner.SoftStopZoneStatus;
                        tmp.RightSafetyScanner.ReducedSpeedZoneStatus = _selectedForklift.Data.RightSafetyScanner.ReducedSpeedZoneStatus;
                        tmp.RightSafetyScanner.MonitoringCaseValid = _selectedForklift.Data.RightSafetyScanner.IsActive;
                        tmp.RightSafetyScanner.ContaminationWarning = _selectedForklift.Data.RightSafetyScanner.IsActive;
                        tmp.RightSafetyScanner.ContaminationError = _selectedForklift.Data.RightSafetyScanner.IsActive;
                        tmp.RightSafetyScanner.AppError = _selectedForklift.Data.RightSafetyScanner.IsActive;
                        tmp.RightSafetyScanner.DeviceError = _selectedForklift.Data.RightSafetyScanner.IsActive;
                    }
                    if (_selectedForklift.Data.LeftScangrid != null && tmp.LeftScangrid != null)
                    {
                        tmp.LeftScangrid.IsActive = _selectedForklift.Data.LeftScangrid.IsActive;
                        tmp.LeftScangrid.MonitoringCaseCanInputStatus = _selectedForklift.Data.LeftScangrid.MonitoringCaseCanInputStatus;
                        tmp.LeftScangrid.MonitoringCaseSwitchInputStatus = _selectedForklift.Data.LeftScangrid.MonitoringCaseSwitchInputStatus;
                        tmp.LeftScangrid.ProtectiveFieldStatus = _selectedForklift.Data.LeftScangrid.ProtectiveFieldStatus;
                        tmp.LeftScangrid.WarningFieldStatus = _selectedForklift.Data.LeftScangrid.WarningFieldStatus;
                        tmp.LeftScangrid.SafetyOutput = _selectedForklift.Data.LeftScangrid.SafetyOutput;
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
                        tmp.RightScangrid.SafetyOutput = _selectedForklift.Data.RightScangrid.SafetyOutput;
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
