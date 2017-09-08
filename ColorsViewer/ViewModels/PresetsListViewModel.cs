using System.Collections.Generic;
using System.Linq;

namespace ColorsViewer.ViewModels {

    using Services;

    internal sealed class PresetsListViewModel {

        public IEnumerable<PresetViewModel> Presets { get; }

        public PresetsListViewModel(PresetsDataService dataService) {
            Presets = new List<PresetViewModel>(
                dataService.Presets.Select(p => new PresetViewModel(this, p)));
        }
    }
}