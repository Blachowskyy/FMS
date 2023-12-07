namespace FMS.Models.Common.Errors
{
    public class DeltaStatus 
    {
        public bool PressureSensorError { get; set; }
        public bool ForksHeightError { get; set; }
        public bool TiltSensorAxis1Error { get; set; }
        public bool TiltSensorAxis2Error { get; set; }
        public bool BatteryReadError { get; set; }
        public bool ManualHandleSpeedRegulatorError { get; set; }
        public bool CurtisSpeedWriteError { get; set; }
        public bool ServoPositionReadError { get; set; }
        public bool ServoMoveError { get; set; }
        public bool ServoHaltError { get; set; }
        public bool ScangridLeftError { get; set; }
        public bool ScangridRightError { get; set; }
    }
}
