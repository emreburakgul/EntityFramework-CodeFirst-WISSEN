using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTask.DataAccess.Models
{
    public class SubTask : TaskBase
    {
        private DateTime? _startOn;
        private DateTime? _complatedOn;
        public int ParentId { get; set; }
        public MainTask ParentTask { get; set; }
        public void Start()
        {
            if (!StartedOn.HasValue)
            {
                _startOn = DateTime.Now; // baking field alıncak
            }
        }
        public void Complete()
        {
            if (StartedOn.HasValue && !CompletedOn.HasValue) // complate kısmı bidaha çağırılsa değişmedi burayı yaptık

            {
                _complatedOn = DateTime.Now;

            }
        }


        public override TaskStatus Status
        {
            get 
            {
                if (!StartedOn.HasValue)
                {
                    return TaskStatus.Open;
                }
                else if (!CompletedOn.HasValue)
                {
                    return TaskStatus.InProgress;
                }
                else
                    return TaskStatus.Done;
            }
           
        }

        public override DateTime? StartedOn => _startOn;
        public override DateTime? CompletedOn { get { return _complatedOn; } }
    }
}
