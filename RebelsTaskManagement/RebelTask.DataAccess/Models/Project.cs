using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTask.DataAccess.Models
{
    public class Project
    {
        private int _estimatedDurationInDays;
        private DateTime? _startedOn;
        private DateTime? _completedOn;
        private DateTime? _closedOn;
        private ProjectStatus _status;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int EstimatedDurationInDays
        {
            get
            {
                return _estimatedDurationInDays;
            }
            set
            {
                if (value < 0)
                {
                    _estimatedDurationInDays = 0;
                }
            }
        }
        public DateTime StartDate { get; set; }
        public DateTime DueDate
        {
            get { return StartDate.AddDays(_estimatedDurationInDays); }
        }
        public DateTime? StartedOn { get { return _startedOn; } }
        public DateTime? CompletedOn { get { return _completedOn; } }
        public DateTime? ClosedOn { get { return _closedOn; } }

        public int WorkedDays
        {
            get
            {
                if (_startedOn == null)
                {
                    return 0;
                }
                else if (_completedOn != null)
                {

                    return (_completedOn.Value.Day - _startedOn.Value.Day);
                }
                else if (_closedOn != null)
                {
                    return _closedOn.Value.Day - _startedOn.Value.Day;
                }
                else
                    return DateTime.Today.Day - _startedOn.Value.Day;
            }
        }
        public int RemainingDays
        {
            get
            {
                if ((DueDate - DateTime.Today).TotalDays < 0)
                {
                    return 0;
                }
                else
                {
                    return (int)(DueDate - DateTime.Today).TotalDays;
                }
            }
        }
        public ProjectStatus Status
        {
            get
            {
                if (_startedOn == null)
                {
                    if (_closedOn != null)
                    {
                        _status = ProjectStatus.Closed;
                    }
                    else
                    {
                        _status = ProjectStatus.None;
                    }
                }
                else if (_startedOn != null)
                {
                    if (_completedOn == null)
                    {
                        if (_closedOn != null)
                        {
                            _status = ProjectStatus.Cancelled;
                        }
                        else if ((DueDate - DateTime.Now).TotalDays < 0)
                        {
                            _status = ProjectStatus.Delayed;
                        }
                        else
                        {
                            _status = ProjectStatus.InProgress;
                        }
                    }
                    else
                    {
                        if ((DueDate - DateTime.Now).TotalDays < 0 && _completedOn != null)
                        {
                            _status = ProjectStatus.CompletedWithDelay;
                        }
                        else if ((DueDate - DateTime.Now).TotalDays >= 0 && _completedOn != null)
                        {
                            
                            _status = ProjectStatus.CompletedOnTime;
                        }
                    }
                }

                return _status;
            }

        }
        public ICollection<MainTask> Tasks { get; }



        public void Start()
        {
            if (_startedOn == null)
            {
                _startedOn = DateTime.Now;
            }
        }

        public void Complete()
        {
            if (_completedOn == null && _startedOn != null)

            {
                _completedOn = DateTime.Now;

                Close();
            }
        }


        public void Close()
        {
            if (_closedOn == null && _startedOn != null)
            {
                _closedOn = DateTime.Now;
            }
        }

    }
}
