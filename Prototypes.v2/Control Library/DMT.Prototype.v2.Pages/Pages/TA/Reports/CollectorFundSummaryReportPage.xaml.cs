﻿using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.TA.Reports
{
    /// <summary>
    /// Interaction logic for CollectorFundSummaryReportPage.xaml
    /// </summary>
    public partial class CollectorFundSummaryReportPage : UserControl
    {
        public CollectorFundSummaryReportPage()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new TA.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new TA.MainMenu();
            PageContentManager.Instance.Current = page;
        }
    }
}
