using FMS.Models.Common;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace FMS.Models.Main
{
    public class Forklift
    {
        [Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public int Port { get; set; }
        [Required]
        public string? ForkliftAddress { get; set; }
        public string? LidarLocAddress { get; set; }
        public string? VisionaryAddress { get; set; }
        public DateTime RegistrationDate { get; set; }
        public TebConfigData? BackedUpTebConfig { get; set; }
        [NotMapped]
        public TcpClient? Client { get; set; }
        [NotMapped]
        public ForkliftData? Data { get; set; }
        [NotMapped]
        public bool IsConnected { get; set; }
        public Forklift()
        {
            Data = new();
            Client = new();
        }
    }
}
