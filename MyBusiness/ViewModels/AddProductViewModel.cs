using Microsoft.Win32;
using MyBusiness.Data;
using MyBusiness.Helpers;
using MyBusiness.Models.Product;
using System.Windows.Input;

namespace MyBusiness.ViewModels
{
    public class AddProductViewModel : ViewModelBase
    {
        private string? imageSource;

        public ICommand ChoosePictureCommand { get; }
        public ICommand AddProductCommand { get; }

        public ProductModel Product { get; set; }
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
            ImageSource = "../../../Images/DefaultImage.jpg";
            ChoosePictureCommand = new ViewModelCommand(ExecuteChoosePictureCommand);
            AddProductCommand = new ViewModelCommand(ExecuteAddProductCommand);
        }

        private void ExecuteAddProductCommand(object obj)
        {
            using (ApplicationContext context = new ApplicationContext())
            {
                Product = (ProductModel)obj;
                Product.Id = 0;
                if (!string.IsNullOrEmpty(ImageSource))
                {
                    Product.ProductImage = ImageHelper.ConvertImageToByteArray(ImageSource);
                }
                context.Products.Add(Product);
                context.SaveChanges();
            }
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
