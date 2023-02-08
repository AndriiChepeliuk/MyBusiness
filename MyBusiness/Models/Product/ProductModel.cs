using MyBusiness.Models.ProdImage;
using System.Collections.Generic;
using System.Drawing;

namespace MyBusiness.Models.Product
{
    public class ProductModel : ModelBase
    {
        private string? name;
        private string? category;
        private float weight;
        private double price;
        private Image image;

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
        public Image Image
        {
            get { return image; }
            set
            {
                image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public ICollection<ProdImageModel> ProdImages { get; set; } = new List<ProdImageModel>();
    }
}
