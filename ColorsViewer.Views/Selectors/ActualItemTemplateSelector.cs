using System.Windows;
using System.Windows.Controls;

namespace ColorsViewer.Views.Selectors {

    using ViewModels;
    using ViewModels.Items;

    public class ActualItemTemplateSelector : DataTemplateSelector {

        public DataTemplate SchemeItemTemplate { get; set; }
        public DataTemplate ColorItemTemplate { get; set; }
        public DataTemplate ColorItemDetailedTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container) {

            var vm = item as ViewModelBase;
            if (vm == null) {
                return null;
            }
            var type = vm.GetType();            
            if (type == typeof(ColorItemDetailedViewModel)) {
                return ColorItemDetailedTemplate;
            }
            if (type == typeof(ColorItemViewModel)) {
                return ColorItemTemplate;
            }
            if (type == typeof(SchemeItemViewModel)) {
                return SchemeItemTemplate;
            }
            return null;
        }
    }
}