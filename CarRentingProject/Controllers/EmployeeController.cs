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
    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        RentcarProvider rp = new RentcarProvider();
        CarProvider carProvider = new CarProvider();
        CustomerProvider cp = new CustomerProvider();
        EmployeeProvider ep = new EmployeeProvider();

        //GET: api/Employee/GetRentById
        [Route("GetRentById/{id}")]
        public Rentcar GetRentById(int id)
        {
            return rp.GetById(id);
        }

        //GET: api/Employee/GetCarById
        [Route("GetCarById/{id}")]
        public Car GetCarById(int id)
        {
            return carProvider.GetById(id);
        }

        //GET: api/Employee/GetCustomerById
        [Route("GetCustomerById/{id}")]
        public Customer GetCustomerById(int id)
        {
            return cp.GetById(id);
        }

        [Route("UpdateRent")]
        //POST api/Employee/UpdateRent
        public void PutRent([FromBody]Rentcar value)
        {
            rp.UpdateRentcar(value);
        }

        [Route("GetEmployee")]
        //POST api/Employee/GetEmployee
        public IList<Employee> GetEmployee()
        {
            return ep.RetrieveEmployee();
        }
    }
}