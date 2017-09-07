using System;
using System.ComponentModel;

namespace ColorsViewer.Interfaces {

    // Views

    public interface IMainView : IView { }

    public interface IView {
        IViewModel ViewModel { get; }
    }

    // ViewModels

    public interface IMainViewModel : IViewModel { }

    public interface IViewModel
        : INotifyPropertyChanged, IDisposable { }
}