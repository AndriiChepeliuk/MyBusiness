using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UmbrellaBiz.Models.Cart;
using UmbrellaBiz.Services;
using UmbrellaBiz.ViewModels.AuxiliaryViewModels;
using UmbrellaBiz.Views.AuxiliaryWindows;

namespace UmbrellaBiz.ViewModels
{
    public class CartsViewModel : ViewModelBase
    {
        private ObservableCollection<CartModel> _carts;
        private CartModel _selectedCart;

        public ObservableCollection<CartModel> Carts
        {
            get { return _carts; }
            set
            {
                _carts = value;
                OnPropertyChanged(nameof(Carts));
            }
        }
        public CartModel SelectedCart
        {
            get { return _selectedCart; }
            set
            {
                _selectedCart = value;
                OnPropertyChanged(nameof(SelectedCart));
            }
        }
        public CartModel Cart { get; set; }

        public ICommand GetCartFullInfoCommand { get; }

        public CartsViewModel()
        {
            Carts = new ObservableCollection<CartModel>(CartModelService.GetAllCarts());
            GetCartFullInfoCommand = new ViewModelCommand(ExecuteGetCartFullInfoCommand, CanExecuteGetCartFullInfoCommand);
        }

        private bool CanExecuteGetCartFullInfoCommand(object obj)
        {
            return _selectedCart != null;
        }

        private void ExecuteGetCartFullInfoCommand(object obj)
        {
            Cart = CartModelService.GetCartById(_selectedCart.Id);

            var cartFullInfoViewModel = new CartFullInfoViewModel(Cart);
            var cartFullInfoWindow = new CartFullInfoWindow() { DataContext = cartFullInfoViewModel };

            cartFullInfoWindow.ShowDialog();
        }
    }
}
