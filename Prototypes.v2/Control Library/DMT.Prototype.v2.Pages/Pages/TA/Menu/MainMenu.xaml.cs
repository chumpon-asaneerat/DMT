#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

#endregion

namespace DMT.Pages.TA
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        #region Constructor

        /// <summary>
        /// Constructor.
        /// </summary>
        public MainMenu()
        {
            InitializeComponent();

            InitPlazaFund();
        }

        #endregion

        private Models.FundEntry plaza = new Models.FundEntry();

        private void InitPlazaFund()
        {
            plaza.Description = "เงินยืม-ทอน (ด่าน)";
            plaza.BHT1 = 100;
            plaza.BHT2 = 100;
            plaza.BHT5 = 100;
            plaza.BHT10c = 100;
            plaza.BHT20 = 100;
            plaza.BHT50 = 100;
            plaza.BHT100 = 100;
            plaza.BHT500 = 100;
            plaza.BHT1000 = 100;
            plaza.HasRemark = false;
        }

        #region Button (Menu) Command Handlers

        private void plazaReceivedReturnFund_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Plaza Fund Received
                var page = new TA.Plaza.PlazaFundReceivedReturnPage();

                BindingList<Models.FundEntry> funds = new BindingList<Models.FundEntry>();
                Models.FundEntry fund;

                fund = new Models.FundEntry();
                fund.Date = new DateTime(2020, 3, 12, 09, 05, 00);
                fund.StaffId = "14055";
                fund.StaffName = "นางวิภา สวัสดิวัฒน์";
                fund.BHT1 = 10;
                fund.BHT2 = 10;
                fund.BHT5 = 10;
                fund.BHT10c = 10;
                fund.BHT20 = 10;
                fund.BHT50 = 10;
                fund.BHT100 = 10;
                fund.BHT500 = 10;
                fund.BHT1000 = 10;
                funds.Add(fund);

                page.Setup(plaza, funds);

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void exchangeBankNote_Click(object sender, RoutedEventArgs e)
        {

        }

        private void plazaReceivedCoupon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Plaza Coupon Received
                var page = new TA.Plaza.PlazaCouponReceivedReturnPage();

                List<Models.Coupon> coupons = new List<Models.Coupon>();
                Models.Coupon coupon;

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 12, 09, 05, 00);
                coupon.StaffId = "14055";
                coupon.StaffName = "นางวิภา สวัสดิวัฒน์";
                coupon.Count = 10;
                coupon.Type = "คูปอง 35 บาท";
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 15, 08, 50, 21);
                coupon.StaffId = "14124";
                coupon.StaffName = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์";
                coupon.Count = 20;
                coupon.Type = "คูปอง 35 บาท";
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 17, 09, 10, 42);
                coupon.StaffId = "14211";
                coupon.StaffName = "นาย ภักดี อมรรุ่งโรจน์";
                coupon.Count = 15;
                coupon.Type = "คูปอง 80 บาท";
                coupons.Add(coupon);

                page.Setup(coupons);

                PageContentManager.Instance.Current = page;
            }
            catch (Exception)
            {
                //Console.WriteLine("Refresh data error.");
            }
        }

        private void plazaAllStock_Click(object sender, RoutedEventArgs e)
        {
            var win = new Windows.TA.Plaza.PlazaStockWindow();
            win.Owner = Application.Current.MainWindow;

            Models.FundEntry fund = new Models.FundEntry();
            fund.Description = "เงินยืมทอน";
            fund.HasRemark = false;
            fund.BHT1 = 100;
            fund.BHT2 = 100;
            fund.BHT5 = 100;
            fund.BHT10c = 100;
            fund.BHT20 = 100;
            fund.BHT50 = 100;
            fund.BHT100 = 100;
            fund.BHT500 = 100;
            fund.BHT1000 = 100;

            Models.CouponEntry coupon = new Models.CouponEntry();
            coupon.Description = "คุปอง";
            coupon.BHT35 = 32;
            coupon.BHT80 = 43;
            win.Setup(fund, coupon);

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

        }

        private void collectorFundReport_Click(object sender, RoutedEventArgs e)
        {

        }

        private void collectorReveivedCoupon_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Coupon Return
                var page = new TA.Coupon.ReceivedCouponPage();

                List<Models.Coupon> coupons = new List<Models.Coupon>();
                Models.Coupon coupon;

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 16, 18, 50, 11);
                coupon.StaffId = "14055";
                coupon.StaffName = "นางวิภา สวัสดิวัฒน์";
                coupon.Lane = 6;
                coupon.Count = 5;
                coupon.Type = "คูปอง 80 บาท";
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 16, 23, 15, 24);
                coupon.StaffId = "14147";
                coupon.StaffName = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์";
                coupon.Lane = 2;
                coupon.Count = 4;
                coupon.Type = "คูปอง 35 บาท";
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 17, 12, 1, 47);
                coupon.StaffId = "12562";
                coupon.StaffName = "นาย ภักดี อมรรุ่งโรจน์";
                coupon.Lane = 4;
                coupon.Count = 9;
                coupon.Type = "คูปอง 80 บาท";
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
            try
            {
                // Coupon Return
                var page = new TA.Coupon.ReturnCouponPage();

                List<Models.Coupon> coupons = new List<Models.Coupon>();
                Models.Coupon coupon;

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 16, 18, 50, 11);
                coupon.StaffId = "14055";
                coupon.StaffName = "นางวิภา สวัสดิวัฒน์";
                coupon.Lane = 6;
                coupon.Count = 10;
                coupon.Type = "คูปอง 35 บาท";
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 16, 23, 15, 24);
                coupon.StaffId = "14147";
                coupon.StaffName = "นางสาว แก้วใส ฟ้ารุ่งโรจณ์";
                coupon.Lane = 2;
                coupon.Count = 7;
                coupon.Type = "คูปอง 80 บาท";
                coupons.Add(coupon);

                coupon = new Models.Coupon();
                coupon.Date = new DateTime(2020, 3, 17, 12, 1, 47);
                coupon.StaffId = "12562";
                coupon.StaffName = "นาย ภักดี อมรรุ่งโรจน์";
                coupon.Lane = 4;
                coupon.Count = 8;
                coupon.Type = "คูปอง 35 บาท";
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
            PageContentManager.Instance.Current = new TA.SignInPage();
        }

        #endregion
    }
}
