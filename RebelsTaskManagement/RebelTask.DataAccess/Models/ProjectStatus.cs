using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTask.DataAccess.Models
{
    public enum ProjectStatus
    {

        None = 0,
        InProgress,
        Delayed,
        CompletedOnTime,
        CompletedWithDelay,
        Closed,
        Cancelled
    }
}
