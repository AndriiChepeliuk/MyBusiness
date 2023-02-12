using MyBusiness.Data;
using MyBusiness.Models.Product;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MyBusiness.ViewModels
{
    public class AllProductsViewModel : ViewModelBase
    {
        private ObservableCollection<ProductModel> products;
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

        public AllProductsViewModel()
        {
            Products = new ObservableCollection<ProductModel>(ProductData.GetAllProducts());
            EditProductCommand = new ViewModelCommand(ExecuteEditProductCommand);
        }

        private void ExecuteEditProductCommand(object obj)
        {
            Product = (ProductModel)obj;
        }
    }
}
