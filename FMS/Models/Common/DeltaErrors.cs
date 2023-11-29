using FMS.Models.Common.Errors;

namespace FMS.Models.Common
{
    public class DeltaErrors : CommonBaseModel
    {
        #region Variables
        private DeltaErrorCodes? _errorCodes;
        public DeltaErrorCodes ErrorCodes
        {
            get
            {
                _errorCodes ??= new DeltaErrorCodes();
                return _errorCodes;
            }
            set
            {
                _errorCodes = value;
                OnPropertyChanged(nameof(ErrorCodes));
            }
        }
        private DeltaStatus? _errorStatus;
        public DeltaStatus ErrorStatus
        {
            get
            {
                _errorStatus ??= new DeltaStatus();
                return _errorStatus;
            }
            set
            {
                _errorStatus = value;
                OnPropertyChanged(nameof(ErrorCodes));
            }
        }
        #endregion
        #region Constructors
        public DeltaErrors() { }
        #endregion
    }
}
