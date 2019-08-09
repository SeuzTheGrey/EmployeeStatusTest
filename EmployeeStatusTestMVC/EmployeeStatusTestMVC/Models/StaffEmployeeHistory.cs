using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeStatusTestMVC.Models
{
    public class StaffEmployeeHistory
    {
        public Staff staff { get; set; }
        public List<EmployeeHistory> EmployeeHistory { get; set; }

        public StaffEmployeeHistory()
        {

        }

        public StaffEmployeeHistory(Staff staff, List<EmployeeHistory> EmployeeHistory)
        {
            this.staff = staff;
            this.EmployeeHistory = EmployeeHistory;
        }
    }
}