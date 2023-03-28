using UmbrellaBiz.Models.CartsItem;
using UmbrellaBiz.Models.Customer;
using System;
using System.Collections.ObjectModel;

namespace UmbrellaBiz.Models.Cart
{
    public class CartModel : ModelBase
    {
        private int _customerId;
        private CustomerModel? _customer;
        private ObservableCollection<CartsItemModel> _cartsItems = new ObservableCollection<CartsItemModel>();
        private float _totalCartWeight;
        private float _totalCartPrice;
        private float _totalCartCost;
        private bool _isOpen;
        private DateTime _dateOfCreation;
        private bool _cartReadyToAdd;

        public int Id { get; private set; }
        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                _customerId = value;
                OnPropertyChanged(nameof(CustomerId));
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
        public ObservableCollection<CartsItemModel> CartsItems
        {
            get { return _cartsItems; }
            set
            {
                _cartsItems = value;
                OnPropertyChanged(nameof(CartsItems));
            }
        }
        public float TotalCartWeight
        {
            get { return _totalCartWeight; }
            set
            {
                _totalCartWeight = value;
                OnPropertyChanged(nameof(TotalCartWeight));
            }
        }
        public float TotalCartPrice
        {
            get { return _totalCartPrice; }
            set
            {
                _totalCartPrice = value;
                OnPropertyChanged(nameof(TotalCartPrice));
            }
        }
        public float TotalCartCost
        {
            get { return _totalCartCost; }
            set
            {
                _totalCartCost = value;
                OnPropertyChanged(nameof(TotalCartCost));
            }
        }
        public bool IsOpen
        {
            get { return _isOpen; }
            set
            {
                _isOpen = value;
                OnPropertyChanged(nameof(IsOpen));
            }
        }
        public DateTime DateOfCreation
        {
            get { return _dateOfCreation; }
            set
            {
                _dateOfCreation = value;
                OnPropertyChanged(nameof(DateOfCreation));
            }
        }
        public bool CartReadyToAdd
        {
            get { return _cartReadyToAdd; }
            set
            {
                _cartReadyToAdd = value;
                OnPropertyChanged(nameof(CartReadyToAdd));
            }
        }

    }
}
