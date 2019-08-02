using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataAccess;

namespace EmployeeStatusTest
{
    public class Export
    {

        public static void ExportReports()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("E:\\Projects\\EmployeeStatusTest\\EmployeeStatusTest\\Reports\\Report.csv"))
                {

                    DatabaseDataSet.GetEmployeeListDataTable GetEmployees = StaffDAL.getEmployeeList();
                    writer.WriteLine("StaffID|FirstName|LastName|Username|Nickname|FlagDeleted|Extension|Status");
                    foreach (var item in GetEmployees)
                    {
                        writer.WriteLine(item.StaffID + "|" + item.Firstname + "|" + item.Lastname + "|" + item.Username + "|" + item.Nickname + "|" + item.FlagDeleted  + "|" + item.TelephoneExtension + "|" + item.Description);
                    }

                }
            }
            catch (Exception)
            {

                
            }
        }
    }
}
