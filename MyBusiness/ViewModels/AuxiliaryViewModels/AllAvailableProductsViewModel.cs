using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using UmbrellaBiz.Models.Product;

namespace UmbrellaBiz.ViewModels.AuxiliaryViewModels
{
    public class AllAvailableProductsViewModel : ViewModelBase
    {
        private ProductModel _selectedProduct;
        private ObservableCollection<ProductModel> _availableProducts;

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        public ObservableCollection<ProductModel> AvailableProducts
        {
            get { return _availableProducts; }
            set
            {
                _availableProducts = value;
                OnPropertyChanged(nameof(AvailableProducts));
            }
        }

        public ICommand CancelCommand { get; }
        public ICommand AddProductCommand { get; }

        public AllAvailableProductsViewModel() : this(new ObservableCollection<ProductModel>()) { }
        public AllAvailableProductsViewModel(ObservableCollection<ProductModel> availableProducts)
        {
            AvailableProducts = availableProducts;
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
            AddProductCommand = new ViewModelCommand(ExecuteAddProductCommand, CanExecuteAddProductCommand);
        }

        private bool CanExecuteAddProductCommand(object obj)
        {
            return SelectedProduct != null;
        }

        private void ExecuteAddProductCommand(object obj)
        {
            var wind = (Window)obj;
            wind.Close();
        }

        private void ExecuteCancelCommand(object obj)
        {
            SelectedProduct = null;
            var wind = (Window)obj;
            wind.Close();
        }
    }
}
