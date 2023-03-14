using UmbrellaBiz.Models.Cart;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace UmbrellaBiz.Models.Customer
{
    public class CustomerModel : ModelBase
    {
        private string? name;
        private string? mobileNumber;
        private BitmapImage avatar;
        private ObservableCollection<CartModel> carts;// = new ObservableCollection<CartModel>();

        public int Id { get; private set; }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string MobileNumber
        {
            get { return mobileNumber; }
            set
            {
                mobileNumber = value;
                OnPropertyChanged(nameof(MobileNumber));
            }
        }
        public byte[]? AvatarByteCode { get; set; }
        public BitmapImage Avatar
        {
            get { return avatar; }
            set
            {
                avatar = value;
                OnPropertyChanged(nameof(Avatar));
            }
        }
        public ObservableCollection<CartModel> Carts
        {
            get { return carts; }
            set
            {
                carts = value;
                OnPropertyChanged(nameof(Carts));
            }
        }
    }
}
