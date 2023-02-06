using MyBusiness.Models.Product;

namespace MyBusiness.Models.ProdImage
{
    public class ProdImageModel : ModelBase
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public byte[]? ProductImage { get; set; }
    }
}
