using System;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Data;

namespace ColorsViewer.Views.Converters {

    [ValueConversion(typeof(string), typeof(string))]
    public sealed class SpacesBeforeCapitalLettersConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            string result = value as string;
            if (value != null) {
                result = Regex.Replace(result, "[A-Z]", " $0");
            }
            return result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return (value as string)?.Replace(" ", "");
        }
    }
}