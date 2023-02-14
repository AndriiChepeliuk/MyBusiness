using Microsoft.Win32;
using MyBusiness.Helpers;
using MyBusiness.Models.Product;
using System.IO;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MyBusiness.ViewModels
{
    public class EditProductViewModel : ViewModelBase
    {
        private ProductModel productToEdit;
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

        public EditProductViewModel()
        {
            ChoosePictureCommand = new ViewModelCommand(ExecuteChoosePictureCommand);
        }
        //public EditProductViewModel(ProductModel productModel)
        //{
        //    ProductToEdit = productModel;
        //}

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
