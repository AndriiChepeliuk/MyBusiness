using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;
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
                
                foreach (var cartItem in cart.CartsItems)
                {
                    context.Products.Attach(cartItem.Product);
                    cartItem.Product.AvailableWeight -= cartItem.ProductWeight;
                }

                cart.DateOfCreation = DateTime.Now;
                cart.IsOpen = true;
                context.Carts.Add(cart);
                context.SaveChanges();
            }
        }

        public static List<CartModel> GetAllCarts()
        {
            using (var context = new ApplicationContext())
            {
                //context.Carts.Load();
                //context.Products.Load();
                //context.CartsItems.Load();
                //context.Customers.Load();
                //var allCarts = context.Carts.OrderByDescending(c => c.DateOfCreation).ToList();
                var allCarts = context.Carts
                                    .Include(c => c.Customer)
                                    .Include(c => c.CartsItems)
                                    .OrderByDescending(c => c.DateOfCreation)
                                    .ToList();

                foreach (var cart in allCarts)
                {
                    MemoryStream memoryStream = new MemoryStream(cart.Customer.AvatarByteCode);
                    cart.Customer.Avatar = new BitmapImage();
                    cart.Customer.Avatar.BeginInit();
                    cart.Customer.Avatar.StreamSource = memoryStream;
                    cart.Customer.Avatar.EndInit();

                    //foreach (var item in cart.CartsItems)
                    //{
                    //    MemoryStream stream = new MemoryStream(item.Product.ProductImage);
                    //    item.Product.Image = new BitmapImage();
                    //    item.Product.Image.BeginInit();
                    //    item.Product.Image.StreamSource = stream;
                    //    item.Product.Image.EndInit();
                    //}
                }

                return allCarts;
            }
        }
    }
}
