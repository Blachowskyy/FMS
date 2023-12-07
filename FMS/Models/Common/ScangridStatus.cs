namespace FMS.Models.Common
{
    public class ScangridStatus
    {
        public bool IsActive { get; set; }
        public bool SafetyOutputStatus { get; set; }
        public bool ProtectiveFieldStatus { get; set; }
        public bool WarningFieldStatus { get; set; }
        public bool ContaminationWarning { get; set; }
        public bool ContaminationError { get; set; }
        public bool MonitoringCaseSwitchInputStatus { get; set; }
        public bool MonitoringCaseCanInputStatus { get; set; }
        public bool VoltageError { get; set; }
        public bool ResistanceToExternalLightError { get; set; }
        public bool SleepModeStatus { get; set; }
    }
}
