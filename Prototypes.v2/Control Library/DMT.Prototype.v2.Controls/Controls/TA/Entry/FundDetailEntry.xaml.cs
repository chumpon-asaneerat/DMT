using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for FundDetailEntry.xaml
    /// </summary>
    public partial class FundDetailEntry : UserControl
    {
        public FundDetailEntry()
        {
            InitializeComponent();
        }

        public void Setup(List<Models.FundEntry> funds)
        {
            //listView.ItemsSource = funds;
        }
    }
}
