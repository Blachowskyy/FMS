namespace FMS.Models.Common
{
    public class StartupStatuses : CommonBaseModel
    {
        #region Variables
        #region Ethernet
        private bool _gatewayStart;
        public bool GatewayStart
        {
            get
            {
                return _gatewayStart;
            }
            set
            {
                _gatewayStart = value;
                OnPropertyChanged(nameof(GatewayStart));
            }
        }
        private bool _lidarLoc;
        public bool LidarLoc
        {
            get
            {
                return _lidarLoc;
            }
            set
            {
                _lidarLoc = value;
                OnPropertyChanged(nameof(LidarLoc));
            }
        }
        private bool _plc;
        public bool Plc
        {
            get
            {
                return _plc;
            }
            set
            {
                _plc = value;
                OnPropertyChanged(nameof(Plc));
            }
        }
        private bool _safetyScannerLeft;
        public bool SafetyScannerLeft
        {
            get
            {
                return _safetyScannerLeft;
            }
            set
            {
                _safetyScannerLeft = value;
                OnPropertyChanged(nameof(SafetyScannerLeft));
            }
        }
        private bool _safetyScannerRight;
        public bool SafetyScannerRight
        {
            get
            {
                return _safetyScannerRight;
            }
            set
            {
                _safetyScannerRight = value;
                OnPropertyChanged(nameof(SafetyScannerRight));
            }
        }
        private bool _flexiGatewayEthernet;
        public bool FlexiGatewayEthernet
        {
            get
            {
                return _flexiGatewayEthernet;
            }
            set
            {
                _flexiGatewayEthernet = value;
                OnPropertyChanged(nameof(FlexiGatewayEthernet));
            }
        }
        private bool _flexiGatewayModbus;
        public bool FlexiGatewayModbus
        {
            get
            {
                return _flexiGatewayModbus;
            }
            set
            {
                _flexiGatewayModbus = value;
                OnPropertyChanged(nameof(FlexiGatewayModbus));
            }
        }
        private bool _gatewayEnd;
        public bool GatewayEnd
        {
            get
            {
                return _gatewayEnd;
            }
            set
            {
                _gatewayEnd = value;
                OnPropertyChanged(nameof(GatewayEnd));
            }
        }
        private bool _fms;
        public bool Fms
        {
            get
            {
                return _fms;
            }
            set
            {
                _fms = value;
                OnPropertyChanged(nameof(Fms));
            }
        }
        private bool _overallResult;
        public bool OverallResult
        {
            get
            {
                return _overallResult;
            }
            set
            {
                _overallResult = value;
                OnPropertyChanged(nameof(OverallResult));
            }
        }
        #endregion
        #region Startup test
        private bool _ethernetTest;
        public bool EthernetTest
        {
            get
            {
                return _ethernetTest;
            }
            set
            {
                _ethernetTest = value;
                OnPropertyChanged(nameof(EthernetTest));
            }
        }
        private bool _scangridsTest;
        public bool ScangridsTest
        {
            get
            {
                return _scangridsTest;
            }
            set
            {
                _scangridsTest = value;
                OnPropertyChanged(nameof(ScangridsTest));
            }
        }
        private bool _servoTest;
        public bool ServoTest
        {
            get
            {
                return _servoTest;
            }
            set
            {
                _servoTest = value;
                OnPropertyChanged(nameof(ServoTest));
            }
        }
        private bool _curtisTest;
        public bool CurtisTest
        {
            get
            {
                return _curtisTest;
            }
            set
            {
                _curtisTest = value;
                OnPropertyChanged(nameof(CurtisTest));
            }
        }
        private bool _forksTest;
        public bool ForksTest
        {
            get
            {
                return _forksTest;
            }
            set
            {
                _forksTest = value;
                OnPropertyChanged(nameof(ForksTest));
            }
        }
        #endregion
        #endregion
        #region Constructors
        public StartupStatuses() { }
        #endregion
    }
}
