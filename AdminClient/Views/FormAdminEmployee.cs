using AdminClient.Views;
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

namespace AdminClient
{
    public partial class FormAdminEmployee : Form, IAdminEmployee
    {
        public event Action Add;
        public event Action Get;
        public event Action Update;
        public event Action Delete;
        public event Action EmployeeSelected;

        public FormAdminEmployee()
        {
            InitializeComponent();
            BindComponent();
        }

        private void BindComponent()
        {
            this.btnAdd.Click += OnAddButtonClick;
            this.btnGet.Click += OnGetButtonClick;
            this.btnUpdate.Click += OnUpdateButtonClick;
            this.btnDelete.Click += OnDeleteButtonClick;

            this.EmployeeListBox.DisplayMember = "name";
            this.EmployeeListBox.SelectedIndexChanged += OnEmployeeListBoxSelectedIndexChanged;
        }

        public Employee RetrieveEmployee()
        {
            Employee employee = new Employee();

            employee.id = Convert.ToInt32(txtId.Text);
            employee.name = txtName.Text;
            employee.password = txtPassword.Text;

            return employee;
        }

        public int RetrieveEmployeeId()
        {
            return Convert.ToInt32(txtId.Text);
        }

        public void LoadEmployee(Employee employee)
        {
            txtId.Text = employee.id.ToString();
            txtName.Text = employee.name;
            txtPassword.Text = employee.password;
        }

        public Employee SelectedEmployee
        {
            get { return this.EmployeeListBox.SelectedItem as Employee; }
        }

        public void LoadEmployes(IList<Employee> employes)
        {
            this.EmployeeListBox.DataSource = employes;
        }

        public void OnAddButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Add != null)
                {
                    this.Add();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnUpdateButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Update != null)
                {
                    this.Update();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnDeleteButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Delete != null)
                {
                    this.Delete();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnGetButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Get != null)
                {
                    this.Get();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnEmployeeListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.EmployeeSelected != null)
                {
                    this.EmployeeSelected();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
