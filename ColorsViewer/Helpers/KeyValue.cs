using System.Windows;

namespace ColorsViewer.Helpers {

    internal sealed class KeyValue : FrameworkElement {

        public string Key { get => (string)GetValue(KeyProperty); set => SetValue(KeyProperty, value); }
        public object Value { get => GetValue(ValueProperty); set => SetValue(ValueProperty, value); }

        public static readonly DependencyProperty KeyProperty = DependencyProperty.Register(
            "Key", typeof(string), typeof(KeyValue), new FrameworkPropertyMetadata(default(string)));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value", typeof(object), typeof(KeyValue), new FrameworkPropertyMetadata(default(object)));
    }
}