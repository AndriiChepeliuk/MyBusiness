using Microsoft.Win32;
using UmbrellaBiz.Helpers;
using UmbrellaBiz.Models.Product;
using UmbrellaBiz.Services;
using System.Windows.Input;

namespace UmbrellaBiz.ViewModels
{
    public class AddProductViewModel : ViewModelBase
    {
        private ProductModel product;
        private string? imageSource;

        public ICommand ChoosePictureCommand { get; }
        public ICommand AddProductCommand { get; }

        public ProductModel Product
        {
            get { return product; }
            set
            {
                product = value;
                OnPropertyChanged(nameof(Product));
            }
        }
        public string ImageSource
        {
            get { return imageSource; }
            set
            {
                imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        public AddProductViewModel()
        {
            Product = new ProductModel();
            ImageSource = "../../../Images/DefaultImage.jpg";
            ChoosePictureCommand = new ViewModelCommand(ExecuteChoosePictureCommand);
            AddProductCommand = new ViewModelCommand(ExecuteAddProductCommand);
        }

        private void ExecuteAddProductCommand(object obj)
        {
            if (!string.IsNullOrEmpty(ImageSource))
            {
                Product.ProductImage = ImageHelper.ConvertImageToByteArray(ImageSource);
            }
            ProductModelService.AddProduct(Product);
            Product = new ProductModel();
            ImageSource = "../../../Images/DefaultImage.jpg";
        }

        private void ExecuteChoosePictureCommand(object obj)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                ImageSource = op.FileName;
            }
        }
    }
}
