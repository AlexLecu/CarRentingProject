using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentingProject.Models;
using AdminClient.Views;
using System.Net.Http;
using System.Net.Http.Headers;

namespace AdminClient.Presenter
{
    public class AdminCustomerPresenter
    {
        private readonly IAdminCustomer view;

        public AdminCustomerPresenter(IAdminCustomer view)
        {
            this.view = view;

            this.view.Add += OnAddCustomer;
            this.view.Get += OnGetCustomer;
            this.view.CustomerSelected += OnCustomerSelected;
            this.view.Update += OnUpdateCustomer;
            this.view.Delete += OnDeleteCustomer;
        }

        public void OnAddCustomer()
        {
            var customer = this.view.RetrieveCustomer();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/Admin/AddCustomer", customer).Result;
        }

        public void OnUpdateCustomer()
        {
            var customer = this.view.RetrieveCustomer();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PutAsJsonAsync("api/Admin/UpdateCustomer", customer).Result;
        }

        public void OnDeleteCustomer()
        {
            var customerId = this.view.RetrieveCustomerId();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync("api/Admin/DeleteCustomer/" + customerId).Result;
        }

        public void OnGetCustomer()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Admin/GetCustomer").Result;

            if (response.IsSuccessStatusCode)
            {
                var customers = response.Content.ReadAsAsync<IList<Customer>>().Result;
                this.view.LoadCustomers(customers);
            }
        }

        public void OnCustomerSelected()
        {
            if (this.view.SelectedCustomer != null)
            {
                var id = this.view.SelectedCustomer.id;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:57626/");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Admin/GetCustomerById/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var customer = response.Content.ReadAsAsync<Customer>().Result;
                    this.view.LoadCustomer(customer);
                }
            }
        }
    }
}
