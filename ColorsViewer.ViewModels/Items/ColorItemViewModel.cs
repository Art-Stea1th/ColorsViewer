using System.Windows.Media;


namespace ColorsViewer.ViewModels.Items {

    public class ColorItemViewModel : ItemViewModel {

        public Color Color { get; }
        public string Name { get; }
        public override string ToString() => $"{Color}: {Name}";

        public ColorItemViewModel(Color color, string name) {
            Color = color; Name = name;
        }
    }
}