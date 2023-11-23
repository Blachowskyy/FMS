using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Models.Common
{
    public class TaskData : CommonBaseModel
    {
        private string? _id;
        public string Id
        {
            get
            {
                return _id ?? string.Empty;
            }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        private int _type;
        public int Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value; 
                OnPropertyChanged(nameof(Type));
            }
        }
/*        private string? _positionX*/
    }
}
