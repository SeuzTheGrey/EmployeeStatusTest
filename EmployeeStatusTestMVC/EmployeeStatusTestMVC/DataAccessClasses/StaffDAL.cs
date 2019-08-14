using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeStatusTestMVC
{
    public class StaffDAL
    {
        public static DatabaseDataSet.getEmployeeDetailsDataTable getEmployeeDetails(int StaffID)
        {
            DatabaseDataSet.getEmployeeDetailsDataTable getEmployeeDetails = new DatabaseDataSet.getEmployeeDetailsDataTable();
            DatabaseDataSetTableAdapters.getEmployeeDetailsTableAdapter getEmployeeDetailsTableAdapter = new DatabaseDataSetTableAdapters.getEmployeeDetailsTableAdapter();
            getEmployeeDetailsTableAdapter.Fill(getEmployeeDetails, StaffID);

            return getEmployeeDetails;
        }

        public static DatabaseDataSet.GetEmployeeListDataTable getEmployeeList()
        {
            DatabaseDataSet.GetEmployeeListDataTable getEmployeeDetails = new DatabaseDataSet.GetEmployeeListDataTable();
            DatabaseDataSetTableAdapters.GetEmployeeListTableAdapter getEmployeeDetailsTableAdapter = new DatabaseDataSetTableAdapters.GetEmployeeListTableAdapter();
            getEmployeeDetailsTableAdapter.Fill(getEmployeeDetails);

            return getEmployeeDetails;
        }

        public static DatabaseDataSet.GetEmployeesDataTable GetEmployees()
        {
            DatabaseDataSet.GetEmployeesDataTable getEmployees = new DatabaseDataSet.GetEmployeesDataTable();

            using (Database.GetConnection())
            {
                DatabaseDataSetTableAdapters.GetEmployeesTableAdapter getEmployeesTableAdapter = new DatabaseDataSetTableAdapters.GetEmployeesTableAdapter();
                getEmployeesTableAdapter.Fill(getEmployees);
            }

            

            return getEmployees;
        }
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

        public static bool UpdateEmployeeStatus(int staffId,int changedby,int description)
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

        public static bool UpdateEmployeeDetails(Models.Staff staff)
        {
            using (Database.GetConnection())
            {
                DatabaseDataSetTableAdapters.QueriesTableAdapter queriesTableAdapter = new DatabaseDataSetTableAdapters.QueriesTableAdapter();
                if (queriesTableAdapter.UpdateEmployeeDetails(staff.StaffID,staff.LastName,staff.FirstName,staff.Nickname,staff.Username,staff.TelephoneExtension,staff.FlagDeleted) > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool DeleteEmployee(int StaffId)
        {
            using (Database.GetConnection())
            {
                DatabaseDataSetTableAdapters.QueriesTableAdapter queriesTableAdapter = new DatabaseDataSetTableAdapters.QueriesTableAdapter();
                if (queriesTableAdapter.DeleteEmployee(StaffId) > 0)
                {
                    return true;
                }
            }

            return false;
        }

        public static bool InsertEmployee(Models.Staff staff,int changedBy)
        {
            using (Database.GetConnection())
            {
                DatabaseDataSetTableAdapters.QueriesTableAdapter queriesTableAdapter = new DatabaseDataSetTableAdapters.QueriesTableAdapter();
                if (queriesTableAdapter.insertEmployee( staff.LastName, staff.FirstName, staff.Nickname, staff.Username,staff.InOutStatusID, staff.TelephoneExtension, staff.FlagDeleted,staff.ManagerID, changedBy) > 0)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
