using UmbrellaBiz.Data;
using UmbrellaBiz.Models.Cart;

namespace UmbrellaBiz.Services
{
    public class CartModelService
    {
        public static void AddCart(CartModel cart)
        {
            using (var context = new ApplicationContext())
            {
                context.Customers.Attach(cart.Customer);
                foreach(var cartItem in cart.CartsItems)
                {
                    context.Products.Attach(cartItem.Product);
                    cartItem.Product.AvailableWeight -= cartItem.ProductWeight;
                }
                context.Carts.Add(cart);
                context.SaveChanges();
            }
        }
    }
}
