using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.Account.RequestExchange
{
    /// <summary>
    /// Interaction logic for AccountRequestExchantePage.xaml
    /// </summary>
    public partial class AccountRequestExchantePage : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public AccountRequestExchantePage()
        {
            InitializeComponent();
        }

        #endregion

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.Account.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.Account.MainMenu();
            PageContentManager.Instance.Current = page;
        }
    }
}
