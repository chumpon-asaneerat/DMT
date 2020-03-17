﻿using System;
using System.Collections.Generic;
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

        public void Setup(Models.RevenueEntry entry)
        {
            bagTraffic.DataContext = entry.Traffic;
            bagCoupon.DataContext = entry.Coupon;
            bagOther.DataContext = entry.Other;
        }
    }
}
