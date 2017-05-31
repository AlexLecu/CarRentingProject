using CarRentingProject.Models;
using CustomerClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClient.Presenter
{
    public class FindCarPresenter
    {
        private readonly IFindCar view;

        public FindCarPresenter(IFindCar view)
        {
            this.view = view;

            this.view.See += OnSeeCar;
            this.view.Rent += OnRentCar;
            this.view.CarSelected += OnCarSelected;
        }

        public void OnSeeCar()
        {
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Customer/GetCar").Result;

            if (response.IsSuccessStatusCode)
            {
                var cars = response.Content.ReadAsAsync<IList<Car>>().Result;
                this.view.LoadCars(cars);
            }
            
        }

        public void OnRentCar()
        {
            if (this.view.SelectedCar != null)
            {
                var id = this.view.SelectedCar.id;
                var myCar = this.view.RetrieveCar();

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:57626/");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Customer/GetCarById/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var car = response.Content.ReadAsAsync<Car>().Result;
                    if((DateTime.Compare(myCar.pickup, car.pickup) < 0) || (DateTime.Compare(myCar.returnDate, car.returnDate) > 0))
                    {
                        view.showMessage();
                    }
                    else
                    {
                        var form = new FormRentCar();
                        var presenter = new RentCarPresenter(form, view);
                        form.Show();
                    }
                }
            }
        }

        public void OnCarSelected()
        {
            if (this.view.SelectedCar != null)
            {
                var id = this.view.SelectedCar.id;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:57626/");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Customer/GetCarById/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var car = response.Content.ReadAsAsync<Car>().Result;
                    this.view.LoadCar(car);
                }
            }
        }
    }
}
