using UmbrellaBiz.Models.AddingWeightItem;
using UmbrellaBiz.Models.CartsItem;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace UmbrellaBiz.Models.Product
{
    public class ProductModel : ModelBase
    {
        private string? _name;
        private string? _category;
        private float _availableWeight;
        private float _reservedWeight;
        private float _price;
        private float _cost;
        private BitmapImage _image;
        private ObservableCollection<CartsItemModel> _cartsItems;
        private ObservableCollection<AddingWeightItemModel> _addingWeightItems;

        public int Id { get; private set; }
        public string Name 
        { 
            get { return _name; } 
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Category
        {
            get { return _category; }
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        public float AvailableWeight
        {
            get { return _availableWeight; }
            set
            {
                _availableWeight = value;
                OnPropertyChanged(nameof(AvailableWeight));
            }
        }
        public float ReservedWeight
        {
            get { return _reservedWeight; }
            set
            {
                _reservedWeight = value;
                OnPropertyChanged(nameof(ReservedWeight));
            }
        }
        public float Price
        {
            get { return _price; }
            set
            {
                _price = value;
                OnPropertyChanged(nameof(Price));
            }
        }
        public float Cost
        {
            get { return _cost; }
            set
            {
                _cost = value;
                OnPropertyChanged(nameof(Cost));
            }
        }
        public byte[]? ProductImage { get; set; }
        public BitmapImage Image
        {
            get { return _image; }
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public ObservableCollection<CartsItemModel> CartsItems
        {
            get { return _cartsItems; }
            set
            {
                _cartsItems = value;
                OnPropertyChanged(nameof(CartsItems));
            }
        }
        public ObservableCollection<AddingWeightItemModel> AddingWeightItems
        {
            get { return _addingWeightItems; }
            set
            {
                _addingWeightItems = value;
                OnPropertyChanged(nameof(AddingWeightItems));
            }
        }
    }
}
