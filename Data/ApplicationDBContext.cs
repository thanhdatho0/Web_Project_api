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
        }

        public DbSet<Category> Categories {get; set;}
        public DbSet<Color> Colors {get; set;}
        public DbSet<Company> Companies {get; set;}
        public DbSet<Customer> Customers {get; set;}
        public DbSet<Department> Departments {get; set;}
        public DbSet<Employee> Employees {get; set;}
        public DbSet<Image> Images {get; set;}
        public DbSet<Material> Materials {get; set;}
        public DbSet<OrderDetail> OrderDetails {get; set;}
        public DbSet<Order> Orders {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<ProductMaterial> ProductMaterials {get; set;}
        public DbSet<ProductSize> ProductSizes {get; set;}
        public DbSet<ProductColor> ProductColors {get; set;}

    }
}