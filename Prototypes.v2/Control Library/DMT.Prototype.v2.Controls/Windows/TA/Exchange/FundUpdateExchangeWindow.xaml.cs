using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DMT.Windows.TA.Exchange
{
    /// <summary>
    /// Interaction logic for FundUpdateExchangeWindow.xaml
    /// </summary>
    public partial class FundUpdateExchangeWindow : Window
    {
        public FundUpdateExchangeWindow()
        {
            InitializeComponent();
        }

        #region Button Handlers

        private void cmdSaveExchange_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion

        #region Public Methods

        public void Setup(Models.FundExchange item)
        {
            //srcEntry.DataContext = item.Plaza;
            requestEntry.DataContext = item.Request;
            approveEntry.DataContext = item.Approve;
            exchangeEntry.DataContext = item.Exchange;
            trueReciveEntry.DataContext = item.TrueRecive;
        }

        #endregion
    }
}
