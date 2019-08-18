﻿using DataAccess;
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
    public partial class Form1 : Form
    {
        DatabaseDataSet.GetEmployeesDataTable GetEmployees;
        BindingSource bindingSource;
        int UserId;
        public Form1(int UserId)
        {
            this.UserId = UserId;
            InitializeComponent();
            GetEmployees = StaffDAL.GetEmployees();
            bindingSource = new BindingSource(GetEmployees, null);
            dataGridView1.DataSource = bindingSource;
            this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            object[] values = GetEmployees[dataGridView1.SelectedRows[0].Index].ItemArray;
            Form2 Employee = new Form2(values,UserId);
            Employee.ShowDialog(this);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.dataGridView1.SelectedRows.Count > 0)

            {
                object[] values = GetEmployees[dataGridView1.SelectedRows[0].Index].ItemArray;
                bindingSource.RemoveAt(this.dataGridView1.SelectedRows[0].Index);
                StaffDAL.DeleteEmployee(int.Parse(values[0].ToString()));

            }

            else

            {

                MessageBox.Show("Please select one row");

            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            
            GetEmployees = StaffDAL.GetEmployees();
            bindingSource = new BindingSource(GetEmployees, null);
            dataGridView1.DataSource = bindingSource;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            object[] values = GetEmployees[dataGridView1.SelectedRows[0].Index].ItemArray;
            Form3 Employee = new Form3(values,UserId);
            Employee.ShowDialog(this);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Form4 Employee = new Form4(UserId);
            Employee.ShowDialog(this);
        }

        private void btnReporting_Click(object sender, EventArgs e)
        {
            object[] values = GetEmployees[dataGridView1.SelectedRows[0].Index].ItemArray;
            Form5 Employee = new Form5(values, UserId);
            Employee.ShowDialog(this);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            Export.ExportReports();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            object[] values = GetEmployees[dataGridView1.SelectedRows[0].Index].ItemArray;
            ChangeStatus changeStatus = new ChangeStatus(UserId, values);
            changeStatus.Show();
        }
    }
}
