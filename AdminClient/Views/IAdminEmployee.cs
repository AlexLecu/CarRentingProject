using CarRentingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminClient.Views
{
    public interface IAdminEmployee
    {
        event Action Add;
        event Action Get;
        event Action Update;
        event Action Delete;
        event Action EmployeeSelected;

        Employee SelectedEmployee { get; }

        void LoadEmployee(Employee employee);
        void LoadEmployes(IList<Employee> employes);

        Employee RetrieveEmployee();
        int RetrieveEmployeeId();
    }
}
