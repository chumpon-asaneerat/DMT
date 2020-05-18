using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.Account.Approve
{
    /// <summary>
    /// Interaction logic for AccountReport.xaml
    /// </summary>
    public partial class AccountReport : UserControl
    {
        public AccountReport()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Report Page
            var page = new Account.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            var page = new Account.MainMenu();
            PageContentManager.Instance.Current = page;
        }
    }
}
