namespace FMS.Models.Common.Errors
{
    public class DeltaErrorCodes 
    {
        public string? PressureSensorErrorCode { get; set; }
        public string? ForksHeightErrorCode { get; set; }
        public string? TiltSensorAxis1ErrorCode { get; set; }
        public string? TiltSensorAxis2ErrorCode { get; set; }
        public string? BatteryReadErrorCode { get; set; }
        public string? ManualHandleSpeedRegulatorErrorCode { get; set; }
        public string? CurtisSpeedWriteErrorCode { get; set; }
        public string? ServoPositionReadErrorCode { get; set; }
        public string? ServoMoveErrorCode { get; set; }
        public string? ServoHaltErrorCode { get; set; }
        public string? ScangridLeftErrorCode { get; set; }
        public string? ScangridRightErrorCode { get; set; }
        public DeltaErrorCodes()
        {
             PressureSensorErrorCode = "";
            ForksHeightErrorCode = "";
            TiltSensorAxis1ErrorCode = "";
            TiltSensorAxis2ErrorCode = "";
            BatteryReadErrorCode = "";
            ManualHandleSpeedRegulatorErrorCode = "";
            CurtisSpeedWriteErrorCode = "";
            ServoPositionReadErrorCode = "";
            ServoMoveErrorCode = "";
            ServoHaltErrorCode = "";
            ScangridLeftErrorCode = "";
            ScangridRightErrorCode = "";  
        }
    }
}
