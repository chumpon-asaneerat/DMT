using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.TA.Coupon
{
    /// <summary>
    /// Interaction logic for ReturnCouponPage.xaml
    /// </summary>
    public partial class ReturnCouponPage : UserControl
    {
        public ReturnCouponPage()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new TA.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
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
            //cbCouponTypes.DataContext = couponTypes;
            //cbCouponTypes.SelectedIndex = 0;
            grid.Setup(coupons);
        }
    }
}
