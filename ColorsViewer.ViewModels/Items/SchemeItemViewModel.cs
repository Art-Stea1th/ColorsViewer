namespace ColorsViewer.ViewModels.Items {

    public sealed class SchemeItemViewModel : ItemViewModel {

        public string Name { get; }
        public string Description { get; }

        public override string ToString() => $"{Name}: {Description}";

        public SchemeItemViewModel(string name, string description) {
            Name = name; Description = description;
        }
    }
}