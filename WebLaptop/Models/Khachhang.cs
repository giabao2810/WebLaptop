using System;
using System.Collections.Generic;

#nullable disable

namespace WebLaptop.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public DateTime? Ngaysinh { get; set; }
        public string Avatar { get; set; }
        public string Diachi { get; set; }
        public string Email { get; set; }
        public string Sdt { get; set; }
        public int? LocationId { get; set; }
        public int? District { get; set; }
        public int? Ward { get; set; }
        public DateTime? CreateDate { get; set; }
        public string Matkhau { get; set; }
        public string Salt { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool Active { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
