using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminClient.Views
{
    public partial class FormAdmin : Form, IAdmin
    {
        public event Action Car;
        public event Action Customer;
        public event Action Employee;

        public FormAdmin()
        {
            InitializeComponent();
            BindComponent();
        }

        private void BindComponent()
        {
            this.btnCar.Click += OnCarButtonClick;
            this.btnCustomer.Click += OnCustomerButtonClick;
            this.btnEmployee.Click += OnEmployeeButtonClick;
        }

        public void OnCarButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Car != null)
                {
                    this.Car();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnCustomerButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Customer != null)
                {
                    this.Customer();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnEmployeeButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Employee != null)
                {
                    this.Employee();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
