using UmbrellaBiz.Models.Product;
using UmbrellaBiz.Services;
using UmbrellaBiz.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace UmbrellaBiz.ViewModels
{
    public class AllProductsViewModel : ViewModelBase
    {
        private ProductModel selectedProduct;
        private ObservableCollection<ProductModel> products;

        public ProductModel SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        public ObservableCollection<ProductModel> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }
        public ProductModel Product { get; set; }

        public ICommand EditProductCommand { get; }
        public ICommand DeleteProductCommand { get; }
        public ICommand AddProductWeightCommand { get; }

        public AllProductsViewModel()
        {
            Products = new ObservableCollection<ProductModel>(ProductModelService.GetAllProducts());
            EditProductCommand = new ViewModelCommand(ExecuteEditProductCommand, CanExecuteEditProductCommand);
            DeleteProductCommand = new ViewModelCommand(ExecuteDeleteProductCommand, CanExecuteDeleteProductCommand);
            AddProductWeightCommand = new ViewModelCommand(ExecuteAddProductWeightCommand, CanExecuteAddProductWeightCommand);
        }

        private bool CanExecuteAddProductWeightCommand(object obj)
        {
            return selectedProduct != null;
        }

        private void ExecuteAddProductWeightCommand(object obj)
        {
            AddProductWeightViewModel addProductWeightViewModel = new AddProductWeightViewModel(SelectedProduct);
            var addWeightWindow = new AddProductWeightWindow() { DataContext = addProductWeightViewModel };
            addWeightWindow.ShowDialog();
        }

        private bool CanExecuteDeleteProductCommand(object obj)
        {
            return selectedProduct != null;
        }

        private void ExecuteDeleteProductCommand(object obj)
        {
            ProductModelService.DeleteProduct(selectedProduct.Id);
            Products = new ObservableCollection<ProductModel>(ProductModelService.GetAllProducts());
        }

        private bool CanExecuteEditProductCommand(object obj)
        {
            return selectedProduct != null;
        }

        private void ExecuteEditProductCommand(object obj)
        {
            EditProductViewModel editProductViewModel = new EditProductViewModel(selectedProduct);
            var editWindow = new EditProductViewWindow() { DataContext = editProductViewModel };
            editWindow.ShowDialog();
        }
    }
}
