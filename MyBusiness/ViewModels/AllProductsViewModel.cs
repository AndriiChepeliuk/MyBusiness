using MyBusiness.Data;
using MyBusiness.Models.Product;
using MyBusiness.Views;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyBusiness.ViewModels
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

        public AllProductsViewModel()
        {
            Products = new ObservableCollection<ProductModel>(ProductData.GetAllProducts());
            EditProductCommand = new ViewModelCommand(ExecuteEditProductCommand, CanExecuteEditProductCommand);
            DeleteProductCommand = new ViewModelCommand(ExecuteDeleteProductCommand, CanExecuteDeleteProductCommand);
        }

        private bool CanExecuteDeleteProductCommand(object obj)
        {
            return selectedProduct != null;
        }

        private void ExecuteDeleteProductCommand(object obj)
        {
            ProductData.DeleteProduct(selectedProduct.Id);
            Products = new ObservableCollection<ProductModel>(ProductData.GetAllProducts());
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
