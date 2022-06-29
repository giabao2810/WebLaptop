using System;
using System.Collections.Generic;

#nullable disable

namespace WebLaptop.Models
{
    public partial class TaiKhoan
    {
        public TaiKhoan()
        {
            Tintucs = new HashSet<Tintuc>();
        }

        public int Id { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Matkhau { get; set; }
        public bool Trangthai { get; set; }
        public string Ten { get; set; }
        public int? RoleId { get; set; }
        public DateTime? Lastlogin { get; set; }
        public DateTime? Createlogin { get; set; }
        public string Salt { get; set; }

        public virtual Role Role { get; set; }
        public virtual ICollection<Tintuc> Tintucs { get; set; }
    }
}
