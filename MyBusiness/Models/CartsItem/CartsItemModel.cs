using UmbrellaBiz.Models.Cart;
using UmbrellaBiz.Models.Product;

namespace UmbrellaBiz.Models.CartsItem
{
    public class CartsItemModel : ModelBase
    {
        private int cartId;
        private CartModel? cart;
        private int productId;
        private ProductModel? product;
        private float price;
        private float productWeight;

        public int Id { get; private set; }
        public int CartId
        {
            get { return cartId; }
            set
            {
                cartId = value;
                OnPropertyChanged(nameof(CartId));
            }
        }
        public CartModel? Cart
        {
            get { return cart; }
            set
            {
                cart = value;
                OnPropertyChanged(nameof(Cart));
            }
        }
        public int ProductId
        {
            get { return productId; }
            set
            {
                productId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }
        public ProductModel? Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        public float Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public float ProductWeight
        {
            get { return productWeight; }
            set
            {
                productWeight = value;
                OnPropertyChanged(nameof(ProductWeight));
            }
        }
    }
}
