namespace FMS.Models.Main
{
    public class JobStepType : BaseModel
    {
        #region Variables
        public int Type { get; set; }
        public string? Description { get; set; }
        #endregion
        #region Constructors
        public JobStepType() { }
        #endregion
    }
}
