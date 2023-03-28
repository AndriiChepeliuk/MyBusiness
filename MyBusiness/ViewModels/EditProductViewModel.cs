using Microsoft.Win32;
using UmbrellaBiz.Helpers;
using UmbrellaBiz.Models.Product;
using UmbrellaBiz.Services;
using System.IO;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace UmbrellaBiz.ViewModels
{
    public class EditProductViewModel : ViewModelBase
    {
        private ProductModel _productToEdit;
        private ProductModel _productData;
        public ProductModel ProductToEdit
        {
            get { return _productToEdit; }
            set
            {
                _productToEdit = value;
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
            _productData = (ProductModel)product.Clone();
        }

        private void ExecuteCancelChangesCommand(object obj)
        {
            ProductToEdit.ProductImage = _productData.ProductImage;
            ProductToEdit.Image = _productData.Image;
            ProductToEdit.Name = _productData.Name;
            ProductToEdit.Category = _productData.Category;
            ProductToEdit.Price = _productData.Price;

            var wind = (Window)obj;
            wind.Close();
        }

        private void ExecuteSaveChangesCommand(object obj)
        {
            ProductModelService.EditProduct(ProductToEdit);

            var wind = (Window)obj;
            wind.Close();
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
