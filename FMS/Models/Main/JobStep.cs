using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Models.Main
{
    public class JobStep : BaseModel
    {
        #region Variables
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
        private Location? _jobStepLocation;
        public Location JobStepLocation
        {
            get
            {
                _jobStepLocation ??= new Location();
                return _jobStepLocation;
            }
            set
            {
                _jobStepLocation = value;
                OnPropertyChanged(nameof(JobStepLocation));
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
        private JobStepType? _jobType;
        public JobStepType JobType
        {
            get
            {
                return _jobType ??= new JobStepType();
            }
            set
            {
                _jobType = value;
                OnPropertyChanged(nameof(JobType));
            }
        }
        #endregion
        #region Constructors
        public JobStep() { }
        #endregion
    }
}
