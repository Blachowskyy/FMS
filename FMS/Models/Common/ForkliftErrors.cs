namespace FMS.Models.Common
{
    public class ForkliftErrors
    {
        public DeltaErrors? PlcErrors { get; set; }
        public ForkliftErrors()
        {
            PlcErrors = new();
        }
    }
}
