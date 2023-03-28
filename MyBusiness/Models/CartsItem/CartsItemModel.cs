using UmbrellaBiz.Models.Cart;
using UmbrellaBiz.Models.Product;

namespace UmbrellaBiz.Models.CartsItem
{
    public class CartsItemModel : ModelBase
    {
        private int _cartId;
        private CartModel? _cart;
        private int _productId;
        private ProductModel? _product;
        private float _totalItemPrice;
        private float _totalItemCost;
        private float _productWeight;
        private bool _readyToAdd;
        private string _errorMessage = "*check weight";

        public int Id { get; private set; }
        public int CartId
        {
            get { return _cartId; }
            set
            {
                _cartId = value;
                OnPropertyChanged(nameof(CartId));
            }
        }
        public CartModel? Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                OnPropertyChanged(nameof(Cart));
            }
        }
        public int ProductId
        {
            get { return _productId; }
            set
            {
                _productId = value;
                OnPropertyChanged(nameof(ProductId));
            }
        }
        public ProductModel? Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        public float TotalItemPrice
        {
            get { return _totalItemPrice; }
            set
            {
                _totalItemPrice = value;
                OnPropertyChanged(nameof(TotalItemPrice));
            }
        }
        public float TotalItemCost
        {
            get { return _totalItemCost; }
            set
            {
                _totalItemCost = value;
                OnPropertyChanged(nameof(TotalItemCost));
            }
        }
        public float ProductWeight
        {
            get { return _productWeight; }
            set
            {
                _productWeight = value;
                OnPropertyChanged(nameof(ProductWeight));
                if (_productWeight > 0 && _productWeight <= Product?.AvailableWeight)
                {
                    ReadyToAdd = true;
                    ErrorMessage = "";
                }
                else
                {
                    ReadyToAdd = false;
                    ErrorMessage = "*check weight";
                }
                TotalItemPrice = _productWeight * Product.Price;
            }
        }
        public bool ReadyToAdd
        {
            get { return _readyToAdd; }
            set
            {
                _readyToAdd = value;
                OnPropertyChanged(nameof(ReadyToAdd));
            }
        }
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
    }
}
