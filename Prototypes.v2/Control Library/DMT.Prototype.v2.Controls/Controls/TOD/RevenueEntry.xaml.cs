using System;
using System.Collections.Generic;
using System.Windows.Controls;

using DMT;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for RevenueEntry.xaml
    /// </summary>
    public partial class RevenueEntry : UserControl
    {
        public RevenueEntry()
        {
            InitializeComponent();
        }

        private Models.Job _job;
        private Models.RevenueEntry _entry;

        public void Setup(Models.Job job, Models.RevenueEntry entry)
        {
            _job = job;
            _entry = entry;
            /*
            bagTraffic.DataContext = entry.Traffic;
            bagOther.DataContext = entry.Other;
            bagCoupon.DataContext = entry.Coupon;
            //couponRevenue.DataContext = null;
            couponUsage.DataContext = entry.CouponUsage;
            */
        }
    }
}
