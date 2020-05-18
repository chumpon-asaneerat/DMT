using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for FundEntry.xaml
    /// </summary>
    public partial class FundEntry : UserControl
    {
        public FundEntry()
        {
            InitializeComponent();
        }

        public void Setup(List<Models.FundEntry> funds)
        {
            //listView.ItemsSource = funds;
        }
    }
}
