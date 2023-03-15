using System.Windows;
using System.Windows.Input;
using UmbrellaBiz.Models.Customer;

namespace UmbrellaBiz.ViewModels
{
    class AddNewCartViewModel : ViewModelBase
    {
        private CustomerModel _customer;

        public ICommand CancelAddNewCartCommand { get; }

        public AddNewCartViewModel() : this(new CustomerModel()) { }
        public AddNewCartViewModel(CustomerModel selectedCustomer)
        {
            _customer = selectedCustomer;
            CancelAddNewCartCommand = new ViewModelCommand(ExecuteCancelAddNewCartCommand);
        }

        private void ExecuteCancelAddNewCartCommand(object obj)
        {
            var wind = (Window)obj;
            wind.Close();
        }
    }
}
