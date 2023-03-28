using System.Windows;
using System.Windows.Input;
using UmbrellaBiz.ViewModels.AuxiliaryViewModels;

namespace UmbrellaBiz.Views.AuxiliaryWindows
{
    /// <summary>
    /// Interaction logic for AllAvailableProductsWindow.xaml
    /// </summary>
    public partial class AllAvailableProductsWindow : Window
    {
        public AllAvailableProductsWindow()
        {
            InitializeComponent();
        }

        private void LViewProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var dataContext = DataContext as AllAvailableProductsViewModel;
            if (dataContext != null)
            {
                dataContext.AddProductCommand.Execute(this);
            }
        }
    }
}
