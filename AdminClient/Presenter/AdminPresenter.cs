using AdminClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminClient.Presenter
{
    public class AdminPresenter
    {
        private readonly IAdmin view;

        public AdminPresenter(IAdmin view)
        {
            this.view = view;

            this.view.Car += OnCar;
            this.view.Customer += OnCustomer;
            this.view.Employee += OnEmployee;
        }

        public void OnCar()
        {
            var form = new FormAdminCar();
            var presenter = new AdminCarPresenter(form);
            form.Show();
        }

        public void OnCustomer()
        {
            var form = new FormAdminCustomer();
            var presenter = new AdminCustomerPresenter(form);
            form.Show();
        }

        public void OnEmployee()
        {
            var form = new FormAdminEmployee();
            var presenter = new AdminEmployeePresenter(form);
            form.Show();
        }
    }
}
