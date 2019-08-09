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


        public static List<InOutStatus> GetStatuses()
        {
            List<InOutStatus> statuses = new List<InOutStatus>();

            DatabaseDataSet.InOutStatusDataTable inOutStatusRows = InOutStatusDAL.GetEmployeeList();

            foreach (DatabaseDataSet.InOutStatusRow item in inOutStatusRows.Rows)
            {
                statuses.Add(new InOutStatus(item.InOutStatusID, item.Description));
            }


            return statuses;
        }
    }
}