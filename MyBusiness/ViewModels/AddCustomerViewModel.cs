using Microsoft.Win32;
using UmbrellaBiz.Helpers;
using UmbrellaBiz.Models.Customer;
using UmbrellaBiz.Services;
using System.Windows.Input;

namespace UmbrellaBiz.ViewModels
{
    public class AddCustomerViewModel : ViewModelBase
    {
        private CustomerModel _customer;
        private string? _imageSource;

        public ICommand ChoosePictureCommand { get; }
        public ICommand AddCustomerCommand { get; }

        public CustomerModel Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }
        public string ImageSource
        {
            get { return _imageSource; }
            set
            {
                _imageSource = value;
                OnPropertyChanged(nameof(ImageSource));
            }
        }

        public AddCustomerViewModel()
        {
            Customer = new CustomerModel();
            ImageSource = "../../../Images/DefaultImage.jpg";
            ChoosePictureCommand = new ViewModelCommand(ExecuteChoosePictureCommand);
            AddCustomerCommand = new ViewModelCommand(ExecuteAddCustomerCommand);
        }

        private void ExecuteAddCustomerCommand(object obj)
        {
            Customer.AvatarByteCode = ImageHelper.ConvertImageToByteArray(ImageSource);
            CustomerModelService.AddCustomer(Customer);
            Customer = new CustomerModel();
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
                try
                {
                    ImageHelper.ConvertImageToByteArray(op.FileName);
                    ImageSource = op.FileName;
                }
                catch { }
            }
        }
    }
}
