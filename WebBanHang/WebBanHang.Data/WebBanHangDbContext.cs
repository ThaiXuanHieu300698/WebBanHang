namespace WebBanHang.Data.DomainModels
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WebBanHangDbContext : DbContext
    {
        public WebBanHangDbContext()
            : base("name=WebBanHangDbContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Category)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Product>()
                .Property(e => e.NewPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .Property(e => e.OldPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithOptional(e => e.Role)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Products)
                .WithOptional(e => e.Supplier)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserRoles)
                .WithOptional(e => e.User)
                .WillCascadeOnDelete();
        }
    }
}
