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
    /// Interaction logic for TODReportMenu.xaml
    /// </summary>
    public partial class TODReportMenu : UserControl
    {
        public TODReportMenu()
        {
            InitializeComponent();
        }

        private void revSlip_Click(object sender, RoutedEventArgs e)
        {
            // Revenue Preview
            var page = new Pages.RevenuePreviewPage();
            PageContentManager.Instance.Current = page;
        }

        private void couponSlip_Click(object sender, RoutedEventArgs e)
        {
            // Coupon Slip Preview
            var page = new Pages.CouponPreviewPage();
            PageContentManager.Instance.Current = page;
        }

        private void revSummary_Click(object sender, RoutedEventArgs e)
        {

        }

        private void couponSummary_Click(object sender, RoutedEventArgs e)
        {
            // Coupon Summary Preview.
            var page = new Pages.CouponSummaryPreviewPage();
            PageContentManager.Instance.Current = page;
        }

        private void backHome_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.TODMainPage();
            PageContentManager.Instance.Current = page;
        }
    }
}
