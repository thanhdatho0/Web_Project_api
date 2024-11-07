using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
            .HasMany(e => e.Orders)
            .WithMany(e => e.Products)
            .UsingEntity<OrderDetail>();

            modelBuilder.Entity<Product>()
            .HasMany(e => e.Colors)
            .WithMany(e => e.Products)
            .UsingEntity<ProductColor>();

            modelBuilder.Entity<Product>()
            .HasMany(e => e.Sizes)
            .WithMany(e => e.Products)
            .UsingEntity<ProductSize>();

            modelBuilder.Entity<Product>()
            .HasMany(e => e.Materials)
            .WithMany(e => e.Products)
            .UsingEntity<ProductMaterial>();

            modelBuilder.Entity<Department>()
            .HasMany(e => e.Employees)
            .WithOne(e => e.Department);

            modelBuilder.Entity<Color>()
                .HasMany(e => e.Images)
                 .WithOne(e => e.Color);

            // Employee vs Order
            modelBuilder.Entity<Employee>()
            .HasMany(e => e.Orders)
            .WithOne(o => o.Employee);

            // Provider vs Product
            modelBuilder.Entity<Provider>()
            .HasMany(pr => pr.ProviderProducts)
            .WithOne(p => p.Provider);

            // Customer vs Order
            modelBuilder.Entity<Customer>()
            .HasMany(e => e.Orders)
            .WithOne(o => o.Customer);

            // Đặt giá trị mặc định cho isDelete là false
            modelBuilder.Entity<Product>()
            .Property(p => p.isDeletet)
            .HasDefaultValue(false);

            // Đặt giá trị mặc đinh cho Male là true
            modelBuilder.Entity<Employee>()
            .Property(e => e.Male)
            .HasDefaultValue(true);

            // Đặt giá trị OrderExportDateTime là ngày hiện tại khi nhập
            modelBuilder.Entity<Order>()
            .Property(o => o.OrderExportDateTime)
            .HasDefaultValueSql("GETDATE()");

            // Check tuổi Employee
            modelBuilder.Entity<Employee>().ToTable(t =>
            t.HasCheckConstraint("CK_Employee_Age", "DATEDIFF(YEAR, DateOfBirth, GETDATE()) >= 16"));
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductMaterial> ProductMaterials { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductColor> ProductColors { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Size> Sizes { get; set; }

    }
}