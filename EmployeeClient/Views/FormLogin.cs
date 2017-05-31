using CarRentingProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeClient.Views
{
    public partial class FormLogin : Form, IFormLogin
    {
        public event Action Ok;

        public FormLogin()
        {
            InitializeComponent();
            BindComponent();
        }

        private void BindComponent()
        {
            this.btnOk.Click += OnOkButtonClick;
        }

        public Employee RetrieveEmployee()
        {
            Employee employee = new Employee();

            employee.id = 0;
            employee.name = txtName.Text;
            employee.password = txtPassword.Text;

            return employee;
        }

        public void OnOkButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Ok != null)
                {
                    this.Ok();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
