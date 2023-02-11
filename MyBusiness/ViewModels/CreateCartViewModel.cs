using MyBusiness.Data;
using MyBusiness.Models.Product;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace MyBusiness.ViewModels
{
    public class CreateCartViewModel : ViewModelBase
    {
        public ProductModel Product { get; set; }
        public BitmapImage BitmapImageImage { get; set; }

        public CreateCartViewModel()
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Product = context.Products.Find(1);

                MemoryStream memoryStream = new MemoryStream(Product.ProductImage);
                var bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.StreamSource = memoryStream;
                bitmap.CacheOption = BitmapCacheOption.OnLoad;
                bitmap.EndInit();
                bitmap.Freeze();
                BitmapImageImage = bitmap;
            }
        }
    }
}
