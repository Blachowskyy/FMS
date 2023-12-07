using FMS.Models.Main;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FMS.Models.Common
{
    public class TebConfigData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int ForkliftId { get; set; }
        
        public string? ForwardMaxVelocity { get; set; }
        public string? BackwardMaxVelocity { get; set; }
        public string? TurningMaxVelocity { get; set; }
        public string? AccelerationLinearLimit { get; set; }
        public string? AccelerationAngularLimit { get; set; }
        public string? TurningRadius {  get; set; }
        public string? Wheelbase {  get; set; }
        public string? GoalToleranceXY { get; set; }
        public string? GoalToleranceYaw { get; set; }
        public string? MinimalObstacleDistance { get; set; }
        public string? StaticObstacleInflationRadius { get; set; }
        public string? DynamicObstacleInflationRadius { get; set; }
        public string? DtRef { get; set; }
        public string? DtHysteresis { get; set; }
        public bool IncludeDynamicObstacles { get; set; }
        public bool IncludeCostmapObstacles { get; set; }
        public bool OscillationRecovery { get; set; }
        public bool AllowInitializeWithBackwardMotion { get; set; }
        public bool SaveSettings { get; set; }
        public TebConfigData()
        {
            
        }
    }
    
}
