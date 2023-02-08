using Microsoft.Win32;
using MyBusiness.Models.Product;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Input;

namespace MyBusiness.ViewModels
{
    public class AddProductViewModel : ViewModelBase
    {
        private Image? productImage;
        private string? imageSource;

        public ICommand ChoosePictureCommand { get; }
        public ICommand AddProductCommand { get; }

        public ProductModel Product { get; set; } = new ProductModel();
        public Image ProductImage
        {
            get { return productImage; }
            set
            {
                productImage = value;
                OnPropertyChanged(nameof(ProductImage));
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
            ImageSource = "../../../Images/DefaultImage.jpg";
            ProductImage = Image.FromFile(ImageSource);
            ChoosePictureCommand = new ViewModelCommand(ExecuteChoosePictureCommand);
            AddProductCommand = new ViewModelCommand(ExecuteAddProductCommand);
        }

        private void ExecuteAddProductCommand(object obj)
        {
            var values = (object[])obj;
            Product.Name = (string)values[0];
            Product.Category = (string)values[1];
            var productPrice = double.Parse((string)values[2]);
            Product.Price = productPrice;
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
                ProductImage = Image.FromFile(ImageSource);
            }
        }

        public byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }
    }
}
