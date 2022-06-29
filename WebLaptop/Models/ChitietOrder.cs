using System;
using System.Collections.Generic;

#nullable disable

namespace WebLaptop.Models
{
    public partial class ChitietOrder
    {
        public int Id { get; set; }
        public int? OrderId { get; set; }
        public int? ProductId { get; set; }
        public int? OrderNumber { get; set; }
        public int? Quantity { get; set; }
        public int? Discount { get; set; }
        public int? Total { get; set; }
        public DateTime? ShipDate { get; set; }

        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
    }
}
