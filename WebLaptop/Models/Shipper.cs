using System;
using System.Collections.Generic;

#nullable disable

namespace WebLaptop.Models
{
    public partial class Shipper
    {
        public int Id { get; set; }
        public string ShipperName { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
    }
}
