using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRentingProject.Models;

namespace AdminClient
{
    public interface IAdminCar
    {
        event Action Add;
        event Action Get;
        event Action Update;
        event Action Delete;
        event Action CarSelected;

        Car SelectedCar { get; }

        void LoadCar(Car car);
        void LoadCars(IList<Car> cars);

        Car RetrieveCar();
        int RetrieveCarId();
    }
}
