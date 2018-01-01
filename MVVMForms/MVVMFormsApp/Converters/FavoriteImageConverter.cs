using System;
using System.Globalization;
using Xamarin.Forms;

namespace MVVMFormsApp.Converters
{
    public class FavoriteImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return string.Empty;


            bool returnImage = (bool)value;

            var a = returnImage ? "HeartRed" : "Wishlist";
            return a;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
