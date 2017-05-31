using EmployeeClient.Presenter;
using EmployeeClient.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace EmployeeClient
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

            //var form = new Form1();
            //var formPresenter = new FormPresenter(form);

            var form = new FormLogin();
            var formPresenter = new FormLoginPresenter(form);

            Application.Run(form);
        }
    }
}
