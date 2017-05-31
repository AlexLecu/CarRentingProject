using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace CarRentingProject.Models
{
    public class Car
    {
        public int id { get; set; }
        public string type { get; set; }
        public string brand { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public DateTime pickup { get; set; }
        public DateTime returnDate { get; set; }
        public byte[] image { get; set; }

    }
}