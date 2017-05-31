using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using AdminClient.Presenter;
using AdminClient.Views;

namespace AdminClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //var formAdminCar = new FormAdminCar();
            //var adminPresenter = new AdminCarPresenter(formAdminCar);

            //var formAdminCustomer = new FormAdminCustomer();
            //var adminCustomerPresenter = new AdminCustomerPresenter(formAdminCustomer);

            //var formAdminEmployee = new FormAdminEmployee();
            //var adminEmployeePresenter = new AdminEmployeePresenter(formAdminEmployee);

            var formAdmin = new FormAdmin();
            var adminPresenter = new AdminPresenter(formAdmin);

            Application.Run(formAdmin);
        }
    }
}
