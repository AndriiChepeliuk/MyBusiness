using MyBusiness.Models.Product;
using MyBusiness.Services;
using System;
using System.Windows;
using System.Windows.Input;

namespace MyBusiness.ViewModels
{
    public class AddProductWeightViewModel : ViewModelBase
    {
        private ProductModel product;
        private ProductModel productData;
        private float productWeight;
        public ProductModel Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        public float ProductWeight
        {
            get { return productWeight; }
            set
            {
                productWeight = value;
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
            productData = (ProductModel)product.Clone();
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
