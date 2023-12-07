using System.ComponentModel.DataAnnotations;

namespace FMS.Models.Common
{
    public class TaskData 
    {
        public int Id { get; set; }
        [Required]
        public string? Type { get; set; }
    }
}
