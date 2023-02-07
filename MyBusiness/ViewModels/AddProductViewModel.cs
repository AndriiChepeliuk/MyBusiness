using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Input;

namespace MyBusiness.ViewModels
{
    public class AddProductViewModel : ViewModelBase
    {
        public ICommand ChoosePictureCommand { get; }

        public AddProductViewModel()
        {
            ChoosePictureCommand = new ViewModelCommand(ExecuteViewModelCommand);
        }

        private void ExecuteViewModelCommand(object obj)
        {
            OpenFileDialog open = new OpenFileDialog()
            {
                Title = "OpenOpen"
            };

            if (open.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(File.OpenRead(open.FileName));
            }
        }
    }
}
