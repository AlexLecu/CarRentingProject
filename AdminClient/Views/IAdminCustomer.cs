using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentingProject.Models;

namespace AdminClient.Views
{
    public interface IAdminCustomer
    {
        event Action Add;
        event Action Get;
        event Action Update;
        event Action Delete;
        event Action CustomerSelected;

        Customer SelectedCustomer { get; }

        void LoadCustomer(Customer customer);
        void LoadCustomers(IList<Customer> customers);

        Customer RetrieveCustomer();
        int RetrieveCustomerId();
    }
}
