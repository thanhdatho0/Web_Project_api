using System.Collections.Specialized;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
        : IdentityDbContext<AppUser>(dbContextOptions)
    {
        #region DbSet
        public DbSet<TargetCustomer> TargetCustomers { get; set; }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Size> Sizes { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Category // TargerCustomer
            modelBuilder.Entity<TargetCustomer>()
            .HasMany(t => t.Categories)
            .WithOne(c => c.TargetCustomer);

            // Order vs Product
            modelBuilder.Entity<OrderDetail>().HasKey(x => new { x.OrderId, x.InventoryId });

            modelBuilder.Entity<OrderDetail>()
           .HasOne(od => od.Order)
           .WithMany(o => o.OrderDetails)
           .HasForeignKey(od => od.OrderId);
            
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Inventory)
                .WithMany(i => i.OrderDetails)
                .HasForeignKey(od => od.InventoryId);
            
            // Color vs image
            modelBuilder.Entity<Color>()
                .HasMany(e => e.Images)
                 .WithOne(e => e.Color);
            
            // Color vs Inventory
            modelBuilder.Entity<Color>()
                .HasMany(e => e.Inventories)
                .WithOne(e => e.Color);

            // Product vs image
            modelBuilder.Entity<Product>()
            .HasMany(p => p.Images)
            .WithOne(i => i.Product);

            //Product vs Inventory
            modelBuilder.Entity<Product>()
                .HasMany(p => p.Inventories)
                .WithOne(i => i.Product);
            
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

            // Category vs Subcategory 
            modelBuilder.Entity<Category>()
            .HasMany(c => c.Subcategories)
            .WithOne(s => s.Category);

            // Subcategory vs Product
            modelBuilder.Entity<Subcategory>()
            .HasMany(s => s.Products)
            .WithOne(p => p.Subcategory);
            
            //Size vs Inventory
            modelBuilder.Entity<Size>()
                .HasMany(s => s.Inventories)
                .WithOne(i => i.Size);

            //Inventory vs OrderDetails
            modelBuilder.Entity<Inventory>()
                .HasMany(i => i.OrderDetails)
                .WithOne(o => o.Inventory);
            
            // Đặt giá trị mặc định cho isDelete là false
            modelBuilder.Entity<Product>()
            .Property(p => p.IsDeleted)
            .HasDefaultValue(false);

            // Đặt giá trị mặc đinh cho Male là true
            modelBuilder.Entity<Employee>()
            .Property(e => e.Male)
            .HasDefaultValue(true);

            modelBuilder.Entity<Product>()
            .Property(p => p.CreatedAt)
            .HasDefaultValueSql("NOW() AT TIME ZONE 'Asia/Ho_Chi_Minh'");

            modelBuilder.Entity<Product>()
           .Property(p => p.UpdatedAt)
           .HasDefaultValueSql("NOW() AT TIME ZONE 'Asia/Ho_Chi_Minh'");

            // Đặt giá trị OrderExportDateTime là ngày hiện tại khi nhập
            modelBuilder.Entity<Order>()
            .Property(o => o.OrderExportDateTime)
            .HasDefaultValueSql("NOW() AT TIME ZONE 'Asia/Ho_Chi_Minh'");

            // rang buoc kieu unique
            modelBuilder.Entity<Category>()
            .HasIndex(c => c.Name)
            .IsUnique();

            modelBuilder.Entity<Subcategory>()
            .HasIndex(c => c.SubcategoryName)
            .IsUnique();

            modelBuilder.Entity<Color>()
            .HasIndex(c => new { c.HexaCode, c.Name })
            .IsUnique();

            modelBuilder.Entity<Product>()
           .HasIndex(c => c.Name)
           .IsUnique();

            modelBuilder.Entity<Size>()
            .HasIndex(c => c.SizeValue)
            .IsUnique();

            // Check tuổi Employee
            modelBuilder.Entity<Employee>().ToTable(t =>
            // t.HasCheckConstraint("CK_Employee_Age", "DATEDIFF(YEAR, DateOfBirth, GETDATE()) >= 16"));
            t.HasCheckConstraint("CK_Employee_Age", "EXTRACT(YEAR FROM AGE(NOW(), \"DateOfBirth\")) >= 16"));

            List<IdentityRole> roles =
            [
                new()
                {
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },


                new()
                {
                    Name = "Customer",
                    NormalizedName = "Customer"
                },


                new()
                {
                    Name = "Employee",
                    NormalizedName = "Employee",
                }
            ];

            modelBuilder.Entity<IdentityRole>().HasData(roles);
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(ul => new { ul.UserId, ul.LoginProvider, ul.ProviderKey });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });
        }
    }
}