using System.Windows.Media;

namespace ColorsViewer.ViewModels {

    using Models;

    internal sealed class ColorDetailsViewModel {

        public PresetViewModel Parent { get; }

        public string FullName => $"{Parent.Name}.{Name.Replace(" ", string.Empty)}";
        public string Name { get; }
        public SolidColorBrush Brush { get; }        

        public ColorDetailsViewModel(PresetViewModel parent, NamedColor color) {
            Parent = parent; Name = color.Name;
            Brush = new SolidColorBrush((Color)ColorConverter.ConvertFromString(color.Color));
        }
    }
}