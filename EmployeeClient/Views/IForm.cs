using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeClient.Views
{
    public interface IForm
    {
        event Action Create;
        event Action Return;
        event Action Refresh;

        int RetrieveCustomerId();
        void ShowMessageRaport();
        void LoadCarReturned(int isReturned);
    }
}
