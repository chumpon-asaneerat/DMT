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
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
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
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
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
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
            try
            {
                var page = new CollectorFundViewPage();

                Models.FundEntry plazaFund = new Models.FundEntry();
                plazaFund.Description = "เงินยืม-ทอน (ด่าน)";
                plazaFund.Date = new DateTime(2020, 3, 12, 09, 05, 00);
                plazaFund.StaffId = "14055";
                plazaFund.BHT1 = 50000;
                plazaFund.BHT2 = 50000;
                plazaFund.BHT5 = 50000;
                plazaFund.BHT10c = 20000;
                plazaFund.BHT10b = 20000;
                plazaFund.BHT20 = 10000;
                plazaFund.BHT50 = 5000;
                plazaFund.BHT100 = 5000;
                plazaFund.BHT500 = 3000;
                plazaFund.BHT1000 = 2500;

                BindingList<Models.FundEntry> funds = new BindingList<Models.FundEntry>();
                Models.FundEntry fund;
                // Collector 1
                fund = new Models.FundEntry();
                fund.Description = "นาย สุเทพ เหมัน";
                fund.Date = new DateTime(2020, 3, 17, 09, 05, 00);
                fund.StaffId = "14321";
                fund.Lane = 1;
                fund.BHT1 = 300;
                fund.BHT2 = 300;
                fund.BHT5 = 300;
                fund.BHT10c = 300;
                fund.BHT10b = 300;
                fund.BHT20 = 300;
                fund.BHT50 = 300;
                fund.BHT100 = 300;
                fund.BHT500 = 300;
                fund.BHT1000 = 300;
                funds.Add(fund);
                
                // Collector 2
                fund = new Models.FundEntry();
                fund.Description = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์";
                fund.Date = new DateTime(2020, 3, 17, 09, 05, 00);
                fund.StaffId = "13201";
                fund.Lane = 4;
                fund.BHT1 = 500;
                fund.BHT2 = 300;
                fund.BHT5 = 200;
                fund.BHT10c = 150;
                fund.BHT10b = 150;
                fund.BHT20 = 250;
                fund.BHT50 = 50;
                fund.BHT100 = 75;
                fund.BHT500 = 30;
                fund.BHT1000 = 30;
                funds.Add(fund);

                // Collector 3
                fund = new Models.FundEntry();
                fund.Description = "นางวิภา สวัสดิวัฒน์";
                fund.Date = new DateTime(2020, 3, 17, 09, 05, 00);
                fund.StaffId = "11559";
                fund.Lane = 8;
                fund.BHT1 = 50;
                fund.BHT2 = 300;
                fund.BHT5 = 100;
                fund.BHT10c = 200;
                fund.BHT10b = 200;
                fund.BHT20 = 150;
                fund.BHT50 = 100;
                fund.BHT100 = 50;
                fund.BHT500 = 50;
                fund.BHT1000 = 50;
                funds.Add(fund);

                // Collector 4
                fund = new Models.FundEntry();
                fund.Description = "นาย ภักดี อมรรุ่งโรจน์";
                fund.Date = new DateTime(2020, 3, 17, 09, 05, 00);
                fund.StaffId = "12866";
                fund.Lane = 5;
                fund.BHT1 = 150;
                fund.BHT2 = 300;
                fund.BHT5 = 50;
                fund.BHT10c = 50;
                fund.BHT10b = 50;
                fund.BHT20 = 200;
                fund.BHT50 = 150;
                fund.BHT100 = 70;
                fund.BHT500 = 70;
                fund.BHT1000 = 70;
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
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
            try
            {

            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void receivedCoupon_Click(object sender, RoutedEventArgs e)
        {
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
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
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
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
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
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
            Windows.SignInWindow win = new Windows.SignInWindow();
            win.Owner = Application.Current.MainWindow;
            if (win.ShowDialog() == false)
            {
                return;
            }
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

        #endregion
    }
}
