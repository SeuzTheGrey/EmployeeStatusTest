using EmployeeStatusTestMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeStatusTestMVC
{
    public class InOutStatusDAL
    {
        //Question 2.1
        public static DatabaseDataSet.InOutStatusDataTable GetEmployeeList()
        {
            DatabaseDataSet.InOutStatusDataTable inOutStatusDataTable = new DatabaseDataSet.InOutStatusDataTable();
            using (Database.GetConnection())
            {
                EmployeeStatusTestMVC.DatabaseDataSetTableAdapters.InOutStatusTableAdapter getEmployeeListTableAdapter = new EmployeeStatusTestMVC.DatabaseDataSetTableAdapters.InOutStatusTableAdapter();
                getEmployeeListTableAdapter.Fill(inOutStatusDataTable);
            }

            return inOutStatusDataTable;
        }
    }
}
