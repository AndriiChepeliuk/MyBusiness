using MyBusiness.Models.Cart;
using System.Collections.ObjectModel;

namespace MyBusiness.Models.Customer
{
    public class CustomerModel : ModelBase
    {
        private string? name;
        private string? mobileNumber;
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
