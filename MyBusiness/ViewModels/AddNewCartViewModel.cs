using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using UmbrellaBiz.Models.Cart;
using UmbrellaBiz.Models.CartsItem;
using UmbrellaBiz.Models.Customer;
using UmbrellaBiz.Models.Product;
using UmbrellaBiz.Services;
using UmbrellaBiz.ViewModels.AuxiliaryViewModels;
using UmbrellaBiz.Views.AuxiliaryWindows;

namespace UmbrellaBiz.ViewModels
{
    public class AddNewCartViewModel : ViewModelBase
    {
        private CartModel _cart;
        private CartsItemModel _selectedCartItem;
        private CustomerModel _customer;
        private ObservableCollection<ProductModel> availableProducts;

        public CartModel Cart
        {
            get { return _cart; }
            set
            {
                _cart = value;
                OnPropertyChanged(nameof(Cart));
            }
        }
        public CartsItemModel SelectedCartItem
        {
            get { return _selectedCartItem; }
            set
            {
                _selectedCartItem = value;
                OnPropertyChanged(nameof(SelectedCartItem));
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
        public ObservableCollection<ProductModel> AvailableProducts
        {
            get { return availableProducts; }
            set
            {
                availableProducts = value;
                OnPropertyChanged(nameof(AvailableProducts));
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
            AvailableProducts = new ObservableCollection<ProductModel>(ProductModelService.GetAvailableProducts());
        }

        private void ExecuteAddProductToCartCommand(object obj)
        {
            var allAvailableProductsViewModel = new AllAvailableProductsViewModel(AvailableProducts);
            var allAvailableProductsWindow = new AllAvailableProductsWindow() { DataContext = allAvailableProductsViewModel };
            allAvailableProductsWindow.ShowDialog();

            if (allAvailableProductsViewModel.SelectedProduct != null)
            {
                var cartItem = new CartsItemModel();
                cartItem.Product = allAvailableProductsViewModel.SelectedProduct;
                Cart.CartsItems.Add(cartItem);
                AvailableProducts.Remove(allAvailableProductsViewModel.SelectedProduct);
            }
        }

        private void ExecuteCancelAddNewCartCommand(object obj)
        {
            var wind = (Window)obj;
            wind.Close();
        }
    }
}
