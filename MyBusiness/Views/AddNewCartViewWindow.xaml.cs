using System;
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


            foreach (var item in cart.Cart.CartsItems)
            {
                tempTotalWeight += item.ProductWeight;
                item.TotalItemCost = item.ProductWeight * item.Product.Price;
                tempTotalCost += (item.ProductWeight * item.Product.Price);
            }

            cart.Cart.TotalCartWeight = tempTotalWeight;
            cart.Cart.TotalCartCost = tempTotalCost;
        }
    }
}
