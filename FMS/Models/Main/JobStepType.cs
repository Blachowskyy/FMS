using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FMS.Models.Main
{
    public class JobStepType 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Type {  get; set; }
        [Required]
        public string? Description { get; set; }
    }
}
