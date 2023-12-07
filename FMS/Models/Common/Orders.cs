namespace FMS.Models.Common
{
    public class Orders
    {
        public bool StartAutoMode { get; set; }
        public bool StartManualMode { get; set; }
        public bool StartWork {  get; set; }
        public bool PauseWork { get; set; }
        public bool StopWork { get; set; }
        public bool ContinueWork { get; set; }
        public bool EmergencyStop {  get; set; }
        public bool StartTask { get; set; }
        public bool StopTask { get; set; }
        public bool CancelTask { get; set; }
    }
}
