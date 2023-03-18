using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using UmbrellaBiz.Models.Product;
using UmbrellaBiz.Services;

namespace UmbrellaBiz.ViewModels.AuxiliaryViewModels
{
    public class AllAvailableProductsViewModel : ViewModelBase
    {
        private ProductModel selectedProduct;
        private string _errorMessage;
        private string _productWeight = "0";
        private ObservableCollection<ProductModel> availableProducts;


        public ProductModel SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
            }
        }
        public string ProductWeight
        {
            get
            {
                return _productWeight;
            }
            set
            {
                _productWeight = value;
                OnPropertyChanged(nameof(ProductWeight));
            }
        }

        public ObservableCollection<ProductModel> AvailableProducts
        {
            get { return availableProducts; }
            set
            {
                availableProducts = value;
                OnPropertyChanged(nameof(AvailableProducts));
            }
        }

        public ICommand CancelCommand { get; }
        public ICommand AddProductCommand { get; }

        public AllAvailableProductsViewModel()
        {
            AvailableProducts = new ObservableCollection<ProductModel>(ProductModelService.GetAvailableProducts());
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
            AddProductCommand = new ViewModelCommand(ExecuteAddProductCommand);
        }

        //private bool CanExecuteAddProductCommand(object obj)
        //{
        //    bool validData;
        //    float weight, availableWeight;
        //    availableWeight = SelectedProduct.AvailableWeight;
        //    float.TryParse(ProductWeight, out weight);

        //    if (!string.IsNullOrEmpty(ProductWeight) && weight > 0 && weight <= availableWeight)
        //    {
        //        validData = true;
        //    }
        //    else
        //    {
        //        ErrorMessage = "*";
        //        validData = false;
        //    }
        //    return validData;
        //}

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
