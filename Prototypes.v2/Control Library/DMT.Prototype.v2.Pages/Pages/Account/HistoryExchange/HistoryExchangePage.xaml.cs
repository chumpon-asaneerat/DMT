using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;


namespace DMT.Pages.Account.History
{
    /// <summary>
    /// Interaction logic for HistoryExchangePage.xaml
    /// </summary>
    public partial class HistoryExchangePage : UserControl
    {
        public HistoryExchangePage()
        {
            InitializeComponent();
            LoadComboPlazaName();
            LoadCombbListStatus();
        }

        private void cmdSearch_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void cmdNew_Click(object sender, RoutedEventArgs e)
        {
            Clear();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Menu Page
            var page = new Pages.Account.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdEdit_Click(object sender, RoutedEventArgs e)
        {
            var win = new DMT.Windows.Account.ExchangeWindow();
            List<Models.FundEntry> Funds = new List<Models.FundEntry>();
            List<Models.AccountFundEntry> AccountFunds = new List<Models.AccountFundEntry>();


            Models.FundEntry fund;

            fund = new Models.FundEntry();
            fund.Description = "รายการอนุมัติจากบัญชี";
            fund.BHT1 = 100;
            fund.BHT2 = 20;
            fund.BHT5 = 50;
            fund.BHT10c = 100;
            fund.BHT20 = 100;
            fund.BHT50 = 10;
            fund.BHT100 = 10;
            fund.BHT500 = 2;
            fund.BHT1000 = 1;

            Models.AccountFundEntry accfund;

            accfund = new Models.AccountFundEntry();
            accfund.Description = "รายการขอยืม/แลกเงินยืมทอน";

            if (this.listTest.SelectedItems.Count > 0)
            {
                foreach (var li in this.listTest.SelectedItems)
                {
                    if (((test5)li).DocDate != null)
                        accfund.DocDate = ((test5)li).DocDate.Value.ToString("dd/MM/yy");
                    break;
                }

            }
            accfund.BHT1 = 100;
            accfund.BHT2 = 10;
            accfund.BHT5 = 10;
            accfund.BHT10c = 10;
            accfund.BHT20 = 10;
            accfund.BHT50 = 10;
            accfund.BHT100 = 10;
            accfund.BHT500 = 10;
            accfund.BHT1000 = 1;

            accfund.EXCHANGE = 100;
            accfund.BORROW = 120;
            accfund.REVOLVINGFUNDS = 180;

            win.Setup(fund, accfund);

            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void LoadComboPlazaName()
        {
            var plazaName = new List<string>();
            plazaName.Add("ทั้งหมด");
            plazaName.Add("ดินแดง");
            plazaName.Add("สุทธิสาร");
            plazaName.Add("ลาดพร้าว");
            plazaName.Add("รัชดาภิเษก");
            plazaName.Add("บางเขน");
            plazaName.Add("แจ้งวัฒนะ");
            plazaName.Add("หลักสี่");
            plazaName.Add("ดอนเมือง");
            plazaName.Add("อนุสรณ์สถาน");
            cbPlazaName.DataContext = plazaName;
            cbPlazaName.SelectedIndex = 0;
        }

        private void LoadCombbListStatus()
        {
            var listStatus = new List<string>();
            listStatus.Add("รอพิจารณา");
            listStatus.Add("อนุมัติ");
            listStatus.Add("ไม่อนุมัติ");
            listStatus.Add("ด่านรับเงิน");
            cbListStatus.DataContext = listStatus;
            cbListStatus.SelectedIndex = 0;
        }

        private void Clear()
        {
            cbPlazaName.SelectedIndex = 0;
            cbListStatus.SelectedIndex = 0;
            listTest.ItemsSource = null;
            dteStartDate.SelectedDate = null;
            dteEndDate.SelectedDate = null;
        }
        private void LoadData()
        {
            List<test5> items = new List<test5>();
            items.Add(new test5()
            {
                PlazaName = "ดินแดน",
                DocDate = DateTime.Now,
                AmountRequested = decimal.Parse("10"),
                ApprovedAmount = decimal.Parse("20"),
                ListStatus = "รอพิจารณา"
            }) ;
            items.Add(new test5()
            {
                PlazaName = "สุทธิสาร",
                DocDate = DateTime.Now,
                AmountRequested = decimal.Parse("500"),
                ApprovedAmount = decimal.Parse("1000"),
                ListStatus = "อนุมัติ"
            });
            items.Add(new test5()
            {
                PlazaName = "ลาดพร้าว",
                DocDate = DateTime.Now.AddDays(-1),
                AmountRequested = decimal.Parse("100"),
                ApprovedAmount = decimal.Parse("200"),
                ListStatus = "ไม่อนุมัติ"
            });
            items.Add(new test5()
            {
                PlazaName = "รัชดาภิเษก",
                DocDate = DateTime.Now.AddDays(-2),
                AmountRequested = decimal.Parse("150"),
                ApprovedAmount = decimal.Parse("250"),
                ListStatus = "ด่านรับเงิน"
            });
            
            listTest.ItemsSource = items;
        }
    }

    public class test5
    {
        public string PlazaName { get; set; }
        public DateTime? DocDate { get; set; }    
        public decimal? AmountRequested { get; set; }
        public decimal? ApprovedAmount { get; set; }

        public string ListStatus { get; set; }

    }

}
