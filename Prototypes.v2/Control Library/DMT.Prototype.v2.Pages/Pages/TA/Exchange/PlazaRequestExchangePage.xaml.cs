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

        private void ReturnFund(Models.FundEntry src, Models.FundEntry dst)
        {
            src.BHT1 -= dst.BHT1;
            src.BHT2 -= dst.BHT2;
            src.BHT5 -= dst.BHT5;
            src.BHT10c -= dst.BHT10c;
            src.BHT20 -= dst.BHT20;
            src.BHT50 -= dst.BHT50;
            src.BHT100 -= dst.BHT100;
            src.BHT500 -= dst.BHT500;
            src.BHT1000 -= dst.BHT1000;


            src.EXCHANGE -= dst.EXCHANGE;
            src.BORROW -= dst.BORROW;
            src.REVOLVINGFUNDS -= dst.REVOLVINGFUNDS;
        }

        private void BorrowFund(Models.FundEntry src, Models.FundEntry dst)
        {
            src.BHT1 += dst.BHT1;
            src.BHT2 += dst.BHT2;
            src.BHT5 += dst.BHT5;
            src.BHT10c += dst.BHT10c;
            src.BHT20 += dst.BHT20;
            src.BHT50 += dst.BHT50;
            src.BHT100 += dst.BHT100;
            src.BHT500 += dst.BHT500;
            src.BHT1000 += dst.BHT1000;

            src.EXCHANGE += dst.EXCHANGE;
            src.BORROW += dst.BORROW;
            src.REVOLVINGFUNDS += dst.REVOLVINGFUNDS;
        }

        private void assign(Models.FundEntry src, Models.FundEntry dst)
        {
            dst.BHT1 = src.BHT1;
            dst.BHT2 = src.BHT2;
            dst.BHT5 = src.BHT5;
            dst.BHT10c = src.BHT10c;
            dst.BHT20 = src.BHT20;
            dst.BHT50 = src.BHT50;
            dst.BHT100 = src.BHT100;
            dst.BHT500 = src.BHT500;
            dst.BHT1000 = src.BHT1000;

            dst.EXCHANGE = src.EXCHANGE;
            dst.BORROW = src.BORROW;
            dst.REVOLVINGFUNDS = src.REVOLVINGFUNDS;

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

        private void UpdateBalance()
        {
            plazaBalance.Text = _plaza.BHTTotal.ToString("n0");
        }


        private Models.FundEntry _plaza;
        Models.LoanMoneyEntry _loan;
        private BindingList<Models.FundExchange> _items;

        public void Setup(Models.FundEntry plaza, BindingList<Models.FundExchange> items , Models.LoanMoneyEntry loan)
        {
            _plaza = plaza;
            _loan = loan;
            _items = items;

            this.plaza.DataContext = _plaza;
            this.loanEntry.DataContext = _loan;

            this.grid.Setup(_plaza, _items);
            UpdateBalance();
        }

        private void _plaza_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateBalance();
        }
    }
}
