using System.Collections.Generic;
using System.Linq;

namespace ColorsViewer.ViewModels {

    using Models;

    internal sealed class PresetViewModel {

        public PresetsListViewModel Parent { get; }

        public string Name { get; }
        public string Description { get; }
        public IEnumerable<ColorDetailsViewModel> Colors { get; }

        public PresetViewModel(PresetsListViewModel parent, ColorPreset preset) {
            Parent = parent; Name = preset.Name; Description = preset.Description;
            Colors = new List<ColorDetailsViewModel>(
                preset.Colors.Select(c => new ColorDetailsViewModel(this, c)));
        }
    }
}