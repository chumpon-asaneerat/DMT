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
    /// Interaction logic for TAMainPage.xaml
    /// </summary>
    public partial class TAMainPage : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public TAMainPage()
        {
            InitializeComponent();
        }

        #endregion

        #region Button (Menu) Command Handlers

        private void receivedFund_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Plaza Fund Received
                var page = new Pages.PlazaFundReceivedPage();

                BindingList<Models.FundEntry> funds = new BindingList<Models.FundEntry>();
                Models.FundEntry fund;

                fund = new Models.FundEntry();
                fund.Date = new DateTime(2020, 3, 12, 09, 05, 00);
                fund.StaffId = "14055";
                fund.BHT1 = 50000;
                fund.BHT2 = 50000;
                fund.BHT5 = 50000;
                fund.BHT10c = 20000;
                fund.BHT10b = 20000;
                fund.BHT20 = 10000;
                fund.BHT50 = 5000;
                fund.BHT100 = 5000;
                fund.BHT500 = 3000;
                fund.BHT1000 = 2500;
                funds.Add(fund);

                page.Setup(funds);

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void receivedFundReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void collectorFund_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var page = new CollectorFundViewPage();

                Models.FundEntry plazaFund = new Models.FundEntry();
                plazaFund.Description = "เงินยืม-ทอน (ด่าน)";
                plazaFund.Date = new DateTime(2020, 3, 12, 09, 05, 00);
                plazaFund.StaffId = "14055";
                plazaFund.BHT1 = 1000;
                plazaFund.BHT2 = 1000;
                plazaFund.BHT5 = 1000;
                plazaFund.BHT10c = 500;
                plazaFund.BHT10b = 500;
                plazaFund.BHT20 = 200;
                plazaFund.BHT50 = 100;
                plazaFund.BHT100 = 200;
                plazaFund.BHT500 = 100;
                plazaFund.BHT1000 = 100;

                BindingList<Models.FundEntry> funds = new BindingList<Models.FundEntry>();
                Models.FundEntry fund;
                // Collector 1
                fund = new Models.FundEntry();
                fund.Description = "นาย สุเทพ เหมัน";
                fund.Date = new DateTime(2020, 3, 17, 09, 05, 00);
                fund.StaffId = "14321";
                fund.Lane = 1;
                fund.BHT1 = 50;
                fund.BHT2 = 50;
                fund.BHT5 = 40;
                fund.BHT10c = 20;
                fund.BHT10b = 20;
                fund.BHT20 = 10;
                fund.BHT50 = 5;
                fund.BHT100 = 18;
                fund.BHT500 = 10;
                fund.BHT1000 = 5;
                funds.Add(fund);
                
                // Collector 2
                fund = new Models.FundEntry();
                fund.Description = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์";
                fund.Date = new DateTime(2020, 3, 17, 09, 05, 00);
                fund.StaffId = "13201";
                fund.Lane = 4;
                fund.BHT1 = 20;
                fund.BHT2 = 15;
                fund.BHT5 = 60;
                fund.BHT10c = 45;
                fund.BHT10b = 65;
                fund.BHT20 = 45;
                fund.BHT50 = 5;
                fund.BHT100 = 24;
                fund.BHT500 = 10;
                fund.BHT1000 = 5;
                funds.Add(fund);

                // Collector 3
                fund = new Models.FundEntry();
                fund.Description = "นางวิภา สวัสดิวัฒน์";
                fund.Date = new DateTime(2020, 3, 17, 09, 05, 00);
                fund.StaffId = "11559";
                fund.Lane = 8;
                fund.BHT1 = 20;
                fund.BHT2 = 15;
                fund.BHT5 = 20;
                fund.BHT10c = 20;
                fund.BHT10b = 20;
                fund.BHT20 = 10;
                fund.BHT50 = 3;
                fund.BHT100 = 21;
                fund.BHT500 = 14;
                fund.BHT1000 = 2;
                funds.Add(fund);

                // Collector 4
                fund = new Models.FundEntry();
                fund.Description = "นาย ภักดี อมรรุ่งโรจน์";
                fund.Date = new DateTime(2020, 3, 17, 09, 05, 00);
                fund.StaffId = "12866";
                fund.Lane = 5;
                fund.BHT1 = 0;
                fund.BHT2 = 0;
                fund.BHT5 = 0;
                fund.BHT10c = 0;
                fund.BHT10b = 0;
                fund.BHT20 = 0;
                fund.BHT50 = 0;
                fund.BHT100 = 0;
                fund.BHT500 = 0;
                fund.BHT1000 = 0;
                funds.Add(fund);

                page.Setup(plazaFund, funds);

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void collectorFundReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var page = new FundSummaryReportPage();
                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void receivedCoupon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Plaza Coupon Received
                var page = new Pages.PlazaReceivedCouponPage();

                List<Models.Coupon> coupons = new List<Models.Coupon>();
                Models.Coupon coupon;

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 12, 09, 05, 00);
                coupon.StaffId = "14055";
                coupon.Count = 500;
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 15, 08, 50, 21);
                coupon.StaffId = "14124";
                coupon.Count = 200;
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 17, 09, 10, 42);
                coupon.StaffId = "14211";
                coupon.Count = 250;
                coupons.Add(coupon);

                page.Setup(coupons);

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void receivedCouponReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {

            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void collectorReveivedCoupon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Coupon Received
                var page = new Pages.CollectorReceivedCouponPage();

                var staffId = "14055";
                List<Models.Coupon> coupons = new List<Models.Coupon>();
                Models.Coupon coupon;

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 16, 18, 50, 11);
                coupon.StaffId = staffId;
                coupon.Lane = 6;
                coupon.Count = 50;
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 16, 23, 15, 24);
                coupon.StaffId = staffId;
                coupon.Lane = 2;
                coupon.Count = 24;
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 17, 12, 1, 47);
                coupon.StaffId = staffId;
                coupon.Lane = 4;
                coupon.Count = 20;
                coupons.Add(coupon);

                page.Setup(coupons);

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void collectorReturnCoupon_Click(object sender, RoutedEventArgs e)
        {
            /*
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
            */
            try
            {
                // Coupon Return
                var page = new Pages.CollectorReturnCouponPage();

                var staffId = "14055";
                List<Models.Coupon> coupons = new List<Models.Coupon>();
                Models.Coupon coupon;
                
                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 16, 18, 50, 11);
                coupon.StaffId = staffId;
                coupon.Lane = 6;
                coupon.Count = 50;
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 16, 23, 15, 24);
                coupon.StaffId = staffId;
                coupon.Lane = 2;
                coupon.Count = 24;
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 17, 12, 1, 47);
                coupon.StaffId = staffId;
                coupon.Lane = 4;
                coupon.Count = 20;
                coupons.Add(coupon);

                page.Setup(coupons);

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            // Init Sign In Page
            PageContentManager.Instance.Current = new Pages.TASignInPage();
        }

        #endregion
    }
}
