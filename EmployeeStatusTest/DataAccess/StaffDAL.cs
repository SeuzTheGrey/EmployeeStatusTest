using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class StaffDAL
    {
        //retrieves specfic details of a employee based on staff id
        public static DatabaseDataSet.getEmployeeDetailsDataTable getEmployeeDetails(int StaffID)
        {
            DatabaseDataSet.getEmployeeDetailsDataTable getEmployeeDetails = new DatabaseDataSet.getEmployeeDetailsDataTable();
            DatabaseDataSetTableAdapters.getEmployeeDetailsTableAdapter getEmployeeDetailsTableAdapter = new DatabaseDataSetTableAdapters.getEmployeeDetailsTableAdapter();
            getEmployeeDetailsTableAdapter.Fill(getEmployeeDetails, StaffID);

            return getEmployeeDetails;
        }

        // Retreives all employees
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

        
        //retrieves employee status
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

        public static bool UpdateEmployeeDetails(int StaffID, string LastName, string FirstName, string Nickname, string TelephoneExtension, bool FlagDeleted)
        {
            using (Database.GetConnection())
            {
                DatabaseDataSetTableAdapters.QueriesTableAdapter queriesTableAdapter = new DatabaseDataSetTableAdapters.QueriesTableAdapter();
                if (queriesTableAdapter.UpdateEmployeeDetails(StaffID, LastName, FirstName, Nickname, TelephoneExtension, FlagDeleted) > 0)
                {
                    return true;
                }
            }

            return false;
        }

        //deletes employee based on staff id
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
    }
}
