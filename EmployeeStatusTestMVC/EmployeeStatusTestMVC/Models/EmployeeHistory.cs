using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeStatusTestMVC.Models
{
    public class EmployeeHistory
    {
        public string Nickname { get; set; }
        public string StatusBeforeChange { get; set; }
        public string StatusAfterChange { get; set; }
        public DateTime DateChanged { get; set; }
        public string StatusChangedBy { get; set; }

        public EmployeeHistory()
        {

        }

        public EmployeeHistory(string Nickname, string StatusBeforeChange, string StatusAfterChange, DateTime DateChanged, string StatusChangedBy)
        {
            this.Nickname = Nickname;
            this.StatusBeforeChange = StatusBeforeChange;
            this.StatusAfterChange = StatusAfterChange;
            this.DateChanged = DateChanged;
            this.StatusChangedBy = StatusChangedBy;
        }


        public static List<EmployeeHistory> GetEmployeeHistories(int id)
        {
            List<EmployeeHistory> employeeHistories = new List<EmployeeHistory>();

            DatabaseDataSet.GetEmployeeHistoryDataTable getEmployeeHistories = StaffInOutHistoryDAL.GetEmployeeHistories(id);

            foreach (DatabaseDataSet.GetEmployeeHistoryRow item in getEmployeeHistories.Rows)
            {
                employeeHistories.Add(new EmployeeHistory(item.Nickname, item.Status_before_change, item.status_after_change, item.DateChanged, item.Status_change_by));
            }

            return employeeHistories;
        }
    }
}