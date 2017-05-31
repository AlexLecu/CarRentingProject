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
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AdminClient
{
    public partial class FormAdminCar : Form, IAdminCar
    {
        public event Action Add;
        public event Action Get;
        public event Action Delete;
        public event Action Update;
        public event Action CarSelected;

        ConvertImage ci = new ConvertImage();

        public FormAdminCar()
        {
            InitializeComponent();
            BindComponent();
        }

        private void BindComponent()
        {
            this.btnAdd.Click += OnAddButtonClick;
            this.btnGetCar.Click += OnGetButtonClick;
            this.btnUpdateCar.Click += OnUpdateButtonClick;
            this.btnDeleteCar.Click += OnDeleteButtonClick;

            this.CarListBox.DisplayMember = "Brand";
            this.CarListBox.SelectedIndexChanged += OnCarListBoxSelectedIndexChanged;
        }

        public Car RetrieveCar()
        {

            Car car = new Car();

            car.id = Convert.ToInt32(txtCarId.Text);
            car.type = txtCarType.Text;
            car.brand = txtCarBrand.Text;
            car.country = txtCarCountry.Text;
            car.city = txtCarCity.Text;
            car.pickup = dtpPickup.Value;
            car.returnDate = dtpReturnDate.Value;
            car.image = ci.imageToByteArray(Image.FromFile(openFileDialog1.FileName));

            return car;
        }

        public int RetrieveCarId()
        {
            return Convert.ToInt32(txtCarId.Text);
        }

        public void LoadCar(Car car)
        {
            txtCarId.Text = car.id.ToString();
            txtCarType.Text = car.type;
            txtCarBrand.Text = car.brand;
            txtCarCountry.Text = car.country;
            txtCarCity.Text = car.city;
            dtpPickup.Value = car.pickup;
            dtpReturnDate.Value = car.returnDate;
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

        public void OnAddButtonClick(object sender, EventArgs e)
        {
            try
            {
                openFileDialog1.ShowDialog();
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
                openFileDialog1.ShowDialog();
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
