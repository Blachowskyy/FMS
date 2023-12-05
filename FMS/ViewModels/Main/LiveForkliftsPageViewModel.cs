using FMS.Models.Main;
using FMS.Services.Common;
using FMS.Services.Common.DataServices;
using FMS.ViewModels.Common;
using FMS.ViewModels.LiveForkliftsPages;
using FMS.Views;
using FMS.Views.LiveForklifsPages;
using System.Windows.Controls;
using System.Windows.Input;

namespace FMS.ViewModels.Main
{
    public class LiveForkliftsPageViewModel : BaseViewModel
    {
        #region Variables
        private Page? _currentLivePage;
        public Page CurrentLivePage
        {
            get
            {
                return _currentLivePage ?? new();
            }
            set
            {
                _currentLivePage = value;
                OnPropertyChanged(nameof(CurrentLivePage));
            }
        }
        private Forklift? _selectedForklift;
        public Forklift SelectedForklift
        {
            get
            {
                _selectedForklift ??= new Forklift { Name = "Wybierz wózek..." };
                return _selectedForklift;
            }
            set
            {
                if (_selectedForklift != value)
                {
                    _selectedForklift = value;
                    OnPropertyChanged(nameof(SelectedForklift));
                }
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
        private bool _isComboboxOpen;
        public bool IsComboboxOpen
        {
            get
            {
                return _isComboboxOpen;
            }
            set
            {
                _isComboboxOpen = value;
                OnPropertyChanged(nameof(IsComboboxOpen));
            }
        }
        private int _currentLivePageId;
        public int CurrentLivePageId
        {
            get
            {
                return _currentLivePageId;
            }
            set
            {
                if (value != _currentLivePageId)
                {
                    _currentLivePageId = value;
                    OnPropertyChanged(nameof(CurrentLivePageId));
                }
            }
        }
        private readonly UserStore? _userStore;
        private readonly ForklfitDataService _forkliftDataService;
        #endregion
        #region Constructor
        public LiveForkliftsPageViewModel(UserStore userStore, List<Forklift> onlineForklifts, ForklfitDataService forklfitDataService)
        {
            _userStore = userStore;
            OnlineForklifts = onlineForklifts ??= [];
            _forkliftDataService = forklfitDataService;
            SelectedForklift = new Forklift { Name = "Wybierz wózek..." };
            ActualParametersPageButtonClick = new RelayCommand(ShowActualParametersPage);
            AutoModeStartupPageButtonClick = new RelayCommand(ShowAutoModeStartupPage);
            ErrorsPageButtonClick = new RelayCommand(ShowErrorsPage);
            ForkliftConfigurationPageButtonClick = new RelayCommand(ShowForkliftConfigurationPage);
            LidarLocPageButtonClick = new RelayCommand(ShowLidarLocPage);
            SafetyDataPageButtonClick = new RelayCommand(ShowSafetyDataPage);
            WorkstatesPageButtonClick = new RelayCommand(ShowWorkstatesPage);
            SelectForkliftFromList = new RelayCommand(SelectForklift);
        }
        #endregion
        #region Program logic
        private void PageRefresher()
        {
            if (_currentLivePageId == 1)
            {
                _selectedForklift ??= new();
                CurrentLivePage = new ActualParametersPage(new ActualParametersPageViewModel(_selectedForklift));
            }
            if (_currentLivePageId == 2)
            {
                _selectedForklift ??= new();
                CurrentLivePage = new AutoModeStartupPage(new AutoModeStartupPageViewModel(_selectedForklift));
            }
            if (_currentLivePageId == 3)
            {
                _selectedForklift ??= new();
                CurrentLivePage = new ErrorsPage(new ErrorsPageViewModel(_selectedForklift));
            }
            if (_currentLivePageId == 4)
            {
                _selectedForklift ??= new();
                CurrentLivePage = new ForkliftConfigurationPage(new ForkliftConfigurationPageViewModel(_selectedForklift, _forkliftDataService));
            }
            if (_currentLivePageId == 5)
            {
                _selectedForklift ??= new();
                CurrentLivePage = new SickPage(new SickPageViewModel(_selectedForklift));
            }
            if (_currentLivePageId == 6)
            {
                _selectedForklift ??= new();
                CurrentLivePage = new SafetyDataPage(new SafetyDataPageViewModel(_selectedForklift));
            }
            if (_currentLivePageId == 7)
            {
                _selectedForklift ??= new();
                CurrentLivePage = new WorkstatesPage(new WorkstatesPageViewModel(_selectedForklift));
            }
        }
        #endregion
        #region Button logic
        private void ShowActualParametersPage(object? param)
        {
            CurrentLivePageId = 1;
            PageRefresher();
        }
        private void ShowAutoModeStartupPage(object? param)
        {
            CurrentLivePageId = 2;
            PageRefresher();
        }
        private void ShowErrorsPage(object? param)
        {
            CurrentLivePageId = 3;
            PageRefresher();
        }
        private void ShowForkliftConfigurationPage(object? param)
        {
            CurrentLivePageId = 4;
            PageRefresher();
        }
        private void ShowLidarLocPage(object? param)
        {
            CurrentLivePageId = 5;
            PageRefresher();
        }
        private void ShowSafetyDataPage(object? param)
        {
            CurrentLivePageId = 6;
            PageRefresher();
        }
        private void ShowWorkstatesPage(object? param)
        {
            CurrentLivePageId = 7;
            PageRefresher();
        }
        private void SelectForklift(object? param)
        {
            if (param != null && _onlineForklifts != null)
            {
                foreach (Forklift fork in _onlineForklifts)
                {
                    if (fork != null)
                    {
                        if (fork.Id == Convert.ToInt32(param))
                        {
                            SelectedForklift = fork;
                            IsComboboxOpen = false;
                            PageRefresher();
                        }
                    }
                }
            }
        }
        #endregion
        #region ICommand declarations
        public ICommand? ActualParametersPageButtonClick { get; private set; }
        public ICommand? AutoModeStartupPageButtonClick { get; private set; }
        public ICommand? ErrorsPageButtonClick { get; private set; }
        public ICommand? ForkliftConfigurationPageButtonClick { get; private set; }
        public ICommand? LidarLocPageButtonClick { get; private set; }
        public ICommand? SafetyDataPageButtonClick { get; private set; }
        public ICommand? WorkstatesPageButtonClick { get; private set; }
        public ICommand? SelectForkliftFromList {  get; private set; }
        #endregion
    }
}
