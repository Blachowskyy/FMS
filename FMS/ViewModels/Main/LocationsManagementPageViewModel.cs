using FMS.Models.Main;
using FMS.Services.Common.DataServices;
using FMS.ViewModels.Common;
using System.Windows.Input;

namespace FMS.ViewModels.Main
{
    public class LocationsManagementPageViewModel : BaseViewModel
    {
        #region Variables
        private Location? _displayedLocation;
        public Location DisplayedLocation
        {
            get
            {
                return _displayedLocation ??= new();
            }
            set
            {
                _displayedLocation = value;
                OnPropertyChanged(nameof(DisplayedLocation));
            }
        }
        private IEnumerable<Location>? _savedLcoations;
        public IEnumerable<Location> SavedLocations
        {
            get
            {
                return _savedLcoations ??= Enumerable.Empty<Location>();
            }
            set
            {
                _savedLcoations = value;
                OnPropertyChanged(nameof(SavedLocations));
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
        private List<Forklift>? _onlineForklifts;
        public List<Forklift> OnlineForklifts
        {
            get
            {
                return _onlineForklifts ??= [];
            }
            set
            {
                _onlineForklifts = value;
                OnPropertyChanged(nameof(OnlineForklifts));
            }
        }
        private readonly LocationDataService _locationData;
        #endregion
        #region Constructor
        public LocationsManagementPageViewModel(LocationDataService locationData, List<Forklift> connectedForklifts)
        {
            _locationData = locationData;
            OnlineForklifts = connectedForklifts;

            GetLocationFromSelectedForkliftButtonClick = new RelayCommand(ExecuteGetLocationFromSelectedForklift);
            SelectForkliftFromList = new RelayCommand(ExecuteSelectForkliftFromList);
            SelectLocationFromList = new RelayCommand(ExecuteSelectLocationFromList);
            SaveLocationButtonClick = new RelayCommand(SaveLocation);
            EditLocationButtonClick = new RelayCommand(EditLocation);
            DeleteLocationButtonClick = new RelayCommand(DeleteLocation);
        }
        #endregion
        #region Program logic
        private async void RefreshLocationsList()
        {
            if(_locationData != null)
            {
                SavedLocations = await _locationData.GetAll();
            }
        }
        private bool CheckLocationData(Location location)
        {
            bool result = true;
            if (location == null) { result = false; }
            if (location.PositionX == null ||  location.PositionX == string.Empty) { result = false; }
            if (location.PositionY == null || location.PositionY == string.Empty) { result = false; }
            if (location.PositionR == null  || location.PositionR == string.Empty) { result = false; }
            if (location.LocationType <= 0) { result = false; }
            return result;
        }
        #endregion
        #region Buttons logic
        private void ExecuteGetLocationFromSelectedForklift(object? param)
        {
            if(_selectedForklift != null)
            {
                DisplayedLocation.PositionX = _selectedForklift.Data.LiveParameters.PositionX;
                DisplayedLocation.PositionY = _selectedForklift.Data.LiveParameters.PositionY;
                DisplayedLocation.PositionR = _selectedForklift.Data.LiveParameters.PositionR;
            }
        }
        private void ExecuteSelectForkliftFromList(object? param)
        {
            if (param != null && _onlineForklifts != null)
            {
                foreach (Forklift fork in  _onlineForklifts)
                {
                    if (fork != null)
                    {
                        if (fork.Id == Convert.ToInt32(param))
                        {
                            SelectedForklift = fork;
                            break;
                        }
                    }
                }
            }
        }
        private async void ExecuteSelectLocationFromList(object? param)
        {
            if (param != null && _locationData != null)
            {
                DisplayedLocation = await _locationData.Get(Convert.ToInt32(param));
            }
        }
        private async void SaveLocation(object? param)
        {
            if (_displayedLocation != null)
            {
                if (CheckLocationData(_displayedLocation))
                {
                    if (_locationData != null)
                    {
                        try
                        {
                            await _locationData.Create(_displayedLocation);
                            RefreshLocationsList();
                        }
                        catch (Exception ex)
                        {

                        }
                    }
                }
            }
        }
        private async void EditLocation(object? param)
        {
            if (_displayedLocation != null)
            {
                if (CheckLocationData(_displayedLocation))
                {
                    if (_locationData != null)
                    {
                        try
                        {
                            await _locationData.Update(_displayedLocation.Id, _displayedLocation);
                            RefreshLocationsList();
                        }
                        catch (Exception ex)
                        {

                        } 
                    }
                }
            }
        }
        private void DeleteLocation(object? param)
        {

        }
        #endregion
        #region ICommand declarations
        public ICommand? GetLocationFromSelectedForkliftButtonClick { get; set; }
        public ICommand? SelectForkliftFromList { get; set; }
        public ICommand? SelectLocationFromList { get; set; }
        public ICommand? SaveLocationButtonClick { get; set; }
        public ICommand? EditLocationButtonClick { get; set; }
        public ICommand? DeleteLocationButtonClick { get; set; }
        #endregion
    }
}
