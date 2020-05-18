using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.TOD.Revenue
{
    /// <summary>
    /// Interaction logic for RevenueEntryPage.xaml
    /// </summary>
    public partial class RevenueEntryPage : UserControl
    {
        public RevenueEntryPage()
        {
            InitializeComponent();
        }

        private Models.Job _job;
        private Models.RevenueEntry _entry;

        public void Setup(Models.Job job, Models.RevenueEntry entry)
        {
            _job = job;
            _entry = entry;
            revEntry.Setup(_job, _entry);
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Slip Preview
            var page = new TOD.Reports.RevenueSlipPreview();
            // back to main menu.
            page.MenuPage = new TOD.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new TOD.MainMenu();
            PageContentManager.Instance.Current = page;
        }
    }
}
