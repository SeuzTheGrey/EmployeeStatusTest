using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeStatusTestMVC.Models
{
    public class InOutStatus
    {
        public int InOutStatusID { get; set; }
        public string Description { get; set; }

        public InOutStatus()
        {

        }

        public InOutStatus(int InOutStatusID, string Description)
        {
            this.InOutStatusID = InOutStatusID;
            this.Description = Description;
        }
    }
}