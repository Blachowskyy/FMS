using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Models
{
    public class ForkliftReadData : BaseModel
    {
        #region Variables
        private string? _lastDataUpdate;
        public string LastDataUpdate
        {
            get
            {
                return _lastDataUpdate ?? string.Empty;
            }
            set
            {
                _lastDataUpdate = value;
                OnPropertyChanged(nameof(LastDataUpdate));
            }
        }

        #endregion
        #region Constructors
        public ForkliftReadData() { }
        #endregion
    }
}
