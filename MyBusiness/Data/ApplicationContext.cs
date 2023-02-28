using Microsoft.EntityFrameworkCore;
using MyBusiness.Models.AddingWeightItem;
using MyBusiness.Models.Cart;
using MyBusiness.Models.CartsItem;
using MyBusiness.Models.Customer;
using MyBusiness.Models.Product;

namespace MyBusiness.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<CartModel> Carts { get; set; }
        public DbSet<CartsItemModel> CartsItems { get; set; }
        public DbSet<AddingWeightItemModel> AddingWeightItems { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=../../../Data/DB/UmbrellaDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CartConfiguration());
            modelBuilder.ApplyConfiguration(new CartsItemConfiguration());
            modelBuilder.ApplyConfiguration(new AddingWeightItemConfiguration());
        }
    }
}
