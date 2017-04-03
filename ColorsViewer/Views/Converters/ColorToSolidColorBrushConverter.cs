using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace ColorsViewer.Views.Converters {

    [ValueConversion(typeof(Color), typeof(SolidColorBrush))]
    public sealed class ColorToSolidColorBrushConverter : IValueConverter {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value is Color ? new SolidColorBrush((Color)value) : value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return (value as SolidColorBrush)?.Color;
        }
    }
}