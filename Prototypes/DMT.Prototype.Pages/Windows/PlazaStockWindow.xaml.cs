using System;
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
using System.Windows.Shapes;

namespace DMT.Windows
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
