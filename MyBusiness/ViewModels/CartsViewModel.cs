using System.Collections.ObjectModel;
using UmbrellaBiz.Models.Cart;
using UmbrellaBiz.Services;

namespace UmbrellaBiz.ViewModels
{
    public class CartsViewModel : ViewModelBase
    {
        private ObservableCollection<CartModel> _carts;

        public ObservableCollection<CartModel> Carts
        {
            get { return _carts; }
            set
            {
                _carts = value;
                OnPropertyChanged(nameof(Carts));
            }
        }

        public CartsViewModel()
        {
            Carts = new ObservableCollection<CartModel>(CartModelService.GetAllCarts());
        }
    }
}
