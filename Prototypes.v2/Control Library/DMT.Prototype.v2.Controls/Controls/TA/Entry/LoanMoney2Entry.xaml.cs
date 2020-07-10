using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for LoanMoney2Entry.xaml
    /// </summary>
    public partial class LoanMoney2Entry : UserControl
    {
        public LoanMoney2Entry()
        {
            InitializeComponent();
        }

        public void Setup(List<Models.LoanMoneyEntry> funds)
        {
            //listView.ItemsSource = funds;
        }
    }
}
