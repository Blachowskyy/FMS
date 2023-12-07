namespace FMS.Models.Common
{
    public class SafetyScannerStatus
    {
        public bool ReducedSpeedZoneStatus { get; set; }
        public bool SoftStopZoneStatus { get; set; }
        public bool EmergencyStopZoneStatus { get; set; }
        public bool IsActive { get; set; }
        public bool MonitoringCaseValid { get; set; }
        public bool AppError { get; set; }
        public bool DeviceError { get; set; }
        public bool ContaminationWarning { get; set; }
        public bool ContaminationError { get; set; }
    }
}
