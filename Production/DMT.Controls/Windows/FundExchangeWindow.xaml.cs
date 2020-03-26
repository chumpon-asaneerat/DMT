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
    public enum ExchangeWindowMode
    {
        New,
        Edit,
        Cancel,
        Exchanged
    }

    /// <summary>
    /// Interaction logic for FundExchangeWindow.xaml
    /// </summary>
    public partial class FundExchangeWindow : Window
    {
        public FundExchangeWindow()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            if (_mode == ExchangeWindowMode.New)
            {
                // new exchanged.
            }
            else if (_mode == ExchangeWindowMode.Edit)
            {
                // edit exchanged.
            }
            else if (_mode == ExchangeWindowMode.Cancel)
            {
                // cancel exchanged.
            }
            else
            {
                // completed exchanged.
            }
            this.DialogResult = true;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private ExchangeWindowMode _mode = ExchangeWindowMode.New;

        public void Setup(ExchangeWindowMode mode, Models.FundExchange item)
        {
            _mode = mode;

            srcEntry.DataContext = item.Plaza;
            requestEntry.DataContext = item.Request;
            exchangeEntry.DataContext = item.Exchange;
            sumEntry.DataContext = item.Result;
        }

        private void cmdCancelRequest_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdExchangeRequest_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
