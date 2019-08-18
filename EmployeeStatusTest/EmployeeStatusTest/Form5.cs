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
    public partial class Form5 : Form
    {
        DatabaseDataSet.GetEmployeeHistoryDataTable GetEmployees;
        BindingSource bindingSource;
        public Form5(object[] values, int UserId)
        {
            InitializeComponent();
            GetEmployees = StaffInOutHistoryDAL.GetEmployeeHistories(int.Parse(values[0].ToString()));
            bindingSource = new BindingSource(GetEmployees, null);
            dataGridView1.DataSource = bindingSource;
        }
    }
}
