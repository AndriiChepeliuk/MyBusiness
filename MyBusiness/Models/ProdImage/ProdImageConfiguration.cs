using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using MyBusiness.Models.Product;

namespace MyBusiness.Models.ProdImage
{
    public class ProdImageConfiguration : IEntityTypeConfiguration<ProdImageModel>
    {
        public void Configure(EntityTypeBuilder<ProdImageModel> builder)
        {
            builder
                .HasOne(p => p.Product)
                .WithMany(p => p.ProdImages)
                .HasForeignKey(p => p.ProductId);
        }
    }
}
