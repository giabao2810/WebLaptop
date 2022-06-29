using System;
using System.Collections.Generic;

#nullable disable

namespace WebLaptop.Models
{
    public partial class Role
    {
        public Role()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Desciption { get; set; }

        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
