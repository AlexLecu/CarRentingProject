using AdminClient.Views;
using CarRentingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AdminClient.Presenter
{
    public class AdminEmployeePresenter
    {
        private readonly IAdminEmployee view;

        public AdminEmployeePresenter(IAdminEmployee view)
        {
            this.view = view;

            this.view.Add += OnAddEmployee;
            this.view.Get += OnGetEmployee;
            this.view.EmployeeSelected += OnEmployeeSelected;
            this.view.Update += OnUpdateEmployee;
            this.view.Delete += OnDeleteEmployee;
        }

        public void OnAddEmployee()
        {
            var employee = this.view.RetrieveEmployee();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/Admin/AddEmployee", employee).Result;
        }

        public void OnUpdateEmployee()
        {
            var employee = this.view.RetrieveEmployee();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PutAsJsonAsync("api/Admin/UpdateEmployee", employee).Result;
        }

        public void OnDeleteEmployee()
        {
            var employeeId = this.view.RetrieveEmployeeId();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync("api/Admin/DeleteEmployee/" + employeeId).Result;
        }

        public void OnGetEmployee()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Admin/GetEmployee").Result;

            if (response.IsSuccessStatusCode)
            {
                var employes = response.Content.ReadAsAsync<IList<Employee>>().Result;
                this.view.LoadEmployes(employes);
            }
        }

        public void OnEmployeeSelected()
        {
            if (this.view.SelectedEmployee != null)
            {
                var id = this.view.SelectedEmployee.id;

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:57626/");

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("api/Admin/GetEmployeeById/" + id).Result;

                if (response.IsSuccessStatusCode)
                {
                    var employee = response.Content.ReadAsAsync<Employee>().Result;
                    this.view.LoadEmployee(employee);
                }
            }
        }
    }
}
