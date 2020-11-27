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
            try
            {
                // All Plaza Fund Page.
                var page = new Account.Check.AllPlazaFundPage();

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void historyExchangeApprove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Account Report
                var page = new Account.History.HistoryExchangePage();
                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }
        private void limit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Account Report
                var page = new Account.Limit.LimitPage();
                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }
        private void accountExchangeApprove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Account Report
                var page = new Account.Approve.AccountReport();
                //var page = new Account.RequestExchange.AccountRequestExchantePage();

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void historyExchangeCoupon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Account Report
                var page = new Account.History.HistoryExchangeCouponPage();

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            Services.SmartCardManager.SignOut();
            // Init Sign In Page
            PageContentManager.Instance.Current = new Account.SignInPage();
        }

        #endregion
    }
}
