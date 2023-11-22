using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Models
{
    public class JobStep : BaseModel
    {
        #region Variables
        [ForeignKey("Job")]
        public virtual required Job Job { get; set; }
        private int _jobId;
        public int JobId
        {
            get
            {
                return _jobId;
            }
            set
            {
                _jobId = value;
                OnPropertyChanged(nameof(JobId));
            }
        }
        private JobStepType? _type;
        public JobStepType Type
        {
            get
            {
                _type ??= new JobStepType
                    {
                        Type = 0,
                        Description = "Standby mode"
                    };
                return _type;
            }

            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        public required Location JobStepLocation { get; set; }
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
        private bool _isDone;
        public bool IsDone
        {
            get
            {
                return _isDone;
            }
            set
            {
                _isDone = value;
                OnPropertyChanged(nameof(IsDone));
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
        #endregion
        #region Constructors
        public JobStep() { }
        #endregion
    }
}
