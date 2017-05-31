using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentingProject.Models
{
    public class Customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string cnp { get; set; }
        public DateTime birthdate { get; set; }
        public string address { get; set; }
    }
}