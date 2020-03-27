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

        private void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        #endregion

        #region Public Methods

        public void Setup(ExchangeWindowMode mode, Models.FundExchange item)
        {
            Mode = mode;

            srcEntry.DataContext = item.Plaza;
            requestEntry.DataContext = item.Request;
        }

        #endregion

        #region Public Properties

        public ExchangeWindowMode Mode { get; private set; }

        #endregion
    }
}
