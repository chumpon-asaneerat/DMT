using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for AccountFundDetailEntry.xaml
    /// </summary>
    public partial class AccountFundDetailEntry : UserControl
    {
        public AccountFundDetailEntry()
        {
            InitializeComponent();
        }

        public void Setup(List<Models.AccountFundEntry> funds)
        {
            //listView.ItemsSource = funds;
        }
    }
}
