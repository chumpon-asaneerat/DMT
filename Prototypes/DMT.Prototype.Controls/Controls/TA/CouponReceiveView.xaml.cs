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

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for CouponReceiveView.xaml
    /// </summary>
    public partial class CouponReceiveView : UserControl
    {
        public CouponReceiveView()
        {
            InitializeComponent();
        }

        private void cmdDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cmdEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Setup(List<Models.Coupon> coupons)
        {
            listView.ItemsSource = coupons;
        }
    }
}
