using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Media;

namespace ColorsViewer.Models {

    public sealed class ColorSchemes : IEnumerable<ColorPreset> {

        public ColorPreset Media
            => new ColorPreset("WPF", "Windows.Media.Colors", GetNamedColors(GetColorProperties(typeof(Colors))));
        public ColorPreset System
            => new ColorPreset("System", "Windows.SystemColors", GetNamedColors(GetColorProperties(typeof(SystemColors))));

        private List<ColorPreset> _presets = new List<ColorPreset>();

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

        public IEnumerator<ColorPreset> GetEnumerator() => GetAllPresets().GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetAllPresets().GetEnumerator();

        private IEnumerable<ColorPreset> GetAllPresets() {
            yield return Media; yield return System;
            foreach (var nextPreset in _presets) {
                yield return nextPreset;
            }
        }
    }
}