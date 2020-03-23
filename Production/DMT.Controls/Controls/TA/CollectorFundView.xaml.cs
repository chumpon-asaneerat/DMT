using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

using NLib;
using NLib.Services;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for CollectorFundView.xaml
    /// </summary>
    public partial class CollectorFundView : UserControl
    {
        public CollectorFundView()
        {
            InitializeComponent();
        }

        private Models.FundEntry _plaza;
        private BindingList<Models.FundEntry> _funds;

        public void Setup(Models.FundEntry plaza,
            BindingList<Models.FundEntry> funds)
        {
            _plaza = plaza;
            _funds = funds;

            listView.ItemsSource = _funds;
        }

        private void ReturnFund(Models.FundEntry src, Models.FundEntry dst)
        {
            src.BHT1 -= dst.BHT1;
            src.BHT2 -= dst.BHT2;
            src.BHT5 -= dst.BHT5;
            src.BHT10c -= dst.BHT10c;
            src.BHT10b -= dst.BHT10b;
            src.BHT20 -= dst.BHT20;
            src.BHT50 -= dst.BHT50;
            src.BHT100 -= dst.BHT100;
            src.BHT500 -= dst.BHT500;
            src.BHT1000 -= dst.BHT1000;

            if (null != ItemChanged) ItemChanged.Invoke(this, EventArgs.Empty);
        }

        private void BorrowFund(Models.FundEntry src, Models.FundEntry dst)
        {
            src.BHT1 += dst.BHT1;
            src.BHT2 += dst.BHT2;
            src.BHT5 += dst.BHT5;
            src.BHT10c += dst.BHT10c;
            src.BHT10b += dst.BHT10b;
            src.BHT20 += dst.BHT20;
            src.BHT50 += dst.BHT50;
            src.BHT100 += dst.BHT100;
            src.BHT500 += dst.BHT500;
            src.BHT1000 += dst.BHT1000;

            if (null != ItemChanged) ItemChanged.Invoke(this, EventArgs.Empty);
        }

        private void assign(Models.FundEntry src, Models.FundEntry dst)
        {
            dst.BHT1 = src.BHT1;
            dst.BHT2 = src.BHT2;
            dst.BHT5 = src.BHT5;
            dst.BHT10c = src.BHT10c;
            dst.BHT10b = src.BHT10b;
            dst.BHT20 = src.BHT20;
            dst.BHT50 = src.BHT50;
            dst.BHT100 = src.BHT100;
            dst.BHT500 = src.BHT500;
            dst.BHT1000 = src.BHT1000;
        }

        private void cmdReceived_Click(object sender, RoutedEventArgs e)
        {
            var fund = (Models.FundEntry)((FrameworkElement)sender).DataContext;
            if (null != fund)
            {
                Models.FundEntry obj = new Models.FundEntry();
                obj.Description = fund.Description;

                var win = new Windows.FundWindow();
                win.Owner = Application.Current.MainWindow;
                win.Title = "ยืมเงิน";
                win.Setup(obj);
                if (win.ShowDialog() == false)
                {
                    return;
                }

                BorrowFund(fund, obj);
            }
        }

        private void cmdReturn_Click(object sender, RoutedEventArgs e)
        {
            var fund = (Models.FundEntry)((FrameworkElement)sender).DataContext;
            if (null != fund)
            {
                Models.FundEntry obj = new Models.FundEntry();
                obj.Description = fund.Description;

                var win = new Windows.FundWindow();
                win.Owner = Application.Current.MainWindow;
                win.Title = "คืนเงิน";
                win.Setup(obj);
                if (win.ShowDialog() == false)
                {
                    return;
                }

                ReturnFund(fund, obj);
            }
        }

        private void cmdView_Click(object sender, RoutedEventArgs e)
        {
            var fund = (Models.FundEntry)((FrameworkElement)sender).DataContext;
            if (null != fund)
            {
                var win = new Windows.FundWindow();
                win.Owner = Application.Current.MainWindow;
                win.Title = "ดูยอดยืม-คืนเงิน";
                win.Setup(fund);
                if (win.ShowDialog() == false) 
                {
                    return;
                }
            }
        }

        public event System.EventHandler ItemChanged;
    }
}
