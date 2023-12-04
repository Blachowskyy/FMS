using FMS.Models.Common;
using FMS.Models.Main;
using FMS.ViewModels.Common;

namespace FMS.ViewModels.LiveForkliftsPages
{
    public class LidarLocPageViewModel : BaseViewModel
    {
        #region Variables
        private Forklift? _dataset;
        public Forklift Dataset
        {
            get
            {
                return _dataset ??= new();
            }
            set
            {
                _dataset = value;
                OnPropertyChanged(nameof(Dataset));
            }
        }
        private string? _refreshDate;
        public string RefreshDate
        {
            get
            {
                return _refreshDate ??= string.Empty;
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
        public LidarLocPageViewModel(Forklift selectedForklift)
        {

            SelectedForklift = selectedForklift;
            
        }
        #endregion
        #region Program logic
        
        #endregion
    }
}
