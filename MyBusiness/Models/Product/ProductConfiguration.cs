using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MyBusiness.Models.Product
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder
                .HasMany(p => p.CartsItems)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId);
            builder
                .HasMany(p => p.AddingWeightItems)
                .WithOne(a => a.Product)
                .HasForeignKey(a => a.ProductId);
            builder
                .Ignore(p => p.Image);
        }
    }
}
