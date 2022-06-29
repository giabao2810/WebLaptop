using System;
using System.Collections.Generic;

#nullable disable

namespace WebLaptop.Models
{
    public partial class TransacStatus
    {
        public TransacStatus()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
