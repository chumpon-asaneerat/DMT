
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
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            // Begin of Job Page
            Windows.TOD.Job.BOJWindow jobWindow = new Windows.TOD.Job.BOJWindow();
            jobWindow.Owner = Application.Current.MainWindow;
            if (jobWindow.ShowDialog() == false)
            {
                return;
            }
        }

        private void endJob_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            // End of Job Page
            var page = new Job.EOJPage();
            // setup
            page.Setup(Models.Job.FindJob("14077"));
            PageContentManager.Instance.Current = page;
        }

        private void revEntry_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            // Revenue Entry
            var page = new Revenue.RevenueDateSelectionPage();
            // setup
            Models.RevenueEntry entry = null;
            page.Setup(Models.Job.FindJob("14077"), entry);
            PageContentManager.Instance.Current = page;
        }

        private void reprintRevSlip_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            var search = new Windows.TOD.Reports.RevenueSlipSearchWindow();
            search.Owner = Application.Current.MainWindow;
            if (search.ShowDialog() == false)
            {
                return;
            }
            // Revenue Slip Preview
            var page = new Reports.RevenueSlipPreview();
            page.MenuPage = this;
            PageContentManager.Instance.Current = page;
        }

        private void changeShift_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            // Change Shift
            var page = new TollAdmin.ChangeShiftPage();
            // setup
            page.Setup(Models.Job.FindJob("14077"));
            PageContentManager.Instance.Current = page;
        }

        private void reportMenu_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
            var page = new TOD.ReportMenu();
            PageContentManager.Instance.Current = page;
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
        }

        #endregion
    }
}
