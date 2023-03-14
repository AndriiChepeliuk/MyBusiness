using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UmbrellaBiz.Models.AddingWeightItem
{
    public class AddingWeightItemConfiguration : IEntityTypeConfiguration<AddingWeightItemModel>
    {
        public void Configure(EntityTypeBuilder<AddingWeightItemModel> builder)
        {
            builder
                .HasOne(a => a.Product)
                .WithMany(p => p.AddingWeightItems)
                .HasForeignKey(a => a.ProductId);
        }
    }
}
