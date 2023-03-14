using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UmbrellaBiz.Models.CartsItem
{
    public class CartsItemConfiguration : IEntityTypeConfiguration<CartsItemModel>
    {
        public void Configure(EntityTypeBuilder<CartsItemModel> builder)
        {
            builder
                .HasOne(c => c.Cart)
                .WithMany(c => c.CartsItems)
                .HasForeignKey(c => c.CartId);
            builder
                .HasOne(c => c.Product)
                .WithMany(c => c.CartsItems)
                .HasForeignKey(c => c.ProductId);
        }
    }
}
