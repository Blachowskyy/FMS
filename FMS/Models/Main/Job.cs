namespace FMS.Models.Main
{
    public class Job : BaseModel
    {
        #region Variables
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
        private int _priority;
        public int Priority
        {
            get
            {
                return _priority;
            }
            set
            {
                _priority = value;
                OnPropertyChanged(nameof(Priority));
            }
        }
        private List<JobStep>? _jobStepList;
        public List<JobStep> JobStepList
        {
            get
            {
                _jobStepList ??= [];
                return _jobStepList;
            }
            set
            {
                _jobStepList = value;
                OnPropertyChanged(nameof(JobStepList));
            }
        }
        private bool _isQueued;
        public bool IsQueued
        {
            get
            {
                return _isQueued;
            }
            set
            {
                _isQueued = value;
                OnPropertyChanged(nameof(IsQueued));
            }
        }
        private bool _isRunning;
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                _isRunning = value;
                OnPropertyChanged(nameof(IsRunning));
            }
        }
        private bool _isCanceled;
        public bool IsCanceled
        {
            get
            {
                return _isCanceled;
            }
            set
            {
                _isCanceled = value;
                OnPropertyChanged(nameof(IsCanceled));
            }
        }
        private bool _isCompleted;
        public bool IsCompleted
        {
            get
            {
                return _isCompleted;
            }
            set
            {
                _isCompleted = value;
                OnPropertyChanged(nameof(IsCompleted));
            }
        }
        #endregion
        #region Constructors
        public Job() { }
        #endregion
    }
}
