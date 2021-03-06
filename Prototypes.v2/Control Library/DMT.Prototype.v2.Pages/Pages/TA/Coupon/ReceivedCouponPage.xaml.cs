﻿using System;
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
            //var couponTypes = new List<string>();
            //couponTypes.Add("คูปอง 35 บาท");
            //couponTypes.Add("คูปอง 80 บาท");
            //cbCouponTypes.DataContext = couponTypes;
            //cbCouponTypes.SelectedIndex = 0;

            revDate.Text = (DateTime.Now == DateTime.MinValue) ? "" : DateTime.Now.ToThaiDateString() + " " + DateTime.Now.ToString("HH:mm");

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
            coupon.CouponCode = "ข635001";
            coupons.Add(coupon);

            coupon = new Models.Coupon35();
            coupon.CouponCode = "ข635002";
            coupons.Add(coupon);

            coupon = new Models.Coupon35();
            coupon.CouponCode = "ข635003";
            coupons.Add(coupon);

            coupon = new Models.Coupon35();
            coupon.CouponCode = "ข635004";
            coupons.Add(coupon);

            coupon = new Models.Coupon35();
            coupon.CouponCode = "ข635005";
            coupons.Add(coupon);

            coupon = new Models.Coupon35();
            coupon.CouponCode = "ข635006";
            coupons.Add(coupon);

            coupon = new Models.Coupon35();
            coupon.CouponCode = "ข635007";
            coupons.Add(coupon);

            coupon = new Models.Coupon35();
            coupon.CouponCode = "ข635008";
            coupons.Add(coupon);

            Models.CouponUser35 coupon35;

            coupon35 = new Models.CouponUser35();
            coupon35.CouponCode = "ข635009";
            couponUs.Add(coupon35);

            coupon35 = new Models.CouponUser35();
            coupon35.CouponCode = "ข635010";
            couponUs.Add(coupon35);

            coupon35 = new Models.CouponUser35();
            coupon35.CouponCode = "ข635019";
            couponUs.Add(coupon35);

            Models.Coupon80 coupon80;

            coupon80 = new Models.Coupon80();
            coupon80.CouponCode = "C635011";
            coupons80.Add(coupon80);

            coupon80 = new Models.Coupon80();
            coupon80.CouponCode = "C635012";
            coupons80.Add(coupon80);

            coupon80 = new Models.Coupon80();
            coupon80.CouponCode = "C635013";
            coupons80.Add(coupon80);

            coupon80 = new Models.Coupon80();
            coupon80.CouponCode = "C635016";
            coupons80.Add(coupon80);

            coupon80 = new Models.Coupon80();
            coupon80.CouponCode = "C635017";
            coupons80.Add(coupon80);


            Models.CouponUser80 cop80;

            cop80 = new Models.CouponUser80();
            cop80.CouponCode = "C635014";
            couponsU80.Add(cop80);

            cop80 = new Models.CouponUser80();
            cop80.CouponCode = "C635015";
            couponsU80.Add(cop80);

            cop80 = new Models.CouponUser80();
            cop80.CouponCode = "C635018";
            couponsU80.Add(cop80);


            win.Setup(coupons, couponUs, coupons80, couponsU80);

            if (win.ShowDialog() == false)
            {
                return;
            }

        }
    }
}
