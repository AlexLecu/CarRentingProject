using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarRentingProject.Models;
using CarRentingProject.Providers;

namespace CarRentingProject.Controllers
{
    [RoutePrefix("api/Customer")]
    public class CustomerController : ApiController
    {
        CarProvider carProvider = new CarProvider();
        CustomerProvider cp = new CustomerProvider();
        RentcarProvider rp = new RentcarProvider();

        //GET: api/Customer/GetCar
        [Route("GetCar")]
        public IEnumerable<Car> GetCar()
        {
            return carProvider.RetrieveCar();
        }

        //GET: api/Customer/GetCarById
        [Route("GetCarById/{id}")]
        public Car GetCarById(int id)
        {
            return carProvider.GetById(id);
        }

        [Route("AddCustomer")]
        // POST: api/Customer/AddCustomer
        public void PostCustomer([FromBody]Customer value)
        {
            cp.AddCustomer(value);
        }

        [Route("AddRent")]
        // POST: api/Customer/AddCustomer
        public void PostRentcar([FromBody]Rentcar value)
        {
            rp.AddRentcar(value);
        }
    }
}