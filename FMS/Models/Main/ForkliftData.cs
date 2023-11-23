using FMS.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Models.Main
{
    public class ForkliftData : BaseModel
    {
        #region Variables
        private string? _lastDataUpdate;
        public string LastDataUpdate
        {
            get
            {
                return _lastDataUpdate ?? string.Empty;
            }
            set
            {
                _lastDataUpdate = value;
                OnPropertyChanged(nameof(LastDataUpdate));
            }
        }
        #region Data In
        private LiveData? _liveParameters;
        public LiveData LiveParameters
        {
            get
            {
                _liveParameters ??= new LiveData();
                return _liveParameters;
            }
            set
            {
                _liveParameters = value;
                OnPropertyChanged(nameof(LiveParameters));
            }
        }
        private SafetyStatus? _safetyData;
        public SafetyStatus? SafetyData
        {
            get
            {
                _safetyData ??= new SafetyStatus();
                return _safetyData;
            }
            set
            {
                _safetyData = value;
                OnPropertyChanged(nameof(SafetyData));
            }
        }
        private SafetyScannerStatus? _leftSafetyScanner;
        public SafetyScannerStatus LeftSafetyScanner
        {
            get
            {
                _leftSafetyScanner ??= new SafetyScannerStatus();
                return _leftSafetyScanner;
            }
            set
            {
                _leftSafetyScanner = value;
                OnPropertyChanged(nameof(LeftSafetyScanner));
            }
        }
        private SafetyScannerStatus? _rightSafetyScanner;
        public SafetyScannerStatus RightSafetyScanner
        {
            get
            {
                _rightSafetyScanner ??= new SafetyScannerStatus();
                return _rightSafetyScanner;
            }
            set
            {
                _rightSafetyScanner = value;
                OnPropertyChanged(nameof(RightSafetyScanner));
            }
        }
        private ScangridStatus? _leftScangrid;
        public ScangridStatus LeftScangrid
        {
            get
            {
                _leftScangrid ??= new ScangridStatus();
                return _leftScangrid;
            }
            set
            {
                _leftScangrid = value;
                OnPropertyChanged(nameof(LeftScangrid));
            }
        }
        private ScangridStatus? _rightScangrid;
        public ScangridStatus RightScangrid
        {
            get
            {
                _rightScangrid ??= new ScangridStatus();
                return _rightScangrid;
            }
            set
            {
                _rightScangrid = value;
                OnPropertyChanged(nameof(RightScangrid));
            }
        }
        private DeltaErrors? _plcErrors;
        public DeltaErrors? PlcErrors
        {
            get
            {
                _plcErrors ??= new DeltaErrors();
                return _plcErrors;
            }
            set
            {
                _plcErrors = value;
                OnPropertyChanged(nameof(PlcErrors));
            }
        }
        private CurrentWorkstates? _actualWorkstates;
        public CurrentWorkstates ActualWorkstates
        {
            get
            {
                _actualWorkstates ??= new CurrentWorkstates();
                return _actualWorkstates;
            }
            set
            {
                _actualWorkstates = value;
                OnPropertyChanged(nameof(ActualWorkstates));
            }
        }
        private StartupStatuses? _startup;
        public StartupStatuses Startup
        {
            get
            {
                _startup ??= new StartupStatuses();
                return _startup;
            }
            set
            {
                _startup = value;
                OnPropertyChanged(nameof(Startup));
            }
        }
        private TebConfigData? _actualTebConfig;
        public TebConfigData ActualTebConfig
        {
            get
            {
                _actualTebConfig ??= new TebConfigData();
                return _actualTebConfig;
            }
            set
            {
                _actualTebConfig = value;
                OnPropertyChanged(nameof(ActualTebConfig));
            }
        }
        private JobStep? _actualTask;
        public JobStep ActualTask
        {
            get
            {
                _actualTask ??= new JobStep();
                return _actualTask;
            }
            set
            {
                _actualTask = value;
                OnPropertyChanged(nameof(ActualTask));
            }
        }
        private Orders? _ordersConfirmations;
        public Orders OrdersConfirmations
        {
            get
            {
                _ordersConfirmations ??= new Orders();
                return _ordersConfirmations;
            }
            set
            {
                _ordersConfirmations = value;
                OnPropertyChanged(nameof(OrdersConfirmations));
            }
        }

        #endregion
        #region Data Out
        private Orders? _ordersSend;
        public Orders OrdersSend
        {
            get
            {
                _ordersSend ??= new Orders();
                return _ordersSend;
            }
            set
            {
                _ordersSend = value;
                OnPropertyChanged(nameof(OrdersSend));
            }
        }
        private JobStep? _taskSend;
        public JobStep TaskSend
        {
            get
            {
                _taskSend ??= new JobStep();
                return _taskSend;
            }
            set
            {
                _taskSend = value;
                OnPropertyChanged(nameof(TaskSend));
            }
        }
        private TebConfigData? _tebConfig;
        public TebConfigData TebConfig
        {
            get
            {
                _tebConfig = new TebConfigData();
                return _tebConfig;
            }
            set
            {
                _tebConfig = value;
                OnPropertyChanged(nameof(TebConfig));
            }
        }

        #endregion
        #endregion
        #region Constructors
        public ForkliftData() { }
        #endregion
    }
}
