using MyBusiness.Models.Product;
using System;
using System.Globalization;
using System.Windows.Data;

namespace MyBusiness.Helpers.Converters
{
    class AddProductConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ProductModel product = new ProductModel();
            product.Name = (string)values[0];
            product.Category = (string)values[1];
            product.Price = double.Parse((string)values[2]);
            return product;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
