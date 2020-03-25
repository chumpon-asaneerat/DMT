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

namespace DMT.Pages
{
    /// <summary>
    /// Interaction logic for PlazaFundReturnPage.xaml
    /// </summary>
    public partial class PlazaFundReturnPage : UserControl
    {
        public PlazaFundReturnPage()
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
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.TAMainPage();
            PageContentManager.Instance.Current = page;
        }

        private void cmdAppend_Click(object sender, RoutedEventArgs e)
        {
            Windows.FundReturnWindow win = new Windows.FundReturnWindow();

            win.Owner = Application.Current.MainWindow;

            /*
            Models.FundEntry fund = new Models.FundEntry();
            fund.BHT1 = 100;
            fund.BHT2 = 100;
            fund.BHT5 = 100;
            fund.BHT10c = 100;
            fund.BHT50 = 100;
            fund.BHT100 = 100;
            fund.BHT500 = 100;
            fund.BHT1000 = 100;
            */

            Models.FundEntry src = new Models.FundEntry();            
            Models.FundEntry obj = new Models.FundEntry();
            Models.FundEntry ret = new Models.FundEntry();
            assign(_plaza, src);

            win.Setup(src, obj, ret);
            src.Description = "ยอดก่อนยืม";
            obj.Description = "ยืมเงิน";
            ret.Description = "ยอดรวม";

            win.Setup(src, obj, ret);
            if (win.ShowDialog() == false)
            {
                return;
            }

            if (obj.BHTTotal > decimal.Zero)
            {
                obj.StaffId = "14077";
                obj.Date = DateTime.Now;
                _funds.Add(obj);
            }
        }


        private Models.FundEntry _plaza;
        private BindingList<Models.FundEntry> _funds;

        public void Setup(Models.FundEntry fund, BindingList<Models.FundEntry> funds)
        {
            _plaza = fund;
            _funds = funds;
            grid.Setup(_funds);
        }
    }
}
