using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StaffDAL
    {

        public static DatabaseDataSet.GetEmployeeStatusDataTable GetEmployeeStatus(int staffId)
        {
            DatabaseDataSet.GetEmployeeStatusDataTable getEmployeeStatuses = new DatabaseDataSet.GetEmployeeStatusDataTable();
            using (Database.GetConnection())
            {
                DatabaseDataSetTableAdapters.GetEmployeeStatusTableAdapter getEmployeeStatusTableAdapter = new DatabaseDataSetTableAdapters.GetEmployeeStatusTableAdapter();
                getEmployeeStatusTableAdapter.Fill(getEmployeeStatuses, staffId);
            }

            return getEmployeeStatuses;
        }

        public static bool UpdateEmployeeStatus(int staffId,int changedby,string description)
        {
            using (Database.GetConnection())
            {
                DatabaseDataSetTableAdapters.QueriesTableAdapter queriesTableAdapter = new DatabaseDataSetTableAdapters.QueriesTableAdapter();
                if (queriesTableAdapter.UpdateEmployeeStatus(staffId, changedby, description) > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
