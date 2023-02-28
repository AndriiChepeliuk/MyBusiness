using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace MyBusiness.Models.Cart
{
    public class CartConfiguration : IEntityTypeConfiguration<CartModel>
    {
        public void Configure(EntityTypeBuilder<CartModel> builder)
        {
            builder
                .HasOne(c => c.Customer)
                .WithMany(c => c.Carts)
                .HasForeignKey(c => c.CustomerId);
        }
    }
}
