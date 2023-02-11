using MyBusiness.Data;
using MyBusiness.Models.Product;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;

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

        public AllProductsViewModel()
        {

            Products = new ObservableCollection<ProductModel>(ProductData.GetAllProducts());

            

        }


    }
}
