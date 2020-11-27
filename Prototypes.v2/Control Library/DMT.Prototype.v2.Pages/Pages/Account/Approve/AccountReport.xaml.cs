using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

using NLib;
using NLib.Services;

namespace DMT.Pages.Account.Approve
{
    /// <summary>
    /// Interaction logic for AccountReport.xaml
    /// </summary>
    public partial class AccountReport : UserControl
    {
        public AccountReport()
        {
            InitializeComponent();
            LoadData();
            LoadDataApprove();
        }

        private void cmdOk_Click(object sender, RoutedEventArgs e)
        {
            // Main Report Page
            var page = new Account.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdCancel_Click(object sender, RoutedEventArgs e)
        {
            var page = new Account.MainMenu();
            PageContentManager.Instance.Current = page;
        }

        private void cmdEdit_Click(object sender, RoutedEventArgs e)
        {
            var win = new DMT.Windows.Account.ExchangeWindow();
            List < Models.FundEntry> Funds = new List<Models.FundEntry>();
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
                    if (((test3)li).StartDate != null && ((test3)li).EndDate != null)
                    accfund.DocDate = ((test3)li).StartDate.Value.ToString("dd/MM/yy") + " - " + ((test3)li).EndDate.Value.ToString("dd/MM/yy");
                    else if (((test3)li).StartDate != null && ((test3)li).EndDate == null)
                        accfund.DocDate = ((test3)li).StartDate.Value.ToString("dd/MM/yy");
                    else if (((test3)li).StartDate == null && ((test3)li).EndDate != null)
                        accfund.DocDate = ((test3)li).EndDate.Value.ToString("dd/MM/yy");

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

        private void LoadData()
        {
            List<test3> items = new List<test3>();
            items.Add(new test3()
            {
                PlazaName = "ดินแดน",
                DocDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = null,
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750"),
                IsSelect = false
            }); ;
            items.Add(new test3()
            {
                PlazaName = "สุทธิสาร",
                DocDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750"),
                IsSelect = true
            });
            items.Add(new test3()
            {
                PlazaName = "ลาดพร้าว",
                DocDate = DateTime.Now.AddDays(-1),
                StartDate = DateTime.Now.AddDays(-1),
                EndDate = DateTime.Now,
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750"),
                IsSelect = true
            });
            items.Add(new test3()
            {
                PlazaName = "รัชดาภิเษก",
                DocDate = DateTime.Now.AddDays(-2),
                StartDate = DateTime.Now.AddDays(-2),
                EndDate = DateTime.Now.AddDays(-1),
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750"),
                IsSelect = true
            });
            items.Add(new test3()
            {
                PlazaName = "บางเขน",
                DocDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = null,
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750"),
                IsSelect = false
            });
            items.Add(new test3()
            {
                PlazaName = "แจ้งวัฒนะ",
                DocDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = null,
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750"),
                IsSelect = false
            });
            items.Add(new test3()
            {
                PlazaName = "หลักสี่",
                DocDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = null,
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750"),
                IsSelect = false
            });
            items.Add(new test3()
            {
                PlazaName = "ดอนเมือง",
                DocDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = null,
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750"),
                IsSelect = false

            });
            items.Add(new test3()
            {
                PlazaName = "อนุสรณ์สถาน",
                DocDate = DateTime.Now,
                StartDate = DateTime.Now,
                EndDate = null,
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750"),
                IsSelect = false
            });
            listTest.ItemsSource = items;
        }

        private void LoadDataApprove()
        {
            List<test4> items = new List<test4>();
            items.Add(new test4()
            {
                PlazaName = "ดินแดน",
                DocDate = DateTime.Now,
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750")
            }); ;
            items.Add(new test4()
            {
                PlazaName = "สุทธิสาร",
                DocDate = DateTime.Now,
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750")
            });
            items.Add(new test4()
            {
                PlazaName = "ลาดพร้าว",
                DocDate = DateTime.Now.AddDays(-1),
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750")
            });
            items.Add(new test4()
            {
                PlazaName = "รัชดาภิเษก",
                DocDate = DateTime.Now.AddDays(-2),
                Baht1 = decimal.Parse("10"),
                Baht2 = decimal.Parse("20"),
                Baht5 = decimal.Parse("50"),
                Baht10 = decimal.Parse("100"),
                Baht20 = decimal.Parse("20"),
                Baht50 = decimal.Parse("50"),
                Baht100 = decimal.Parse("1000"),
                Baht500 = decimal.Parse("500"),
                Baht1000 = decimal.Parse("1000"),
                Total = decimal.Parse("2750")
            });
          
            listApprove.ItemsSource = items;
        }

        private void cmdApprove_Click(object sender, RoutedEventArgs e)
        {
            var win = new DMT.Windows.Account.ApproveWindow();
            if (win.ShowDialog() == false)
            {
                return;
            }
        }

        private void cmdNotApprove_Click(object sender, RoutedEventArgs e)
        {
            var win = new DMT.Windows.Account.UnApproveWindow();
            if (win.ShowDialog() == false)
            {
                return;
            }
        }
    }

    public class test3
    {
        public string PlazaName { get; set; }
        public DateTime? DocDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? Baht1 { get; set; }
        public decimal? Baht2 { get; set; }
        public decimal? Baht5 { get; set; }
        public decimal? Baht10 { get; set; }
        public decimal? Baht20 { get; set; }
        public decimal? Baht50 { get; set; }
        public decimal? Baht100 { get; set; }
        public decimal? Baht500 { get; set; }
        public decimal? Baht1000 { get; set; }
        public decimal? Total { get; set; }

        public bool IsSelect { get; set; }
    }

    public class test4
    {
        public string PlazaName { get; set; }
        public DateTime? DocDate { get; set; }
        public decimal? Baht1 { get; set; }
        public decimal? Baht2 { get; set; }
        public decimal? Baht5 { get; set; }
        public decimal? Baht10 { get; set; }
        public decimal? Baht20 { get; set; }
        public decimal? Baht50 { get; set; }
        public decimal? Baht100 { get; set; }
        public decimal? Baht500 { get; set; }
        public decimal? Baht1000 { get; set; }
        public decimal? Total { get; set; }

    }
}
