using System;
using System.Globalization;
using System.Windows.Data;

namespace Tp_Final_Fred.Services
{
    public class WeatherIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            string iconCode = value.ToString();
            string url = $"https://www.weatherbit.io/static/img/icons/{iconCode}.png";

            return url;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
