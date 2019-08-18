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
    public partial class Form4 : Form
    {
        int UserId;
        public Form4(int UserId)
        {
            this.UserId = UserId;
            InitializeComponent();
            List<InOutStatus> inOutStatuses = InOutStatus.GetStatuses();
            List<Staff> staffs = Staff.GetStaffs();
            BindingSource bindingSourcestatuses = new BindingSource(inOutStatuses, null);
            BindingSource bindingSourceStaff = new BindingSource(staffs, null);
            cmbStatus.DataSource = bindingSourcestatuses;
            cmbManagerID.DataSource = bindingSourceStaff;
            cmbStatus.DisplayMember = "Description";
            cmbStatus.ValueMember = "InOutStatusID";
            cmbManagerID.DisplayMember = "FirstName";
            cmbManagerID.ValueMember = "StaffID";
            cmbManagerID.SelectedIndex = -1;
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            Staff staff;
            if (cmbManagerID.SelectedValue != null)
            {
                 staff = new Staff(0, txtlastName.Text, txtFirstName.Text, txtNickName.Text, txtUsername.Text, int.Parse(cmbStatus.SelectedValue.ToString()), txtExtension.Text, bool.Parse(txtFlagDeleted.Text), int.Parse(cmbManagerID.SelectedValue.ToString()));
            }
            else
            {
                staff = new Staff(0, txtlastName.Text, txtFirstName.Text, txtNickName.Text, txtUsername.Text, int.Parse(cmbStatus.SelectedValue.ToString()), txtExtension.Text, bool.Parse(txtFlagDeleted.Text));
            }
            Staff.InsertEmployee(staff, UserId);
            this.Close();
        }
    }
}
