using DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeStatusTest
{
    public partial class Form3 : Form
    {
        DatabaseDataSet.getEmployeeDetailsDataTable GetEmployees;
        object[] employee;
        public Form3(object[] values)
        {
            InitializeComponent();

            GetEmployees = StaffDAL.getEmployeeDetails(int.Parse(values[0].ToString()));
            employee = GetEmployees.Rows[0].ItemArray;

            txtFirstName.Text = employee[1].ToString();
            txtLastName.Text = employee[2].ToString();
            txtNickname.Text = employee[3].ToString();
            txtTelephoneExtension.Text = employee[6].ToString();
            txtUsername.Text = employee[4].ToString();
            txtFlagDeleted.Text = employee[7].ToString();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpate_Click(object sender, EventArgs e)
        {
            if (StaffDAL.UpdateEmployeeDetails(int.Parse(employee[0].ToString()), txtLastName.Text, txtFirstName.Text, txtNickname.Text, txtTelephoneExtension.Text, bool.Parse(txtFlagDeleted.Text)))
            {
                this.Close();
            }
            else
            {
                MessageBox.Show("Update Failed");
            }
        }
    }
}
