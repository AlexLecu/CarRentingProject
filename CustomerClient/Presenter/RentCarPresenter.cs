using CustomerClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CarRentingProject.Models;

namespace CustomerClient.Presenter
{
    public class RentCarPresenter
    {
        private readonly IRentCar view;
        private readonly IFindCar viewFind;

        public RentCarPresenter(IRentCar view, IFindCar viewFind)
        {
            this.view = view;
            this.viewFind = viewFind;

            this.view.Rent += OnRentCar;
        }

        public void OnRentCar()
        {
            var customer = this.view.RetrieveCustomer();

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:57626/");

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("api/Customer/AddCustomer", customer).Result;

            var rentcar = new Rentcar();

            rentcar.idcustomer = customer.id;
            rentcar.idcar = viewFind.returnCarId();
            rentcar.isReturned = 0;

            HttpClient client2 = new HttpClient();
            client2.BaseAddress = new Uri("http://localhost:57626/");

            client2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response2 = client.PostAsJsonAsync("api/Customer/AddRent", rentcar).Result;

            using (SmtpClient smtp = new SmtpClient())
            {
                smtp.Host = "smtp.gmail.com";
                smtp.UseDefaultCredentials = false;
                NetworkCredential netCred = new NetworkCredential("lecu.alex12@gmail.com", "laboratorPS");
                smtp.Credentials = netCred;
                smtp.EnableSsl = true;

                using (MailMessage msg = new MailMessage("lecu.alex12@gmail.com", "lecu.alex12@gmail.com"))
                {
                    msg.Subject = "Teste Proiect";
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("Salut, tocmai ai inchiriat o masina de la compania noastra");
                    sb.AppendLine("Datele dumneavoastra de contact sunt urmatoarele:");
                    sb.AppendLine("ID: " + customer.id);
                    sb.AppendLine("Name: " + customer.name);
                    sb.AppendLine("Password: " + customer.password);
                    sb.AppendLine("CNP: " + customer.cnp);
                    sb.AppendLine("Address: " + customer.address);
                    sb.AppendLine("Birthdate: " + customer.birthdate);
                    sb.AppendLine("Multumim pentu alegerea facuta!");
                    msg.Body = sb.ToString();
                    msg.IsBodyHtml = false;
                    smtp.Send(msg);
                }
            }

            try
            {
                view.ShowMessage();
            }
            catch(Exception ex)
            {
                view.ShowMessageEx(ex);
            }
        }
    }
}
