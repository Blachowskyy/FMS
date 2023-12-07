using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FMS.Models.Main
{
    public class Job 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PriorityLevel { get; set; }
        public string? Name { get; set; }
        public bool IsQueued { get; set; }
        public bool IsRunning { get; set; }
        public bool IsDone { get; set; }
        public bool IsCanceled { get; set; }
        public List<JobStep>? JobStepsList { get; set; }
        public Job()
        {
            Name = "";
            JobStepsList = [];
        }
    }
}
