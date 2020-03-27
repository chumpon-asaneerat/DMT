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
    /// Interaction logic for CouponPreviewPage.xaml
    /// </summary>
    public partial class CouponPreviewPage : UserControl
    {
        public CouponPreviewPage()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Report Page
            var page = new Pages.TODReportMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Report Page
            var page = new Pages.TODReportMenu();
            PageContentManager.Instance.Current = page;
        }
    }
}
