using System.Windows;
using System.Windows.Input;
using UmbrellaBiz.Models.Cart;
using UmbrellaBiz.Models.Customer;

namespace UmbrellaBiz.ViewModels
{
    class AddNewCartViewModel : ViewModelBase
    {
        private CartModel _cart;
        private CustomerModel _customer;

        public CartModel Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                OnPropertyChanged(nameof(Cart));
            }
        }
        public CustomerModel Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }

        public ICommand CancelAddNewCartCommand { get; }

        public AddNewCartViewModel() : this(new CustomerModel()) { }
        public AddNewCartViewModel(CustomerModel selectedCustomer)
        {
            _customer = selectedCustomer;
            _cart = new CartModel();
            CancelAddNewCartCommand = new ViewModelCommand(ExecuteCancelAddNewCartCommand);
        }

        private void ExecuteCancelAddNewCartCommand(object obj)
        {
            var wind = (Window)obj;
            wind.Close();
        }
    }
}
