using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StaffInOutHistoryDAL
    {
        //retreives Employee history from stored procedure GetEmployeeHistories
        public static DatabaseDataSet.GetEmployeeHistoryDataTable GetEmployeeHistories(int staffId)
        {
            DatabaseDataSet.GetEmployeeHistoryDataTable getEmployeeHistories = new DatabaseDataSet.GetEmployeeHistoryDataTable();

            using (Database.GetConnection())
            {
                DatabaseDataSetTableAdapters.GetEmployeeHistoryTableAdapter getEmployeeHistoryTableAdapter = new DatabaseDataSetTableAdapters.GetEmployeeHistoryTableAdapter();
                getEmployeeHistoryTableAdapter.Fill(getEmployeeHistories, staffId);
            }

            return getEmployeeHistories;
        }

        //Updates the status of the employee
        public static bool UpdateStatus(int staffid, int changedby, int status)
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
