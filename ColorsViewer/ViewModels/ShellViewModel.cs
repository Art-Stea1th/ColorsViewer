using System.Windows;
using System.Windows.Input;

namespace ColorsViewer.ViewModels {

    using Helpers;
    using Services;

    internal sealed class ShellViewModel : Observable {

        private object actualView;
        public object ActualView {
            get => actualView;
            set => Set(ref actualView, value);
        }
        public ICommand ChangeActualView => new RelayCommand<object>(v => ActualView = v, v => v != null);
        public ICommand CopyToClipboard => new RelayCommand<object>(s => Clipboard.SetText(s.ToString()));
        public ShellViewModel() => ChangeActualView.Execute(new PresetsListViewModel(PresetsDataService.Instance));
    }
}