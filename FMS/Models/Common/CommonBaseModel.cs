using System.ComponentModel;

namespace FMS.Models.Common
{
    public class CommonBaseModel
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
