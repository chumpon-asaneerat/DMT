using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DMT.Windows.TA.Exchange
{
    /// <summary>
    /// Interaction logic for FundRequestExchangeWindow.xaml
    /// </summary>
    public partial class FundRequestExchangeWindow : Window
    {
        public FundRequestExchangeWindow()
        {
            InitializeComponent();
        }

        #region Button Handlers

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cmdCancelRequest_Click(object sender, RoutedEventArgs e)
        {
            // change mode to cancel.
            Mode = ExchangeWindowMode.Cancel;
            this.DialogResult = true;
        }

        //private void cmdClose_Click(object sender, RoutedEventArgs e)
        //{
        //    this.DialogResult = false;
        //}

        #endregion

        #region Public Methods

        public void Setup(ExchangeWindowMode mode, Models.FundExchange item)
        {
            Mode = mode;

            requestEntry.DataContext = item.Request;
            requestDetailEntry.DataContext = item.Request;
        }

        #endregion

        #region Public Properties

        public ExchangeWindowMode Mode { get; private set; }

        #endregion
    }
}
