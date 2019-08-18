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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DatabaseDataSet.GetEmployeeListDataTable getEmployeeListRows = StaffDAL.getEmployeeList();

            foreach (DatabaseDataSet.GetEmployeeListRow item in getEmployeeListRows.Rows)
            {
                if (item.Username == txtUsername.Text)
                {
                    Form1 form = new Form1(item.StaffID);
                    form.Show();
                    this.Hide();
                }
            }
        }
    }
}
