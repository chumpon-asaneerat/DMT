using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for AccountFundEntry.xaml
    /// </summary>
    public partial class AccountFundEntry : UserControl
    {
        public AccountFundEntry()
        {
            InitializeComponent();
        }

        public void Setup(List<Models.AccountFundEntry> funds)
        {
            //listView.ItemsSource = funds;
        }
    }
}
