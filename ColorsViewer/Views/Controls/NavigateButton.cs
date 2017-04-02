using System;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ColorsViewer.Views.Controls {

    public partial class NavigateButton : Button {

        public Uri NavigateUri { get; set; }

        public NavigateButton() => Click += (s, e)
            => NavigationService.GetNavigationService(this)?.Navigate(NavigateUri);
    }
}