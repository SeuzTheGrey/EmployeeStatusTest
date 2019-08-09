using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeStatusTestMVC.Models
{
    public class StaffInOutHistory
    {
        public int StaffInOutHistoryID { get; set; }
        public int StaffID { get; set; }
        public int InOutStatusIDOld { get; set; }
        public int InOutStatusIDNew { get; set; }
        public DateTime DateChanged { get; set; }
        public int ChangedByStaffID { get; set; }
    }
}