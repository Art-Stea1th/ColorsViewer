using System;
using System.Windows;

namespace ColorsViewer {

    using Helpers;
    using Interfaces;
    using ViewModels;
    using Views;

    public partial class App : Application, IDisposable {

        public App() {

            Startup += (s, e) => {
                Container.Register<IMainViewModel, MainViewModel>();
                Container.Register<IMainView, MainView>();
                (MainWindow = Container.Resolve<IMainView>() as Window).Show();
                };

            DispatcherUnhandledException += (s, e) => Dispose();
            Exit += (s, e) => Dispose();
        }
        public void Dispose() => (MainWindow?.DataContext as IDisposable)?.Dispose();
    }
}