using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.Converters
{
    public class TemperatureToColorConverter : IValueConverter//optional 2. Converter for string text color depending on temperature values.
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            Color color = Colors.Black;//default can be edited later on.
            if (value is string result)
            {
                string cleaned = result.Replace("°C", "")
                    .Replace("°", "")
                    .Replace("C", "")
                    .Replace("+","")
                    .Trim();
                bool parse = int.TryParse(cleaned, out int number);
                if (parse)
                {
                    if (number < 14) { color = Colors.Blue; }
                    if (number >= 14 && number <= 26) { color = Colors.Orange; }
                    if (number > 26) { color = Colors.Red; }
                }
            }
            return color;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
