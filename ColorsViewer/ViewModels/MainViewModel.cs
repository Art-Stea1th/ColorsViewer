using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace ColorsViewer.ViewModels {

    public sealed class MainViewModel {

        public IEnumerable<ColorViewModel> SystemColors { get; set; }
        public IEnumerable<ColorViewModel> WPFColors { get; set; }

        public MainViewModel() {
            WPFColors = GetColorPropertiesFrom(typeof(Colors));
            SystemColors = GetColorPropertiesFrom(typeof(SystemColors));
        }

        private IEnumerable<ColorViewModel> GetColorPropertiesFrom(Type type) {
            return type.GetProperties()
                .Where(p => p.PropertyType == typeof(Color))
                .Select(c => new ColorViewModel {
                    Color = (Color)c.GetValue(null),
                    Name = c.Name.Replace("Color", "")
                });
        }
    }
}