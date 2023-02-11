using System.Drawing;
using System.Windows.Media.Imaging;

namespace MyBusiness.Models.Product
{
    public class ProductModel : ModelBase
    {
        private string? name;
        private string? category;
        private float weight;
        private double price;
        private BitmapImage image;

        public int Id { get; set; }
        public string Name 
        { 
            get { return name; } 
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Category
        {
            get { return category; }
            set
            {
                category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        public float Weight
        {
            get { return weight; }
            set
            {
                weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }
        public double Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public byte[]? ProductImage { get; set; }
        public BitmapImage Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
    }
}
