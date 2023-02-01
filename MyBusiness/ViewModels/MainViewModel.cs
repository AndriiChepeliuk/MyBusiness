using FontAwesome.Sharp;
using System.Windows.Input;

namespace MyBusiness.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _currentChildView;
        private string _caption;
        private IconChar _icon;

        public ViewModelBase CurrentChildView
        {
            get
            {
                return _currentChildView;
            }
            set
            {
                _currentChildView = value;
                OnPropertyChanged(nameof(CurrentChildView));
            }
        }
        public string Caption
        {
            get
            {
                return _caption;
            }
            set
            {
                _caption = value;
                OnPropertyChanged(nameof(Caption));
            }
        }
        public IconChar Icon
        {
            get
            {
                return _icon;
            }
            set
            {
                _icon = value;
                OnPropertyChanged(nameof(Icon));
            }
        }

        public ICommand ShowAllProductsViewCommand { get; }
        public ICommand ShowCreateCartViewCommand { get; }
        public ICommand ShowSuppliesCommand { get; }

        public MainViewModel()
        {
            //--> Initialize commands
            ShowAllProductsViewCommand = new ViewModelCommand(ExecuteShowAllProductsViewCommand);
            ShowCreateCartViewCommand = new ViewModelCommand(ExecuteShowCreateCartViewCommand);
            ShowSuppliesCommand = new ViewModelCommand(ExecuteShowSuppliesCommand);

            //--> Default view
            ExecuteShowAllProductsViewCommand(null);
        }

        private void ExecuteShowSuppliesCommand(object obj)
        {
            //CurrentChildView = new CustomerViewModel();
            Caption = "Supplies";
            Icon = IconChar.CubesStacked;
        }
        private void ExecuteShowCreateCartViewCommand(object obj)
        {
            //CurrentChildView = new CustomerViewModel();
            Caption = "Create cart";
            Icon = IconChar.CartShopping;
        }

        private void ExecuteShowAllProductsViewCommand(object obj)
        {
            //CurrentChildView = new HomeViewModel();
            Caption = "All products";
            Icon = IconChar.ListCheck;
        }


    }
}
