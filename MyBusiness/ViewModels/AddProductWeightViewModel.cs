using UmbrellaBiz.Models.Product;
using UmbrellaBiz.Services;
using System.Windows;
using System.Windows.Input;

namespace UmbrellaBiz.ViewModels
{
    public class AddProductWeightViewModel : ViewModelBase
    {
        private ProductModel _product;
        private float _productWeight;
        public ProductModel Product
        {
            get { return _product; }
            set
            {
                _product = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        public float ProductWeight
        {
            get { return _productWeight; }
            set
            {
                _productWeight = value;
                OnPropertyChanged(nameof(ProductWeight));
            }
        }

        public ICommand AddWeightCommand { get; }
        public ICommand CancelAddWeightCommand { get; }

        public AddProductWeightViewModel() : this(new ProductModel()) { }

        public AddProductWeightViewModel(ProductModel product)
        {
            AddWeightCommand = new ViewModelCommand(ExecuteAddWeightCommand);
            CancelAddWeightCommand = new ViewModelCommand(ExecuteCancelAddWeightCommand);
            Product = product;
        }

        private void ExecuteCancelAddWeightCommand(object obj)
        {
            var wind = (Window)obj;
            wind.Close();
        }

        private void ExecuteAddWeightCommand(object obj)
        {
            ProductModelService.AddProductWeight(Product, ProductWeight);
            var wind = (Window)obj;
            wind.Close();
        }
    }
}
