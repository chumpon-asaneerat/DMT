
#region Using

using System.Windows;
using System.Windows.Controls;

using NLib.Services;

#endregion

namespace DMT.Pages.TOD
{
    /// <summary>
    /// Interaction logic for TODMainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();
        }

        #endregion

        #region Button (Menu) Command Handlers

        private void beginJob_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }

            Windows.BOJWindow jobWindow = new Windows.BOJWindow();
            win.Owner = Application.Current.MainWindow;
            if (jobWindow.ShowDialog() == false)
            {
                return;
            }
        }

        private void endJob_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
            // End of Job Page
            //var page = new Pages.EOJPage();
            //PageContentManager.Instance.Current = page;
        }

        private void revEntry_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void reprintRevSlip_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void changeShift_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void reportMenu_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        #endregion
    }
}
