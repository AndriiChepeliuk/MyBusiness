using MyBusiness.Models.Product;
using System.Collections.Generic;
using System.Linq;

namespace MyBusiness.Data
{
    public class ProductData
    {
        public static void AddProduct(ProductModel product)
        {
            using (var context = new ApplicationContext())
            {
                var productToDB = new ProductModel();
                context.Products.Add(productToDB);
                context.SaveChanges();
            }
        }

        public static List<ProductModel> GetAllProducts()
        {
            using (var context = new ApplicationContext())
            {
                var products = context.Products.OrderBy(p => p.Category).ToList();
                return products;
            }
        }

        public static ProductModel GetProductById(int id)
        {
            using (var context = new ApplicationContext())
            {
                var product = context.Products.FirstOrDefault(x => x.Id == id);
                return product;
            }
        }
    }
}
