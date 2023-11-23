using FMS.Models.Main;
using FMS.Services.Common.Interfaces;
using FMS.ViewModels.Common;
using System.Windows.Controls;

namespace FMS.ViewModels.Main
{
    public class MainWindowViewModel(IDataService<User> userDataService,
        IDataService<JobStepType> jobStepTypeDataService,
        IDataService<JobStep> jobStepDataService,
        IDataService<Job> jobDataService,
        IDataService<Location> locationDataService,
        IDataService<Forklift> forkliftDataService) : BaseViewModel
    {
        #region Variables
        #region Logic
        private Page? _currentPage;
        public Page CurrentPage
        {
            get
            {
                _currentPage ??= new Page();
                return _currentPage;
            }
            set
            {
                _currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }
        private bool _showSideMenu;
        public bool ShowSideMenu
        {
            get
            {
                return _showSideMenu;
            }
            set
            {
                _showSideMenu = value;
                OnPropertyChanged(nameof(ShowSideMenu));
            }
        }
        #endregion
        #region Privates
        private readonly IDataService<User> _userDataService = userDataService;
        private readonly IDataService<JobStepType> _jobStepTypeDataService = jobStepTypeDataService;
        private readonly IDataService<JobStep> _jobStepDataService = jobStepDataService;
        private readonly IDataService<Job> _jobDataService = jobDataService;
        private readonly IDataService<Location> _locationDataService = locationDataService;
        private readonly IDataService<Forklift> _forkliftDataService = forkliftDataService;

        #endregion
        #endregion
        #region Constructors
        #endregion
    }
}
