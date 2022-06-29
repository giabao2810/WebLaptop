using System;
using System.Collections.Generic;

#nullable disable

namespace WebLaptop.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
            Tintucs = new HashSet<Tintuc>();
        }

        public int CatId { get; set; }
        public string CastName { get; set; }
        public string Descriiption { get; set; }
        public int? ParentId { get; set; }
        public int? Levels { get; set; }
        public int? Ordering { get; set; }
        public int Published { get; set; }
        public string Thumb { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string MetaDesc { get; set; }
        public string MetaKey { get; set; }
        public string Cover { get; set; }
        public string SchemaMarkup { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Tintuc> Tintucs { get; set; }
    }
}
