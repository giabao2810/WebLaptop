using System;
using System.Collections.Generic;

#nullable disable

namespace WebLaptop.Models
{
    public partial class Attribute
    {
        public Attribute()
        {
            AttributesPrices = new HashSet<AttributesPrice>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AttributesPrice> AttributesPrices { get; set; }
    }
}
