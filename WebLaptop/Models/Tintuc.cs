using System;
using System.Collections.Generic;

#nullable disable

namespace WebLaptop.Models
{
    public partial class Tintuc
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Scontent { get; set; }
        public string Contact { get; set; }
        public string Thumb { get; set; }
        public bool Published { get; set; }
        public string Alias { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Author { get; set; }
        public int? AccountId { get; set; }
        public string Tags { get; set; }
        public int? CatId { get; set; }
        public bool? IsHot { get; set; }
        public bool? IsNewfeed { get; set; }
        public string MetaKey { get; set; }
        public string MetaDesc { get; set; }
        public int? Views { get; set; }

        public virtual TaiKhoan Account { get; set; }
        public virtual Category Cat { get; set; }
    }
}
