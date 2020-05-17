#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

#endregion

namespace DMT.Pages.TA
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

        private void plazaFundReceivedReturn_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void exchangeBankNote_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void collectorFund_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void collectorFundReport_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void receivedCoupon_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void receivedCouponReport_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void collectorReveivedCoupon_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void collectorReturnCoupon_Click(object sender, RoutedEventArgs e)
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
