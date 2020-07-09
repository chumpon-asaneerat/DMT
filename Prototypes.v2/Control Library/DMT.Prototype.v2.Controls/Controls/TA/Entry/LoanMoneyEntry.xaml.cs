using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for LoanMoneyEntry.xaml
    /// </summary>
    public partial class LoanMoneyEntry : UserControl
    {
        public LoanMoneyEntry()
        {
            InitializeComponent();
        }

        public void Setup(List<Models.LoanMoneyEntry> funds)
        {
            //listView.ItemsSource = funds;
        }
    }
}
