using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.Account.Check
{
    /// <summary>
    /// Interaction logic for AllPlazaFundPage.xaml
    /// </summary>
    public partial class AllPlazaFundPage : UserControl
    {
        public AllPlazaFundPage()
        {
            InitializeComponent();
        }

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
