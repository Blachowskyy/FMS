using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FMS.Models.Main
{
    public class JobStep 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public Location? JobStepLocation { get; set; }
        [Required]
        public JobStepType? JobType { get; set; }
        public bool IsRunning { get; set; }
        public bool IsDone { get; set; }
        public bool IsCanceled { get; set; }
        public JobStep()
        {
            JobStepLocation = new();
            JobType = new();
        }
    }
}
