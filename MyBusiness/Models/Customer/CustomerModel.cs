using UmbrellaBiz.Models.Cart;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace UmbrellaBiz.Models.Customer
{
    public class CustomerModel : ModelBase
    {
        private string? _name;
        private string? _mobileNumber;
        private BitmapImage _avatar;
        private ObservableCollection<CartModel> _carts;// = new ObservableCollection<CartModel>();

        public int Id { get; private set; }
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string MobileNumber
        {
            get { return _mobileNumber; }
            set
            {
                _mobileNumber = value;
                OnPropertyChanged(nameof(MobileNumber));
            }
        }
        public byte[]? AvatarByteCode { get; set; }
        public BitmapImage Avatar
        {
            get { return _avatar; }
            set
            {
                _avatar = value;
                OnPropertyChanged(nameof(Avatar));
            }
        }
        public ObservableCollection<CartModel> Carts
        {
            get { return _carts; }
            set
            {
                _carts = value;
                OnPropertyChanged(nameof(Carts));
            }
        }
    }
}
