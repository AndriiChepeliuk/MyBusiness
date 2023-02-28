using MyBusiness.Models.AddingWeightItem;
using MyBusiness.Models.CartsItem;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace MyBusiness.Models.Product
{
    public class ProductModel : ModelBase
    {
        private string? name;
        private string? category;
        private float availableWeight;
        private float reservedWeight;
        private float price;
        private BitmapImage image;
        private ObservableCollection<CartsItemModel> cartsItems;
        private ObservableCollection<AddingWeightItemModel> addingWeightItems;

        public int Id { get; private set; }
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
        public float AvailableWeight
        {
            get { return availableWeight; }
            set
            {
                availableWeight = value;
                OnPropertyChanged(nameof(AvailableWeight));
            }
        }
        public float ReservedWeight
        {
            get { return reservedWeight; }
            set
            {
                reservedWeight = value;
                OnPropertyChanged(nameof(ReservedWeight));
            }
        }
        public float Price
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
        public ObservableCollection<CartsItemModel> CartsItems
        {
            get { return cartsItems; }
            set
            {
                cartsItems = value;
                OnPropertyChanged(nameof(CartsItems));
            }
        }
        public ObservableCollection<AddingWeightItemModel> AddingWeightItems
        {
            get { return addingWeightItems; }
            set
            {
                addingWeightItems = value;
                OnPropertyChanged(nameof(AddingWeightItems));
            }
        }
    }
}
