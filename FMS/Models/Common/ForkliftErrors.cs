namespace FMS.Models.Common
{
    public class ForkliftErrors : CommonBaseModel
    {
        #region Vaiables
        private DeltaErrors? _delta;
        public DeltaErrors Delta
        {
            get
            {
                _delta ??= new DeltaErrors();
                return _delta;
            }
            set
            {
                _delta = value;
                OnPropertyChanged(nameof(Delta));
            }
        }
        #endregion
        #region Constructors
        public ForkliftErrors() { }
        #endregion
    }
}
