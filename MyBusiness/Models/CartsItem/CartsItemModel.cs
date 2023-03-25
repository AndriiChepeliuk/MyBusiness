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
        private float totalItemCost;
        private float productWeight;
        private bool readyToAdd;
        private string errorMessage = "*check weight";

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
        public float TotalItemCost
        {
            get { return totalItemCost; }
            set
            {
                totalItemCost = value;
                OnPropertyChanged(nameof(TotalItemCost));
            }
        }
        public float ProductWeight
        {
            get { return productWeight; }
            set
            {
                productWeight = value;
                OnPropertyChanged(nameof(ProductWeight));
                if (productWeight > 0 && productWeight <= Product?.AvailableWeight)
                {
                    ReadyToAdd = true;
                    ErrorMessage = "";
                }
                else
                {
                    ReadyToAdd = false;
                    ErrorMessage = "*check weight";
                }
                TotalItemCost = productWeight * Product.Price;
            }
        }
        public bool ReadyToAdd
        {
            get { return readyToAdd; }
            set
            {
                readyToAdd = value;
                OnPropertyChanged(nameof(ReadyToAdd));
            }
        }
        public string ErrorMessage
        {
            get { return errorMessage; }
            set
            {
                errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
    }
}
