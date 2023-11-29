using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace FMS.Models.Main
{
    public class Forklift : BaseModel
    {
        #region Variables
        #region Connections
        private string? _ipAddress;
        public string IpAdress
        {
            get
            {
                return _ipAddress ?? string.Empty;
            }
            set
            {
                _ipAddress = value;
                OnPropertyChanged(nameof(IpAdress));
            }
        }
        private int _port;
        public int Port
        {
            get
            {
                return _port;
            }
            set
            {
                _port = value;
                OnPropertyChanged(nameof(Port));
            }
        }
        private string? _lidarLocAddress;
        public string LidarLocAddress
        {
            get
            {
                return _lidarLocAddress ?? string.Empty;
            }
            set
            {
                _lidarLocAddress = value;
                OnPropertyChanged(nameof(LidarLocAddress));
            }
        }
        #endregion
        #region Properties
        private DateTime? _registationDate;
        public DateTime RegistrstationDate
        {
            get
            {
                return _registationDate ?? DateTime.Now;
            }
            set
            {
                _registationDate = value;
                OnPropertyChanged(nameof(RegistrstationDate));
            }
        }
        private string? _name;
        public string Name
        {
            get
            {
                return _name ?? "default";
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        #endregion
        #region Not Mapped to database
        [NotMapped]
        private ForkliftData? _data;
        [NotMapped]
        public ForkliftData Data
        {
            get
            {
                _data ??= new ForkliftData();
                return _data;
            }
            set
            {
                _data = value;
                OnPropertyChanged(nameof(Data));
            }
        }
        [NotMapped]
        private bool _isConnected;
        [NotMapped]
        public bool IsConnected
        {
            get
            {
                return _isConnected;
            }
            set
            {
                _isConnected = value;
                OnPropertyChanged(nameof(IsConnected));
            }
        }
        [NotMapped]
        private TcpClient? _client;
        [NotMapped]
        public TcpClient Client
        {
            get
            {
                _client ??= new TcpClient();
                return _client;
            }
            set
            {
                _client = value;
                OnPropertyChanged(nameof(Client));
            }
        }

        #endregion
        #endregion
    }
}
