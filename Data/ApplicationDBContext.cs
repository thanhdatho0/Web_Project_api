using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Order vs Product
            modelBuilder.Entity<OrderDetail>(entity => entity.HasKey(o => new { o.OrderId, o.ProductId, o.ColorId, o.SizeId }));

            modelBuilder.Entity<OrderDetail>()
            .HasOne(od => od.Product)
            .WithMany(p => p.OrderDetails)
            .HasForeignKey(od => od.ProductId);

            modelBuilder.Entity<OrderDetail>()
           .HasOne(od => od.Order)
           .WithMany(o => o.OrderDetails)
           .HasForeignKey(od => od.OrderId);
            
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Color)
                .WithMany(c => c.OrderDetails)
                .HasForeignKey(od => od.ColorId);
            
            modelBuilder.Entity<OrderDetail>()
                .HasOne(od => od.Size)
                .WithMany(c => c.OrderDetails)
                .HasForeignKey(od => od.SizeId);

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

            // Color vs image
            modelBuilder.Entity<Color>()
                .HasMany(e => e.Images)
                 .WithOne(e => e.Color);

            // Product vs image
            modelBuilder.Entity<Product>()
            .HasMany(p => p.Images)
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
            modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(ul => new { ul.UserId, ul.LoginProvider });
            modelBuilder.Entity<IdentityUserToken<string>>().HasKey(ut => new { ut.UserId, ut.LoginProvider });
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });
        }
        public DbSet<Subcategory> Subcategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
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