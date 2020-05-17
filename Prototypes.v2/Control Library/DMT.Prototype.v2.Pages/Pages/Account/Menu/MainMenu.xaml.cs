#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

#endregion

namespace DMT.Pages.Account
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
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

        private void accountAllPlazaSummary_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
        }

        private void accountExchangeApprove_Click(object sender, RoutedEventArgs e)
        {
            var signinWin = new Windows.SignInWindow();
            signinWin.Owner = Application.Current.MainWindow;
            if (signinWin.ShowDialog() == false)
            {
                return;
            }
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
