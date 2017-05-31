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
    public partial class FormAdminCustomer : Form, IAdminCustomer
    {
        public event Action Add;
        public event Action Get;
        public event Action Delete;
        public event Action Update;
        public event Action CustomerSelected;

        public FormAdminCustomer()
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

            this.CustomerListBox.DisplayMember = "name";
            this.CustomerListBox.SelectedIndexChanged += OnCustomerListBoxSelectedIndexChanged;
        }

        public Customer RetrieveCustomer()
        {

            Customer customer = new Customer();

            customer.id = Convert.ToInt32(txtCustomerId.Text);
            customer.name = txtCustomerName.Text;
            customer.password = txtCustomerPassword.Text;
            customer.cnp = txtCustomerCNP.Text;
            customer.birthdate = dtpBirthdate.Value;
            customer.address = txtCustomerAddress.Text;

            return customer;
        }

        public int RetrieveCustomerId()
        {
            return Convert.ToInt32(txtCustomerId.Text);
        }

        public void LoadCustomer(Customer customer)
        {
            txtCustomerId.Text = customer.id.ToString();
            txtCustomerName.Text = customer.name;
            txtCustomerPassword.Text = customer.password;
            txtCustomerCNP.Text = customer.cnp;
            dtpBirthdate.Value = customer.birthdate;
            txtCustomerAddress.Text = customer.address;
        }

        public Customer SelectedCustomer
        {
            get { return this.CustomerListBox.SelectedItem as Customer; }
        }

        public void LoadCustomers(IList<Customer> customers)
        {
            this.CustomerListBox.DataSource = customers;
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

        private void OnCustomerListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.CustomerSelected != null)
                {
                    this.CustomerSelected();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
