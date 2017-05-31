using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminClient.Presenter;
using System.Net.Http;
using System.Net.Http.Headers;
using CarRentingProject.Models;

namespace AdminClient.Presenter
{
    public class AdminCarPresenter
    {
        private readonly IAdminCar view;

        public AdminCarPresenter(IAdminCar view)
        {
            this.view = view;

            this.view.Add += OnAddCar;
            this.view.Get += OnGetCar;
            this.view.CarSelected += OnCarSelected;
            this.view.Update += OnUpdateCar;
            this.view.Delete += OnDeleteCar;
        }

        public void OnAddCar()
        {
            var car = this.view.RetrieveCar();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/Admin/AddCar", car).Result;

        }

        public void OnUpdateCar()
        {
            var car = this.view.RetrieveCar();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PutAsJsonAsync("api/Admin/UpdateCar", car).Result;

        }

        public void OnDeleteCar()
        {
            var carId = this.view.RetrieveCarId();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync("api/Admin/DeleteCar/" + carId ).Result;
        }

        public void OnGetCar()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Admin/GetCar").Result;

            if (response.IsSuccessStatusCode)
            {
                var cars = response.Content.ReadAsAsync<IList<Car>>().Result;
                this.view.LoadCars(cars);
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

                HttpResponseMessage response = client.GetAsync("api/Admin/GetCarById/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var car = response.Content.ReadAsAsync<Car>().Result;
                    this.view.LoadCar(car);
                }
            }
        }

    }
}
