using System.Windows.Controls;

namespace MyBusiness.Views
{
    /// <summary>
    /// Interaction logic for AddProductView.xaml
    /// </summary>
    public partial class AddProductView : UserControl
    {
        public System.Drawing.Image er = System.Drawing.Image.FromFile("../../../Images/DefaultImage.jpg");
        public AddProductView()
        {
            InitializeComponent();
        }
    }
}
