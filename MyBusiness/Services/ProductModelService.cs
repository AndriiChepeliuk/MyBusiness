using Microsoft.EntityFrameworkCore;
using UmbrellaBiz.Data;
using UmbrellaBiz.Models.AddingWeightItem;
using UmbrellaBiz.Models.Product;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Media.Imaging;

namespace UmbrellaBiz.Services
{
    public class ProductModelService
    {
        public static void AddProduct(ProductModel product)
        {
            using (var context = new ApplicationContext())
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public static List<ProductModel> GetAllProducts()
        {
            using (var context = new ApplicationContext())
            {
                var products = context.Products.OrderBy(p => p.Category).AsNoTracking().ToList();

                foreach (var product in products)
                {
                    MemoryStream memoryStream = new MemoryStream(product.ProductImage);
                    product.Image = new BitmapImage();
                    product.Image.BeginInit();
                    product.Image.StreamSource = memoryStream;
                    product.Image.EndInit();
                }

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

        public static void EditProduct(ProductModel editedProduct)
        {
            using (var context = new ApplicationContext())
            {
                var currentProduct = GetProductById(editedProduct.Id);
                if (currentProduct != null)
                {
                    currentProduct.Name = editedProduct.Name;
                    currentProduct.Category = editedProduct.Category;
                    currentProduct.ProductImage = editedProduct.ProductImage;
                    currentProduct.Price = editedProduct.Price;
                    //context.Entry(currentProduct);
                    context.Update(currentProduct);
                    context.SaveChanges();
                }
            }
        }

        public static void AddProductWeight(ProductModel product, float productWeight)
        {
            using (var context = new ApplicationContext())
            {
                var currentProduct = GetProductById(product.Id);
                if (currentProduct != null)
                {
                    currentProduct.AvailableWeight = product.AvailableWeight += productWeight;

                    var AddingWeightItem = new AddingWeightItemModel();
                    AddingWeightItem.Weight = productWeight;
                    AddingWeightItem.Product = currentProduct;
                    AddingWeightItem.Date = DateTime.Now;
                    context.AddingWeightItems.Add(AddingWeightItem);

                    context.Update(currentProduct);
                    context.SaveChanges();
                }
            }
        }

        public static void DeleteProduct(int productId)
        {
            using (var context = new ApplicationContext())
            {
                var productToDelete = GetProductById(productId);
                if (productToDelete != null)
                {
                    context.Products.Remove(productToDelete);
                    context.SaveChanges();
                }
            }
        }
    }
}
