using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRentingProject.Models
{
    public class Rentcar
    {
        public int idcar { get; set; }
        public int idcustomer { get; set; }
        public int isReturned { get; set; }
    }
}