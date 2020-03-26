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
using System.Windows.Navigation;
using System.Windows.Shapes;

using NLib;
using NLib.Services;

namespace DMT.Pages
{
    /// <summary>
    /// Interaction logic for PlazaReceivedCouponPage.xaml
    /// </summary>
    public partial class PlazaReceivedCouponPage : UserControl
    {
        public PlazaReceivedCouponPage()
        {
            InitializeComponent();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.TAMainPage();
            PageContentManager.Instance.Current = page;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.TAMainPage();
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
            var plazaCoupons = new Models.CouponEntry();
            plazaCoupons.Description = "สรุปยอดคูปอง";
            plazaCoupons.BHT35 = 200;
            plazaCoupons.BHT80 = 200;
            plaza.DataContext = plazaCoupons;
            plaza.IsEnabled = false;
        }
    }
}
