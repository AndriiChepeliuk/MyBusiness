using System;
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

        public AllAvailableProductsViewModel()
        {
            AvailableProducts = new ObservableCollection<ProductModel>(ProductModelService.GetAvailableProducts());
            CancelCommand = new ViewModelCommand(ExecuteCancelCommand);
        }

        private void ExecuteCancelCommand(object obj)
        {
            var wind = (Window)obj;
            wind.Close();
        }
    }
}
