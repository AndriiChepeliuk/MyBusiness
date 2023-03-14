using System.Collections.ObjectModel;
using UmbrellaBiz.Models.Customer;
using UmbrellaBiz.Services;

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

        public AllCustomersViewModel()
        {
            Customers = new ObservableCollection<CustomerModel>(CustomerModelService.GetAllCustomers());
        }


    }
}
