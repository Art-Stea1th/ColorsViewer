using System.Windows;


namespace ColorsViewer.Views {

    using Interfaces;
    using Helpers;

    public partial class MainView : Window, IMainView {

        public IViewModel ViewModel => Container.Resolve<IMainViewModel>();

        public MainView() {
            InitializeComponent();
            DataContext = ViewModel;
        }
    }
}