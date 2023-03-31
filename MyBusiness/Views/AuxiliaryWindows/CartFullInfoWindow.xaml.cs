using System.Windows;

namespace UmbrellaBiz.Views.AuxiliaryWindows
{
    /// <summary>
    /// Interaction logic for CartFullInfoWindow.xaml
    /// </summary>
    public partial class CartFullInfoWindow : Window
    {
        public CartFullInfoWindow()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            //Application.Current.Shutdown();
        }
    }
}
