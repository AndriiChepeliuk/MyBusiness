using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UmbrellaBiz.Models.Customer;
using UmbrellaBiz.Services;
using UmbrellaBiz.Views;

namespace UmbrellaBiz.ViewModels
{
    public class AllCustomersViewModel : ViewModelBase
    {
        private CustomerModel selectedCustomer;
        private ObservableCollection<CustomerModel> customers;

        public CustomerModel SelectedCustomer
        {
            get { return selectedCustomer; }
            set
            {
                selectedCustomer = value;
                OnPropertyChanged(nameof(SelectedCustomer));
            }
        }
        public ObservableCollection<CustomerModel> Customers
        {
            get { return customers; }
            set
            {
                customers = value;
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
            var addNewCartViewModel = new AddNewCartViewModel(selectedCustomer);
            var addNewCartWindow = new AddNewCartViewWindow() { DataContext = addNewCartViewModel };
            addNewCartWindow.Show();
        }
    }
}
