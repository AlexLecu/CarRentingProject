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
    [RoutePrefix("api/Admin")]
    public class AdminController : ApiController
    {
        CustomerProvider cp = new CustomerProvider();
        EmployeeProvider ep = new EmployeeProvider();
        CarProvider carProvider = new CarProvider();

        //GET: api/Admin/GetCustomer
        [Route("GetCustomer")]
        public IEnumerable<Customer> GetCustomer()
        {
            return cp.RetrieveCustomer();
        }

        [Route("AddCustomer")]
        // POST: api/Admini/AddCustomer
        public void PostCustomer([FromBody]Customer value)
        {
            cp.AddCustomer(value);
        }

        [Route("UpdateCustomer")]
        //POST api/Admin/UpdateCustomer
        public void PutCustomer([FromBody]Customer value)
        {
            cp.UpdateCustomer(value);
        }

        //GET: api/Admin/GetCustomerById
        [Route("GetCustomerById/{id}")]
        public Customer GetCustomerById(int id)
        {
            return cp.GetById(id);
        }

        [Route("DeleteCustomer/{id}")]
        //DELETE api/Admin/DeleteCustomer
        public void DeleteCustomer(int id)
        {
            cp.DeleteCustomer(id);
        }

        //GET: api/Admin/GetEmployee
        [Route("GetEmployee")]
        public IEnumerable<Employee> GetEmployee()
        {
            return ep.RetrieveEmployee();
        }

        [Route("AddEmployee")]
        // POST: api/Admin/AddEmployee
        public void PostEmployee([FromBody]Employee value)
        {
            ep.AddEmployee(value);
        }

        [Route("UpdateEmployee")]
        //POST api/Admin/UpdateEmployee
        public void PutEmployee([FromBody]Employee value)
        {
            ep.UpdateEmployee(value);
        }

        //GET: api/Admin/GetEmployeeById
        [Route("GetEmployeeById/{id}")]
        public Employee GetEmployeeById(int id)
        {
            return ep.GetById(id);
        }

        [Route("DeleteEmployee/{id}")]
        //DELETE api/Admin/DeleteEmployee
        public void DeleteEmployee(int id)
        {
            ep.DeleteEmployee(id);
        }

        [Route("AddCar")]
        // POST: api/Admin/AddCustomer
        public void PostCar([FromBody]Car value)
        {
            carProvider.AddCar(value);
        }

        //GET: api/Admin/GetCar
        [Route("GetCar")]
        public IEnumerable<Car> GetCar()
        {
            return carProvider.RetrieveCar();
        }

        //GET: api/Admin/GetCarById
        [Route("GetCarById/{id}")]
        public Car GetCarById(int id)
        {
            return carProvider.GetById(id);
        }

        [Route("UpdateCar")]
        //POST api/Admin/UpdateCar
        public void PutCar([FromBody]Car value)
        {
            carProvider.UpdateCar(value);
        }

        [Route("DeleteCar/{id}")]
        //DELETE api/Admin/DeleteEmployee
        public void DeleteCar(int id)
        {
            carProvider.DeleteCar(id);
        }
    }
}