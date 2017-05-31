using EmployeeClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentingProject.Models;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EmployeeClient.Presenter
{
    public class FormLoginPresenter
    {
        private readonly IFormLogin view;

        public FormLoginPresenter(IFormLogin view)
        {
            this.view = view;

            this.view.Ok += OnOk;
        }

        public void OnOk()
        {
            var employee = view.RetrieveEmployee();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync("api/Employee/GetEmployee").Result;

            if (response.IsSuccessStatusCode)
            {
                var employes = response.Content.ReadAsAsync<IList<Employee>>().Result;
                Security secure = new Security();

                for (int i = 0; i < employes.Count; i++)
                {
                    if (employes.ElementAt(i).name.Equals(employee.name) && employes.ElementAt(i).password.Equals(employee.password))
                    {
                        var form = new Form1();
                        var formPresenter = new FormPresenter(form);
                        form.Show();
                    }

                }
            }
        }
    }
}
