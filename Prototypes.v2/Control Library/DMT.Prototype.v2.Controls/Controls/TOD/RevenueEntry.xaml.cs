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
            if (null != _entry)
            {
                this.DataContext = _entry;
                trafficRevenue.DataContext = _entry.Traffic;
                otherRevenue.DataContext = _entry.Other;
                couponUsage.DataContext = _entry.CouponUsage;
                couponRevenue.DataContext = _entry.CouponRevenue;
            }
        }
    }
}
