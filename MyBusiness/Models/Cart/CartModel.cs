using MyBusiness.Models.Customer;

namespace MyBusiness.Models.Cart
{
    public class CartModel : ModelBase
    {
        private int customerId;
        private CustomerModel? customer;
        private float totalCartWeight;
        private float totalCartCost;
        private bool isOpen;

        public int Id { get; private set; }
        public int CustomerId
        {
            get { return customerId; }
            set
            {
                customerId = value;
                OnPropertyChanged(nameof(CustomerId));
            }
        }
        public CustomerModel Customer
        {
            get { return customer; }
            set
            {
                customer = value;
                OnPropertyChanged(nameof(Customer));
            }
        }
        public float TotalCartWeight
        {
            get { return totalCartWeight; }
            set
            {
                totalCartWeight = value;
                OnPropertyChanged(nameof(TotalCartWeight));
            }
        }
        public float TotalCartCost
        {
            get { return totalCartCost; }
            set
            {
                totalCartCost = value;
                OnPropertyChanged(nameof(TotalCartCost));
            }
        }
        public bool IsOpen
        {
            get { return isOpen; }
            set
            {
                isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
            }
        }
    }
}
