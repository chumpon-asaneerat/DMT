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
    /// Interaction logic for CollectorFundViewPage.xaml
    /// </summary>
    public partial class CollectorFundViewPage : UserControl
    {
        public CollectorFundViewPage()
        {
            InitializeComponent();

            grid.ItemChanged += Grid_ItemChanged;
        }

        private void Grid_ItemChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.TAMainPage();
            PageContentManager.Instance.Current = page;
        }

        private Models.FundEntry _plaza;
        private Models.FundEntry _current = new Models.FundEntry();
        private BindingList<Models.FundEntry> _funds;

        private void assign(Models.FundEntry src, Models.FundEntry dst)
        {
            dst.Description = src.Description;

            dst.BHT1 = src.BHT1;
            dst.BHT2 = src.BHT2;
            dst.BHT5 = src.BHT5;
            dst.BHT10c = src.BHT10c;
            dst.BHT20 = src.BHT20;
            dst.BHT50 = src.BHT50;
            dst.BHT100 = src.BHT100;
            dst.BHT500 = src.BHT500;
            dst.BHT1000 = src.BHT1000;
        }

        public void Setup(Models.FundEntry plazaFund,
            BindingList<Models.FundEntry> funds)
        {
            _plaza = plazaFund;
            _funds = funds;

            Calculate();

            plaza.DataContext = _current;
            grid.Setup(_plaza, _funds);
        }

        public void Calculate()
        {
            if (null == _plaza) return;
            if (null == _current) return;
            if (null == _funds) return;

            plazaBalance.Text = _plaza.BHTTotal.ToString("n0");
            // set init value.
            assign(_plaza, _current);

            foreach (Models.FundEntry fund in _funds)
            {
                _current.BHT1 -= fund.BHT1;
                _current.BHT2 -= fund.BHT2;
                _current.BHT5 -= fund.BHT5;
                _current.BHT10c -= fund.BHT10c;
                _current.BHT20 -= fund.BHT20;
                _current.BHT50 -= fund.BHT50;
                _current.BHT100 -= fund.BHT100;
                _current.BHT500 -= fund.BHT500;
                _current.BHT1000 -= fund.BHT1000;
            }
        }
    }
}
