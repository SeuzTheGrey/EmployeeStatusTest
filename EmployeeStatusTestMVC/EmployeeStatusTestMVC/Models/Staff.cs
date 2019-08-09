using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeStatusTestMVC.Models
{
    public class Staff
    {
        public int StaffID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Nickname { get; set; }
        public string Username { get; set; }
        public int InOutStatusID { get; set; }
        public string Status { get; set; }
        public string TelephoneExtension { get; set; }
        public bool FlagDeleted { get; set; }
        public int? ManagerID { get; set; }


        public Staff()
        {

        }

        public Staff(int StaffID, string LastName, string FirstName, string Nickname, string Username, int InOutStatusID, string TelephoneExtension, bool FlagDeleted, int? ManagerID)
        {
            this.StaffID = StaffID;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Nickname = Nickname;
            this.Username = Username;
            this.InOutStatusID = InOutStatusID;
            this.TelephoneExtension = TelephoneExtension;
            this.FlagDeleted = FlagDeleted;
            this.ManagerID = ManagerID;
        }
        public Staff(int StaffID, string LastName, string FirstName, string Nickname, string Username, int InOutStatusID, string TelephoneExtension, bool FlagDeleted)
        {
            this.StaffID = StaffID;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Nickname = Nickname;
            this.Username = Username;
            this.InOutStatusID = InOutStatusID;
            this.TelephoneExtension = TelephoneExtension;
            this.FlagDeleted = FlagDeleted;
        }

        public static List<Staff> GetStaffs()
        {
            List<Staff> staffs = new List<Staff>();

            DatabaseDataSet.GetEmployeeListDataTable getEmployee = StaffDAL.getEmployeeList();

            foreach (DatabaseDataSet.GetEmployeeListRow item in getEmployee.Rows)
            {
                if (item.ManagerID == null)
                {
                    staffs.Add(new Staff(item.StaffID, item.Lastname, item.Firstname, item.Nickname, item.Username, item.InOutStatusID, item.TelephoneExtension, item.FlagDeleted));
                }
                else
                {
                    staffs.Add(new Staff(item.StaffID, item.Lastname, item.Firstname, item.Nickname, item.Username, item.InOutStatusID, item.TelephoneExtension, item.FlagDeleted, item.ManagerID));
                }
            }

            return staffs;
        }

        public static Staff GetDetail(int id)
        {
            Staff staff = new Staff();

            DatabaseDataSet.getEmployeeDetailsDataTable getEmployeeDetails = StaffDAL.getEmployeeDetails(id);
            if (getEmployeeDetails[0].ManagerID == null)
            {
                staff = new Staff(getEmployeeDetails[0].StaffID, getEmployeeDetails[0].Lastname, getEmployeeDetails[0].Firstname, getEmployeeDetails[0].Nickname, getEmployeeDetails[0].Username, getEmployeeDetails[0].InOutStatusID, getEmployeeDetails[0].TelephoneExtension, getEmployeeDetails[0].FlagDeleted);
            }
            else
            {
                staff = new Staff(getEmployeeDetails[0].StaffID, getEmployeeDetails[0].Lastname, getEmployeeDetails[0].Firstname, getEmployeeDetails[0].Nickname, getEmployeeDetails[0].Username, getEmployeeDetails[0].InOutStatusID, getEmployeeDetails[0].TelephoneExtension, getEmployeeDetails[0].FlagDeleted,getEmployeeDetails[0].ManagerID);
            }

            return staff;
        }

    }
}