using System;
using System.Collections.Generic;
using System.Windows;

namespace DMT.Windows.TA.Plaza
{
    /// <summary>
    /// Interaction logic for PlazaStockWindow.xaml
    /// </summary>
    public partial class PlazaStockWindow : Window
    {
        public PlazaStockWindow()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public void Setup(Models.FundEntry fund, Models.CouponEntry coupon)
        {
            this.Fund = fund;
            this.Coupon = coupon;
            fundEntry.DataContext = this.Fund;
            couponEntry.DataContext = this.Coupon;
        }

        public Models.FundEntry Fund  { get; set; }
        public Models.CouponEntry Coupon { get; set; }
    }
}
