using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Models
{
    public class Location : BaseModel
    {
        #region Vairables
        private string? _name;
        public string Name
        {
            get
            {
                return _name ?? string.Empty;
            }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public int _locationType;
        public int LocationType
        {
            get
            {
                return _locationType;
            }
            set
            {
                _locationType = value;
                OnPropertyChanged(nameof(LocationType));
            }
        }
        private string? _positionX;
        public string PositionX
        {
            get
            {
                return _positionX ?? string.Empty;
            }
            set
            {
                _positionX = value;
                OnPropertyChanged(nameof(PositionX));
            }
        }
        private string? _positionY;
        public string PositionY
        {
            get
            {
                return _positionY ?? string.Empty;
            }
            set
            {
                _positionY = value;
                OnPropertyChanged(nameof(PositionY));
            }
        }
        private string? _positionR;
        public string PositionR
        {
            get
            {
                return _positionR ?? string.Empty;
            }
            set
            {
                _positionR = value;
                OnPropertyChanged(nameof(PositionR));
            }
        }
        private bool _isActive;
        public bool IsActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }
        #endregion
        #region Constructors
        public Location() { }
        #endregion

    }
}
