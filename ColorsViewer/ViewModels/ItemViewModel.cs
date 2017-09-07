using System.Windows.Media;

namespace ColorsViewer.ViewModels {

    using Helpers;

    public class ColorItemDetailedViewModel : ColorItemViewModel {
        public ColorItemDetailedViewModel(Color color, string name)
            : base(color, name) { }
    }

    public class ColorItemViewModel : ItemViewModel {

        public Color Color { get; }
        public string Name { get; }
        public override string ToString() => $"{Color}: {Name}";

        public ColorItemViewModel(Color color, string name) {
            Color = color; Name = name;
        }
    }

    public sealed class SchemeItemViewModel : ItemViewModel {

        public string Name { get; }
        public string Description { get; }

        public override string ToString() => $"{Name}: {Description}";

        public SchemeItemViewModel(string name, string description) {
            Name = name; Description = description;
        }
    }

    public abstract class ItemViewModel : Observable { }
}