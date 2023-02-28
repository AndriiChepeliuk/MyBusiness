using MyBusiness.Models.CartsItem;
using MyBusiness.Models.Customer;
using System;
using System.Collections.ObjectModel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace MyBusiness.Models.Cart
{
    public class CartModel : ModelBase
    {
        private int customerId;
        private CustomerModel? customer;
        private ObservableCollection<CartsItemModel> cartsItems;
        private float totalCartWeight;
        private float totalCartCost;
        private bool isOpen;
        private DateTime dateOfCreation;

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
        public ObservableCollection<CartsItemModel> CartsItems
        {
            get { return cartsItems; }
            set
            {
                cartsItems = value;
                OnPropertyChanged(nameof(CartsItems));
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
        public DateTime DateOfCreation
        {
            get { return dateOfCreation; }
            set
            {
                dateOfCreation = value;
                OnPropertyChanged(nameof(DateOfCreation));
            }
        }

    }
}
