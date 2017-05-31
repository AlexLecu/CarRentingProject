using CarRentingProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerClient.Views
{
    public interface IFindCar
    {
        event Action See;
        event Action Rent;
        event Action CarSelected;

        Car SelectedCar { get; }

        void LoadCar(Car car);
        void LoadCars(IList<Car> cars);
        Car RetrieveCar();

        void showMessage();
        int returnCarId();
    }
}
