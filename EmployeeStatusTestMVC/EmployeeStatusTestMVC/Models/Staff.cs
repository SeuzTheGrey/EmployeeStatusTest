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
        public string Status { get; set; }
        public string TelephoneExtension { get; set; }
        public bool FlagDeleted { get; set; }
        public int? ManagerID { get; set; }


        public Staff(int StaffID, string LastName, string FirstName, string Nickname, string TelephoneExtension, bool FlagDeleted, int? ManagerID)
        {
            this.StaffID = StaffID;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Nickname = Nickname;
            this.TelephoneExtension = TelephoneExtension;
            this.FlagDeleted = FlagDeleted;
            this.ManagerID = ManagerID;
        }

        public Staff(int StaffID, string LastName, string FirstName, string Nickname, string TelephoneExtension, bool FlagDeleted)
        {
            this.StaffID = StaffID;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Nickname = Nickname;
            this.TelephoneExtension = TelephoneExtension;
            this.FlagDeleted = FlagDeleted;
        }

        public Staff()
        {

        }

        public Staff(int StaffID, string LastName, string FirstName, string Status, string TelephoneExtension)
        {
            this.StaffID = StaffID;
            this.LastName = LastName;
            this.FirstName = FirstName;
            this.Status = Status;
            this.TelephoneExtension = TelephoneExtension;
        }

        public static List<Staff> GetStaffs()
        {
            List<Staff> staffs = new List<Staff>();
            DatabaseDataSet.GetEmployeesDataTable getEmployees = StaffDAL.GetEmployees();

            var data = from item in getEmployees select new Staff(item.StaffID, item.Firstname, item.Lastname, item.Status, item.Extension);

            foreach (var item in data)
            {
                staffs.Add(item);
            }

            return staffs;
        }

        public static Staff GetDetail(int StaffID)
        {
            Staff staffs = new Staff();
            DatabaseDataSet.getEmployeeDetailsDataTable getEmployees = StaffDAL.getEmployeeDetails(StaffID);

            var data = from item in getEmployees select new Staff(item.StaffID, item.Lastname, item.Firstname, item.Nickname, item.TelephoneExtension, item.FlagDeleted);

            foreach (var item in data)
            {
                staffs = item;
            }

            return staffs;
        }
    }
}