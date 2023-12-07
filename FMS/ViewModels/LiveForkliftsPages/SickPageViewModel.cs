using FMS.Models.Main;
using FMS.ViewModels.Common;

namespace FMS.ViewModels.LiveForkliftsPages
{
    public class SickPageViewModel : BaseViewModel
    {
        #region Variables

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
        public SickPageViewModel(Forklift selectedForklift)
        {

            SelectedForklift = selectedForklift;

        }
        #endregion
        #region Program logic

        #endregion
    }
}
