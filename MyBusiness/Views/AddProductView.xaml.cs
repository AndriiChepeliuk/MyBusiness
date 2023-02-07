using Microsoft.Win32;
using MyBusiness.ViewModels;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace MyBusiness.Views
{
    /// <summary>
    /// Interaction logic for AddProductView.xaml
    /// </summary>
    public partial class AddProductView : UserControl
    {
        public AddProductView()
        {
            InitializeComponent();
            DataContext = new AddProductViewModel();
        }

        private void addPicture_Click(object sender, RoutedEventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                Title = "Open"
            };

            if (open.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(File.OpenRead(open.FileName));
            }
        }
    }
}
