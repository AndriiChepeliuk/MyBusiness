using System;
using System.Linq;
using System.Windows;
using UmbrellaBiz.ViewModels;

namespace UmbrellaBiz.Views
{
    /// <summary>
    /// Interaction logic for AddNewCartViewWindow.xaml
    /// </summary>
    public partial class AddNewCartViewWindow : Window
    {
        public AddNewCartViewWindow()
        {
            InitializeComponent();
        }

        private void cartItemsDataGrid_CurrentCellChanged(object sender, EventArgs e)
        {
            float tempTotalWeight = 0;
            float tempTotalCost = 0;
            var cart = DataContext as AddNewCartViewModel;

            if (cart != null)
            {
                foreach (var item in cart.Cart.CartsItems)
                {
                    tempTotalWeight += item.ProductWeight;
                    tempTotalCost += (item.ProductWeight * item.Product.Price);
                }

                if (cart.Cart.CartsItems.FirstOrDefault(x => x.ReadyToAdd == false) == null)
                {
                    cart.Cart.CartReadyToAdd = true;
                }
                else cart.Cart.CartReadyToAdd = false;

                cart.Cart.TotalCartWeight = tempTotalWeight;
                cart.Cart.TotalCartCost = tempTotalCost;

            }

        }
    }
}
