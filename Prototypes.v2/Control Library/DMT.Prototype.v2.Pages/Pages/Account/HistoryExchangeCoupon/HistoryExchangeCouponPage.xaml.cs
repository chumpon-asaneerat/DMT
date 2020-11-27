using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;


namespace DMT.Pages.Account.History
{
    /// <summary>
    /// Interaction logic for HistoryExchangeCouponPage.xaml
    /// </summary>
    public partial class HistoryExchangeCouponPage : UserControl
    {
        public HistoryExchangeCouponPage()
        {
            InitializeComponent();
        }

        private void cmdSearch_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.Account.MainMenu();
            PageContentManager.Instance.Current = page;
        }

    }


}
