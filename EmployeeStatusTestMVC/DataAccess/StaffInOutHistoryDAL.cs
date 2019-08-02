using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    class StaffInOutHistoryDAL
    {

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

    }
}
