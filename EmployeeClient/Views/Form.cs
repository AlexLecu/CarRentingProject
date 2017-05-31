using EmployeeClient.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeClient
{
    public partial class Form1 : Form, IForm
    {
        public event Action Create;
        public event Action Return;
        public event Action Refresh;

        public Form1()
        {
            InitializeComponent();
            BindComponent();
        }

        private void BindComponent()
        {
            this.btnCreate.Click += OnCreateButtonClick;
            this.btnReturn.Click += OnReturnButtonClick;
            this.btnRefresh.Click += OnRefreshButtonClick;
        }

        public int RetrieveCustomerId()
        {
            return Convert.ToInt32(txtId.Text);
        }

        public void ShowMessageRaport()
        {
            MessageBox.Show("Contractul a fost creat cu succes!");
        }

        public void LoadCarReturned(int isReturned)
        {
            this.txtCarReturned.Text = Convert.ToString(isReturned);
        }

        public void OnCreateButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Create != null)
                {
                    this.Create();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnReturnButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Return != null)
                {
                    this.Return();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void OnRefreshButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.Refresh != null)
                {
                    this.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
