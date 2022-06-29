using System;
using System.Collections.Generic;

#nullable disable

namespace WebLaptop.Models
{
    public partial class Order
    {
        public Order()
        {
            ChitietOrders = new HashSet<ChitietOrder>();
        }

        public int Id { get; set; }
        public int? KhachhangId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? TransacStatusId { get; set; }
        public bool? Delete { get; set; }
        public bool? Paid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? PaymentId { get; set; }
        public string Note { get; set; }

        public virtual Khachhang Khachhang { get; set; }
        public virtual TransacStatus TransacStatus { get; set; }
        public virtual ICollection<ChitietOrder> ChitietOrders { get; set; }
    }
}
