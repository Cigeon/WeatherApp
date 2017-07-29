using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherAppClientUWP.Models;
using Windows.UI.Xaml.Data;

namespace WeatherAppClientUWP.Converters
{
    public class TemperatureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value == null)
                return null;

            var temp = value as Temp;
            return $"{temp.Min} ... {temp.Max}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}
