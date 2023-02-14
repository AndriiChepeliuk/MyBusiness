using Microsoft.Win32;
using MyBusiness.Helpers;
using MyBusiness.Models.Product;
using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MyBusiness.ViewModels
{
    public class EditProductViewModel : ViewModelBase
    {
        private ProductModel productToEdit;
        private ProductModel productData;
        public ProductModel ProductToEdit
        {
            get { return productToEdit; }
            set
            {
                productToEdit = value;
                OnPropertyChanged(nameof(ProductToEdit));
            }
        }

        public ICommand ChoosePictureCommand { get; }
        public ICommand SaveChangesCommand { get; }
        public ICommand CancelChangesCommand { get; }

        public EditProductViewModel() : this(new ProductModel()) { }

        public EditProductViewModel(ProductModel product)
        {
            ChoosePictureCommand = new ViewModelCommand(ExecuteChoosePictureCommand);
            SaveChangesCommand = new ViewModelCommand(ExecuteSaveChangesCommand);
            CancelChangesCommand = new ViewModelCommand(ExecuteCancelChangesCommand);
            ProductToEdit = product;
            productData = (ProductModel)product.Clone();
        }

        private void ExecuteCancelChangesCommand(object obj)
        {
            ProductToEdit.ProductImage = productData.ProductImage;
            ProductToEdit.Image = productData.Image;

            var wind = (Window)obj;
            wind.Close();
        }

        private void ExecuteSaveChangesCommand(object obj)
        {
            throw new NotImplementedException();
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
                ProductToEdit.ProductImage = ImageHelper.ConvertImageToByteArray(op.FileName);
                MemoryStream memoryStream = new MemoryStream(ProductToEdit.ProductImage);
                var newImage = new BitmapImage();
                newImage.BeginInit();
                newImage.StreamSource = memoryStream;
                newImage.EndInit();
                ProductToEdit.Image = newImage;
            }
        }
    }
}
