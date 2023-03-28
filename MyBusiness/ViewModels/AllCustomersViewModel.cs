using System.Collections.ObjectModel;
using System.Windows.Input;
using UmbrellaBiz.Models.Customer;
using UmbrellaBiz.Services;
using UmbrellaBiz.Views;

namespace UmbrellaBiz.ViewModels
{
    public class AllCustomersViewModel : ViewModelBase
    {
        private CustomerModel _selectedCustomer;
        private ObservableCollection<CustomerModel> _customers;

        public CustomerModel SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }
        public ObservableCollection<CustomerModel> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
                OnPropertyChanged(nameof(Customers));
            }
        }

        public ICommand AddNewCartForSelectedCustomerCommand { get; }

        public AllCustomersViewModel()
        {
            Customers = new ObservableCollection<CustomerModel>(CustomerModelService.GetAllCustomers());
            AddNewCartForSelectedCustomerCommand = new ViewModelCommand(ExecuteAddNewCartCommand, CanExecuteAddNewCartCommand);
        }

        private bool CanExecuteAddNewCartCommand(object obj)
        {
            return SelectedCustomer != null;
        }

        private void ExecuteAddNewCartCommand(object obj)
        {
            var addNewCartViewModel = new AddNewCartViewModel(_selectedCustomer);
            var addNewCartWindow = new AddNewCartViewWindow() { DataContext = addNewCartViewModel };
            addNewCartWindow.ShowDialog();
        }
    }
}
