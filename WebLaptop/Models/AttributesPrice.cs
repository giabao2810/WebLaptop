using System;
using System.Collections.Generic;

#nullable disable

namespace WebLaptop.Models
{
    public partial class AttributesPrice
    {
        public int Id { get; set; }
        public int? AttributesId { get; set; }
        public int? ProductId { get; set; }
        public int? Price { get; set; }
        public bool Active { get; set; }

        public virtual Attribute Attributes { get; set; }
        public virtual Product Product { get; set; }
    }
}
