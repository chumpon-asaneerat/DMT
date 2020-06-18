using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.TA.Coupon
{
    /// <summary>
    /// Interaction logic for ReceivedCouponPage.xaml
    /// </summary>
    public partial class ReceivedCouponPage : UserControl
    {
        public ReceivedCouponPage()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new TA.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new TA.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        public void Setup(List<Models.Coupon> coupons)
        {
            var couponTypes = new List<string>();
            couponTypes.Add("คูปอง 35 บาท");
            couponTypes.Add("คูปอง 80 บาท");
            cbCouponTypes.DataContext = couponTypes;
            cbCouponTypes.SelectedIndex = 0;
            grid.Setup(coupons);
        }

        private void cmdAppend_Click(object sender, RoutedEventArgs e)
        {
            var win = new DMT.Windows.TA.Coupon.CouponEditWindow();

            List<Models.Coupon35> coupons = new List<Models.Coupon35>();
            List<Models.CouponUser35> couponUs = new List<Models.CouponUser35>();
            List<Models.Coupon80> coupons80 = new List<Models.Coupon80>();
            List<Models.CouponUser80> couponsU80 = new List<Models.CouponUser80>();

            Models.Coupon35 coupon;

            coupon = new Models.Coupon35();
            coupon.CouponCode = "124356";
            coupons.Add(coupon);

            coupon = new Models.Coupon35();
            coupon.CouponCode = "1252678";
            coupons.Add(coupon);


            coupon = new Models.Coupon35();
            coupon.CouponCode = "976554";
            coupons.Add(coupon);

            coupon = new Models.Coupon35();
            coupon.CouponCode = "5788890";
            coupons.Add(coupon);


            Models.Coupon80 coupon80;

            coupon80 = new Models.Coupon80();
            coupon80.CouponCode = "898762";
            coupons80.Add(coupon80);

            coupon80 = new Models.Coupon80();
            coupon80.CouponCode = "5675785";
            coupons80.Add(coupon80);

            coupon80 = new Models.Coupon80();
            coupon80.CouponCode = "4367788";
            coupons80.Add(coupon80);


            win.Setup(coupons, couponUs, coupons80, couponsU80);

            if (win.ShowDialog() == false)
            {
                return;
            }

        }
    }
}
