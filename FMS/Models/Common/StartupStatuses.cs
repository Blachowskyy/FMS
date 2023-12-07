namespace FMS.Models.Common
{
    public class StartupStatuses
    {
        #region Ethernet test results
        public bool GatewayStart { get; set; }
        public bool LidarLoc {  get; set; }
        public bool Plc {  get; set; }
        public bool LeftLidar { get; set; }
        public bool RightLidar { get; set; }
        public bool FlexiEthernetGateway { get; set; }
        public bool FlexiModbusGateway { get; set; }
        public bool GatewayEnd { get; set; }
        public bool Fms {  get; set; }
        public bool OverallResult { get; set; }
        #endregion
        #region Startup sequence test result
        public bool EthernetTest { get; set; }
        public bool ScangridsTest { get; set; }
        public bool ServoTest { get; set; }
        public bool ForksTest { get; set; }
        public bool CurtisTest { get; set; }
        #endregion
    }
}
