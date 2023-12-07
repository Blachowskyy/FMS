using FMS.Models.Common.Errors;

namespace FMS.Models.Common
{
    public class DeltaErrors
    {
        public DeltaStatus? Status { get; set; }
        public DeltaErrorCodes? ErrorCodes { get; set; }
        public DeltaErrors()
        {
            ErrorCodes = new DeltaErrorCodes();
            Status = new DeltaStatus();
        }
    }
}
