using FMS.Models.Common;
using FMS.Models.Main;
using FMS.ViewModels.Common;

namespace FMS.ViewModels.LiveForkliftsPages
{
    public class WorkstatesPageViewModel : BaseViewModel
    {
        #region Variables
        private CurrentWorkstates? _dataset;
        public CurrentWorkstates Dataset
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
        public WorkstatesPageViewModel(Forklift selectedForklift)
        {

            SelectedForklift = selectedForklift;
            if (_selectedForklift != null)
            {
                if (_selectedForklift.Client != null)
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
                    CurrentWorkstates tmp = new()
                    {
                        S01 = _selectedForklift.Data.ActiveWorkstates.S01,
                        S02 = _selectedForklift.Data.ActiveWorkstates.S02,
                        S03 = _selectedForklift.Data.ActiveWorkstates.S03,
                        S1 = _selectedForklift.Data.ActiveWorkstates.S1,
                        S2 = _selectedForklift.Data.ActiveWorkstates.S2,
                        S3 = _selectedForklift.Data.ActiveWorkstates.S3,
                        S4 = _selectedForklift.Data.ActiveWorkstates.S4,
                        S40 = _selectedForklift.Data.ActiveWorkstates.S40,
                        S41 = _selectedForklift.Data.ActiveWorkstates.S41,
                        S42 = _selectedForklift.Data.ActiveWorkstates.S42,
                        S43 = _selectedForklift.Data.ActiveWorkstates.S43,
                        S44 = _selectedForklift.Data.ActiveWorkstates.S44,
                        S45 = _selectedForklift.Data.ActiveWorkstates.S45,
                        S46 = _selectedForklift.Data.ActiveWorkstates.S46
                    };
                    Dataset = tmp;
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
