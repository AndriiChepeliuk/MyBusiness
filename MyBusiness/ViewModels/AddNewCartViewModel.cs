using System;
using System.Windows;
using System.Windows.Input;
using UmbrellaBiz.Models.Cart;
using UmbrellaBiz.Models.CartsItem;
using UmbrellaBiz.Models.Customer;
using UmbrellaBiz.ViewModels.AuxiliaryViewModels;
using UmbrellaBiz.Views.AuxiliaryWindows;

namespace UmbrellaBiz.ViewModels
{
    public class AddNewCartViewModel : ViewModelBase
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
        public ICommand AddProductToCartCommand { get; }

        public AddNewCartViewModel() : this(new CustomerModel()) { }
        public AddNewCartViewModel(CustomerModel selectedCustomer)
        {
            _customer = selectedCustomer;
            _cart = new CartModel();
            CancelAddNewCartCommand = new ViewModelCommand(ExecuteCancelAddNewCartCommand);
            AddProductToCartCommand = new ViewModelCommand(ExecuteAddProductToCartCommand);
        }

        private void ExecuteAddProductToCartCommand(object obj)
        {
            Cart.CartsItems.Add(AddCartItem());
        }

        private void ExecuteCancelAddNewCartCommand(object obj)
        {
            var wind = (Window)obj;
            wind.Close();
        }

        private CartsItemModel AddCartItem()
        {
            var allAvailableProductsViewModel = new AllAvailableProductsViewModel();
            var allAvailableProductsWindow = new AllAvailableProductsWindow() { DataContext = allAvailableProductsViewModel };
            allAvailableProductsWindow.ShowDialog();
            return new CartsItemModel();
        }
    }
}
