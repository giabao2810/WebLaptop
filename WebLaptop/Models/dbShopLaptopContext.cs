using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebLaptop.Models
{
    public partial class DbShopLaptopContext : DbContext
    {
        public DbShopLaptopContext()
        {
        }

        public DbShopLaptopContext(DbContextOptions<DbShopLaptopContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Attribute> Attributes { get; set; }
        public virtual DbSet<AttributesPrice> AttributesPrices { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<ChitietOrder> ChitietOrders { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<TaiKhoan> TaiKhoans { get; set; }
        public virtual DbSet<Tintuc> Tintucs { get; set; }
        public virtual DbSet<TransacStatus> TransacStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=ADMIN;Database=DbShopLaptop;;User=sa;Password=sa");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Attribute>(entity =>
            {
                entity.ToTable("attributes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(250);
            });

            modelBuilder.Entity<AttributesPrice>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.AttributesId).HasColumnName("AttributesID");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.HasOne(d => d.Attributes)
                    .WithMany(p => p.AttributesPrices)
                    .HasForeignKey(d => d.AttributesId)
                    .HasConstraintName("FK_AttributesPrices_attributes");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.AttributesPrices)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_AttributesPrices_Products");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CastName).HasMaxLength(250);

                entity.Property(e => e.Cover).HasMaxLength(250);

                entity.Property(e => e.MetaDesc).HasMaxLength(250);

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.ParentId).HasColumnName("ParentID");

                entity.Property(e => e.Thumb).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(250);
            });

            modelBuilder.Entity<ChitietOrder>(entity =>
            {
                entity.ToTable("chitietOrder");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.OrderId).HasColumnName("orderID");

                entity.Property(e => e.ProductId).HasColumnName("productID");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.ChitietOrders)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK_chitietOrder_Order");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ChitietOrders)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_chitietOrder_Products");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.ToTable("khachhang");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Avatar).HasMaxLength(250);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(250)
                    .HasColumnName("diachi");

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .HasColumnName("email");

                entity.Property(e => e.FullName).HasMaxLength(250);

                entity.Property(e => e.LastLogin).HasColumnType("datetime");

                entity.Property(e => e.LocationId).HasColumnName("LocationID");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(50)
                    .HasColumnName("matkhau");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.Salt)
                    .HasMaxLength(8)
                    .IsFixedLength(true);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("sdt");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Khachhangs)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_khachhang_Location");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.Property(e => e.NameWithType).HasMaxLength(255);

                entity.Property(e => e.PathWithType).HasMaxLength(255);

                entity.Property(e => e.Slug).HasMaxLength(100);

                entity.Property(e => e.Type).HasMaxLength(20);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.KhachhangId).HasColumnName("khachhangID");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("datetime")
                    .HasColumnName("orderDate");

                entity.Property(e => e.PaymentDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentId).HasColumnName("PaymentID");

                entity.Property(e => e.ShipDate).HasColumnType("datetime");

                entity.Property(e => e.TransacStatusId).HasColumnName("TransacStatusID");

                entity.HasOne(d => d.Khachhang)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.KhachhangId)
                    .HasConstraintName("FK_Order_khachhang");

                entity.HasOne(d => d.TransacStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.TransacStatusId)
                    .HasConstraintName("FK_Order_TransacStatus");
            });

            modelBuilder.Entity<Page>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CreatedAt).HasColumnType("datetime");

                entity.Property(e => e.MetaDesc).HasMaxLength(250);

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.PageName)
                    .HasMaxLength(250)
                    .HasColumnName("pageName");

                entity.Property(e => e.Thumb).HasMaxLength(250);

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("title");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateModified).HasColumnType("datetime");

                entity.Property(e => e.MetaDesc).HasMaxLength(250);

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.ProducName)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ShortDesc).HasMaxLength(250);

                entity.Property(e => e.Thumb).HasMaxLength(250);

                entity.Property(e => e.Title).HasMaxLength(250);

                entity.Property(e => e.Video).HasMaxLength(250);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_Products_Categories");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Desciption).HasMaxLength(50);

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Shipper>(entity =>
            {
                entity.ToTable("Shipper");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Company).HasMaxLength(150);

                entity.Property(e => e.Phone)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.ShipperName)
                    .HasMaxLength(150)
                    .HasColumnName("shipperName");
            });

            modelBuilder.Entity<TaiKhoan>(entity =>
            {
                entity.ToTable("TaiKhoan");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createlogin)
                    .HasColumnType("datetime")
                    .HasColumnName("createlogin");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Lastlogin)
                    .HasColumnType("datetime")
                    .HasColumnName("lastlogin");

                entity.Property(e => e.Matkhau)
                    .HasMaxLength(50)
                    .HasColumnName("matkhau");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.Salt)
                    .HasMaxLength(6)
                    .HasColumnName("salt")
                    .IsFixedLength(true);

                entity.Property(e => e.Sdt)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("sdt");

                entity.Property(e => e.Ten)
                    .HasMaxLength(150)
                    .HasColumnName("ten");

                entity.Property(e => e.Trangthai).HasColumnName("trangthai");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.TaiKhoans)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_TaiKhoan_Roles");
            });

            modelBuilder.Entity<Tintuc>(entity =>
            {
                entity.ToTable("tintucs");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("AccountID");

                entity.Property(e => e.Alias).HasMaxLength(250);

                entity.Property(e => e.Author).HasMaxLength(250);

                entity.Property(e => e.CatId).HasColumnName("CatID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.IsHot).HasColumnName("isHot");

                entity.Property(e => e.IsNewfeed).HasColumnName("isNewfeed");

                entity.Property(e => e.MetaDesc).HasMaxLength(250);

                entity.Property(e => e.MetaKey).HasMaxLength(250);

                entity.Property(e => e.Scontent)
                    .HasMaxLength(250)
                    .HasColumnName("SContent");

                entity.Property(e => e.Thumb).HasMaxLength(250);

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .HasColumnName("title");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Tintucs)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK_tintucs_TaiKhoan");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Tintucs)
                    .HasForeignKey(d => d.CatId)
                    .HasConstraintName("FK_tintucs_Categories");
            });

            modelBuilder.Entity<TransacStatus>(entity =>
            {
                entity.ToTable("TransacStatus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
