using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace ColorsViewer.ViewModels {

    public sealed class MainViewModel {

        public IEnumerable<NamedColor> WPFColors
            => GetNamedColors(GetColorProperties(typeof(Colors)));

        public IEnumerable<NamedColor> SystemColors
            => GetNamedColors(GetColorProperties(typeof(SystemColors)));

        private IEnumerable<PropertyInfo> GetColorProperties(Type type) {
            return type.GetProperties()
                .Where(p => p.PropertyType == typeof(Color));
        }

        private IEnumerable<NamedColor> GetNamedColors(IEnumerable<PropertyInfo> colorProperties) {
            return colorProperties.Select(c => new NamedColor {
                Color = (Color)c.GetValue(null),
                Name = c.Name.Replace("Color", "")
            });
        }
    }
}