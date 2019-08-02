using EmployeeStatusTestMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeStatusTestMVC
{
    public class StaffInOutHistoryDAL
    {

        public static DatabaseDataSet.GetEmployeeHistoryDataTable GetEmployeeHistories(int staffId)
        {
            DatabaseDataSet.GetEmployeeHistoryDataTable getEmployeeHistories = new DatabaseDataSet.GetEmployeeHistoryDataTable();

            using (Database.GetConnection())
            {
                EmployeeStatusTestMVC.DatabaseDataSetTableAdapters.GetEmployeeHistoryTableAdapter getEmployeeHistoryTableAdapter = new EmployeeStatusTestMVC.DatabaseDataSetTableAdapters.GetEmployeeHistoryTableAdapter();
                getEmployeeHistoryTableAdapter.Fill(getEmployeeHistories, staffId);
            }

            return getEmployeeHistories;
        }

        public static bool UpdateStatus(int staffid,int changedby, string status)
        {
            using (Database.GetConnection())
            {
                DatabaseDataSetTableAdapters.QueriesTableAdapter queriesTableAdapter = new DatabaseDataSetTableAdapters.QueriesTableAdapter();
                if (queriesTableAdapter.UpdateEmployeeStatus(staffid, changedby, status) > 0)
                {
                    return true;
                }
            }

            return false;
        }

    }
}
