using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for CouponReturnView.xaml
    /// </summary>
    public partial class CouponReturnView : UserControl
    {
        public CouponReturnView()
        {
            InitializeComponent();
        }

        public void Setup(List<Models.Coupon> coupons)
        {
            listView.ItemsSource = coupons;
        }
    }
}
