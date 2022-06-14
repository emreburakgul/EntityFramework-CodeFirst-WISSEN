using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RebelTask.DataAccess.Models
{
    public class Employee
    {
        private EmployeeExperience _exp = EmployeeExperience.None;

        private DateTime? _leavedate;
        private DateTime? _hiredate;

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public int DepartmentId { get; set; }

        public EmployeeExperience Experience
        {
            get
            {
                var year = (DateTime.Now - HireDate.Value).TotalDays/365;

                if (HireDate == null)
                {
                    _exp = EmployeeExperience.None;
                }
                else if (year < 2)
                {
                    _exp = EmployeeExperience.Junior;
                }
                else if (year < 5)
                {
                    _exp = EmployeeExperience.Middle;
                }
                else if (year < 10)
                {
                    _exp = EmployeeExperience.Senior;
                }
                else if (year >= 10)
                {
                    _exp = EmployeeExperience.Principal_Architec;
                }

                return _exp;
            }
        }
      
        public string Title { get; set; }

        public DateTime? HireDate
        {
            get 
            {
                return _hiredate;
            }
            set 
            {
                _hiredate = value;

                if (value==null)
                {
                    _leavedate = null;
                }
            } 
        }

        public DateTime? LeaveDate
        {
            get
            {
                return _leavedate;
            }

            set
            {
                if (_hiredate != null)
                {
                    _leavedate = value;
                }
                else
                { _leavedate = null; }
            }
        }

        public Department Department { get; set; }

    }
}
