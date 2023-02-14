using System.Windows;

namespace MyBusiness.Views
{
    /// <summary>
    /// Interaction logic for EditProductViewWindow.xaml
    /// </summary>
    public partial class EditProductViewWindow : Window
    {
        public EditProductViewWindow()
        {
            InitializeComponent();
        }

        private void cancelEditing_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
