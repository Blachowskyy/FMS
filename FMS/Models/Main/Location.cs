using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Models.Main
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int LocationType { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? PositionX { get; set; }
        [Required]
        public string? PositionY { get; set; }
        [Required]
        public string? PositionR { get; set; }
        public bool IsActive { get; set; }
    }
}
