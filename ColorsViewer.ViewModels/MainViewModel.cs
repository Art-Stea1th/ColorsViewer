using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace ColorsViewer.ViewModels {

    using Helpers;
    using Items;
    using Models;

    public sealed class MainViewModel : ViewModelBase {

        private ColorSchemes _presets; // data from model

        private SchemeItemViewModel _selectedScheme;
        private ColorItemViewModel _selectedColor;

        private IEnumerable<ItemViewModel> _actualItems;
        public IEnumerable<ItemViewModel> ActualItems {
            get => _actualItems;
            set => Set(ref _actualItems, value);
        }

        public ICommand ChangeActualItems => new RelayCommand(ChangeActualItemsExecute);
        public ICommand GoBack => new RelayCommand(GoBackExecute, (o) => _selectedScheme != null);

        private void ChangeActualItemsExecute(object param) {

            if (param is ColorItemViewModel color) {
                _selectedColor = color;
                ActualItems = GetDetailedColorFrom(color);
                return;
            }
            if (param is SchemeItemViewModel scheme) {
                _selectedScheme = scheme;
                ActualItems = GetColorsFrom(scheme);
                return;
            }
            if (param == null) {
                ActualItems = GetSchemes();
                return;
            }
        }

        private void GoBackExecute(object param) {
            if (_selectedColor != null) {
                ActualItems = GetColorsFrom(_selectedScheme);
                _selectedColor = null;
            }
            else {
                ActualItems = GetSchemes();
                _selectedScheme = null;
            }
        }

        private IEnumerable<ColorItemDetailedViewModel> GetDetailedColorFrom(ColorItemViewModel colorItem) {
            yield return new ColorItemDetailedViewModel(colorItem.Color, colorItem.Name);
        }

        private IEnumerable<ColorItemViewModel> GetColorsFrom(SchemeItemViewModel scheme) {
            return _presets
                .First(s => s.Name == scheme.Name)
                .Select(c => new ColorItemViewModel(c.Color, c.Name));
        }

        private IEnumerable<SchemeItemViewModel> GetSchemes() {
            return _presets
                .Select(s => new SchemeItemViewModel(s.Name, s.Description));
        }

        public MainViewModel() {
            _presets = new ColorSchemes();
            ChangeActualItemsExecute(null);
        }
    }
}