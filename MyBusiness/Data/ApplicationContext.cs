using Microsoft.EntityFrameworkCore;
using MyBusiness.Models.ProdImage;
using MyBusiness.Models.Product;

namespace MyBusiness.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<ProdImageModel> ProdImages { get; set; }

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
        }
    }
}
