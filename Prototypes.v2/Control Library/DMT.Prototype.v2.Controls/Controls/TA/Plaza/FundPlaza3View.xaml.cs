using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Controls
{
    /// <summary>
    /// Interaction logic for FundPlaza3View.xaml
    /// </summary>
    public partial class FundPlaza3View : UserControl
    {
        public FundPlaza3View()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            PageContentManager.Instance.OnTick += new EventHandler(Instance_OnTick);
        }

        private void UserControl_Unloaded(object sender, RoutedEventArgs e)
        {
            PageContentManager.Instance.OnTick -= new EventHandler(Instance_OnTick);
        }

        private void cmdEdit_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            Models.FundEntry item = b.CommandParameter as Models.FundEntry;
            if (null != item)
            {
                var win = new Windows.TA.Exchange.ReceivedFundReturWindow();
                win.Owner = Application.Current.MainWindow;

                win.Title = "แลกเงินหมุนเวียนภายในด่าน";

                Models.FundEntry srcObj = new Models.FundEntry();
                Models.FundEntry rcvObj = new Models.FundEntry();

                assign(_plaza, srcObj);
                assign(_plaza, rcvObj);

                srcObj.Description = "เงินขอแลกออก";
                srcObj.HasRemark = false;

                rcvObj.Description = "เงินขอแลกเข้า";
                rcvObj.HasRemark = false;

                win.Setup(srcObj, rcvObj, Windows.TA.Exchange.ExchangeWindowMode.Edit);
                if (win.ShowDialog() == false)
                {
                    return;
                }

                
                if (win.Mode == Windows.TA.Exchange.ExchangeWindowMode.Cancel)
                {
                    // remove an item if cancel.
                    _items.Remove(item);
                }

                // refresh the update item.
                listView.Items.Refresh();
            }
        }

        private void assign(Models.FundEntry src, Models.FundEntry dst)
        {
            dst.BHT1 = src.BHT1;
            dst.BHT2 = src.BHT2;
            dst.BHT5 = src.BHT5;
            dst.BHT10c = src.BHT10c;
            dst.BHT20 = src.BHT20;
            dst.BHT50 = src.BHT50;
            dst.BHT100 = src.BHT100;
            dst.BHT500 = src.BHT500;
            dst.BHT1000 = src.BHT1000;

            dst.EXCHANGE = src.EXCHANGE;
            dst.BORROW = src.BORROW;
            dst.REVOLVINGFUNDS = src.REVOLVINGFUNDS;

        }


        private void AppendPlazaFund(Models.FundExchange item)
        {
            _plaza.BHT1 = _plaza.BHT1 - item.Exchange.BHT1 + item.Request.BHT1;
            _plaza.BHT2 = _plaza.BHT2 - item.Exchange.BHT2 + item.Request.BHT2;
            _plaza.BHT5 = _plaza.BHT5 - item.Exchange.BHT5 + item.Request.BHT5;
            _plaza.BHT10c = _plaza.BHT10c - item.Exchange.BHT10c + item.Request.BHT10c;
            _plaza.BHT20 = _plaza.BHT20 - item.Exchange.BHT20 + item.Request.BHT20;
            _plaza.BHT50 = _plaza.BHT50 - item.Exchange.BHT50 + item.Request.BHT50;
            _plaza.BHT100 = _plaza.BHT100 - item.Exchange.BHT100 + item.Request.BHT100;
            _plaza.BHT500 = _plaza.BHT500 - item.Exchange.BHT500 + item.Request.BHT500;
            _plaza.BHT1000 = _plaza.BHT1000 - item.Exchange.BHT1000 + item.Request.BHT1000;
        }

        private void Approve(Models.FundExchange item)
        {
            item.Approve.BHT1 = item.Request.BHT1;
            item.Approve.BHT2 = item.Request.BHT2;
            item.Approve.BHT5 = item.Request.BHT5;
            item.Approve.BHT10c = item.Request.BHT10c;
            item.Approve.BHT20 = item.Request.BHT20;
            item.Approve.BHT50 = item.Request.BHT50;
            item.Approve.BHT100 = item.Request.BHT100;
            item.Approve.BHT500 = item.Request.BHT500;
            item.Approve.BHT1000 = item.Request.BHT1000;
        }

        private DateTime _lastupdated = DateTime.Now;

        void Instance_OnTick(object sender, EventArgs e)
        {
            // update status.
            if (null != _items && _items.Count > 0)
            {
                Models.FundEntry[] items = null;
                lock (this)
                {
                    items = _items.ToArray();
                }

                var ts = DateTime.Now - _lastupdated;
                var bChanged = false;
                if (ts.TotalSeconds >= 10)
                {
                    _lastupdated = DateTime.Now;
                    // refresh the items list.
                    if (bChanged)
                    {
                        listView.Items.Refresh();
                    }
                }
            }
        }

        private Models.FundEntry _plaza;
        private BindingList<Models.FundEntry> _items;

        public void Setup(Models.FundEntry plaza, BindingList<Models.FundEntry> items)
        {
            _plaza = plaza;
            _items = items;
            listView.ItemsSource = _items;
        }
    }
}
