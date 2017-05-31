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

namespace CustomerClient.Views
{
    public partial class FormRentCar : Form, IRentCar
    {
        public event Action Rent;

        public FormRentCar()
        {
            InitializeComponent();
            BindComponent();
        }

        private void BindComponent()
        {
            this.btnRent.Click += OnRentButtonClick;
        }

        public Customer RetrieveCustomer()
        {
            Customer customer = new Customer();

            customer.id = Convert.ToInt32(txtId.Text);
            customer.name = txtName.Text;
            customer.password = txtPassword.Text;
            customer.cnp = txtCNP.Text;
            customer.birthdate = dtpBirthdate.Value;
            customer.address = txtAddress.Text;

            return customer;
        }

        public void ShowMessage()
        {
            MessageBox.Show("Inchirierea a fost realizata cu succes! O sa primiti un mail de confirmare!");
        }

        public void ShowMessageEx(Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        public void OnRentButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Rent != null)
                {
                    this.Rent();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
