using FMS.Models.Common;
using FMS.Models.Main;
using FMS.ViewModels.Common;

namespace FMS.ViewModels.LiveForkliftsPages
{
    public class ActualParametersPageViewModel : BaseViewModel
    {
        #region Variables
        private LiveData? _data;
        public LiveData Data
        {
            get
            {
                return _data ??= new();
            }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
        private DateTime _refreshDate;
        public DateTime RefreshDate
        {
            get
            {
                return _refreshDate;
            }
            set
            {
                _refreshDate = value;
                OnPropertyChanged(nameof(RefreshDate));
            }
        }
        private Forklift? _selectedForklift;
        public Forklift SelectedForklift
        {
            get
            {
                return _selectedForklift ??= new();
            }
            set
            {
                _selectedForklift = value;
                OnPropertyChanged(nameof(SelectedForklift));
            }
        }
        #endregion
        #region Constructor
        public ActualParametersPageViewModel(Forklift selectedForklift)
        {
            
            SelectedForklift = selectedForklift;
            if (_selectedForklift != null)
            {
                if(_selectedForklift.Client != null)
                {
                    Task.Run(() => { DataRefresh(); });
                }
            }
        }
        #endregion
        #region Program logic
        private async void DataRefresh()
        {
            if (_selectedForklift != null)
            {
                while (_selectedForklift.Client.Connected)
                {
                    LiveData tmp = new()
                    {
                        PositionX = _selectedForklift.Data.LiveParameters.PositionX,
                        PositionY = _selectedForklift.Data.LiveParameters.PositionY,
                        PositionR = _selectedForklift.Data.LiveParameters.PositionR,
                        BatteryVoltage = _selectedForklift.Data.LiveParameters.BatteryVoltage,
                        BatteryPercentage = _selectedForklift.Data.LiveParameters.BatteryPercentage,
                        BatteryCritical = _selectedForklift.Data.LiveParameters.BatteryCritical,
                        TiltAxis1 = _selectedForklift.Data.LiveParameters.TiltAxis1,
                        TiltAxis2 = _selectedForklift.Data.LiveParameters.TiltAxis2,
                        ActualForksHeight = _selectedForklift.Data.LiveParameters.ActualForksHeight,
                        ForksHeightLimiter = _selectedForklift.Data.LiveParameters.ForksHeightLimiter,
                        WeightOnForks = _selectedForklift.Data.LiveParameters.WeightOnForks,
                        CargoWeight = _selectedForklift.Data.LiveParameters.CargoWeight,
                        OverallDistanceMilimeters = _selectedForklift.Data.LiveParameters.OverallDistanceMilimeters,
                        OverallDistanceMeters = _selectedForklift.Data.LiveParameters.OverallDistanceMeters,
                        OverallDistanceKilometers = _selectedForklift.Data.LiveParameters.OverallDistanceKilometers,
                        Pwm = _selectedForklift.Data.LiveParameters.Pwm,
                        ServoAngle = _selectedForklift.Data.LiveParameters.ServoAngle,
                        Speed = _selectedForklift.Data.LiveParameters.Speed
                    };
                    RefreshDate = _selectedForklift.Data.LastDataRefresh;
                    Data = tmp;
                    await Task.Delay(100);
                }
            }
        }
        #endregion
        #region Buttons logic

        #endregion
        #region ICommands declarations

        #endregion
    }
}
