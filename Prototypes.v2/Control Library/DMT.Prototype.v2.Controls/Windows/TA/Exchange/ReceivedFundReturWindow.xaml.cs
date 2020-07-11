using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DMT.Windows.TA.Exchange
{
    /// <summary>
    /// Interaction logic for ReceivedFundReturWindow.xaml
    /// </summary>
    public partial class ReceivedFundReturWindow : Window
    {
        public ReceivedFundReturWindow()
        {
            InitializeComponent();
        }

        #region Button Handlers

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion

        #region Public Methods

        public void Setup(Models.FundEntry srcObj,
            Models.FundEntry rcvObj, ExchangeWindowMode mode)
        {
            Mode = mode;

            this.Source = srcObj;
            this.Borrow = rcvObj;

            requestEntry.DataContext = this.Source;
            requestDetailEntry.DataContext = this.Borrow;
        }

        #endregion

        #region Public Properties
        public Models.FundEntry Source { get; private set; }
        public Models.FundEntry Borrow { get; private set; }
        public ExchangeWindowMode Mode { get; private set; }

        #endregion
    }
}
