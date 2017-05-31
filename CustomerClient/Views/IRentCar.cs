using CarRentingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClient.Views
{
    public interface IRentCar
    {
        event Action Rent;
        Customer RetrieveCustomer();

        void ShowMessage();
        void ShowMessageEx(Exception ex);
    }
}
