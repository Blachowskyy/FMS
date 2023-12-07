namespace FMS.Models.Common
{
    public class SafetyStatus 
    {
        public bool CpuStatus { get; set; }
        public bool EncoderStatus { get; set; }
        public bool SafetyStandstillStatus { get; set; }
        public bool OverspeedGuardStatus { get; set; }
        public bool LeftEmergencyStopButtonStatus { get; set; }
        public bool RightEmergencyStopButtonStatus { get; set; }
    }
}
