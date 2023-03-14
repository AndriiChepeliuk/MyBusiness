using UmbrellaBiz.Models.Product;
using System;
using System.Globalization;
using System.Windows.Data;

namespace UmbrellaBiz.Helpers.Converters
{
    public class AddProductConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ProductModel product = new ProductModel();
            product.Name = (string)values[0];
            product.Category = (string)values[1];
            product.Price = float.Parse((string)values[2]);
            return product;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
