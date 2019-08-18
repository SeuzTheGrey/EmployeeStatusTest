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
    public partial class ChangeStatus : Form
    {
        object[] employee;
        int UserID;
        public ChangeStatus(int UserId, object[] values)
        {
            employee = values;
            this.UserID = UserId;
            InitializeComponent();
            List<InOutStatus> inOutStatuses = InOutStatus.GetStatuses();
            BindingSource bindingSourcestatuses = new BindingSource(inOutStatuses, null);
            cmbStatus.DataSource = bindingSourcestatuses;
            cmbStatus.DisplayMember = "Description";
            cmbStatus.ValueMember = "InOutStatusID";
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
           
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            StaffInOutHistoryDAL.UpdateStatus(int.Parse(employee[0].ToString()), UserID, int.Parse(cmbStatus.SelectedValue.ToString()));
            this.Close();
        }
    }
}
