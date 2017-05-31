using CustomerClient.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CarRentingProject.Models;

namespace CustomerClient
{
    public partial class FindCar : Form, IFindCar
    {
        public event Action See;
        public event Action Rent;
        public event Action CarSelected;
        ConvertImage ci = new ConvertImage();

        public FindCar()
        {
            InitializeComponent();
            BindComponent();
        }

        private void BindComponent()
        {
            this.btnRent.Click += OnRentButtonClick;
            this.btnSee.Click += OnSeeButtonClick;

            this.CarListBox.DisplayMember = "Brand";
            this.CarListBox.SelectedIndexChanged += OnCarListBoxSelectedIndexChanged;
        }

        public void showMessage()
        {
            MessageBox.Show("Masina nu este disponibila in perioada dorita!");
        }

        public Car RetrieveCar()
        {
            Car car = new Car();

            car.id = Convert.ToInt32(txtId.Text);
            car.type = txtType.Text;
            car.brand = txtBrand.Text;
            car.country = txtCountry.Text;
            car.city = txtCity.Text;
            car.pickup = dtpMyPickupDate.Value;
            car.returnDate = dtpMyReturnDate.Value;
            car.image = null;

            return car;
        }

        public int returnCarId()
        {
            return Convert.ToInt32(txtId.Text);
        }

        public void LoadCar(Car car)
        {
            txtId.Text = car.id.ToString();
            txtType.Text = car.type;
            txtBrand.Text = car.brand;
            txtCountry.Text = car.country;
            txtCity.Text = car.city;
            dtpPickup.Value = car.pickup;
            dtpReturn.Value = car.returnDate;
            pictureBox1.Image = ci.byteArrayToImage(car.image);
        }

        public Car SelectedCar
        {
            get { return this.CarListBox.SelectedItem as Car; }
        }

        public void LoadCars(IList<Car> cars)
        {
            this.CarListBox.DataSource = cars;
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

        public void OnSeeButtonClick(object sender, EventArgs e)
        {
            try
            {
                if (this.See != null)
                {
                    this.See();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnCarListBoxSelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.CarSelected != null)
                {
                    this.CarSelected();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
