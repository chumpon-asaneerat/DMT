using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for PlazaFundReceivedPage.xaml
    /// </summary>
    public partial class PlazaFundReceivedPage : UserControl
    {
        public PlazaFundReceivedPage()
        {
            InitializeComponent();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.TAMainPage();
            PageContentManager.Instance.Current = page;
        }

        private void cmdAppend_Click(object sender, RoutedEventArgs e)
        {
            Windows.ReceivedFundWindow win = new Windows.ReceivedFundWindow();
            win.Owner = Application.Current.MainWindow;

            Models.FundEntry fund = new Models.FundEntry();
            fund.Description = "เงินยืม-ทอน";
            fund.Date = DateTime.Now;
            fund.StaffId = "14577";

            win.Setup(fund);
            if (win.ShowDialog() == false)
            {
                return;
            }

            if (fund.BHTTotal > decimal.Zero)
            {
                _funds.Add(fund);
            }
        }

        private BindingList<Models.FundEntry> _funds;
        public void Setup(BindingList<Models.FundEntry> funds)
        {
            _funds = funds;
            grid.Setup(_funds);
        }
    }
}
