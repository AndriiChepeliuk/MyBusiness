using Microsoft.EntityFrameworkCore;
using UmbrellaBiz.Models.AddingWeightItem;
using UmbrellaBiz.Models.Cart;
using UmbrellaBiz.Models.CartsItem;
using UmbrellaBiz.Models.Customer;
using UmbrellaBiz.Models.Product;

namespace UmbrellaBiz.Data
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
            optionsBuilder.UseSqlite("Data Source=../../../Data/UmbrellaDB.db");
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
