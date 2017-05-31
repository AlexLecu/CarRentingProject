using EmployeeClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using CarRentingProject.Models;
using System.IO;

namespace EmployeeClient.Presenter
{
    public class FormPresenter
    {
        private readonly IForm view;

        public FormPresenter(IForm view)
        {
            this.view = view;

            this.view.Create += OnCreate;
            this.view.Return += OnReturn;
            this.view.Refresh += OnRefresh;
        }

        public void OnRefresh()
        {
            var id = this.view.RetrieveCustomerId();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Employee/GetRentById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                var rentcar = response.Content.ReadAsAsync<Rentcar>().Result;
                this.view.LoadCarReturned(rentcar.isReturned);
            }
        }

        public void OnCreate()
        {
            var id = this.view.RetrieveCustomerId();

            Rentcar rentcar = new Rentcar();
            Customer customer = new Customer();
            Car car = new Car();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Employee/GetRentById/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                rentcar = response.Content.ReadAsAsync<Rentcar>().Result;
            }
            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("http://localhost:57626/");

            client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response2 = client2.GetAsync("api/Employee/GetCustomerById/" + id).Result;
            if (response2.IsSuccessStatusCode)
            {
                customer = response2.Content.ReadAsAsync<Customer>().Result;
            }
            HttpClient client3 = new HttpClient();
            client3.BaseAddress = new Uri("http://localhost:57626/");

            client3.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response3 = client3.GetAsync("api/Employee/GetCarById/" + rentcar.idcar).Result;
            if (response3.IsSuccessStatusCode)
            {
                car = response3.Content.ReadAsAsync<Car>().Result;
            }

            string path = @"F:\Contract.txt";

            var csv = new StringBuilder();
            csv.AppendLine("Clientul cu ID-ul" + view.RetrieveCustomerId() + " , numele " + customer.name + " nascut in data de " + customer.birthdate + " cu domiciliul in " + customer.address);
            csv.AppendLine(" a inchiriat o masina de tip " + car.type + " marca " + car.brand + " in orasul " + car.city + " din tara " + car.country);
            csv.AppendLine(" in data de " + car.pickup + " pana la data de " + car.returnDate);
            csv.AppendLine("Semnatura dumneavoasta!");

            File.WriteAllText(path, String.Empty);

            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(csv);
                view.ShowMessageRaport();
            }

        }

        public void OnReturn()
        {
            var id = this.view.RetrieveCustomerId();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Employee/GetRentById/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                var rentcar = response.Content.ReadAsAsync<Rentcar>().Result;
                rentcar.isReturned = 1;

                HttpClient client2 = new HttpClient();
                client2.BaseAddress = new Uri("http://localhost:57626/");

                client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response2 = client.PutAsJsonAsync("api/Employee/UpdateRent", rentcar).Result;


            }
        }

    }
}
