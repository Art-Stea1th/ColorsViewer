using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ColorsViewer.ViewModels {

    using Helpers;
    using Models;
    using Interfaces;
    using System.Windows.Media;

    public sealed class MainViewModel : Observable, IMainViewModel {

        private ColorSchemes presets;

        private SchemeItemViewModel selectedScheme;
        private ColorItemViewModel selectedColor;

        private IEnumerable<ItemViewModel> actualItems;
        public IEnumerable<ItemViewModel> ActualItems {
            get => actualItems;
            set => Set(ref actualItems, value);
        }

        public ICommand ChangeActualItems => new RelayCommand<ItemViewModel>(ChangeActualItemsExecute);
        public ICommand GoBack => new RelayCommand(GoBackExecute, () => selectedScheme != null);

        private void ChangeActualItemsExecute(ItemViewModel param) {

            switch (param) {
                case null:
                    ActualItems = GetSchemes();
                    break;
                case ColorItemViewModel color:
                    selectedColor = color;
                    ActualItems = GetDetailedColorFrom(color);
                    break;
                case SchemeItemViewModel scheme:
                    selectedScheme = scheme;
                    ActualItems = GetColorsFrom(scheme);
                    break;
            }
        }

        private void GoBackExecute() {

            if (selectedColor != null) {
                ActualItems = GetColorsFrom(selectedScheme);
                selectedColor = null;
            }
            else {
                ActualItems = GetSchemes();
                selectedScheme = null;
            }
        }

        private IEnumerable<ColorItemDetailedViewModel> GetDetailedColorFrom(ColorItemViewModel colorItem) {
            yield return new ColorItemDetailedViewModel(colorItem.Color, colorItem.Name);
        }

        // by (Name && Description) IMPORTANT! Since the names or descriptions of some color presets may be the same
        private IEnumerable<ColorItemViewModel> GetColorsFrom(SchemeItemViewModel scheme) {
            return presets
                .First(s => s.Name == scheme.Name && s.Description == scheme.Description).Colors
                .Select(c => new ColorItemViewModel((Color)ColorConverter.ConvertFromString(c.Color), c.Name));
        }

        private IEnumerable<SchemeItemViewModel> GetSchemes() {
            return presets
                .Select(s => new SchemeItemViewModel(s.Name, s.Description));
        }

        public MainViewModel() {
            presets = new ColorSchemes();
            ChangeActualItemsExecute(null);
        }
    }
}