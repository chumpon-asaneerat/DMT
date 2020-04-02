using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DMT.Windows
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
            srcEntry.DataContext = item.Plaza;
            requestEntry.DataContext = item.Request;
            exchangeEntry.DataContext = item.Exchange;
        }

        #endregion
    }
}
