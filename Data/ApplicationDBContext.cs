using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Order vs Product
            modelBuilder.Entity<OrderDetail>(entity => entity.HasKey(o => new { o.OrderId, o.ProductId }));

            modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<OrderDetail>()
           .HasOne(od => od.Order)
           .WithMany(o => o.OrderDetails)
           .HasForeignKey(od => od.OrderId);

            // Product vs Color
            modelBuilder.Entity<ProductColor>(entity => entity.HasKey(pc => new { pc.ColorId, pc.ProductId }));

            modelBuilder.Entity<ProductColor>()
            .HasOne(pc => pc.Color)
            .WithMany(c => c.ProductColors)
            .HasForeignKey(pc => pc.ColorId);

            modelBuilder.Entity<ProductColor>()
            .HasOne(pc => pc.Product)
            .WithMany(p => p.ProductColors)
            .HasForeignKey(pc => pc.ProductId);

            // Product vs size
            modelBuilder.Entity<ProductSize>(entity => entity.HasKey(pz => new { pz.ProductId, pz.SizeId }));

            modelBuilder.Entity<ProductSize>()
            .HasOne(pz => pz.Product)
            .WithMany(p => p.ProductSizes)
            .HasForeignKey(pz => pz.ProductId);

            modelBuilder.Entity<ProductSize>()
           .HasOne(pz => pz.Size)
           .WithMany(s => s.ProductSizes)
           .HasForeignKey(pz => pz.SizeId);

            // Product vs Material
            modelBuilder.Entity<ProductMaterial>(x => x.HasKey(pm => new { pm.MaterialId, pm.ProductId }));

            modelBuilder.Entity<ProductMaterial>()
            .HasOne(pm => pm.Product)
            .WithMany(e => e.ProductMaterials)
            .HasForeignKey(pm => pm.ProductId);

            modelBuilder.Entity<ProductMaterial>()
           .HasOne(pm => pm.Material)
           .WithMany(e => e.ProductMaterials)
           .HasForeignKey(pm => pm.MaterialId);

            // Department vs Employee
            modelBuilder.Entity<Department>()
            .HasMany(e => e.Employees)
            .WithOne(e => e.Department);
            // Color vs image
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
            .Property(p => p.isDeleted)
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
            
            
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            
            modelBuilder.Entity<IdentityRole>().HasData(roles);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserToken<string>>().HasNoKey();
            modelBuilder.Entity<IdentityUserRole<string>>().HasNoKey();
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