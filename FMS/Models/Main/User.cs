namespace FMS.Models.Main
{
    public class User : BaseModel
    {
        #region Variables
        private string? _username;
        public string Username
        {
            get
            {
                return _username ?? string.Empty;
            }
            set
            {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }
        private string? _password;
        public string Password
        {
            get
            {
                return _password ?? string.Empty;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        private string? _tag;
        public string Tag
        {
            get
            {
                return _tag ?? string.Empty;
            }
            set
            {
                _tag = value;
                OnPropertyChanged(nameof(Tag));
            }
        }
        private bool _isLogged;
        public bool IsLogged
        {
            get
            {
                return _isLogged;
            }
            set
            {
                _isLogged = value;
                OnPropertyChanged(nameof(IsLogged));
            }
        }
        private bool _client;
        public bool Client
        {
            get
            {
                return _client;
            }
            set
            {
                _client = value;
                OnPropertyChanged(nameof(Client));
            }
        }
        private bool _installator;
        public bool Installator
        {
            get
            {
                return _installator;
            }
            set
            {
                _installator = value;
                OnPropertyChanged(nameof(Installator));
            }
        }
        private bool _admin;
        public bool Admin
        {
            get
            {
                return _admin;
            }
            set
            {
                _admin = value;
                OnPropertyChanged(nameof(Admin));
            }
        }
        #endregion
        #region Constructors
        public User()
        {

        }
        #endregion

    }
}
