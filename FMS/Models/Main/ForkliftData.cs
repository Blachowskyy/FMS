using FMS.Models.Common;

namespace FMS.Models.Main
{
    public class ForkliftData
    {
        public DateTime LastDataRefresh { get; set; }
        #region Data from forklift
        public LiveData? LiveParameters { get; set; }
        public SafetyStatus? MainSafetyData { get; set; }
        public SafetyScannerStatus? LeftLidar { get; set; }
        public SafetyScannerStatus? RightLidar { get; set; }
        public ScangridStatus? LeftScangrid { get; set; }
        public ScangridStatus? RightScangrid { get; set; }
        public ForkliftErrors? Errors { get; set; }
        public CurrentWorkstates? ActiveWorkstates { get; set; }
        public StartupStatuses? Startup { get; set; }
        public TebConfigData? ActualTebConfig { get; set; }
        public JobStep? ActualTask { get; set; }
        public Orders? OrdersConfirmations { get; set; }
        #endregion
        #region Data to forklift
        public Orders? OrdersSend { get; set; }
        public JobStep? TaskSend { get; set; }
        public TebConfigData? TebConfigSend { get; set; }
        #endregion
        public ForkliftData()
        {
            TebConfigSend = new();
            ActualTebConfig = new();
            LiveParameters = new();
            MainSafetyData = new();
            LeftLidar = new();
            RightLidar = new();
            LeftScangrid = new();
            RightScangrid = new();
            Errors = new();
            ActualTask = new();
            TaskSend = new();
            TebConfigSend = new();
            ActiveWorkstates = new();
            Startup = new();
            OrdersConfirmations = new();
            OrdersSend = new();
        }
    }
}
