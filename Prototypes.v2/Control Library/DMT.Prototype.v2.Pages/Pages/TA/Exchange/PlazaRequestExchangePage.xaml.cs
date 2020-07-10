using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.TA.Exchange
{
    /// <summary>
    /// Interaction logic for PlazaRequestExchangePage.xaml
    /// </summary>
    public partial class PlazaRequestExchangePage : UserControl
    {
        public PlazaRequestExchangePage()
        {
            InitializeComponent();
        }

        private void cmdRequest_Click(object sender, RoutedEventArgs e)
        {
            var win = new Windows.TA.Exchange.FundRequestExchangeWindow();
            win.Owner = Application.Current.MainWindow;

            var obj = Models.FundExchange.CreateNewFundRequest(_plaza, "14055", "นางวิภา สวัสดิวัฒน์", 0);

            win.Title = "คำร้องขอการแลกเปลี่ยนเงิน";
            win.Setup(Windows.TA.Exchange.ExchangeWindowMode.New, obj);
            if (win.ShowDialog() == false)
            {
                return;
            }

            if (win.Mode == Windows.TA.Exchange.ExchangeWindowMode.New)
            {
                // append item.
                _items.Add(obj);
            }
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.TA.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private Models.FundEntry _plaza;
        private BindingList<Models.FundExchange> _items;

        public void Setup(Models.FundEntry plaza, BindingList<Models.FundExchange> items)
        {
            _plaza = plaza;
            _items = items;

            this.plaza.DataContext = _plaza;
            this.grid.Setup(_plaza, _items);
        }
    }
}
