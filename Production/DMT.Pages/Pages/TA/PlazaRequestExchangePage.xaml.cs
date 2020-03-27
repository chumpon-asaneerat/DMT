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
    /// Interaction logic for PlazaRequestExchangePage.xaml
    /// </summary>
    public partial class PlazaRequestExchangePage : UserControl
    {
        public PlazaRequestExchangePage()
        {
            InitializeComponent();
        }

        private void cmdRequest_Click(object sender, RoutedEventArgs e)
        {
            Windows.FundExchangeWindow win = new Windows.FundExchangeWindow();
            win.Owner = Application.Current.MainWindow;

            DateTime dt = DateTime.Now;
            Models.FundExchange obj = new Models.FundExchange();
            obj.StaffId = "14055";
            obj.Date = dt;
            obj.Status = "รออนุมัติ";

            obj.Plaza = _plaza;
            //obj.Plaza.Description = "ยอดก่อนยืม";
            obj.Plaza.Description = "ยอดเงินยืม-ทอน (ด่าน)";

            obj.Request = new Models.FundEntry();
            obj.Request.Description = "ประเภทเงินยืมทอนที่ขอเปลี่ยน";
            obj.Request.StaffId = "14055";
            obj.Request.Date = dt;

            obj.Exchange = new Models.FundEntry();
            obj.Exchange.Description = "ประเภทเงินยืมทอนที่ขอแลก";
            obj.Exchange.StaffId = "14055";
            obj.Exchange.Date = dt;

            obj.Result = new Models.FundEntry();
            obj.Result.Description = "ยอดรวมคงเหลือ";
            obj.Result.StaffId = "14055";
            obj.Result.Date = dt;

            win.Title = "Request Exchange";
            win.Setup(Windows.ExchangeWindowMode.New, obj);
            if (win.ShowDialog() == false)
            {
                return;
            }
            // append item.
            _items.Add(obj);
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.TAMainPage();
            PageContentManager.Instance.Current = page;
        }

        private void UpdateResult()
        {

        }

        private Models.FundEntry _plaza;
        private BindingList<Models.FundExchange> _items;

        public void Setup(Models.FundEntry plaza, BindingList<Models.FundExchange> items)
        {
            _plaza = plaza;
            _items = items;

            this.plaza.DataContext = _plaza;
            this.grid.Setup(_plaza, _items);

            UpdateResult();
        }
    }
}
