using CarRentingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClient.Views
{
    public interface IFormLogin
    {
        event Action Ok;

        Employee RetrieveEmployee();
    }
}
