using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminClient.Views
{
    public interface IAdmin
    {
        event Action Car;
        event Action Customer;
        event Action Employee;
    }
}
