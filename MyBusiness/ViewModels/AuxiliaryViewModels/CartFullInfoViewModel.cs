using UmbrellaBiz.Models.Cart;

namespace UmbrellaBiz.ViewModels.AuxiliaryViewModels
{
    public class CartFullInfoViewModel
    {
        public CartModel Cart { get; set; }

        public CartFullInfoViewModel() : this(new CartModel()) { }
        public CartFullInfoViewModel(CartModel cart)
        {
            Cart = cart;
        }
    }
}
